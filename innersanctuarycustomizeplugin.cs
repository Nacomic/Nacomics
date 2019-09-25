namespace Turbo.Plugins.Ls
{
    using Turbo.Plugins.Default;
 
       public class InnerSanctuaryCustomizePlugin : BasePlugin, ICustomizer
    {
        public WorldDecoratorCollection InnerSanctuaryDecorator {get; set;}
 
        public InnerSanctuaryCustomizePlugin()
        {
            Enabled = true;
 
        }
        public override void Load(IController hud)
        {
            base.Load(hud);
 
            InnerSanctuaryDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(245, 255, 0, 127, 9f),
                    Radius = 13.0f,
                },
		new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(245, 245, 245, 245, 2),
                    Radius = 13.0f,
                },
                new GroundLabelDecorator(Hud)
                {
                    CountDownFrom = 6,
                    TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 0, 255, 0, true, false, 128, 0, 0, 0, true),
                },
                new GroundTimerDecorator(Hud)
                {
                    CountDownFrom = 6,
                    BackgroundBrushEmpty = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    BackgroundBrushFill = Hud.Render.CreateBrush(245, 255, 0, 0, 0),
                    Radius = 35,
                }
            );
 
        }
        public void Customize()
        {
            Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
            {
                plugin.InnerSanctuaryDefaultDecorator = InnerSanctuaryDecorator;
                plugin.InnerSanctuarySafeHavenDecorator = InnerSanctuaryDecorator;
                plugin.InnerSanctuarySanctifiedGroundDecorator = InnerSanctuaryDecorator;
                plugin.InnerSanctuaryTempleOfProtecteionDecorator = InnerSanctuaryDecorator;
            });
        }
    }
}