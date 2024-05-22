using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PractisesJWT2.DTOS;
using PractisesJWT2.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PractisesJWT2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityIdentityController : ControllerBase
    {
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;

        public SecurityIdentityController(  UserManager<ApplicationUser> userManager,IConfiguration config)
        {
            this.userManager = userManager;
            this.config = config;
        }

        // create 2 action methods (register - Login)
        [HttpPost]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = registerDto.UserName;
                user.Email = registerDto.E_Mail;
              //  user.PasswordHash = registerDto.Password;
                user.Address = registerDto.Address;
                
                        IdentityResult result = await userManager.CreateAsync(user, registerDto.Password);
                        if (result.Succeeded)
                        {
                            return Ok("saving register ok");
                         }
                else
                {
                    var errors = result.Errors.Select(s => s.Description);
                    var errorsmsg = string.Join(";", errors);
                    return BadRequest(errorsmsg); 
                }
               
            }
            else
            {
                return BadRequest("sorry something is wrong");
            }
          
        }


        //------------------------------------------------------------ (login)
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                // check if username founded or not 
                ApplicationUser user =  await userManager.FindByNameAsync(loginDto.UserName);
                if (user is not null) 
                {
                    // check password 
                    bool found =  await userManager.CheckPasswordAsync(user, loginDto.Password);
                    if (found)
                    {
                        /*
                         steps to create tocken 
                        1/ write issuer & audians & Key as a json 
                        2/ create object from jwtsecuritytocken and put information about tacken (header(algorithm) - payload(claims) - signeture )
                        3/ add a claims as a list<claims> 
                        4/ get roles 
                        5/ signingCredentials to be a signeture trusted and valid 
                        6/ instanse from securitykey to pass a key but as a arrayofbytes 
                         
                         
                         
                         
                         */
                      //  return Ok("this user ok");
                        // & create tocken

                        var claimss = new List<Claim>();
                        claimss.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claimss.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claimss.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var roles =  await userManager.GetRolesAsync(user);
                        foreach(var itemrole in roles)
                        {
                            claimss.Add(new Claim(ClaimTypes.Role, itemrole));
                        }
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"])); //  
                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        // use this algorithm to create signeture 

                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: config["JWT:issuer"] ,
                            audience: config["JWT:audians"],
                            expires: DateTime.Now.AddDays(1),
                            claims:claimss,
                            signingCredentials: signingCredentials
                            );


                        return Ok(new {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo

                        });

                    }
                    else
                    {
                        return BadRequest("this password is not true pls try again ..!");
                    }
                }
                else
                {
                    return BadRequest("this user is not found please resgiter");
                }
            }
            else
            {
                var errors = ModelState.Select(s => s.Value);

                return BadRequest(errors);
            }
        }
    }
}
