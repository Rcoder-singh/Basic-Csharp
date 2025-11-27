using EmployeeManager.Models;
using System.Text.Json;

namespace EmployeeManager.Services
{
    public class EmployeeServices
    {
        private List<Employee> employees = new();
        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
        }
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
        public Employee? GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
        public void DeleteEmployee(int id)
        {
            var emp = GetEmployeeById(id);
            if (emp != null)
            {
                employees.Remove(emp);
            }
        }
        public void UpdateEmployee(Employee updatedEmp)
        {
            var emp = GetEmployeeById(updatedEmp.Id);
            if (emp != null)
            {
                emp.Name = updatedEmp.Name;
                emp.Department = updatedEmp.Department;
                emp.Salary = updatedEmp.Salary;
            }
        }
        public void SaveToFile(string filePath)
        {
            var json = JsonSerializer.Serialize(employees);
            File.WriteAllText(filePath, json);
        }
        public void LoadFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                employees = JsonSerializer.Deserialize<List<Employee>>(json) ?? new List<Employee>();
            }
        }
    }
}