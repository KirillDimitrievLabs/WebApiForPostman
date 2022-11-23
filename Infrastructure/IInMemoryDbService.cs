using System.Collections.Generic;

namespace WebApiForPostman.Infrastructure;

public interface IInMemoryDbService<TEntity>
{
    TEntity GetUser(int id);
    List<TEntity> GetUsers();
    TEntity CreateUser(string name, string login, int? age, string phoneNumber);
    int DeleteUser(int userId);

    TEntity UpdateUser(int userId, string? name = null, string? login = null, int? age = int.MaxValue,
        string? phoneNumber = null);
}