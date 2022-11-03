using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async.DeadLockTests
{
    internal class Account
    {
        double _balance;
        int _id;

        public Account(int id, double balance)
        {
            this._id = id;
            this._balance = balance;
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public void Withdraw(double amount)
        {
            _balance -= amount;
        }

        public void Deposit(double amount)
        {
            _balance += amount;
        }
    }
}
