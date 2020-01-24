using System.ComponentModel.DataAnnotations;


namespace SweeneyVidyaGames.Api.Resources
{
    public class SaveVideoGameResource
    {
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        public string Platform { get; set; }
    }
}
