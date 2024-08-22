using System.ComponentModel.DataAnnotations;

namespace Handmade_Dotnet.Models
{
    public class huongdan_model
    {
        [Key]
        public string tutorialid { get; set; }
        public string tutorialname { get; set; }
        public string video { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
