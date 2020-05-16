using System;
using System.Globalization;
using Account.Entities;
using Account.Entities.Exceptions;

namespace Account
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                BankAccount conta = new BankAccount(number, holder, initialBalance, withdrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double withdraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                conta.Withdraw(withdraw);
                Console.WriteLine("New balance: " + conta.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Format Error: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception: " + e.Message);
            }

        }
    }
}
