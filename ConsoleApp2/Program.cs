using ConsoleApp2.Contexts;
using ConsoleApp2.Models;

ShopContext shopContext = new ShopContext();
void GetAll()
{
    List<Category> categories = shopContext.Category.Where(cat => !cat.IsDeleted).ToList();

    foreach (Category category in categories)
        Console.WriteLine($"Id:{category.Id} Name:{category.Name} IsDeleted:{category.IsDeleted}");
}

void GetById()
{
    Console.WriteLine("Input Id:");
    int.TryParse(Console.ReadLine(), out int Id);

    Category? category = shopContext.Category.Where(cat => cat.Id == Id && !cat.IsDeleted).FirstOrDefault();

    if (category != null)
        Console.WriteLine($"Id:{category.Id} Name:{category.Name} IsDeleted:{category.IsDeleted}");
    else
        Console.WriteLine("Not Found!");
}

void Create()
{
    Console.WriteLine("Input Name:");
    string Name = Console.ReadLine();

    Category category = new Category();
    category.Name = Name;
    shopContext.Add(category);
    int result = shopContext.SaveChanges();

    if (result == 0)
        Console.WriteLine("Failed to save changes!");
    else
        Console.WriteLine("Saved Changes!");
}

Create();
GetById();
GetAll();