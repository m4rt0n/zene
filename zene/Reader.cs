using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace zene
{
    class Reader
    {
        private List<Track> _trackList;

        public List<Track> TrackList
        {
            get
            {
                if (this._trackList == null)
                {
                    this._trackList = new List<Track>();
                }
                return this._trackList;
            }
        }

        public void AddTrack(int radio, int time, string name)
        {
            this.TrackList.Add(new Track(radio, time, name));
        }

        public void ReadList(string readText)
        {
        string text = System.IO.File.ReadAllText(readText);
            //System.Console.WriteLine("Contents of WriteText.txt = {0}", text);

            
        }



    }
}

/*
 List<Track>[] radio = new List<Track>[3];
            for (int i = 0; i < 3; i++)
            {
                radio[i] = new List<Track>();
            }
 */
