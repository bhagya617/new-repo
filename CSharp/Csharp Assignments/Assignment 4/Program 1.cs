using System;

namespace Programs
{
    
    public class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    
    public interface IAccount
    {
        void Deposit(double amount);
        void Withdraw(double amount);
        double GetBalance();
        string AccountDetails();
    }

    public class BankAccount : IAccount
    {
        private double _balance;
        public string AccountHolder { get; private set; }

        public BankAccount(string accountHolder, double initialBalance)
        {
            if (string.IsNullOrEmpty(accountHolder))
                throw new ArgumentException("Account holder name cannot be null or empty.");

            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");

            AccountHolder = accountHolder;
            _balance = initialBalance;
        }

        
        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            try
            {
                
                _balance = checked(_balance + amount);  
                Console.WriteLine($"Deposited {amount}. Current balance: {_balance}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow Error: {ex.Message}");
            }
        }


        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (_balance < amount)
                throw new InsufficientBalanceException("Insufficient balance to complete the withdrawal.");

            try
            {
               
                _balance = checked(_balance - amount);  
                Console.WriteLine($"Withdrew {amount}. Current balance: {_balance}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow Error: {ex.Message}");
            }
        }

        
        public double GetBalance()
        {
            return _balance;
        }

        public string AccountDetails()
        {
            return $"Account Holder: {AccountHolder}, Balance: {_balance}";
        }
    }

    
    public class BankSystem
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the account holder's name:");
                string accountHolder = Console.ReadLine();

                double initialBalance = 0;
                bool validBalance = false;

               
                while (!validBalance)
                {
                    Console.WriteLine("Enter the initial balance:");
                    string balanceInput = Console.ReadLine();

                    if (double.TryParse(balanceInput, out initialBalance) && initialBalance >= 0)
                    {
                        validBalance = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid initial balance (positive number).");
                    }
                }

               
                var account = new BankAccount(accountHolder, initialBalance);
                Console.WriteLine(account.AccountDetails());

                
                Console.WriteLine("Enter amount to deposit:");
                double depositAmount = double.Parse(Console.ReadLine());
                account.Deposit(depositAmount);

                Console.WriteLine("Enter amount to withdraw:");
                double withdrawAmount = double.Parse(Console.ReadLine());
                account.Withdraw(withdrawAmount);

               
                Console.WriteLine("Attempting withdrawal with an excessive amount...");
                account.Withdraw(initialBalance + 100); 


                Console.WriteLine("Attempting deposit with an excessive amount...");
                account.Deposit(double.MaxValue);  
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overflow Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
