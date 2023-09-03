using System.Text.Json;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization.Infrastructure;

class Program
{
    static void Main (String[] args)
    {
        using var DbContext = new MyDbContext();
        var myObject  = new UserEntity
        {
            JsonData = JsonSerializer.Serialize(new
            {
                Id = 1,
                Name = "Adi"
            })
        };
        DbContext.MyObjects.Add(myObject);
        DbContext.SaveChanges();
        Console.WriteLine("Object stored in the DB");
    }
}