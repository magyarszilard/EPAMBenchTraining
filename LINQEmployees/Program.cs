using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQEmployees
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new[] {
              new { Name="Andras", Salary=420},
              new { Name="Bela", Salary=400},
              new { Name="Csaba", Salary=250},
              new { Name="David", Salary=300},
              new { Name="Endre", Salary=620},
              new { Name="Ferenc", Salary=350},
              new { Name="Gabor", Salary=410},
              new { Name="Hunor", Salary=500},
              new { Name="Imre", Salary=900},
              new { Name="Janos", Salary=600},
              new { Name="Karoly", Salary=700},
              new { Name="Laszlo", Salary=400},
              new { Name="Marton", Salary=500}
            };

            Console.WriteLine(employees.OrderByDescending(o => o.Salary).Select(s => s.Name).First());
            var lowEarners = employees.Where(a => a.Salary < employees.Average(avg => avg.Salary)).Select(s => s.Name);
            var ordered = employees.OrderBy(o => o.Salary);
            var sameSalary = employees.Where(a => employees.Count(c => c.Salary == a.Salary) > 1).OrderBy(o => o.Salary).ThenBy(o => o.Name).Select(s => s.Name);
            var group = employees.GroupBy(g => g.Salary < 400 ? "200-399" : g.Salary < 600 ? "400-599" : g.Salary < 800 ? "600-799" : "800-999").Select(s=>new
            {
                Range = s.Key,
                Employees = s,
            });
            Console.Read();
        }
    }
}
