using System.Runtime.InteropServices;

namespace Assignment2
{
    internal class Driver
    {
        static void Main(string[] args)
        {
            //Bill instantiation
            Bill billy = new Bill();
            bool exited = false;
            while(!exited)
            {
                

                //Copy of 'items' list from the Bill class. Updated after every change to the original list

                List<BillingItem> newList = billy.getList();

                //Copy of 'subitems' list from the BillingItem class. Updated after every change to a subitem
                List<BillingSubItem> newSubList;

                int choice;
                Console.Write("1. Add Item\n2. Remove Item\n3. Add subitem\n4. Remove subitem\n5. See Tax\n" +
                    "6. Set Tax\n7. Preview Bill\n8. Finish\nSelect Option: ");
                choice = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        //Prompts the user for input information as they create the new BillingItem
                        Console.Write("The item's description: ");
                        string desc = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("The item's amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();

                        BillingItem added = new BillingItem(amount, desc);

                        //Adds the item
                        billy.addItem(added);
                        
                        //Updates copy list
                        newList = billy.getList();
                        break;

                    case 2:
                        
                        //Variable for the item indexes the user inputs
                        int index;

                        //Displays current items if they are available. Otherwise prints an error
                        if (newList.Count() > 0)
                        {
                            Console.Write(billy.seeItems());

                            //Prompts the user to choose which object they want to remove
                            Console.WriteLine();
                            Console.Write("Which item?: ");
                            index = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine();

                            //Checks if that index exists, otherwise prints an error
                            if (index < newList.Count() & index>=0)
                            {
                                billy.removeItem(newList[index]);
                            }
                            else
                            {
                                Console.WriteLine("Error. No item exists at that index");
                                Console.WriteLine();
                            }
                        }
                        

                        else
                        {
                            Console.WriteLine("Error. No items available");
                            Console.WriteLine();
                        }

                        newList = billy.getList();
                        break;       

                    case 3:

                        int addDex;

                        //Same as case 2 until adding subitems
                        if (newList.Count() > 0)
                        {
                            Console.Write(billy.seeItems());

                            //Prompts the user to choose which item they want subitems for
                            Console.WriteLine();
                            Console.Write("Which item?: ");
                            addDex = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine();

                            //Checks if that item exists to add subitems for
                            if (addDex < newList.Count() & addDex >= 0)
                            {
                                //Prompts the user for input information as they create the new BillingSubItem
                                Console.Write("The subitem's description: ");
                                string subDesc = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("The subitem's amount: ");
                                double subAmount = Convert.ToDouble(Console.ReadLine());
                                Console.WriteLine();

                                BillingSubItem subAdded = new BillingSubItem(subAmount, subDesc);

                                //Minus one because the menu starts at 1 instead of it's actual index of 0. Adds the subitem to the billingitem
                                newList[addDex].addSubItem(subAdded);

                                //Modifies the original list
                                billy.modList(newList);
                            }

                            else
                            {
                                Console.WriteLine("Error. No item exists at that index");
                                Console.WriteLine();
                            }
                        }

                        else
                        {
                            Console.WriteLine("Error. No items available");
                            Console.WriteLine();

                        }
                        newList = billy.getList();
                        

                        break;

                    case 4:

                        //Choice index
                        int removeDex;
                        int removeSubDex;

                       
                        //Same as case 3 until removing subitems
                        if (newList.Count() > 0)
                        {

                            Console.Write(billy.seeItems());

                            //Prompts the user to choose which item they want to remove subitems from
                            Console.WriteLine();
                            Console.Write("Which item?: ");
                            removeDex = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine();

                            //Checks if the item at that input exists, if so, shows a list of all available subitems. Otherwise, prints error

                            if (removeDex < newList.Count() & removeDex >= 0)
                            {
                                //Updates newSubList for writing convenience
                                newSubList = newList[removeDex].getSubList();

                                //Displays subitems if available

                                Console.WriteLine(newList[removeDex].seeSubItems());

                                //Prompts the user for which subitem to remove
                                Console.Write("Which subitem?: ");
                                removeSubDex = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine();

                                if (removeSubDex < newList.Count() & removeSubDex >= 0)
                                {
                                    newList[removeDex].removeSubItem(newSubList[removeSubDex]);

                                    //Updating all lists
                                    billy.modList(newList);
                                    newSubList = newList[removeDex].getSubList();
                                    newList = billy.getList();
                                }

                                else
                                {
                                    Console.WriteLine("Error. No subitems available at that index");
                                    Console.WriteLine();
                                }

                                

                            }
                            else
                            {
                                Console.WriteLine("Error. No items available at that index");
                                Console.WriteLine();
                            }
                        }
                       
                        else
                        {
                            Console.WriteLine("Error. No items available");
                            Console.WriteLine();
                            newList = billy.getList();
                        }

                        break;
       

                    case 5:
                        //Gives the user the tax's current percentage
                        Console.WriteLine("Current tax is: " + Bill.getTax());
                        Console.WriteLine();
                        break;

                    case 6:

                        //Prompts the user for the new tax before setting it to their input
                        Console.Write("Enter the new tax: ");
                        double newTax = Convert.ToDouble(Console.ReadLine());
                        Bill.setTax(newTax);
                        Console.WriteLine();

                        newList = billy.getList();
                        break;

                    case 7:
                        //Prints out the current bill
                        Console.Write("------------------------");
                        Console.WriteLine(billy.ToString());
                        Console.Write("------------------------");
                        break;

                    case 8:
                        //Prints out the current bill, asks them if they want to make a new bill, and then loops or closes conditionally
                        int input;

                        Console.WriteLine("------------------------");
                        Console.WriteLine(billy.ToString());
                        Console.WriteLine("------------------------");
                        Console.Write("Another bill? (0 for no. Any other integer input for yes): ");
                        input = Convert.ToInt16(Console.ReadLine());
                        
                        
                        if (input == 0)
                        {
                            exited = true;
                            break;
                        }
                        Console.WriteLine();
                        //Bill instantiation
                        billy = new Bill();
                        break;
                }
            }
        }
    }
}
