using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class ValidateToken
{
    private readonly string _secretKey = "jX!l+;/k,?wuTYpaOMz]F:EX9.P#hA:={oI[]9G|M]+jX.eehc6Be,d(IaZ3;!(9Fh*;#";

    public bool ValidateToken_(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
            ValidateIssuer = false, // установите в true, если требуется проверка issuer
            ValidateAudience = true, // установите в true, если требуется проверка audience
            RequireExpirationTime = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // допустимое отклонение времени, можно настроить
        };

        SecurityToken validatedToken;
        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            return true;
        }
        catch (SecurityTokenException)
        {
            // Если токен недействителен (например, истек или подпись неверна)
            return false;
        }
    }
}
