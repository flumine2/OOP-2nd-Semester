using System;

namespace Lab_4.ua.cdu.edu.exception
{
    public class TransactionException : InvalidOperationException
    {
        public TransactionException(string message) : base(message)
        {
        }
    }
}
