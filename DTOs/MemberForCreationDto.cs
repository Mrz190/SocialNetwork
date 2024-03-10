using System.ComponentModel.DataAnnotations;

namespace CheckSkillsASP.DTOs
{
    public class MemberForCreationDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string NickName { get; set; }

        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }

        [Required]
        public DateTime WasCreated { get; set; } = DateTime.Now;

        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
