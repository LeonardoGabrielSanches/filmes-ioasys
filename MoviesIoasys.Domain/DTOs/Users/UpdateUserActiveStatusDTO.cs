namespace MoviesIoasys.Domain.DTOs.Users
{
    public class UpdateUserActiveStatusDTO
    {
        public UpdateUserActiveStatusDTO(string email,
                                         bool active)
        {
            Email = email;
            Active = active;
        }

        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
