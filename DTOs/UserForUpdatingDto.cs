using System.ComponentModel.DataAnnotations;

namespace CheckSkillsASP.DTOs
{
    public class UserForUpdatingDto
    {
        [Required]
        public string UserName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
    }
}
