using System;
using System.Collections.Generic;
using System.Linq;

namespace Vending_Machine
{
    public class Storage
    {
        public List<Item> inventory { get; }= new();

        public Storage()
        {
            inventory.Add(new Item("1", "In America", 42, 1));
            inventory.Add(new Item("2", "Jeremiah Johnson", 46, 26));
            inventory.Add(new Item("3", "Shopping", 73, 21));
            inventory.Add(new Item("4", "Baghead", 46, 65));
            inventory.Add(new Item("5", "Sunes Sommar", 62, 62));
        }

        public void GetAllItems()
        {
            Console.WriteLine("Items in stock");
            Console.WriteLine("--------------");

            foreach (var item in inventory.ToList())
            {
                if (item.supply == 0)
                {
                    inventory.Remove(item);
                    continue;
                }
                Console.WriteLine($"{item.id}. ${item.price}, {item.name} Remaining: {item.supply}");
            }
            
            Console.WriteLine();
        }
    }
}