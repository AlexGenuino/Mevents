using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Api.Domain.Security;
using Api.Domain.Secutiry;
using Api.Service.Services.Encripty;
using Domain.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _repositoryUser;
        private IAdminRepository _repositoryAdmin;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration {get;}
        
        public LoginService(IUserRepository Userrepository, IAdminRepository Admrepository, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations,
        IConfiguration configuration)
        {
            _repositoryUser = Userrepository;
            _repositoryAdmin = Admrepository;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
        }

        public async Task<object> Login(LoginDto user)
        {
            
            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                var ResultUser = new UserEntity();
                user.Password = EncriptyPassword.CreateMD5(user.Password);
                ResultUser = await _repositoryUser.Login(user.Email, user.Password);
                
                if (ResultUser == null)
                {
                    var ResultAdmin = new Admin();
                    ResultAdmin = await _repositoryAdmin.Login(user.Email, user.Password);
                    
                    if (ResultAdmin == null)
                    {
                        var Result = new
                        {
                            Autheticated = false,
                            Message = "Falha ao autenticar"
                        };

                        return Result;
                    }
                    else
                    {
                        ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                            new Claim(ClaimTypes.Role, "Admin"),
                        }
                    );

                        DateTime createDate = DateTime.UtcNow;
                        DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                        var handler = new JwtSecurityTokenHandler();
                        string token = CreateToken(identity, createDate, expirationDate, handler);
                        return SuccessObjectAdmin(createDate, expirationDate, token, ResultAdmin);
                    }
                }
                else
                {
                    ClaimsIdentity identity = new ClaimsIdentity(
                        new GenericIdentity(user.Email),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                            new Claim(ClaimTypes.Role, "Usuario"),
                        }
                    );

                    DateTime createDate = DateTime.UtcNow;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    return SuccessObjectUser(createDate, expirationDate, token, ResultUser);
                }
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
            });

            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object SuccessObjectUser(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = user.Email,
                name = user.Name,
                message = "Usu??rio Logado com sucesso"
            };
        }

        private object SuccessObjectAdmin(DateTime createDate, DateTime expirationDate, string token, Admin admin)
        {
            return new
            {
                authenticated = true,
                create = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                userName = admin.Email,
                name = admin.Name,
                message = "Administrador Logado com sucesso"
            };
        }
    }
}