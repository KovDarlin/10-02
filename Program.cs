using System;
using System.Collections.Generic;

public record Item(string Name, double Volume);

class Backpack
{
    public string Color { get; set; }
    public string Brand { get; set; }
    public string Fabric { get; set; }
    public double Weight { get; set; }
    public double Capacity { get; set; }
    public List<Item> Contents { get; set; } = new();

    public event Action<Item> ItemAdded;
    public event Action<Item> ItemRemoved;
    public event Action<Item> ItemChanged;

    private double currentVolume = 0;

    public void AddItem(Item item)
    {
        if (currentVolume + item.Volume > Capacity)
            throw new InvalidOperationException("Too much for backpack!");

        Contents.Add(item);
        currentVolume += item.Volume;
        ItemAdded?.Invoke(item);
    }

    public void RemoveItem(Item item)
    {
        if (Contents.Remove(item))
        {
            currentVolume -= item.Volume;
            ItemRemoved?.Invoke(item);
        }
    }

    public void ChangeItem(int index, Item newItem)
    {
        if (index < 0 || index >= Contents.Count)
            throw new ArgumentOutOfRangeException("No correct index");

        var oldItem = Contents[index];
        double newVolume = currentVolume - oldItem.Volume + newItem.Volume;

        if (newVolume > Capacity)
            throw new InvalidOperationException("Too much!");

        Contents[index] = newItem;
        currentVolume = newVolume;
        ItemChanged?.Invoke(newItem);
    }
}

class Program
{
    static void Main()
    {
        var backpack = new Backpack
        {
            Color = "Black",
            Brand = "Adidas",
            Fabric = "Plastic",
            Weight = 1.5,
            Capacity = 15
        };

        backpack.ItemAdded += delegate (Item item)
        {
            Console.WriteLine($"Added: {item.Name}, Amount: {item.Volume}");
        };

        backpack.ItemRemoved += delegate (Item item)
        {
            Console.WriteLine($"Deleted: {item.Name}");
        };

        backpack.ItemChanged += delegate (Item item)
        {
            Console.WriteLine($"Changed to: {item.Name}, Amount: {item.Volume}");
        };

        try
        {
            var copybook = new Item("copybook", 3);
            var book = new Item("book", 1.5);
            var pen = new Item("pen", 0.2);

            backpack.AddItem(copybook);
            backpack.AddItem(book);
            backpack.AddItem(pen); 
        }
        catch (Exception problem)
        {
            Console.WriteLine($"Error: {problem.Message}");
        }
    }
}
