using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee kadir = new Employee
            {
                Name = "Kadir Gültekin"
            };
            Employee salih = new Employee
            {
                Name = "Salih Gültekin"
            };

            kadir.AddSubordinate(salih);
            Employee elanur = new Employee
            {
                Name = "Elanur Gültekin"
            };
            kadir.AddSubordinate(elanur);

            Employee ahmet = new Employee
            {
                Name = "Ahmet"
            };
            elanur.AddSubordinate(ahmet);
            Console.WriteLine(kadir.Name);
            foreach (Employee manager in kadir)
            {
                Console.WriteLine(manager.Name);
                foreach (Employee employee in manager)
                {
                    Console.WriteLine(employee.Name);
                }
            }

            Console.ReadLine();
        }
    }


    interface IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get ; set ; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate; 
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
