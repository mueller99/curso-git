using Projeto_teste.Entities;
using Projeto_teste.Entities.Enums;
using System;
using System.Globalization;

namespace Projeto_teste
{
    class Program
    {

        static void Main(string[] args)
        {
            Worker worker = new Worker();
            Console.Write("Enter department's name: ");
            worker.Department = new Department(Console.ReadLine());
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            worker.Name = Console.ReadLine();
            Console.WriteLine("Level (Junior/MidLevel/Senior): ");

            WorkerLevel wl;
            if (Enum.TryParse(Console.ReadLine(), out wl))
            {
                worker.Level = wl;
            }
            Console.WriteLine("Base Salary: ");
            double salary;
            if (double.TryParse(Console.ReadLine(), out salary))
            {
                worker.BaseSalary = salary;
            }

            Console.WriteLine("How many contracts to this worker? ");
            int contractsNumber;
            if (int.TryParse(Console.ReadLine(), out contractsNumber))
            {
                for (int i = 1; i <= contractsNumber; i++)
                {
                    Console.WriteLine($"Enter #{i} contract data:");
                    HourContract contract = new HourContract();
                    Console.WriteLine("Date (dd/MM/yyyy): ");
                    DateTime date;
                    if (DateTime.TryParse(Console.ReadLine(), out date))
                    {
                        contract.Date = date;
                        Console.WriteLine("Value per hour: ");
                        double value;
                        if (double.TryParse(Console.ReadLine(), out value))
                        {
                            contract.ValuePerHour = value;
                            Console.WriteLine("Duration (hours): ");
                            int hours;
                            if (int.TryParse(Console.ReadLine(), out hours))
                            {
                                contract.Hours = hours;
                                worker.AddContract(contract);
                            }
                        }
                    }
                }
                Console.WriteLine();
                Console.Write("Enter month and year to calculate income (MM/yyyy): ");
                string yearAndMonth = Console.ReadLine();
                int month, year;
                if (int.TryParse(yearAndMonth.Substring(0, 2), out month) && int.TryParse(yearAndMonth.Substring(3), out year))
                {
                    Console.WriteLine($"Name: {worker.Name}");
                    Console.WriteLine($"Department: {worker.Department.Name}");
                    Console.WriteLine($"Income for {yearAndMonth}: R$ {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");
                }
            }
        }
    }
}
