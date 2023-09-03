1. mkdir skeleton -- create floder
2. cd skeleton
3. dotnet new sln -- create new solution file (container for projects)
4. dotnet new webapi -n API - create project file - webapi 
5. dotnet sln add API - put API inside the solution
6. code . - open the project from visual code

in vs-code:
1. API => new folder: Entities => add new file(class): MyObjectEntity:
        public int Id { get; set; }
        public string? JsonData  { get; set; }
2. install entityframework sqlite to the api:
show all comands -> nuget: open nuget galery -> entityframeworkcore -> Microsoft.EntityFrameworkCore.Sqlite(not core!) -> API.csproj V -> install
																	  Microsoft.EntityFrameworkCore.Design
					
3. API => new floder: DATA => add new file: MyDbContext:
public class DataContext: DbContext	
public DbSet<MyObjectEntity> MyObjects { get; set; }
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseSqlite("Data Source=mydatabase.db");
}	
4. C:\adi\hexagon\API> dotnet ef migrations add InitialCreate -o Data/Migrations
5. C:\adi\hexagon\API> dotnet ef database update
6. delete program.cs and insert instead:
using System.Text.Json;
using API.Data;
using API.Entities;
class Program
{
    static void Main(string[] args)
    {
        using var DbContext = new MyDbContext();
        var myObject = new MyObjectEntity
        {
            JsonData = JsonSerializer.Serialize(new 
            {
                Id = 1,
                Name = "Adi"
            })
        };
		
        DbContext.MyObjects.Add(myObject);
        DbContext.SaveChanges();
        Console.WriteLine("Object stored in th db");       
    }
}
