using System;
using System.ComponentModel.DataAnnotations;
using SweeneyVidyaGames.Web.Models;

namespace SweeneyVidyaGames.Api.Models
{
    public class VideoGameDTO
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Platform { get; set; }
        public DateTime DateAdded { get; set; }
        public string PlatformApplication { get; set; }
        public EGenreType Genre { get; set; }
        public DateTime Released { get; set; }
        public string ImagePath { get; set; }
        public float Rating { get; set; }

        public VideoGameDTO()
        {
            DateAdded = DateTime.UtcNow;
        }
    }
}
