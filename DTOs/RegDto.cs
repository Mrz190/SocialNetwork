using System.ComponentModel.DataAnnotations;

namespace CheckSkillsASP.DTOs
{
    public class RegDto
    {
        [Required]
        public string Username { get; set; }
        public DateTime WasCreated { get; set; } = DateTime.Now;

        [Required] public string NickName { get; set; }
        [Required] public string City { get; set; }
        [Required] public string Country { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
