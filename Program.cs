using System;
using MenssagerBrokers;

namespace SendEmailService
{
    class Program
    {
        static void Main(string[] args)
        {
            Consumer.ListenCommunication();
        }
    }
}
