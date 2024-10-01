using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Assignment2
{
    public class BillingItem
    {
        private List<BillingSubItem> subitems;
        private double amount;
        private string description;
        
        public BillingItem()
        {
            subitems = new List<BillingSubItem>();
            amount = 0.0;
            description = "";
        }

        public BillingItem(double amount, string description)
        {
            subitems = new List<BillingSubItem>();
            this.amount = amount;
            this.description = description;
        }

        public double getAmount()
        {
            double total = 0;
            if(subitems.Count()>0)
            {
                for (int i = 0; i < subitems.Count(); i++)
                {
                    total += subitems[i].getAmount();
                }
                return total;
            }
            else
            {
                return amount;
            }       
        }

        public void setAmount(double amount)
        {
            this.amount = amount;
        }

        public void addSubItem(BillingSubItem item)
        {
            subitems.Add(item);
        }

        public void removeSubItem(BillingSubItem item)
        {
            subitems.Remove(item);
        }

        public BillingSubItem getSubItem(int index)
        {
            if (index < subitems.Count())
            {
                return subitems[index];
            }
            return null;
        }


        public string seeSubItems()
        {
            string output = "";
            if (subitems.Count() > 0)
            {
                for (int i = 0; i < subitems.Count(); i++)
                {
                    output += i + ". " + subitems[i].getDesc() + ": $" + subitems[i].getAmount() + "\n";
                }
            }
            return output;
        }

        public string getDesc()
        {
            return description;
        }

        public void setDesc(string description)
        {
            this.description = description;
        }

        public override string ToString()
        {
            string output = description + ": $" + this.getAmount() +  "\n";
            
            if (subitems.Count() > 0)
            {
                for (int i = 0; i < subitems.Count(); i++)
                {
                    output += "\t" + subitems[i].ToString();
                }
            }

            Console.WriteLine();

            return output;
        }

        public List<BillingSubItem> getSubList()
        {
            return subitems;
        }
    }
}
