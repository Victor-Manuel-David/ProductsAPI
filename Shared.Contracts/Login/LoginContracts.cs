namespace Shared.Contracts.Login;

public record LoginRequest(string Username, string Password);
public record LoginResponse(string Access_Token, int Expires_In);
