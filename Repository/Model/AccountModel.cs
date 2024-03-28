namespace Repository.Model
{
    public class AccountModel
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTimeOffset? Birthdate { get; set; }
        public string? Role { get; set; }
        public string? Work { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public DateTimeOffset? DeleteTime { get; set; }
    }
}
