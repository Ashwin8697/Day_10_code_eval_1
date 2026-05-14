using SecureUserManagement.Services;

UserService userService = new UserService();

while (true)
{
    Console.WriteLine("\n===== Secure User Management =====");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Exit");
    Console.Write("Choose option: ");

    string? choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine() ?? "";

        Console.Write("Enter password: ");
        string password = Console.ReadLine() ?? "";

        Console.Write("Enter sensitive details: ");
        string details = Console.ReadLine() ?? "";

        bool result = userService.Register(username, password, details);

        Console.WriteLine(result ? "Registration successful." : "Registration failed.");
    }
    else if (choice == "2")
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine() ?? "";

        Console.Write("Enter password: ");
        string password = Console.ReadLine() ?? "";

        bool result = userService.Authenticate(username, password);

        Console.WriteLine(result ? "Login successful." : "Login failed.");
    }
    else if (choice == "3")
    {
        Console.WriteLine("Application closed.");
        break;
    }
    else
    {
        Console.WriteLine("Invalid option.");
    }
}