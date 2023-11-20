using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Topping
    {
        string _name; 
        public Topping(string name) { 
            _name = name;
        }
        public string Name { get { return _name;} }

        public override string ToString()
        {
            return _name;
        }
    }
}
