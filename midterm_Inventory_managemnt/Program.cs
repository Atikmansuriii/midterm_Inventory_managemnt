using System;

public class InventoryItem
{
    // Properties to store item details
    public string ItemName { get; set; }
    public int ItemId { get; set; }
    public double Price { get; set; }
    public int QuantityInStock { get; set; }

    // Constructor to initialize the properties with the values provided
    public InventoryItem(string itemName, int itemId, double price, int quantityInStock)
    {
        ItemName = itemName;
        ItemId = itemId;
        Price = price;
        QuantityInStock = quantityInStock;
    }

    // Method to update the price of the item
    public void UpdatePrice(double newPrice)
    {
        Price = newPrice;
    }

    // Method to restock the item by adding additional quantity
    public void RestockItem(int additionalQuantity)
    {
        QuantityInStock += additionalQuantity;
    }

    // Method to sell an item, reducing the stock quantity
    public void SellItem(int quantitySold)
    {
        if (quantitySold <= QuantityInStock)
        {
            QuantityInStock -= quantitySold;
        }
        else
        {
            Console.WriteLine("Not enough stock to sell the requested quantity.");
        }
    }

    // Method to check if the item is currently in stock
    public bool IsInStock()
    {
        return QuantityInStock > 0;
    }

    // Method to print the details of the item
    public void PrintDetails()
    {
        Console.WriteLine($"Item Name: {ItemName}, Item ID: {ItemId}, Price: ${Price:F2}, Quantity in Stock: {QuantityInStock}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances of InventoryItem for different products
        InventoryItem item1 = new InventoryItem("Laptop", 101, 1200.50, 5);
        InventoryItem item2 = new InventoryItem("Smartphone", 102, 800.30, 12);
        InventoryItem item3 = new InventoryItem("TV", 103, 1500.00, 4);
        InventoryItem item4 = new InventoryItem("AC", 104, 500.75, 18);
        InventoryItem item5 = new InventoryItem("Room Heater", 105, 300.40, 7);

        // Array to store all items for easy access
        InventoryItem[] items = { item1, item2, item3, item4, item5 };

        bool running = true;
        while (running)
        {
            // Display menu options for the user with fancy separation
            Console.WriteLine("\n╔═════════════════════════════════════════╗");
            Console.WriteLine("║        Inventory Management System       ║");
            Console.WriteLine("╠═════════════════════════════════════════╣");
            Console.WriteLine("║ 1. View Item Details                     ║");
            Console.WriteLine("║ 2. Buy Item                              ║");
            Console.WriteLine("║ 3. Restock Item                          ║");
            Console.WriteLine("║ 4. Update Item Price                     ║");
            Console.WriteLine("║ 5. Check Stock Status                    ║");
            Console.WriteLine("║ 6. Exit                                  ║");
            Console.WriteLine("╚═════════════════════════════════════════╝");
            Console.Write("Select an option: ");

            // Read user input and handle invalid inputs
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("════════════════════════════════════════════");
                switch (choice)
                {
                    case 1:
                        // Display details of all items
                        Console.WriteLine("\nItem Details:");
                        foreach (var item in items)
                        {
                            item.PrintDetails();
                        }
                        break;
                    case 2:
                        // Handle buying an item
                        Console.Write("Enter Item ID to buy: ");
                        int buyId;
                        if (int.TryParse(Console.ReadLine(), out buyId))
                        {
                            Console.Write("Enter quantity to buy: ");
                            int buyQuantity;
                            if (int.TryParse(Console.ReadLine(), out buyQuantity))
                            {
                                InventoryItem itemToBuy = Array.Find(items, item => item.ItemId == buyId);
                                if (itemToBuy != null)
                                {
                                    itemToBuy.SellItem(buyQuantity);
                                    Console.WriteLine($"Bought {buyQuantity} units of {itemToBuy.ItemName}.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Item ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Item ID.");
                        }
                        break;
                    case 3:
                        // Handle restocking an item
                        Console.Write("Enter Item ID to restock: ");
                        int restockId;
                        if (int.TryParse(Console.ReadLine(), out restockId))
                        {
                            Console.Write("Enter quantity to restock: ");
                            int restockQuantity;
                            if (int.TryParse(Console.ReadLine(), out restockQuantity))
                            {
                                InventoryItem itemToRestock = Array.Find(items, item => item.ItemId == restockId);
                                if (itemToRestock != null)
                                {
                                    itemToRestock.RestockItem(restockQuantity);
                                    Console.WriteLine($"Restocked {restockQuantity} units of {itemToRestock.ItemName}.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Item ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid quantity.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Item ID.");
                        }
                        break;
                    case 4:
                        // Handle updating the price of an item
                        Console.Write("Enter Item ID to update price: ");
                        int priceId;
                        if (int.TryParse(Console.ReadLine(), out priceId))
                        {
                            Console.Write("Enter new price: ");
                            double newPrice;
                            if (double.TryParse(Console.ReadLine(), out newPrice))
                            {
                                InventoryItem itemToUpdate = Array.Find(items, item => item.ItemId == priceId);
                                if (itemToUpdate != null)
                                {
                                    itemToUpdate.UpdatePrice(newPrice);
                                    Console.WriteLine($"Updated price of {itemToUpdate.ItemName} to ${newPrice:F2}.");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Item ID.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid price.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Item ID.");
                        }
                        break;
                    case 5:
                        // Display stock status of all items
                        Console.WriteLine("\nStock Status:");
                        foreach (var item in items)
                        {
                            Console.WriteLine($"{item.ItemName} - Quantity: {item.QuantityInStock}");
                        }
                        break;
                    case 6:
                        // Exit the application
                        running = false;
                        break;
                    default:
                        // Handle invalid menu option
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            Console.WriteLine("════════════════════════════════════════════");
        }
        // Display farewell message when exiting the application
        Console.WriteLine("Exiting the application. Goodbye!");
    }
}

