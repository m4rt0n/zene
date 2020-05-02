using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace zene
{

    class Program
    {

        static void Main(string[] args)
        {
            Repo repo = new Repo();

            //1.
            Console.WriteLine("1. feladat:");
            repo.ReadList("musor.txt");

            //2.
            Console.WriteLine("2. feladat:");
            repo.GroupByRadio();

            //3
            Console.WriteLine("3. feladat:");
            repo.ClaptonTime("Eric Clapton");

            //4
            Console.WriteLine("4. feladat:");
            repo.Omega("Omega:Legenda");

            //5
            Console.WriteLine("5. feladat:");
            Console.Write("Irja be a keresett szoveget: ");
            string sms = Console.ReadLine();           
            repo.SearchSms(sms);
            
            //6
            Console.WriteLine("6. feladat:");
            repo.Change();
        }
    }
}
