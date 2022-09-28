using System.ComponentModel.DataAnnotations.Schema;

namespace DotSheepFight.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string ? Name { get; set; }
        public string ? Device { get; set; }
        public string ? FotoUrl { get; set; }
        [NotMapped]
        public IFormFile ? Foto { get; set; }
    }
}
