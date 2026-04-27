namespace cbms.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }

        public Project() { }

        public Project(string title, string tagline, string text, string link)
        {
            Title = title;
            Tagline = tagline;
            Text = text;
            Link = link;
        }
    }
}
