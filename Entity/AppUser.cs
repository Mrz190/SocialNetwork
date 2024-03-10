using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckSkillsASP.Entity
{
    public class AppUser : IdentityUser<int>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NickName { get; set; }
        public DateTime WasCreated { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}