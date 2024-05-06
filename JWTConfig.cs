namespace DiplomApi;

public class JWTConfig
{
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public int ValidityHours { get; set; }
}
