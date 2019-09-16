namespace LoggerApplication.Models.Layouts
{
    using LoggerApplication.Models.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
