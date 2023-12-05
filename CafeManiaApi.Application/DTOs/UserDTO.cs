namespace CafeManiaApi.Application.DTOs
{
    public class UserDTO
    {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Username { get;  set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public bool IsAdmin { get;  set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }


    }
}
