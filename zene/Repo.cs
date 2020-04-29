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
            List<Track> listRadioOne = TrackList.FindAll(x => x.Rad == 1);
           //first and last EC
        var firstClapton = listRadioOne.Find
                (x => x.Name.Contains("Eric Clapton"));             
        var lastClapton= listRadioOne.FindLast(x =>  x.Name.Contains("Eric Clapton"));
            //index first and last EC
            var firstClaptonIndex = listRadioOne.FindIndex
                (i=>i.Name==firstClapton.Name);
            var lastClaptonIndex = listRadioOne.FindIndex
                (i => i.Name == lastClapton.Name);
            // tracks between first and last EC
            var range = listRadioOne.GetRange(firstClaptonIndex, lastClaptonIndex-firstClaptonIndex);
            var time = 0;
            foreach (Track t in range)
            {
                //time in sec
                time += t.Min * 60 + t.Sec; 
            }
            //convert time sec
            Console.WriteLine("Time passed between first & last EC tracks:\n{0}",TimeConvert(time));                      
        }
        
        public string TimeConvert(int seconds)
        {           
                //var second = t.Min * 60 + t.Sec;
                TimeSpan time = TimeSpan.FromSeconds(seconds);
                string str = time.ToString(@"hh\:mm\:ss");
            return str;
                //Console.WriteLine("converted time : {1}", str);                       
        }

        //4
        public void Omega()
        {
            //omega name
            string omegaName = "Omega:Legenda";       
            //find omega object
            var omegaObj = TrackList.Find(o => o.Name == omegaName);
            //find radio of omega 
            var omegaRadio = TrackList.Contains(omegaObj);            
            //radio played
            Console.WriteLine("Radio number: {0}",omegaObj.Rad);
            //list by radio
            List<Track> listRadioOne = TrackList.FindAll(x => x.Rad == 1);
            List<Track> listRadioTwo = TrackList.FindAll(x => x.Rad == 2);
            List<Track> listRadioThree = TrackList.FindAll(x => x.Rad == 3);    
            //index omega track
            var omegaIndex=listRadioThree.IndexOf(omegaObj);
            Console.WriteLine("index of: {0} : {1}",omegaName, omegaIndex);
            //tracks before omega            
            var omegaListRange = listRadioOne.GetRange(0, omegaIndex); 
            /*
            foreach (Track t in omegaListRange)
            {
                Console.WriteLine(t.Name);          
            }
            */
            Console.WriteLine("Omega track start: {0}", TimeConvert(TimePassed(omegaListRange)));
            
        }

        public int TimePassed(List<Track> list)
        {          
                int trackTime = 0;
                int listTime = 0;
                foreach (Track t in list)
                {
                    trackTime = t.Min * 60 + t.Sec;
                    listTime += trackTime;                    
                }
                return listTime;           
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
 
