﻿namespace MoviesIoasys.Domain.DTOs.Users
{
    public class LoginDTO
    {
        public LoginDTO(string email,
                        string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
