using System;

class Accounts
{
    
    private string accountNo;
    private string customerName;
    private string accountType;
    private double balance;

    public Accounts(string accountNumber, string customer, string accType)
    {
        accountNo = accountNumber;   
        customerName = customer;     
        accountType = accType;
        balance = 0;  
    }


    public void Credit(int amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount}. Updated Balance: {balance}");
    }

  
    public void Debit(int amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrew {amount}. Updated Balance: {balance}");
        }
        else
        {
            Console.WriteLine("Insufficient balance for withdrawal.");
        }
    }


    public void ShowData()
    {
        Console.WriteLine("\nAccount Details:");
        Console.WriteLine($"Account Number: {accountNo}");
        Console.WriteLine($"Customer Name: {customerName}");
        Console.WriteLine($"Account Type: {accountType}");
        Console.WriteLine($"Balance: {balance}");
    }

    public void UpdateBalance(string transactionType, int amount)
    {
        if (transactionType.ToUpper() == "D")
        {
            Credit(amount); // Deposit
        }
        else if (transactionType.ToUpper() == "W")
        {
            Debit(amount); // Withdrawal
        }
        else
        {
            Console.WriteLine("Invalid transaction type.");
        }
    }
}

class Program
{
    static void Main()
    {
        
        Console.Write("Enter Account Number: ");
        string accountNo = Console.ReadLine();
        
        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();
        
        Console.Write("Enter Account Type (e.g., Savings, Current): ");
        string accountType = Console.ReadLine();


        Accounts account = new Accounts(accountNo, customerName, accountType);

        Console.Write("\nEnter Transaction Type (D for Deposit, W for Withdrawal): ");
        string transactionType = Console.ReadLine();

        Console.Write("Enter Amount: ");
        int amount = int.Parse(Console.ReadLine());

       
        account.UpdateBalance(transactionType, amount);

       
        account.ShowData();
    }
}
