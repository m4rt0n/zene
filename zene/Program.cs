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

            repo.ReadList("musor.txt");

            
                Console.WriteLine("\n Tracks from list: \n" + "Radio - Name - Min - Sec \n");
                repo.TrackList.ForEach(track => {
                    Console.WriteLine(track.Rad + " - " + track.Name + " - " + track.Min + " - " + track.Sec);
                });
            



        }
    }
}

/*

*/
