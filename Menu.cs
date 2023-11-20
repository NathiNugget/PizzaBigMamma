using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Menu
    {
        List<Pizza> _pizzaList; 

        public Menu()
        {
            _pizzaList =
            [
                new Pizza("Margeritha", "Cheese and tomatoes", 45),
                new Pizza("Vegan", "Cringe pizza for those not able to eat like a true viking", 45),
                new Pizza("Meat Lover", "Bacon, Ham and Pepperoni", 65)
            ];
        }

        public List<Pizza> PizzaList { get { return _pizzaList; } set { _pizzaList = value; } }
        
        public Pizza? GetPizza(string name)
        {
            foreach (Pizza p in _pizzaList)
            {
                if(p.Name == name) return p;
            }
            return null;
        }

        public int GetIndex(string name)
        {
            foreach (Pizza p in _pizzaList)
            {
                if (p.Name == name)
                {
                    return _pizzaList.IndexOf(p); 
                }
            }
            return -1; 
        }

        public void AddTopping(string name, Pizza p) {
            p.ToppingList.Add(new Topping(name));
        }

        public override string ToString()
        {
            string _toPrint = "";
            int i = 1; 
            foreach (var item in _pizzaList)
            {
                _toPrint += $"#{i} {item.ToString()} \n"; 
            }
            return _toPrint ?? "There are no pizzas on the menu today :(";
        }
    }
}
