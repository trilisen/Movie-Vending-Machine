using System;
using System.Threading;

namespace Vending_Machine
{
    public class BankAccount
    {
        private int balance { get; set; } = 500;
        private Card _card;

        public void Start(Card card)
        {
            while (true)
            {
                this._card = card;
                Console.Clear();
                Console.WriteLine("Welcome to the ATM");
                Console.WriteLine();
                Console.WriteLine($"Your balance is ${balance}.");
                Console.WriteLine("Your options are:");
                Console.WriteLine("1.    Withdraw money");
                Console.WriteLine("2.    Deposit money");
                Console.WriteLine("B.    Go back");
                Console.WriteLine();
            
                Console.Write("Please enter your choice: ");
                var input = Console.ReadLine();
                input = input.ToUpper();
                var result = HandleInput(input);
                if (!result)
                {
                    Thread.Sleep(1500);
                    Console.WriteLine(result);
                    break;
                }
            }
        }

        private bool HandleInput(string input)
        {
            switch (input)
            {
                case "1":
                    WithdrawMoneyFromAtm();
                    return true;
                case "2":
                    DepositMoneyToAtm();
                    return true;
                case "B":
                    Console.Clear();
                    Console.WriteLine("You move your vision to the Vending machine");
                    Thread.Sleep(1500);
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please enter a valid input");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    return true;
            }
        }

        private void WithdrawMoneyFromAtm()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("How much do you want to withdraw? (B to go back)");
                Console.Write("Amount: ");
                var money = Console.ReadLine();
                if (money.ToUpper() == "B")
                {
                    break;
                }
                if (money != null && Int32.TryParse(money, out int result))
                {
                    if (result <= balance)
                    {
                        _card.AddMoney(result);
                        balance -= result;
                        Console.WriteLine($"Succesfully added {money} to your card.");
                        Thread.Sleep(1500);
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You don't have enough money to withdraw that amount");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
                    
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please input a valid number");
                Console.ResetColor();
                Thread.Sleep(1500);
            }
        }

        private void DepositMoneyToAtm()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("How much do you want to deposit? (B to go back)");
                Console.Write("Amount: ");
                var money = Console.ReadLine();
                if (money.ToUpper() == "B")
                {
                    break;
                }
                if (money != null && Int32.TryParse(money, out int result))
                {
                    if (result <= _card.AccountBalance())
                    {
                        _card.WithdrawMoney(result);
                        balance += result;
                        Console.WriteLine($"Succesfully added {money} to your bank balance.");
                        Thread.Sleep(1500);
                        break;
                    }
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You don't have enough money to deposit that amount");
                    Console.ResetColor();
                    Thread.Sleep(1500);
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please input a valid number");
                Console.ResetColor();
                Thread.Sleep(1500);
            }
        }
    }
}