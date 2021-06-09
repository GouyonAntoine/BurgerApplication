using Dal;
using System;

namespace ConsoleAppBurger
{
    class Program
    {
        static void Main(string[] args)
        {
            using (RestoContext context = new RestoContext())
            {
                context.Initialize(true);
            }
        }
    }
}
