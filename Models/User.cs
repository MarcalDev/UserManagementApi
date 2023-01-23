namespace UserManagementApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateTime RealeaseDate { get; set; }
        public bool isActive { get; set; }
    }
}
