namespace WebApiForPostman.Infrastructure;

public class TokenService
{
    private readonly InMemoryDbContext _inMemoryDbContext;

    public TokenService(InMemoryDbContext inMemoryDbContext)
    {
        _inMemoryDbContext = inMemoryDbContext;
    }

    public string GetToken()
    {
        return _inMemoryDbContext.Token;
    }
}