using System.ComponentModel.DataAnnotations;

namespace KmdProject.Api.Models.User
{
    public class UserDetailsViewModel
    {
        public long Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Initials { get; set; }
    }
}
