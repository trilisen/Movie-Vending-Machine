namespace Vending_Machine
{
    public class Card
    {
        private int balance { get; set; }

        public void AddMoney(int money)
        {
            if (money > 0)
            {
                balance += money;
            }
        }

        public bool WithdrawMoney(int money)
        {
            // If amount to withdraw is less or equal to amount in account
            if (balance >= money)
            {
                balance -= money;
                return true;
            }

            return false;
        }

        public int AccountBalance()
        {
            return balance;
        }
    }
}