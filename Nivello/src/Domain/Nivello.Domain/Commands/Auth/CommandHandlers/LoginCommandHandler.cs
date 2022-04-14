using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nivello.Domain.Commands.Auth.Commands;
using Nivello.Domain.Commands.Auth.Queries;
using Nivello.Domain.Commands.Auth.Validators;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Admins;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using Nivello.Lib.Nivello.Lib.Domain.Commands.Interfaces;
using Nivello.Lib.Nivello.Lib.Infrastructure.Data.Models;

namespace Nivello.Domain.Commands.Auth.CommandHandlers
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IConfiguration _configuration;
        public LoginCommandHandler(ICustomerRepository customerRepository,
            IAdminRepository adminRepository, IConfiguration configuration)
        {
            _customerRepository = customerRepository;
            _adminRepository = adminRepository;
            _configuration = configuration;
        }
        public async Task<CommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validator = new LoginCommandValidator();
            validator.ValidateAndThrow(request);
            string token;
            if (request.IsAdmin)
            {
              token = CreatedToken(await _adminRepository.FirstOrDefaultAsync(AuthQueries<SystemAdmin>.LoginQuery(request.Email, request.Password)), true);
            }
            else
            {
               token = CreatedToken(await _customerRepository.FirstOrDefaultAsync(AuthQueries<Infrastructure.Data.Model.Customer>.LoginQuery(request.Email, request.Password)), false);
            }

            return new CommandResult(true, token);
        }

        private string CreatedToken(User user, bool isAdmin)
        {
            if (user == null)
                throw new ArgumentException("Invalid parameters");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, (isAdmin) ? "Admin" : "Customer")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
