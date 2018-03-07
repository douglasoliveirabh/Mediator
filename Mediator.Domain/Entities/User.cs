using System;
using Flunt.Validations;

namespace Mediator.Domain.Entities
{
    public class User : EntityBase
    {        
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public User()
        {           
        }

        public User(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .HasMinLen(Username, 8, "Username", "O Username deve conter pelo menos 3 caracteres")
                .HasLen(Password, 6, "Password", "A senha deve ter exatos 6 caracteres")
            );
        }
    }
}