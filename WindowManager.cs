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
        List<String> _usernames;
        List<User> _users; 
        public WindowManager(Menu menu)
        {
            _menu = menu;
            _usernames = new List<String>();
            _users = new List<User>();
            LoginFromScratch();
        }

        private void LoginFromScratch()
        {
            Console.WriteLine("Who do you want to login as?");
            Console.WriteLine("You may login as Owner, Guest or User");
            Console.WriteLine("Loyal Customers (User) get 5% discount on orders!");
            
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
                            Console.WriteLine("Type ATT to add topping to some pizza");
                            Console.WriteLine("Type CRUD to manipulate user database");
                            Console.WriteLine("Type CRUD P to manipulate menu card");
                            string _input = Console.ReadLine();
                            switch (_input)
                            {
                                case "ATO":
                                    {
                                        Console.WriteLine("Type in some pizza name from the menu to add one to your order");
                                        Console.WriteLine(_menu.ToString());
                                        string _lookup = Console.ReadLine();
                                        _order.Add(_menu.GetPizza(_lookup));
                                        int _ = CalculateTotalPrice(true);
                                        Console.WriteLine(_ + " DKK");
                                        break;
                                    }

                                case "ATT":
                                    {

                                        Console.WriteLine("Which pizza do you want to add topping to? Type in the name or number without #");
                                        foreach (var item in _order)
                                        {
                                            Console.WriteLine($"{_menu.GetIndex(item.Name) + 1} - {item}");
                                        }
                                        string _lookup = Console.ReadLine();
                                        string _toAdd = Console.ReadLine();
                                        _menu.AddTopping(_toAdd, _menu.GetPizza(_lookup));
                                        break;
                                    }

                                case "ORDER":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Are you sure you want to order now? These items are in your current order!");
                                        foreach (var item in _order)
                                        {
                                            Console.WriteLine(item.ToString());
                                        }
                                        _input = Console.ReadLine();
                                        if (_input == "yes" || _input == "1")
                                        {
                                            Console.WriteLine("Thanks for your order!\nSee ya next time!");
                                        }

                                        break;
                                    }

                                case "CRUD":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Which actions do you want to do?");
                                        Console.WriteLine("C - Create user");
                                        Console.WriteLine("R - Read information about a user");
                                        Console.WriteLine("U - Update a user balance");
                                        Console.WriteLine("D - Delete a user");
                                        string _action = Console.ReadKey().ToString();
                                        switch (_action)
                                        {
                                            case "C":
                                                Console.WriteLine("Type username");
                                                string _usrName = Console.ReadLine();
                                                Console.WriteLine("Type in a balance");
                                                int _balance = 0;
                                                bool _ = int.TryParse(Console.ReadLine(), out _balance);
                                                while (!_)
                                                {
                                                    Console.WriteLine("Type in a balance using only integers!");
                                                    _balance = 0;
                                                    _ = int.TryParse(Console.ReadLine(), out _balance);
                                                }
                                                _user = new User(_usrName, _balance);
                                                _usernames.Add(_usrName);
                                                _users.Add(_user);
                                                break;
                                            case "R":
                                                Console.WriteLine("Type in some username which is in db");
                                                foreach (var item in _usernames)
                                                {
                                                    Console.WriteLine(item, "500DKK");

                                                }
                                                break;
                                            case "D":
                                                break;
                                        }

                                        break;
                                    }
                                case "CRUD P":
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Which actions do you want to do?");
                                        Console.WriteLine("C - Create Pizza");
                                        Console.WriteLine("R - Read information about a Pizza");
                                        Console.WriteLine("U - Update a Pizza description");
                                        Console.WriteLine("D - Delete a user");
                                        string _action = Console.ReadLine(); 
                                        switch (_action)
                                        {
                                            case "C":
                                                Console.WriteLine("Type a Pizza name");
                                                string _pizzaName = Console.ReadLine();
                                                Console.WriteLine("Type in a Pizza Description");
                                                string _pizzaDesc = Console.ReadLine();
                                                int _price; 
                                                bool _ = int.TryParse(Console.ReadLine(), out _price);
                                                while (!_)
                                                {
                                                    Console.WriteLine("Type in a price using only integers!");
                                                    _ = int.TryParse(Console.ReadLine(), out _price);
                                                }
                                             
                                                _menu.AddPizza(_pizzaName, _pizzaDesc, _price);
                                                break;
                                            case "R":
                                                Console.WriteLine("Type in a number for a pizza you want to know info about");
                                                int _num = 0;
                                                _ = int.TryParse(Console.ReadLine(),out _num);
                                                while (!_)
                                                {
                                                    Console.WriteLine("Pizza either doesn't exist in system or you typed in something which is not a number!");
                                                    _num = 0;
                                                    _ = int.TryParse(Console.ReadLine(), out _num);
                                                }
                                                
                                                Console.WriteLine(_menu.GetPizza(_num.ToString()).ToString());
                                                Console.WriteLine("Press any key to continue");
                                                string _continue = Console.ReadKey().ToString();
                                                Console.Clear(); 
                                                break;
                                            case "D":
                                                break;
                                        }

                                        break;
                                    }

                                case "EXIT":
                                    LoginFromScratch();
                                    break;
                            }

                        }
                    } else Login(username);
                    break;
                case "Guest":
                    Console.WriteLine("Welcome to Mamma's Pizzaria");
                    Console.WriteLine("You should go to our physical Pizzaria in order to become a member and have loyalty savings!");
                    Console.WriteLine("Click any key to continue");
                    Console.ReadKey();
                    while (!exit)
                    {
                        Console.WriteLine("What do you want to do next?");
                        Console.WriteLine("Type ATO to order a pizza");
                        Console.WriteLine("Type ATT to add topping to some pizza");
                        string _input = Console.ReadLine();
                        switch (_input)
                        {
                            case "ATO":
                                {
                                    Console.WriteLine("Type in some pizza name from the menu to add one to your order");
                                    Console.WriteLine(_menu.ToString());
                                    string _lookup = Console.ReadLine();
                                    _order.Add(_menu.GetPizza(_lookup));
                                    int _ = CalculateTotalPrice(false);
                                    Console.WriteLine(_ + " DKK");
                                    break;
                                }

                            case "ATT":
                                {

                                    Console.WriteLine("Which pizza do you want to add topping to? Type in the name or number without #");
                                    foreach (var item in _order)
                                    {
                                        Console.WriteLine($"{_menu.GetIndex(item.Name) + 1} - {item}");
                                    }
                                    string _lookup = Console.ReadLine();
                                    string _toAdd = Console.ReadLine();
                                    _menu.AddTopping(_toAdd, _menu.GetPizza(_lookup));
                                    break;
                                }

                            case "ORDER":
                                {
                                    Console.Clear();
                                    Console.WriteLine("Are you sure you want to order now? These items are in your current order!");
                                    foreach (var item in _order)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    _input = Console.ReadLine();
                                    if (_input == "yes" || _input == "1")
                                    {
                                        Console.WriteLine("Thanks for your order!\nSee ya next time!");
                                    }

                                    break;
                                }

                            case "EXIT":
                                LoginFromScratch();
                                break;
                        }

                    }


                    break;
                case "User":
                    Console.WriteLine("Type in username");
                    string _usr = Console.ReadLine();
                    if (_usernames.Contains(_usr))
                    {
                        _user = _users[_usernames.IndexOf(_usr)];
                        Console.WriteLine($"Welcome back {_usr} - press any key to continue!");
                        _ = Console.ReadKey(); 
                        Console.Clear();
                    }
                    else {
                        _user = new User(_usr, 500);
                        _users.Add(_user); 
                        _usernames.Add(_usr);
                    }
                    
                    
                    while (!exit)
                    {
                        Console.WriteLine("What do you want to do next?");
                        Console.WriteLine("Type ATO to order a pizza");
                        Console.WriteLine("Type ATT to add topping to some pizza");
                        string _input = Console.ReadLine();
                        switch (_input)
                        {
                            case "ATO":
                                {
                                    Console.WriteLine("Type in some pizza name from the menu to add one to your order");
                                    Console.WriteLine(_menu.ToString());
                                    string _lookup = Console.ReadLine();
                                    _order.Add(_menu.GetPizza(_lookup));
                                    int _ = CalculateTotalPrice(true);
                                    Console.WriteLine(_ + " DKK");
                                    break;
                                }

                            case "ATT":
                                {

                                    Console.WriteLine("Which pizza do you want to add topping to? Type in the name or number without #");
                                    foreach (var item in _order)
                                    {
                                        Console.WriteLine($"{_menu.GetIndex(item.Name) + 1} - {item}");
                                    }
                                    string _lookup = Console.ReadLine();
                                    string _toAdd = Console.ReadLine();
                                    _menu.AddTopping(_toAdd, _menu.GetPizza(_lookup));
                                    break;
                                }

                            case "ORDER":
                                {
                                    Console.Clear();
                                    Console.WriteLine("Are you sure you want to order now? These items are in your current order!");
                                    foreach (var item in _order)
                                    {
                                        Console.WriteLine(item.ToString());
                                    }
                                    _input = Console.ReadLine();
                                    if (_input == "yes" || _input == "1")
                                    {
                                        Console.WriteLine("Thanks for your order!\nSee ya next time!");
                                    }

                                    break;
                                }

                            case "EXIT":
                                LoginFromScratch();
                                break;
                        }

                    }
                    break;



            }



        }

        private List<Pizza> Order { get; set; }
        private int CalculateTotalPrice(bool isMember)
        {
            int total = 0;
            if (!isMember)
            {
                foreach (var item in _order)
                {
                    total += item.Price;
                }
                total = (int)(total * 1.25);

            }
            else
            {
                foreach (var item in _order)
                {
                    total += item.Price;
                }
                total = (int)(total*0.95 * 1.25);
            }
             
            return total + 40;
        }


    }
}
