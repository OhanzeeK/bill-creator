using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    public class Bill
    {
        private List<BillingItem> items;
        private static int nextID = 0;
        private int id;
        private static double taxPercentage = 0.0;

        public Bill()
        {
            items = new List<BillingItem>();
            id = nextID;
            nextID++;
        }

        public static void setTax(double newTax)
        {
            if(newTax >= 0)
            {
                taxPercentage = newTax;
            }
        }

        public static double getTax()
        {
            return taxPercentage;
        }

        public void addItem(BillingItem item)
        {
            items.Add(item);
        }

        public void removeItem(BillingItem item)
        {
            items.Remove(item);
        }

        public BillingItem getItem(int index)
        {
            if (index < items.Count())
            {
                return items[index];
            }
            return null;
        }

        public int getID()
        {
            return id;
        }

        
        public string seeItems()
        {
            string output = "";
            if (items.Count() > 0)
            {
                for (int i = 0; i < items.Count(); i++)
                {
                    output += i + ". " + items[i].getDesc() + ": $" + items[i].getAmount() + "\n";
                }
            }
            return output;

        }

        public double calculateSubTotal()
        {
            double total = 0;
            for (int i = 0; i < items.Count(); i++)
            {
                total += items[i].getAmount();
            }

            return total;
        }

        public double calculateTotal()
        {
            double subTotal = calculateSubTotal();
            return subTotal * ((taxPercentage / 100)+1);
        }

        public override string ToString()
        {
            string output = "";
            output += "#" + this.getID() + "\n";

            for (int i = 0; i < items.Count(); i++)
            {
                output += items[i].ToString();
            }

            output += "Subtotal: $" + this.calculateSubTotal() + "\nTotal + Tax: $" +  this.calculateTotal() + "\n";
            return output;

        }


        //Returns the list of subitems to make accesing list properties (like sizes or indexes) easier
        public List<BillingItem> getList()
        {
            return items;
        }

        //Modifies the BillingItem List after changes have been made to references of it
        public void modList(List<BillingItem> bills)
        {
            items = bills;
        }


    }
}
