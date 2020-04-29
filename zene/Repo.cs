using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace zene
{
   
    public class Repo
    {
        public List<Track> TrackList { get; set; }

        

        //1
        public void ReadList(string readText)
        {
            string[] lines = System.IO.File.ReadAllLines(readText);
            lines = lines.Skip(1).ToArray();
            TrackList = new List<Track>();

            try
            {
                foreach (string line in lines)
                {

                    string[] trackData = new string[4];
                    char[] sep = { ' ' };
                    trackData = line.Split(sep, 4);
                    int Rad = Convert.ToInt32(trackData[0]);
                    int Min = Convert.ToInt32(trackData[1]);
                    int Sec = Convert.ToInt32(trackData[2]);
                    string Name = trackData[3];
                    Track t = new Track(Rad, Min, Sec, Name);
                    TrackList.Add(t);                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} error:", e);
            }
        }
        //2.
        public void GroupByRadio()
        {
            for (int i = 1; i < 4; i++)
            { 
            Console.WriteLine("{0} Radio : {1} tracks", i,
                TrackList.Where(x => x.Rad == i).Count());
            }
        }
        //3
        public void ClaptonTime()
        {   //radio 1
            List<Track> firstList = TrackList.FindAll(x => x.Rad == 1);
           //first and last EC
        var firstClapton = firstList.Find
                (x => x.Name.Contains("Eric Clapton"));             
        var lastClapton= firstList.FindLast(x =>  x.Name.Contains("Eric Clapton"));
            //index first and last EC
            var firstClaptonIndex = firstList.FindIndex
                (i=>i.Name==firstClapton.Name);
            var lastClaptonIndex = firstList.FindIndex
                (i => i.Name == lastClapton.Name);
            // tracks between first and last EC
            var range = firstList.GetRange(firstClaptonIndex, lastClaptonIndex-firstClaptonIndex);
            foreach (Track t in range)
            {
                Console.WriteLine(t.Name);
            }

            Console.WriteLine("first C: {0} \n last C: {1}", firstClapton.Name, lastClapton.Name);

            
            //Console.WriteLine("Time between first & last Clapton Clapton tracks: {0}", );
            
        }

        public void TimeConvert(Track t)
        {           
                var seconds = t.Min * 60 + t.Sec;
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                string str = time.ToString(@"hh\:mm\:ss\:fff");
                Console.WriteLine("duration of {0} : {1}", t.Name, str);                       
        }

        public void groupByRadioToList()
        {

            List<Track> firstList = TrackList.FindAll(x => x.Rad == 1);
            List<Track> secondList = TrackList.FindAll(x => x.Rad == 2);
            List<Track> thirdList = TrackList.FindAll(x => x.Rad == 3);           
        }

        /*
        public void timePassed()
        {
            
            for (int i = 0; i < 3; i++)
            {
                int time = 0;
                foreach (Track t in radioGroup[i])
                {
                    t.Begin = time;
                    time += TimeConvert(t);
                }
            }
        }
        */
    }
}


 /*           
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string str = time .ToString(@"hh\:mm\:ss\:fff");
            */
 
