namespace SchemaLayer;

public class TokenRequest
{
    public string UserEmail { get; set; }
    public string UserPassword { get; set; }
}

public class TokenResponse
{
    public string Token { get; set; }
}