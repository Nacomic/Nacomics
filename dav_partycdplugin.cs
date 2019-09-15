using System;
using System.Linq;
using SharpDX.DirectInput;
using SharpDX;
using Turbo.Plugins.Default;
using System.Globalization;
using System.Collections.Generic;
 
namespace Turbo.Plugins.DavPlayer
{
	public class DAV_PartyCDPlugin : BasePlugin, IInGameTopPainter {
		public DAV_SkillPainter SkillPainter { get; set; }
		public IFont ClassFont { get; set; }
		public List<uint> WatchedSnos;
 
		public float StartXPos { get; set; }
		public float StartYPos { get; set; }
		public float IconSize { get; set; }
		private float _size;
		private float HudWidth { get { return Hud.Window.Size.Width; } }
		private float HudHeight { get { return Hud.Window.Size.Height; } }
		private Dictionary<HeroClass, string> _classShortName;
 
		public DAV_PartyCDPlugin() {
			Enabled = true;
		}
	   
		public override void Load(IController hud) {
			base.Load(hud);
		   
			StartYPos = 0.005f;
			StartXPos = 0.625f;
			IconSize = 0.05f;
			_size = HudWidth * 0.03f;
 
			ClassFont = Hud.Render.CreateFont("tahoma", 3, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
			SkillPainter = new DAV_SkillPainter(Hud);
			_classShortName = new Dictionary<HeroClass, string> {
				{HeroClass.Necromancer, "\n(Necro)"},
				{HeroClass.Wizard, "\n(Wiz)"},
			};
		   
			WatchedSnos = new List<uint> {
				
				//--- Necromancer
				Hud.Sno.SnoPowers.Necromancer_Simulacrum.Sno,
				Hud.Sno.SnoPowers.Necromancer_LandOfTheDead.Sno,
 
				//--- Wizard
				Hud.Sno.SnoPowers.Wizard_Archon.Sno,
			//	Hud.Sno.SnoPowers.Wizard_BlackHole.Sno
			};	 
		}
	   
		public void PaintTopInGame(ClipState clipState) {
			if (clipState != ClipState.BeforeClip) return;
 
			var xPos = HudWidth * StartXPos;
			var index = 0;
			foreach (var player in Hud.Game.Players.OrderBy(p => p.HeroClassDefinition.HeroClass)) {
				var foundCarrySkill = false;
				var flagIsFirstIterator = true;
				var yPos = HudHeight * StartYPos;
			   
				foreach (var skill in player.Powers.UsedSkills.OrderBy(p => p.SnoPower.Sno)) {
					if (skill == null || !WatchedSnos.Contains(skill.SnoPower.Sno)) continue;
				   
					foundCarrySkill = true;
					if (flagIsFirstIterator) {
						var layout = ClassFont.GetTextLayout(player.BattleTagAbovePortrait + _classShortName[player.HeroClassDefinition.HeroClass]);
						ClassFont.DrawText(layout, xPos, yPos);
						flagIsFirstIterator = false;
						yPos += 0.035f * HudHeight;
					}
				   
					var rect = new SharpDX.RectangleF(xPos, yPos, _size, _size);
					SkillPainter.Paint(skill, rect);
					yPos += _size*1.1f;
				}
			   
				var CheatDeathBuff = player.Powers.GetBuff(Hud.Sno.SnoPowers.WitchDoctor_Passive_SpiritVessel.Sno);
				switch (player.HeroClassDefinition.HeroClass) {
					case HeroClass.Necromancer: CheatDeathBuff = player.Powers.GetBuff(Hud.Sno.SnoPowers.Necromancer_Passive_FinalService.Sno); break;
					case HeroClass.Wizard: CheatDeathBuff = player.Powers.GetBuff(Hud.Sno.SnoPowers.Wizard_Passive_UnstableAnomaly.Sno); break;
				}
			   
				if (CheatDeathBuff != null && CheatDeathBuff.TimeLeftSeconds[1] > 0.0) {
					if (flagIsFirstIterator) {
						var layout = ClassFont.GetTextLayout(player.BattleTagAbovePortrait + _classShortName[player.HeroClassDefinition.HeroClass]);
						ClassFont.DrawText(layout, xPos, yPos);
						foundCarrySkill = true;
						yPos += 0.03f * HudHeight;
					}
					var Texture = Hud.Texture.GetTexture(Hud.Sno.SnoPowers.WitchDoctor_Passive_SpiritVessel.Icons[1].TextureId);
					switch (player.HeroClassDefinition.HeroClass) {
						case HeroClass.Necromancer: Texture = Hud.Texture.GetTexture(Hud.Sno.SnoPowers.Necromancer_Passive_FinalService.Icons[1].TextureId); break;
						case HeroClass.Wizard: Texture = Hud.Texture.GetTexture(Hud.Sno.SnoPowers.Wizard_Passive_UnstableAnomaly.Icons[1].TextureId); break;
					}
					if (Texture != null) Texture.Draw(xPos, yPos, _size, _size);
					var layout2 = ClassFont.GetTextLayout(CheatDeathBuff.TimeLeftSeconds[1].ToString("0"));
					ClassFont.DrawText(layout2, xPos + (_size - (float)Math.Ceiling(layout2.Metrics.Width)) / 2, yPos + (_size - layout2.Metrics.Height) / 2);
				}
			   
				if (foundCarrySkill) xPos += _size * 2.5f;
				index++;
			}
		}
	}
   
	public class DAV_SkillPainter : ITransparentCollection {
		public bool Enabled { get; set; }
		public IController Hud { get; set; }
 
		public IFont CDFont { get; set; }
		public IFont BuffFont { get; set; }
 
		public DAV_SkillPainter(IController hud) {
			Enabled = true;
			Hud = hud;
 
			CDFont = Hud.Render.CreateFont("arial", 13, 255, 255, 255, 255, true, false, 255, 0, 0, 0, true);
			BuffFont = Hud.Render.CreateFont("arial", 13, 255, 51, 255, 51, true, false, 255, 0, 0, 0, true);
		}
 
		public void Paint(IPlayerSkill skill, RectangleF rect) {
			if (skill == null) return;
 
			var texture = Hud.Texture.GetTexture(skill.SnoPower.NormalIconTextureId);
			if (texture != null) texture.Draw(rect.X, rect.Y, rect.Width, rect.Height);
 
			if (skill.BuffIsActive) {
				var ActiveTime = 0.0d;
				for (var i = 2; i >= 0; i--) {
					ActiveTime= skill.Buff.TimeLeftSeconds[i];
					if (ActiveTime > 0)
						break;
				}
			   
				if (ActiveTime > 0) {
					var bufftext = ActiveTime.ToString(ActiveTime > 3.0f ? "F0" : "F1", CultureInfo.InvariantCulture);
					var bufftextLayout = BuffFont.GetTextLayout(bufftext);
					BuffFont.DrawText(bufftextLayout, rect.X, rect.Y);
				}
			}
		   
			var remainingSeconds = (skill.CooldownFinishTick - Hud.Game.CurrentGameTick) / 60.0d;
			if (skill != null && skill.SnoPower.Sno == Hud.Sno.SnoPowers.Wizard_Archon.Sno && skill.BuffIsActive) {
				var ActiveTime = skill.Buff.TimeLeftSeconds[2];
			   
				if (ActiveTime > 0)
					remainingSeconds = skill.CalculateCooldown(skill.Rune == 3.0? 100 : 120) - 20 + ActiveTime;
			}
			   
			if (remainingSeconds <= 0) return;
			   
			var text = remainingSeconds.ToString(remainingSeconds > 3.0f ? "F0" : "F1", CultureInfo.InvariantCulture);
			var textLayout = CDFont.GetTextLayout(text);
			var x = rect.X + rect.Width - (float)Math.Ceiling(textLayout.Metrics.Width);
			var y = rect.Y + rect.Height - textLayout.Metrics.Height;
			CDFont.DrawText(textLayout, x, y);
		}
 
		public IEnumerable<ITransparent> GetTransparents() {
			yield return CDFont;
			yield return BuffFont;
		}
	}
}