using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PizzaStore
{

    public class WindowManager
    {
        User? _user;
        Menu _menu;
        List<Pizza> _order;
        public WindowManager(Menu menu)
        {
            _menu = menu;
            Console.WriteLine("Who do you want to login as?");
            _order = new List<Pizza>();
            Login(Console.ReadLine());
            
        }

        private void Login(string username)
        {
            bool exit = false;
            bool login = false; 
            switch (username)
            {
                case "Owner":
                    Console.WriteLine("Type in password please");
                    int i = 3;
                    _user = new Owner("Owner", 10000);
                    while (i > 0)
                    {
                        Console.WriteLine($"You have {i} attempts");
                        if (Console.ReadLine() == "Admin123")
                        {
                            Console.WriteLine("Welcome back, owner");
                            login = true; 
                            break;
                        }
                        else i--;

                    } 
                    if (login)
                    {
                        while (!exit)
                        {
                            Console.WriteLine("What do you want to do next?");
                            Console.WriteLine("Type ATO to order a pizza");
                            if (Console.ReadLine() == "ATO")
                            {
                                Console.WriteLine("Type in some pizza name from the menu to add one to your order");
                                Console.WriteLine(_menu.ToString());
                                string _lookup = Console.ReadLine();
                                _order.Add(_menu.GetPizza(_lookup)); 
                                int _ = CalculateTotalPrice();
                                Console.WriteLine(_);
                            }
                        }
                    } else Login(username);
                    break;
                case "Guest":
                    Console.WriteLine("Welcome to Mamma's Pizzaria");
                    break;
                case "User":
                    Console.WriteLine("Type in username");
                    break;



            }



        }

        private List<Pizza> Order { get; set; }
        private int CalculateTotalPrice()
        {
            int total = 0;
            foreach (var item in _order)
            {
                total += item.Price; 
            }
            total = (int) (total * 1.25); 
            return total + 40;
        }


    }
}
