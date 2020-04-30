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
            repo.ReadList("musor.txt");
            //2.
            repo.GroupByRadio();
            //3
            repo.ClaptonTime();
            //4
            repo.Omega();
            //5
            repo.SearchSms();
            //6

        }
    }
}

/*
Console.WriteLine("\n Tracks from list: \n" + "Radio - Min - Sec - Name \n");
                repo.TrackList.ForEach(track => {
                    Console.WriteLine(track.Rad + " - " + track.Min + " - " + track.Sec + " - " + track.Name);
                });
*/
