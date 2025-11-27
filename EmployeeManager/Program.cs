using EmployeeManager.Models;
using EmployeeManager.Services;

EmployeeServices empService = new();
string filePath = "Data/employees.json";
empService.LoadFromFile(filePath);

while (true)
{
    Console.WriteLine("\nEmployee Management System");
    Console.WriteLine("1. Add Employee");
    Console.WriteLine("2. View All Employees");
    Console.WriteLine("3. Update Employee");
    Console.WriteLine("4. Delete Employee");
    Console.WriteLine("5. Save & Exit");
    Console.Write("Choose an option: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Employee newEmp = new();
            Console.Write("Enter Id: ");
            newEmp.Id = int.Parse(Console.ReadLine()!);
            Console.Write("Enter Name: ");
            newEmp.Name = Console.ReadLine()!;
            Console.Write("Enter Department: ");
            newEmp.Department = Console.ReadLine()!;
            Console.Write("Enter Salary: ");
            newEmp.Salary = double.Parse(Console.ReadLine()!);
            empService.AddEmployee(newEmp);
            break;
        case "2":
            var employees = empService.GetAllEmployees();
            foreach (var emp in employees)
            {
                Console.WriteLine($"Id: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
            break;
        case "3":
            Console.Write("Enter Id of employee to update: ");
            int updateId = int.Parse(Console.ReadLine()!);
            var empToUpdate = empService.GetEmployeeById(updateId);
            if (empToUpdate != null)
            {
                Console.Write("Enter New Name: ");
                empToUpdate.Name = Console.ReadLine()!;
                Console.Write("Enter New Department: ");
                empToUpdate.Department = Console.ReadLine()!;
                Console.Write("Enter New Salary: ");
                empToUpdate.Salary = double.Parse(Console.ReadLine()!);
                empService.UpdateEmployee(empToUpdate);
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
            break;
        case "4":
            Console.Write("Enter Id of employee to delete: ");
            int deleteId = int.Parse(Console.ReadLine()!);
            empService.DeleteEmployee(deleteId);
            break;
        case "5":
            empService.SaveToFile(filePath);
            Console.WriteLine("\nData saved. Exiting...");
            return;
        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
}
