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
                new Pizza("Margherita", "Tomato & cheese", 69),
                new Pizza("Vesuvivo", "Tomato, cheese % ham", 75),
                new Pizza("Cappriciossa", "Tomto, cheese, ham & mushrooms", 80),
                new Pizza("Calzone", "Baked pizza with tomato, cheese, ham & mushrooms", 80),
                new Pizza("Quattro Stagioni", "Tomto, cheese, ham mushrooms, shrimp & peppers", 85),
                new Pizza("Marinara", "Tomato, cheese, shrimp, mussels & garlic", 85),
                new Pizza("Vegetarian", "Tomato, cheese & vegetables", 80),
                new Pizza("Italiana", "Tomato, cheese, onion & meat sauce", 75),
                new Pizza("Gorgonzola", "Tomato, gorgonzola, onion, & mushrooms", 85),
                new Pizza("Contadina", "Tomto, cheese, mushrooms & olives", 75),
                new Pizza("Naples", "Tomato, cheese, ham, mushrooms, pepper, garlic & cheese", 80),
                new Pizza("Vihinga", "Tomato, cheese, ham, mushrooms, peppers, garlic & chili (strong)", 80),
                new Pizza("Calzone Special", "(Not baked) tomato, cheese, shrimp, ham & meat sauce", 80),
                new Pizza("Esotica", "Tomato, cheese, ham, shrimp & pineapple", 80),
                new Pizza("Tonno", "Tomato, cheese, tuna & shrimp", 80),
                new Pizza("Sardegna", "Tomato, cheese, cocktail sausages, bacon, onions & eggs", 80),
                new Pizza("Romana", "Tomato, cheese, ham, bacon & onions", 78),
                new Pizza("Sole", "Tomato, cheese, ham, bacon & eggs", 78),
                new Pizza("Big Mamma", "Tomato, gorgonzola, shrimp, asparagus, and parma ham", 90),
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
                else if(int.TryParse(name, out int index))
                {
                    return _pizzaList[index-1];
                }
            }
            return null;
        }

        public int GetIndex(string name)
        {
            foreach (Pizza p in _pizzaList)
            {
                if (p.Name == name || p.Name.ToUpper() == name.ToUpper())
                {
                    return _pizzaList.IndexOf(p); 
                }
            }
            return -1; 
        }

        public void ChangeDescription(string name, string newDesc)
        {
            GetPizza(name).Description = newDesc;
        }

        public void AddTopping(string name, Pizza p) {
            p.ToppingList.Add(new Topping(name));
            p.Price += 5; 
        }

        public override string ToString()
        {
            string _toPrint = "";
            foreach (var item in _pizzaList)
            {
                _toPrint += $"#{_pizzaList.IndexOf(item)+1} {item.ToString()} \n";
                
            }
            return _toPrint ?? "There are no pizzas on the menu today :(";
        }

        public void AddPizza(string name, string description, int price)
        {
            _pizzaList.Add(new Pizza(name, description, price));
        }

    }
}
