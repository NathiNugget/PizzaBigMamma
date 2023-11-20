using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Pizza
    {
        string _name;
        string _description;
        int _price; 
        List<Topping> _toppingList;
        public Pizza(string name, string description, int price) {
            _name = name;
            _description = description;
            _price = price;
            _toppingList = new List<Topping>();
        }

        public int Price { get { return _price; } set { _price = value; } }
        public string Name { get { return _name; } }
        public List<Topping> ToppingList { get { return _toppingList; } set { _toppingList = value;} }

        public override string ToString()
        {
            int _toppingPrice = 0;
            foreach (var item in _toppingList)
            {
                _toppingPrice += 5; 
            }
            return $"Name: {_name} Description: {_description} Price: {_price} + topping: {_toppingPrice}"; 
        }
    }
}
