using SharpDX.DirectInput;
using System.Linq;
using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.glq
{
    using System.Text;

    // by 
    public class MonstersCountPlugin : BasePlugin, IInGameTopPainter, IInGameWorldPainter, IKeyEventHandler
    {
        public IFont DefaultTextFont { get; set; }
        public IFont OrangeTextFont { get; set; }
        public IFont RedTextFont { get; set; }
        public WorldDecoratorCollection StatisticalRangeDecorator { get; set; }
        public WorldDecoratorCollection MaxStatisticalRangeDecorator { get; set; }
        private float currentYard;
        public float BaseYard
        {
            get { return baseMapShapeDecorator.Radius; }
            set {
                baseMapShapeDecorator.Radius = value;
                currentYard = BaseYard;
            }
        }
        public float MaxYard
        {
            get { return maxMapShapeDecorator.Radius; }
            set { maxMapShapeDecorator.Radius = value; }
        }
        public bool ShowCircle { get; set; }
        public IKeyEvent ToggleKeyEvent { get; set; }
        public bool ShowMonstersCount { get; set; }

        public bool ShowTotalProgression { get; set; }
        public bool ShowTrashProgression { get; set; }
        public bool ShowEliteProgression { get; set; }
        public bool ShowRareMinionProgression { get; set; }
        public bool ShowRiftGlobeProgression { get; set; }

        public bool ShowLlocustCount { get; set; }
        public bool ShowHauntedCount { get; set; }
        public bool ShowPalmedCount { get; set; }
        public bool ShowPhoenixedCount { get; set; }
        public bool ShowStrongarmedCount { get; set; }
        public bool ShowTime { get; set; }
        public bool ToggleEnable { get; set; }
        public float XWidth { get; set; }
        public float YHeight { get; set; }

        private IFont currentFont;
        private bool TurnedOn;

        private MapShapeDecorator baseMapShapeDecorator;
        private MapShapeDecorator maxMapShapeDecorator;

        private StringBuilder textBuilder;



        public MonstersCountPlugin()
        {
            Enabled = true;
            ShowCircle = false;
            ToggleEnable = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.LeftControl, true, false, false);
            DefaultTextFont = Hud.Render.CreateFont("tahoma", 11, 255, 180, 147, 109, false, false, 250, 0, 0, 0, true);
            OrangeTextFont = Hud.Render.CreateFont("tahoma", 11, 255, 255, 128, 0, false, false, 250, 0, 0, 0, true);
            RedTextFont = Hud.Render.CreateFont("tahoma", 11, 255, 255, 0, 0, false, false, 250, 0, 0, 0, true);

            TurnedOn = false;
            ShowMonstersCount = true;
            ShowTotalProgression = true;
            ShowTrashProgression = true;
            ShowEliteProgression = true;
            ShowRareMinionProgression = false;
            ShowRiftGlobeProgression = false;
            ShowTime = false;
            ShowLlocustCount = true;
            ShowHauntedCount = true;
            ShowPalmedCount = true;
            ShowPhoenixedCount = false;
            ShowStrongarmedCount = true;

            XWidth = 0.84f;
            YHeight = 0.61f;
            textBuilder = new StringBuilder();
            
            baseMapShapeDecorator = new MapShapeDecorator(Hud)
            {
                Brush = Hud.Render.CreateBrush(150, 180, 147, 109, 1),
                ShapePainter = new CircleShapePainter(Hud),
                Radius = 40,
            };
            StatisticalRangeDecorator = new WorldDecoratorCollection(baseMapShapeDecorator);
            currentYard = BaseYard;
            maxMapShapeDecorator = new MapShapeDecorator(Hud)
            {
                Brush = Hud.Render.CreateBrush(150, 180, 147, 109, 1),
                ShapePainter = new CircleShapePainter(Hud),
                Radius = 120,
            };
            MaxStatisticalRangeDecorator = new WorldDecoratorCollection(maxMapShapeDecorator);

		

        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent) && ToggleEnable)
            {
                TurnedOn = !TurnedOn;
                currentYard = TurnedOn ? MaxYard : BaseYard;
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Game.IsInTown || !ShowCircle) return;
            if (TurnedOn)
            {
                MaxStatisticalRangeDecorator.Paint(layer, null, Hud.Game.Me.FloorCoordinate, null);
            }
            else
            {
                StatisticalRangeDecorator.Paint(layer, null, Hud.Game.Me.FloorCoordinate, null);
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            var inRift = Hud.Game.SpecialArea == SpecialArea.Rift || Hud.Game.SpecialArea == SpecialArea.GreaterRift;
            var inGR = Hud.Game.SpecialArea == SpecialArea.GreaterRift;
            if (DefaultTextFont == null)
            {
                return;
            }

            double totalMonsterRiftProgression = 0;
            double TrashMonsterRiftProgression = 0;
            double EliteProgression = 0;
            double RareMinionProgression = 0;
            double RiftGlobeProgression = 0;

            int monstersCount = 0;
			int minMonsterCount = 0;
			int sytherCount = 0;
            int EliteCount = 0;
            int RareMinionCount = 0;
            int ElitePackCount = 0;
            // locust
            int locustCount = 0;
            int ElitelocustCount = 0;
            // haunted
            int hauntedCount = 0;
            int ElitehauntedCount = 0;
            //Palmed
            int palmedCount = 0;
            int ElitepalmedCount = 0;
            //Phoenixed BUG? http://turbohud.freeforums.net/thread/3945/monster-phoenixed
            int phoenixedCount = 0;
            int ElitephoenixedCount = 0;
            //Strongarmed Obsolete
            int strongarmedCount = 0;
            int ElitestrongarmedCount = 0;
			int ddalHealth = 30;
            float XPos = Hud.Window.Size.Width * XWidth;
            float YPos = Hud.Window.Size.Height * YHeight;

            var monsters = Hud.Game.AliveMonsters.Where(m => ((m.SummonerAcdDynamicId == 0 && m.IsElite) || !m.IsElite) && m.FloorCoordinate.XYDistanceTo(Hud.Game.Me.FloorCoordinate) <= currentYard);
            Dictionary<IMonster, string> eliteGroup = new Dictionary<IMonster, string>();
            foreach (var monster in monsters)
            {
                var Elite = monster.Rarity == ActorRarity.Rare || monster.Rarity == ActorRarity.Champion || monster.Rarity == ActorRarity.Unique || monster.Rarity == ActorRarity.Boss;
                monstersCount++;
                if (!monster.IsElite)
                {
                    if (inRift) {
						TrashMonsterRiftProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
						var health = monster.CurHealth / (monster.MaxHealth / 100.0f);
						if(health < ddalHealth){
							minMonsterCount++;
						} 
						
						if (health < 15)
						{
							sytherCount++;
						}
					}
                }
                else
                {
                    if (monster.Rarity == ActorRarity.RareMinion)
                    {
                        RareMinionCount++;
                        if (inRift) RareMinionProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
                    }
                    else
                    {
                        if (monster.Rarity == ActorRarity.Unique || monster.Rarity == ActorRarity.Boss)
                        {
                            EliteCount++;
                            ElitePackCount++;
                        }

                        if (monster.Rarity == ActorRarity.Champion)
                        {
                            EliteCount++;
                            eliteGroup.Add(monster, String.Join(", ", monster.AffixSnoList));
                            if (inRift) EliteProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
                        }

                        if (monster.Rarity == ActorRarity.Rare)
                        {
                            EliteCount++;
                            ElitePackCount++;
                            if (inRift)
                            {
                                EliteProgression += 4 * 1.15d;
                                EliteProgression += monster.SnoMonster.RiftProgression * 100.0d / this.Hud.Game.MaxQuestProgress;
                            }
                        }
                    }
                }
                if (monster.Locust && ShowLlocustCount)
                {
                    locustCount++;
                    if (Elite) ElitelocustCount++;
                }
                if (monster.Haunted && ShowHauntedCount)
                {
                    hauntedCount++;
                    if (Elite) ElitehauntedCount++;
                }
                if (monster.Palmed && ShowPalmedCount)
                {
                    palmedCount++;
                    if (Elite) ElitepalmedCount++;
                }
                if (monster.Phoenixed && ShowPhoenixedCount)
                {
                    phoenixedCount++;
                    if (Elite) ElitephoenixedCount++;
                }
                if (monster.Strongarmed && ShowStrongarmedCount)
                {
                    strongarmedCount++;
                    if (Elite) ElitestrongarmedCount++;
                }
            }
            Dictionary<IMonster, string> eliteGroup1 = eliteGroup.OrderBy(p => p.Value).ToDictionary(p => p.Key, o => o.Value);
            var actors = Hud.Game.Actors.Where(x => x.SnoActor.Kind == ActorKind.RiftOrb);
            foreach (var actor in actors)
            {
                RiftGlobeProgression += 1.15d;
            }
            string preStr = null;
            foreach (var elite in eliteGroup1)
            {
                if (elite.Key.Rarity == ActorRarity.Champion)
                {
                    if (preStr != elite.Value)
                    {

                        EliteProgression += 3 * 1.15f;
                        ElitePackCount++;
                    }
                    preStr = elite.Value;
                }
            }
            textBuilder.Clear();
            if (inRift)
            {
                textBuilder.AppendFormat("{0} �ߵ�, ��ü�� : {1}", currentYard, monstersCount);
                textBuilder.AppendLine();
                textBuilder.AppendFormat("����: {0}({1}����)", EliteCount, ElitePackCount);
                textBuilder.AppendFormat(", �ϼ���: {0}", RareMinionCount);
                textBuilder.AppendLine();
                textBuilder.AppendFormat("���: {0}", monstersCount - EliteCount - RareMinionCount);
                textBuilder.AppendLine();
				textBuilder.AppendFormat("���� 30�۹̸�: {0}", minMonsterCount);
			    textBuilder.AppendFormat(", ���� ����: {0}", sytherCount);
               textBuilder.AppendLine();
			                  textBuilder.AppendLine();
            }

            if (inRift)
            {
                totalMonsterRiftProgression = TrashMonsterRiftProgression + EliteProgression + RareMinionProgression + RiftGlobeProgression;
                long totalTime = (long)totalMonsterRiftProgression * 90000000;
                long TrashTime = (long)TrashMonsterRiftProgression * 90000000;
                long EliteTime = (long)EliteProgression * 90000000;
                long RareMinionTime = (long)RareMinionProgression * 90000000;
                long RiftGlobeTime = (long)RiftGlobeProgression * 90000000;
				double percent = Hud.Game.RiftPercentage + totalMonsterRiftProgression;

                if (inRift)
                {
					textBuilder.AppendFormat("===������===");
	                textBuilder.AppendLine();
                    if (inRift)
                    {
						textBuilder.AppendFormat("�ջ� ������: {0}%", percent.ToString("f2"));
 		               textBuilder.AppendLine();
                        textBuilder.AppendFormat("��ȭ�� ������: {0}%", totalMonsterRiftProgression.ToString("f2"));
                    }
                    else
                    {
                        textBuilder.AppendFormat("������: {0}%", totalMonsterRiftProgression.ToString("f2"));
                    }
                    textBuilder.AppendLine();
                }

                if (inRift)
                {
                    if (inRift)
                    {
                        textBuilder.AppendFormat("���: {0}%", TrashMonsterRiftProgression.ToString("f2"));
                    }
                    else
                    {
                        textBuilder.AppendFormat("���: {0}%", TrashMonsterRiftProgression.ToString("f2"));
                    }
                    textBuilder.AppendLine();
                }
                if (inRift)
                {
                    if (inRift)
                    {
                        textBuilder.AppendFormat("����: {0}%", EliteProgression.ToString("f2"));
                    }
                    else
                    {
                        textBuilder.AppendFormat("����: {0}%", EliteProgression.ToString("f2"));
                    }
                    textBuilder.AppendLine();
                }
                if (inRift)
                {
                    if (inRift)
                    {
                        textBuilder.AppendFormat("�ϼ���: {0}%", RareMinionProgression.ToString("f2"));
                    }
                    else
                    {
                        textBuilder.AppendFormat("�ϼ���: {0}%", RareMinionProgression.ToString("f2"));
                    }
                    textBuilder.AppendLine();
                }
                if (RiftGlobeProgression > 0 && ShowRiftGlobeProgression)
                {
                    if (ShowTime && inGR)
                    {
                        textBuilder.AppendFormat("����: {0}%", RiftGlobeProgression.ToString("f2"));
                    }
                    else
                    {
                        textBuilder.AppendFormat("����: {0}%", RiftGlobeProgression.ToString("f2"));
                    }
                    textBuilder.AppendLine();
                }
				
                textBuilder.AppendLine();
            }
            
            if (inRift)
            {
                //textBuilder.AppendFormat("�޶ѱ�: {0}/{1}", locustCount, monstersCount);
                if (ElitelocustCount > 0) textBuilder.AppendFormat(" ������: {0}/{1}��", ElitelocustCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (inRift)
            {
                //textBuilder.AppendFormat("ȥ��: {0}/{1}", hauntedCount, monstersCount);
                if (ElitehauntedCount > 0) textBuilder.AppendFormat(" ������: {0}/{1}��", ElitehauntedCount, EliteCount);
                textBuilder.AppendLine();
            }
   
            if (palmedCount > 0 && ShowPalmedCount)
            {
                textBuilder.AppendFormat("����: {0}/{1}", palmedCount, monstersCount);
                if (ElitepalmedCount > 0) textBuilder.AppendFormat(" ������: {0}/{1}��", ElitepalmedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (phoenixedCount > 0 && ShowPhoenixedCount)
            {
                textBuilder.AppendFormat("Phoenixed: {0}/{1}", phoenixedCount, monstersCount);
                if (ElitephoenixedCount > 0) textBuilder.AppendFormat(" ��Elite: {0}/{1}��", ElitephoenixedCount, EliteCount);
                textBuilder.AppendLine();
            }
            if (strongarmedCount > 0 && ShowStrongarmedCount)
            {
                textBuilder.AppendFormat("�Ⱦ���: {0}/{1}", strongarmedCount, monstersCount);
                if (ElitestrongarmedCount > 0) textBuilder.AppendFormat(" ��Elite: {0}/{1}��", ElitestrongarmedCount, EliteCount);
                textBuilder.AppendLine();
            }

            if (totalMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100 || TrashMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100)
            {
                if (totalMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100) currentFont = OrangeTextFont;
                if (TrashMonsterRiftProgression >= 100d - Hud.Game.RiftPercentage && Hud.Game.RiftPercentage != 100) currentFont = RedTextFont;
            }
            else
            {
                currentFont = DefaultTextFont;
            }


            var layout = currentFont.GetTextLayout(textBuilder.ToString());
            currentFont.DrawText(layout, XPos, YPos);
        }
    }
}