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

		        foreach(MonsterAffix afx in System.Enum.GetValues(typeof(MonsterAffix))) //�Ӽ� ǥ��

                plugin.DisplayAffix.Clear(); 

                plugin.DisplayAffix[MonsterAffix.Arcane] = "����";
                plugin.DisplayAffix[MonsterAffix.Desecrator] = "�ż�";
                plugin.DisplayAffix[MonsterAffix.Electrified] = "����";
                plugin.DisplayAffix[MonsterAffix.FireChains] = "�罽";
                plugin.DisplayAffix[MonsterAffix.Frozen] = "����";
                plugin.DisplayAffix[MonsterAffix.FrozenPulse] = "����";
                plugin.DisplayAffix[MonsterAffix.Jailer] = "����";
                plugin.DisplayAffix[MonsterAffix.Juggernaut] = "����";
                plugin.DisplayAffix[MonsterAffix.Molten] = "����";
                plugin.DisplayAffix[MonsterAffix.Mortar] = "����";
                plugin.DisplayAffix[MonsterAffix.Orbiter] = "����";
                plugin.DisplayAffix[MonsterAffix.Plagued] = "����";
                plugin.DisplayAffix[MonsterAffix.Poison] = "����";
                plugin.DisplayAffix[MonsterAffix.Reflect] = "�ǹ�";
                plugin.DisplayAffix[MonsterAffix.Thunderstorm] = "õ��";
                plugin.DisplayAffix[MonsterAffix.Waller] = "����";

                plugin.DisplayAffix[MonsterAffix.ExtraHealth] = "�߻�";
                plugin.DisplayAffix[MonsterAffix.HealthLink] = "����";
                plugin.DisplayAffix[MonsterAffix.Fast] = "����";
                plugin.DisplayAffix[MonsterAffix.Knockback] = "��ħ";
                plugin.DisplayAffix[MonsterAffix.Nightmarish] = "�Ǹ�";
                plugin.DisplayAffix[MonsterAffix.Illusionist] = "ȯ��";
                plugin.DisplayAffix[MonsterAffix.Shielding] = "����";
                plugin.DisplayAffix[MonsterAffix.Teleporter] = "����";
                plugin.DisplayAffix[MonsterAffix.Vampiric] = "����";
                plugin.DisplayAffix[MonsterAffix.Vortex] = "�ҵ�";
                plugin.DisplayAffix[MonsterAffix.Wormhole] = "�ð�";
                plugin.DisplayAffix[MonsterAffix.Avenger] = "�Ӱ�";
                plugin.DisplayAffix[MonsterAffix.Horde] = "����";
                plugin.DisplayAffix[MonsterAffix.MissileDampening] = "��ȭ";
    });
}
}
}
