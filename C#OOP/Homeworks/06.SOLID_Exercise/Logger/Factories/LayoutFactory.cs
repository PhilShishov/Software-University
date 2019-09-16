namespace LoggerApplication.Factories
{
    using LoggerApplication.Exceptions;
    using LoggerApplication.Models.Contracts;
    using LoggerApplication.Models.Layouts;
    using System;

    public class LayoutFactory
    {
        public ILayout GetLayout(string layoutType)
        {
            ILayout layout;

            if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }

            else if (layoutType == "XmlLayout")
            {
                layout = new XmlLayout();
            }

            else
            {
                throw new InvalidLayoutTypeException();
            }

            return layout;
        }
    }
}
