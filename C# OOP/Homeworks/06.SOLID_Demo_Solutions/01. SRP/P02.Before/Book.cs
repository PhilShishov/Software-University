namespace P02.Before
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public int Location { get; set; }

        public string TurnPage(int page)
        {
            return "Current page";
        }
    }
}
