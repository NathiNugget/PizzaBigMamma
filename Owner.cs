using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class Owner : User
    {
        bool _isOwner;
        readonly string _password; 
        public Owner(string name, int balance) : base(name, balance) {
            _isOwner = true;
            _password = "Admin123"; 
        }

        public bool IsOwner { get { return _isOwner; } }

        public string Password { get { return _password; } init { _password = value; } }

        public override string ToString()
        {
            return base.ToString() + " and is Owner"; 
        }

    }
}
