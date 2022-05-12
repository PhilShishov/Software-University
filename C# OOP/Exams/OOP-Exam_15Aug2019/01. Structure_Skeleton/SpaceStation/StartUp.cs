
namespace SpaceStation
{
    using SpaceStation.Core;
    using SpaceStation.Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}