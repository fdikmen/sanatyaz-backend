namespace proje.Entities
{
    public class About: Base
    {        
        public string Title { get; set; }
        public string Text { get; set; }
        public string mediaUrl { get; set; }
        public string imageUrl { get; set; }
        public bool isActive { get; set; }        
    }
}
