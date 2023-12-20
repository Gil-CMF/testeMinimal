using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;


public class TokenHandler{


public static string GenerateJwtToken(Usuario usuario)
{
    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Sub, usuario.Username)

    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("minhaChaveChavosa12345612345123123!"));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    var token = new JwtSecurityToken(
        issuer: "issuer",
        audience: "audience",
        claims: claims,
        expires: DateTime.Now.AddMinutes(30),
        signingCredentials: creds);

    return new JwtSecurityTokenHandler().WriteToken(token);
}

}