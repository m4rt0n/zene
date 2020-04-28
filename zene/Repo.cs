using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zene
{
    public class Repo
    {


        public  List<Track> TrackList { get; set; }
        /*
        public void AddTrack(int rad, int min, int sec, string name)
        {
            this.TrackList.Add(new Track(rad, min, sec, name));
        }
        */
        public void ReadList(string readText)
        {
            
            //read text as one string
            //string text = System.IO.File.ReadAllText(readText);
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            //read by lines
            string[] lines = System.IO.File.ReadAllLines(readText);
           
            //System.Console.WriteLine(readText);

            
            //var trackList = new List<Track>();

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
                //AddTrack(Rad, Min, Sec, Name);
            }

        }

       

    }
}

/*
 
 */
