using System;

class Program
{
    static void Main(string[] args)
    {
        // ===== Order 1 (USA Customer) =====
        Address address1 = new Address("123 Main Street", "Rexburg", "ID", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Wireless Mouse", "WM-1001", 25.99, 2));
        order1.AddProduct(new Product("USB-C Hub", "UH-2045", 49.50, 1));
        order1.AddProduct(new Product("Laptop Stand", "LS-3300", 34.99, 1));

        Console.WriteLine("========== ORDER 1 ==========");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // ===== Order 2 (International Customer) =====
        Address address2 = new Address("45 Maple Avenue", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Emily Chen", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Mechanical Keyboard", "MK-7788", 89.99, 1));
        order2.AddProduct(new Product("Noise Cancelling Headphones", "NC-5520", 129.99, 1));

        Console.WriteLine("========== ORDER 2 ==========");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalCost():F2}");
    }
}