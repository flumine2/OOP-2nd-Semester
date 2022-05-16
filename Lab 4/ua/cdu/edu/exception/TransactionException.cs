using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4.ua.cdu.edu.exception
{
    public class TransactionException : InvalidOperationException
    {
        public TransactionException(string message) : base(message)
        {
        }
    }
}
