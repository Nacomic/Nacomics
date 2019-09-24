//################################################################################
//# ..:: created with TCT Version 5.1 for THUD v7.2 (17.3.26.1) ::.. by RealGsus #
//################################################################################

using Turbo.Plugins.Default;

namespace Turbo.Plugins.TCT
{

    public class TCTEliteMonsterAffixPlugin : BasePlugin, ICustomizer
    {

        public TCTEliteMonsterAffixPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void Customize()
        {
            //##### ARCANE #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Arcane, "비전");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Arcane);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Arcane, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 120, 0, 120, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Avenger);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Desecrator);
            //##### ELECTRIFIED #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Electrified, "감전");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Electrified);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Electrified, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 40, 40, 240, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.ExtraHealth);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Fast);
            //##### FIRECHAINS #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.FireChains, "사슬");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.FireChains);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.FireChains, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 170, 50, 0, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Frozen);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.FrozenPulse);
            //##### HealthLink #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.HealthLink, "생연");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.HealthLink);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.HealthLink, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
            }
            ));
            //##### HORDE #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Horde, "무리");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Horde);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Horde, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 200, 220, 120, false, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 50, 50, 50, 0),
            }
            ));
            //##### ILLUSIONIST #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Illusionist, "환영");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Illusionist);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Illusionist, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 200, 220, 120, false, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 50, 50, 50, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Jailer);
            //##### JUGGERNAUT #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Juggernaut, "거한");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Juggernaut);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Juggernaut, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Knockback);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.MissileDampening);
            //##### MOLTEN #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Molten, "융해");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Molten);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Molten, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 170, 50, 0, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Mortar);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Nightmarish);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Orbiter);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Plagued);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Poison);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Reflect);
            //##### SHIELDING #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Shielding, "보막");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Shielding);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Shielding, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
            }
            ));
            //##### Teleporter #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Teleporter, "텔포");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Teleporter);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Teleporter, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 255, 255, 255, true, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0),
            }
            ));
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Thunderstorm);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Vortex);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Waller);
            //##### WORMHOLE #####
            Hud.GetPlugin<EliteMonsterAffixPlugin>().CustomAffixNames.Add(MonsterAffix.Wormhole, "시공");
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Remove(MonsterAffix.Wormhole);
            Hud.GetPlugin<EliteMonsterAffixPlugin>().AffixDecorators.Add(MonsterAffix.Wormhole, new WorldDecoratorCollection(
            new GroundLabelDecorator(Hud)
            {
                BorderBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 10f, 255, 200, 220, 120, false, false, false),
                BackgroundBrush = Hud.Render.CreateBrush(255, 50, 50, 50, 0),
            }
            ));
        }

    }

}