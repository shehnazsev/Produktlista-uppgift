using Resources.Enums;
using Resources.Models;
using Resources.Services;

namespace MainProject.Menus;

internal class ProductMenu
{
    private readonly ProductService _productService = new ProductService();
    public void CreateProduct()
    {
        Product product = new Product();

        Console.Clear();
        Console.WriteLine("Create new product");

        Console.Write("Enter Product Name: ");
        product.Name = Console.ReadLine() ?? "";

        Console.Write("Enter Product Price: ");
        product.Price = int.Parse(Console.ReadLine());

        var result = _productService.AddToList(product);

        switch (result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nProduct was created successfully.");
                break;

            case ResultStatus.Exists:
                Console.WriteLine("\nProduct with the same name already exists.");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while creating the product.");
                break;
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    public void ViewAllProducts()
    {
        var productList = _productService.GetAllProducts();

        Console.Clear();
        Console.WriteLine("View All Products\n");

        if (productList.Any())
        {
            foreach (Product product in productList)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Id: {product.Id}\n");
            }
        }
        else
        {
            Console.WriteLine("No products in the list\n");
        }

        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }

    public void SaveToFile()
    {
        var result = _productService.SaveProductsToFile();

        switch (result)
        {
            case ResultStatus.Success:
                Console.WriteLine("\nProduct was saved successfully.");
                break;

            case ResultStatus.FileNotFound:
                Console.WriteLine("\nFile was not found");
                break;

            case ResultStatus.Failed:
                Console.WriteLine("\nSomething went wrong while saving the product.");
                break;
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadKey();
    }
    public void GetFromFile()
    {
        var list = _productService.GetFromFile();

        if (list.Any())
        {
            foreach (Product product in list)
            {
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Id: {product.Id}\n");
            }
        }
        else
        {
            Console.WriteLine("No products in the list\n");
        }

        Console.ReadKey();
    }

}

