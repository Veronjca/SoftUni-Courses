using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            this.employees = new List<Employee>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public string Name { get; set; }
        public int Count => this.employees.Count;

        public void Add(Employee employee)
        {
            if (this.employees.Count < this.Capacity)
            {
                this.employees.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee current = this.employees.FirstOrDefault(e => e.Name == name);
            if (current == null)
            {
                return false;
            }
            this.employees.Remove(current);
            return true;
        }

        public Employee GetOldestEmployee()
            => this.employees.OrderByDescending(e => e.Age).FirstOrDefault();

        public Employee GetEmployee(string name)
            => this.employees.FirstOrDefault(e => e.Name == name);

        public string Report()
        {
            return $"Employees working at Bakery {this.Name}:{Environment.NewLine}{string.Join(Environment.NewLine, this.employees)}";
        }
    }
}
