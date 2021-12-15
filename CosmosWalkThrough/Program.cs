


using Microsoft.EntityFrameworkCore;

using var context = new TestContext();
//context.Database.EnsureCreated();

var account = new Account()
{
    AccountId = 1,
    Balance = 5000,
    Name = "Test Account 1"
};

var user = new User()
{
    Email = "me@me.com",
    Id = 1,
    Name = "me",
    Password = "test",
    Status = "New",
};
user.Accounts.Add(account);

//context.Users.Add(user);
//context.SaveChanges();

var product = new Product()
{
    Description = "Comic Book",
    Id = 1,
    ItemNumber = 123,
    Price = 2.25m
};

context.Products.Add(product);
context.SaveChanges();



public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Status { get; set; }
    public List<Account> Accounts { get; set; } = new List<Account>();
}

public class Account
{
    public string? Name { get; set; }
    public float Balance { get; set; }
    public int AccountId { get; set; }
}

public class Product
{
    public int Id { get; set; }
    public int ItemNumber { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

public class TestContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "TestDb");
        base.OnConfiguring(optionsBuilder);
    }
}