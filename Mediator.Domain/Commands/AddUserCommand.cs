using Flunt.Notifications;
using Flunt.Validations;
using Mediator.Shared.Commands;

namespace Mediator.Domain.Commands{

    public class AddUserCommand : CommandBase
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public AddUserCommand(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
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