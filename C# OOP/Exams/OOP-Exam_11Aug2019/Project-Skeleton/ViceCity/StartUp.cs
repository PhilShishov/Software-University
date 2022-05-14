
namespace ViceCity
{
    using ViceCity.Core;
    using ViceCity.Core.Contracts;

    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
