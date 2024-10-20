namespace MainProject.Menus;

internal class Menu
{
    private readonly ProductMenu _productMenu = new ProductMenu();
    public void MainMenu()
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Clear();
        Console.WriteLine("Main Menu");
        Console.WriteLine("1. Create Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Save Products to file");
        Console.WriteLine("4. Get Products from file");
        Console.Write("\nEnter your choice: ");

        var option = Console.ReadLine();

        switch (option)
        {
            case "1":
                _productMenu.CreateProduct();
                break;

            case "2":
                _productMenu.ViewAllProducts();
                break;

            case "3":
                _productMenu.SaveToFile();
                break;

            case "4":
                _productMenu.GetFromFile();
                break;

            default:
                Console.WriteLine("\nIncorrect choice, please try again by pressing any key.");
                Console.ReadKey();
                break;
        }
    }
}