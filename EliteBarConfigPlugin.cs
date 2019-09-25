using System;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Gigi
{
    public class EliteBarConfigPlugin : BasePlugin, ICustomizer
	{
        public EliteBarConfigPlugin()
		{
            Enabled = true;
		}
        public void Customize()
        {
      
	
 Hud.RunOnPlugin<Gigi.EliteBarPlugin>(plugin =>             {

		        foreach(MonsterAffix afx in System.Enum.GetValues(typeof(MonsterAffix))) //¼Ó¼º Ç¥±â

                plugin.DisplayAffix.Clear(); 

                plugin.DisplayAffix[MonsterAffix.Arcane] = "ºñÀü";
                plugin.DisplayAffix[MonsterAffix.Desecrator] = "½Å¼º";
                plugin.DisplayAffix[MonsterAffix.Electrified] = "°¨Àü";
                plugin.DisplayAffix[MonsterAffix.FireChains] = "»ç½½";
                plugin.DisplayAffix[MonsterAffix.Frozen] = "ºù°á";
                plugin.DisplayAffix[MonsterAffix.FrozenPulse] = "³ÃÆø";
                plugin.DisplayAffix[MonsterAffix.Jailer] = "°¡µÎ";
                plugin.DisplayAffix[MonsterAffix.Juggernaut] = "°ÅÇÑ";
                plugin.DisplayAffix[MonsterAffix.Molten] = "À¶ÇØ";
                plugin.DisplayAffix[MonsterAffix.Mortar] = "Æ÷°Ý";
                plugin.DisplayAffix[MonsterAffix.Orbiter] = "Àü±Ë";
                plugin.DisplayAffix[MonsterAffix.Plagued] = "¿ªº´";
                plugin.DisplayAffix[MonsterAffix.Poison] = "µ¶°Ý";
                plugin.DisplayAffix[MonsterAffix.Reflect] = "ÇÇ¹Ý";
                plugin.DisplayAffix[MonsterAffix.Thunderstorm] = "ÃµÆø";
                plugin.DisplayAffix[MonsterAffix.Waller] = "º®»ý";

                plugin.DisplayAffix[MonsterAffix.ExtraHealth] = "Ãß»ý";
                plugin.DisplayAffix[MonsterAffix.HealthLink] = "»ý¿¬";
                plugin.DisplayAffix[MonsterAffix.Fast] = "ºü¸§";
                plugin.DisplayAffix[MonsterAffix.Knockback] = "¹ÐÄ§";
                plugin.DisplayAffix[MonsterAffix.Nightmarish] = "¾Ç¸ù";
                plugin.DisplayAffix[MonsterAffix.Illusionist] = "È¯¿µ";
                plugin.DisplayAffix[MonsterAffix.Shielding] = "º¸¸·";
                plugin.DisplayAffix[MonsterAffix.Teleporter] = "¼øÀÌ";
                plugin.DisplayAffix[MonsterAffix.Vampiric] = "ÈíÇ÷";
                plugin.DisplayAffix[MonsterAffix.Vortex] = "¼Òµ¹";
                plugin.DisplayAffix[MonsterAffix.Wormhole] = "½Ã°ø";
                plugin.DisplayAffix[MonsterAffix.Avenger] = "¾Ó°±";
                plugin.DisplayAffix[MonsterAffix.Horde] = "¹«¸®";
                plugin.DisplayAffix[MonsterAffix.MissileDampening] = "µÐÈ­";
    });
}
}
}
