using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Actors
{
    public class WitchDoctorPetsPlugin : BasePlugin, IInGameWorldPainter
    {
        public HashSet<uint> GargantuansIds { get; set; }
        public WorldDecoratorCollection GargantuansDecorators { get; set; }

        public HashSet<uint> ZombiesDogsIds { get; set; }
        public WorldDecoratorCollection ZombiesDogsDecorators { get; set; }


        public WitchDoctorPetsPlugin()
        {
            Enabled = true;
            GargantuansIds = new HashSet<uint> { 432690, 432691, 432692, 432693, 432694, 122305, 179776, 171491, 179778, 171501, 171502, 179780, 179779, 179772 };
            ZombiesDogsIds = new HashSet<uint> { 51353, 108536, 103215, 108543, 104079, 105763, 108560, 110959, 105772, 103235, 108550, 103217, 108556, 105606 };
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            var gargantuanBrush = Hud.Render.CreateBrush(222, 0, 255, 0, 2);
            GargantuansDecorators = new WorldDecoratorCollection(
                new GroundShapeDecorator(hud)
                {
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 1f,
                    Brush = gargantuanBrush,
                },
                new GroundCircleDecorator(hud)
                {
                    Radius = 1f,
                    Brush = gargantuanBrush,
                },
                new MapShapeDecorator(hud)
                {
                    ShapePainter = new TriangleShapePainter(hud),
                    Radius = 6f,
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 0, 1),
                }
                //,
                //new MapShapeDecorator(hud)
                //{
                //    ShapePainter = new CrossShapeFilter(hud),
                //    Radius = 6f,
                //    BarBrush = Hud.Render.CreateBrush(255, 0, 255, 0, 1),
                //}
            );

            var zombieDogBrush = Hud.Render.CreateBrush(178, 0, 255, 0, 2);
            ZombiesDogsDecorators = new WorldDecoratorCollection(
                new GroundShapeDecorator(hud)
                {
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 0.35f,
                    Brush = gargantuanBrush,
                },
                new GroundCircleDecorator(hud)
                {
                    Radius = 0.35f,
                    Brush = zombieDogBrush,
                },
                new MapShapeDecorator(hud)
                {
                    ShapePainter = new CrossShapePainter(hud),
                    Radius = 1f,
                    Brush = zombieDogBrush,
                }
            );
            foreach (var mapShapeDecorator in ZombiesDogsDecorators.GetDecorators<MapShapeDecorator>())
            {
                mapShapeDecorator.Enabled = false;
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Render.UiHidden) return;
            if (Hud.Game.IsInTown) return;
            if (Hud.Game.Me.HeroClassDefinition.HeroClass != HeroClass.WitchDoctor) return;

            var Gargantuans = Hud.Game.Actors.Where(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && GargantuansIds.Contains(a.SnoActor.Sno));

            foreach (var garg in Gargantuans)
            {
                GargantuansDecorators.Paint(layer, garg, garg.FloorCoordinate, null);
            }

            var zombieDogs = Hud.Game.Actors.Where(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && ZombiesDogsIds.Contains(a.SnoActor.Sno));

            foreach (var zombieDog in zombieDogs)
            {
                ZombiesDogsDecorators.Paint(layer, zombieDog, zombieDog.FloorCoordinate, null);
            }
        }
    }
}