using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uk.co.nfocus.ecommerceFinal.Utilities
{
    internal class Customer
    {
        string firstName = Environment.GetEnvironmentVariable("fName");
        string lastName = Environment.GetEnvironmentVariable("lName");
        string billingAddress = Environment.GetEnvironmentVariable("Address");
        string billingCity = Environment.GetEnvironmentVariable("City");
        string billingPostcode = Environment.GetEnvironmentVariable("Postcode");
        string billingPhone = Environment.GetEnvironmentVariable("PhoneNumber");
        string billingEmail = Environment.GetEnvironmentVariable("Email");

        public string getFirstName()
        {
            return firstName;
        }
        public string getLastName()
        {
            return lastName;
        }
        public string getBillingAddress()
        {
            return billingAddress;
        }
        public string getBillingCity()
        {
            return billingCity;
        }
        public string getBillingPostcode()
        {
            return billingPostcode;
        }
        public string getBillingPhone()
        {
            return billingPhone;
        }
        public string getBillingEmail()
        {
            return billingEmail;
        }

    }
}
