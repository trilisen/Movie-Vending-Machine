using System;
using System.Threading;

namespace Vending_Machine
{
    public class VendingMachine
    {
        public Storage storage = new();

        private Card card = new();

        private BankAccount bankAccount = new();
        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Movierev");
                Console.ResetColor();
                Console.WriteLine("budget movie vending machine");
                Console.WriteLine();
                Console.WriteLine("Choose your options:");
                Console.WriteLine("--------------------");
                Console.WriteLine("1.    Display inventory");
                Console.WriteLine("2.    Check the balance of your card");
                Console.WriteLine("3.    Withdraw from ATM");
                Console.WriteLine("Exit. Walk away");
                Console.WriteLine();
                Console.Write("Please input your option: ");
                var input = Console.ReadLine();
                input = input.ToUpper();
                if (HandleInput(input))
                {
                    break;
                }
            }

        }

        public bool HandleInput(string input)
        {
            switch (input)
            {
                case "1" :
                    DisplayInventory();
                    return false;
                case "2":
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"Your account balance is: {card.AccountBalance()}");
                        Console.Write("Press B to go back: ");
                        if (Console.ReadKey().Key == ConsoleKey.B)
                        {
                            return false;
                        }
                    }
                case "3":
                    Console.Clear();
                    bankAccount.Start(card);
                    return false;
                case "EXIT":
                    Console.Clear();
                    Console.WriteLine("You walk away slowly, as the vending machine didn't have the movie you were looking for...");
                    return true;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please input a valid number");
                    Console.ResetColor();
                    return false;
            }
        }

        public void DisplayInventory()
        {
            while (true)
            {
                Console.Clear();
                storage.GetAllItems();
                Console.WriteLine("Enter the item you want to purchase, or enter 'B' to go back");
                var itemId = Console.ReadLine();
                if (itemId.ToUpper() == "B")
                {
                    break;
                }
                var item = ValidateItem(itemId);
                if (item == null)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Item doesn't exist");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    continue;
                }
                Console.WriteLine($"Are you sure you want to purchase {item.name}. Y/n");
                var inputLine = Console.ReadLine();
                if (inputLine.ToUpper() != "Y")
                {
                    continue;
                }

                if (!card.WithdrawMoney(item.price))
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You don't have enough money to purchase this product.");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    continue;
                };
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Successfully purchased {item.name}");
                Console.ResetColor();
                item.supply -= 1;
                Thread.Sleep(1500);
                
            }
        }

        public Item ValidateItem(string itemId)
        {
            foreach (var item in storage.inventory)
            {
                if (item.id == itemId)
                {
                    return item;
                }
            }

            return null;
        }
    }
}