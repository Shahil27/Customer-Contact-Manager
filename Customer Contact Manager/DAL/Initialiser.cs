using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer_Contact_Manager.Models;
using System.Data.Entity;

namespace Customer_Contact_Manager.DAL
{
    public class Initialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var customers = new List<Customer>
            {
            new Customer{Name="Manchester United",Latitude=10,Longitude=-70},
            new Customer{Name="Bayern Munich",Latitude=10,Longitude=-90},
            new Customer{Name="Real Madrid",Latitude=-105,Longitude=50}
            };
            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var customercontacts = new List<CustomerContact>
            {
            new CustomerContact{CustomerID=1,Name="Jose Mourinho",Email="Mourinho@gmail.com",ContactNumber=001},
            new CustomerContact{CustomerID=1,Name="Michael Carrick",Email="Carrick@gmail.com",ContactNumber=002},
            new CustomerContact{CustomerID=2,Name="Carlo Ancelotti",Email="Ancelotti@gmail.com",ContactNumber=003},
            new CustomerContact{CustomerID=2,Name="Thomas Muller",Email="Muller@gmail.com",ContactNumber=004},
            new CustomerContact{CustomerID=3,Name="Zinedine Zidane",Email="Zidane@gmail.com",ContactNumber=005},
            new CustomerContact{CustomerID=3,Name="Sergio Ramos",Email="Ramos@gmail.com",ContactNumber=005}
            };
            customercontacts.ForEach(s => context.CustomerContacts.Add(s));
            context.SaveChanges();
        }
    }
}
