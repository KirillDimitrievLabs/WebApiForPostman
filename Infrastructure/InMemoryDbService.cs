using System;
using System.Collections.Generic;
using System.Linq;
using WebApiForPostman.Infrastructure.Entities;

namespace WebApiForPostman.Infrastructure;

public class InMemoryDbService : IInMemoryDbService<User>
{
    private readonly InMemoryDbContext _inMemoryDbContext;

    public InMemoryDbService(InMemoryDbContext inMemoryDbContext)
    {
        _inMemoryDbContext = inMemoryDbContext;
    }

    public User GetUser(int id)
    {
        return _inMemoryDbContext.Users.FirstOrDefault(user => user.id == id) ?? throw new InvalidOperationException();
    }

    public List<User> GetUsers()
    {
        return _inMemoryDbContext.Users;
    }

    public User CreateUser(string name, string login, int? age, string phoneNumber)
    {
        if (name == "") throw new ArgumentException("Name cannot be empty string");
        if (login == "") throw new ArgumentException("Login cannot be empty string");
        if (age < 1) throw new ArgumentException("Impossible age");
        if (phoneNumber.Length < 11) throw new ArgumentException("Too short phone number");

        var lastId = _inMemoryDbContext.Users.Last().id;

        var newUser = new User()
        {
            id = lastId + 1,
            Name = name,
            Age = age,
            Login = login,
            PhoneNumber = phoneNumber
        };

        _inMemoryDbContext.Users.Add(newUser);

        return newUser;
    }

    public int DeleteUser(int userId)
    {
        var userToDelete = _inMemoryDbContext.Users.FirstOrDefault(user => user.id == userId);

        if (userToDelete != null)
        {
            _inMemoryDbContext.Users.Remove(userToDelete);
        }
        else
        {
            throw new ArgumentException($"Cannot find user with id = {userId}");
        }

        return userId;
    }

    public User UpdateUser(int userId, string? name = null, string? login = null, int? age = null,
        string? phoneNumber = null)
    {
        //if (age < 1) throw new ArgumentException("Impossible age");

        var userToUpdateId = _inMemoryDbContext.Users.FindIndex(user => user.id == userId);

        _inMemoryDbContext.Users[userToUpdateId].Age = age ?? _inMemoryDbContext.Users[userToUpdateId].Age;
        _inMemoryDbContext.Users[userToUpdateId].Login = login ?? _inMemoryDbContext.Users[userToUpdateId].Login;
        _inMemoryDbContext.Users[userToUpdateId].Name = name ?? _inMemoryDbContext.Users[userToUpdateId].Name;
        _inMemoryDbContext.Users[userToUpdateId].PhoneNumber =
            phoneNumber ?? _inMemoryDbContext.Users[userToUpdateId].PhoneNumber;
        return _inMemoryDbContext.Users[userToUpdateId];
    }
}