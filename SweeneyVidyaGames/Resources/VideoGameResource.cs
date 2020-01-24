using System;
namespace SweeneyVidyaGames.Api.Resources
{
    public class VideoGameResource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Platform { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlatformApplication { get; set; }
        public string Genre { get; set; }
        public DateTime Released { get; set; }
        public string ImagePath { get; set; }
        public float Rating { get; set; }
    }
}
