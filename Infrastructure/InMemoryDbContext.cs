using System;
using System.Collections.Generic;
using WebApiForPostman.Infrastructure.Entities;

namespace WebApiForPostman.Infrastructure;

public class InMemoryDbContext
{
    public InMemoryDbContext()
    {
        Users = new List<User>();
        InitUsers();
    }

    public List<User> Users { get; set; }

    private void InitUsers()
    {
        var names = new List<string>() { "Andrew", "Kate", "Kirill", "Michael", "John", "Snow" };
        var logins = new List<string>() { "rapebot", "steel1337", "oposum", "mrak", "postman", "windows" };
        var rn = new Random(3265);
        var rnPhone = new Random(3245234);
        for (int i = 0; i < 6; i++)
        {
            Users.Add(new User()
            {
                id = i,
                Age = rn.Next(20, 80),
                Login = logins[i],
                Name = names[i],
                PhoneNumber = $"+7960{rnPhone.Next(1000000, 9999999).ToString()}"
            });
        }
    }
}