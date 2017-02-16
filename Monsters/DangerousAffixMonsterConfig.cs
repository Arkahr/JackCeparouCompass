﻿namespace Turbo.Plugins.JackCeparouCompass.Monsters
{
    using System;
    using Turbo.Plugins.Default;

    public class DangerousAffixMonsterConfig : BasePlugin
    {
        public DangerousAffixMonsterConfig()
        {
            Enabled = true;
        }

        public override void Customize()
        {
            //Debug(); return;
            Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin =>
            {
                ////////////////////////////////////////////////
                // first, redefine plugin defaults if you want :
                ////////////////////////////////////////////////
                // DEFAULTS //
                //////////////
                // plugin.DefaultMapShapePainter = new CircleShapePainter(Hud);
                // plugin.DefaultRadiusTransformator = new StandardPingRadiusTransformator(Hud, 500);
                // plugin.DefaultBackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
                // plugin.DefaultForegroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0);
                // plugin.DefaultEliteAffixesFont = Hud.Render.CreateFont("tahoma", 10f, 200, 255, 255, 0, false, false, 128, 0, 0, 0, true);
                // plugin.DefaultMinionAffixesFont = Hud.Render.CreateFont("tahoma", 7f, 200, 255, 255, 0, false, false, 128, 0, 0, 0, true);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // A complete example for Juggernaut overriding all defaults
                plugin.DefineDangerousAffix(MonsterAffix.Juggernaut,
                    (a) => a.NameLocalized.Substring(0, 3), // or a string like "Jug"
                    priority: 420, // higher first
                    // decorator background
                    bgBrush: Hud.Render.CreateBrush(255, 0, 0, 0, 0), // default
                    bgShapePainter: new CircleShapePainter(Hud), // default new CircleShapePainter(Hud)
                    bgPing: true, // default false
                    bgRadiusTransformator: new StandardPingRadiusTransformator(Hud, 500), // default
                    eliteBgRadius: 8, // default 8
                    minionBgRadius: 6, // default 6
                    // decorator foreground
                    fgBrush: Hud.Render.CreateBrush(255, 255, 0, 0, 1), // default
                    fgShapePainter: new RotatingTriangleShapePainter(Hud), // default new CircleShapePainter(Hud)
                    fgPing: true, // default false
                    fgRadiusTransformator: new StandardPingRadiusTransformator(Hud, 500), // default
                    eliteFgRadius: 6, // default 6
                    minionFgRadius: 2, // default 2
                    // labels fonts
                    eliteFont: Hud.Render.CreateFont("tahoma", 10f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                    minionFont: Hud.Render.CreateFont("tahoma", 7f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                    // minions
                    showMinionDecorators: false, // default false
                    showMinionAffixesNames: false // default false
                );
                plugin.DefineDangerousAffix(MonsterAffix.Illusionist, (a) => a.NameLocalized.Substring(0, 3));
                plugin.DefineDangerousAffix(MonsterAffix.Reflect, (a) => a.NameLocalized.Substring(0, 1));
                plugin.DefineDangerousAffix(MonsterAffix.Poison, (a) => a.NameLocalized.Substring(0, 1));
                plugin.DefineDangerousAffix(MonsterAffix.Arcane, (a) => a.NameLocalized.Substring(0, 2));
                plugin.DefineDangerousAffix(MonsterAffix.Shielding, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Molten, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Desecrator, (a) => a.NameLocalized.Substring(0, 3));
                plugin.DefineDangerousAffix(MonsterAffix.Molten, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Wormhole, (a) => a.NameLocalized.Substring(0, 4));

                plugin.DefineDangerousAffix(MonsterAffix.Waller, string.Empty);
                /**/
            });
            // the config is done, disable this plugin
            Enabled = false;
        }

        public void Debug()
        {
            Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin =>
            {
                var p = 420;
                foreach (MonsterAffix affix in Enum.GetValues(typeof (MonsterAffix)))
                {
                    plugin.DefineDangerousAffix(affix,
                        (a) => a.NameLocalized.Substring(0, 3), // or a string like "Jug"
                        priority: p--, // higher first
                        // decorator background
                        bgBrush: Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                        bgShapePainter: new CircleShapePainter(Hud), // default new CircleShapePainter(Hud)
                        bgPing: true, // default false
                        bgRadiusTransformator: new StandardPingRadiusTransformator(Hud, 666),
                        eliteBgRadius: 8, // default 8
                        minionBgRadius: 6, // default 6
                        // decorator foreground
                        fgBrush: Hud.Render.CreateBrush(255, 255, 0, 0, 1),
                        fgShapePainter: new RotatingTriangleShapePainter(Hud), // default new CircleShapePainter(Hud)
                        fgPing: false, // default false
                        fgRadiusTransformator: new StandardPingRadiusTransformator(Hud, 666),
                        eliteFgRadius: 6, // default 6
                        minionFgRadius: 2, // default 2
                        // labels fonts
                        eliteFont: Hud.Render.CreateFont("tahoma", 10f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                        minionFont: Hud.Render.CreateFont("tahoma", 7f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                        // minions
                        showMinionDecorators: true, // default false
                        showMinionAffixesNames: true // default false
                        );
                }
            });
        }
    }
}