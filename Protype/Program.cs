using System;

namespace Protype
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer { FirstName = "Kadir", LastName = "Gültein", City = "Kocaeli", Id = 1};
            Console.WriteLine(customer.FirstName);

            Customer customer1 = (Customer)customer.Clone();
            customer1.City = "Kocaeli";
           
        }
    }


    public abstract class Person
    {
        public abstract Person Clone();
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }

    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }

        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
