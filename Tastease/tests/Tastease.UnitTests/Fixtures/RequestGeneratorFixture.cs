using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tastease.UnitTests.Fixtures
{
    public class UserCredentials
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class RequestGeneratorFixture : IDisposable
    {
        /// <summary>
        /// Minimum eight and maximum 10 characters, at least one uppercase letter, one lowercase letter, one number and one special character:
        /// </summary>
        public const string passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$";
        public RequestGeneratorFixture()
        {

        }
        public UserCredentials GenerateUserCredentials() => new Faker<UserCredentials>()
            .RuleFor(user => user.Email, f => f.Internet.Email())
            .RuleFor(user => user.Password, f => f.Internet.Password(regexPattern: passwordRegex))
            .Generate(1)
            .First();

        public void Dispose()
        {
            
        }
    }
}
