using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public abstract class User
    {
        
        protected string _name;
        protected int _balance;
    
        public User(string name, int balance)
        {
            _name = name;
            _balance = balance;
        }

        public string Name { get { return _name; } }
        public int Balance { get { return _balance; } set { _balance = value; } }

        public override string ToString()
        {
            return "Name: _name _balance"; 
        }
    }
}
