using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class BillingSubItem
    {
        private double amount;
        private string description;

        public BillingSubItem(double amount, string description)
        {
            this.amount = amount;
            this.description = description;
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public void setDesc(string desc)
        {
            this.description = desc;
        }

        public double getAmount()
        {
            return amount;
        }

        public string getDesc()
        {
            return description; 
        }

        public override string ToString()
        {
            return description + ": $" + amount + "\n";
        }
    }
}
