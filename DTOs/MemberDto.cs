namespace CheckSkillsASP.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
        public string NickName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public DateTime WasCreated { get; set; }
    }
}
