using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zene
{
    class Track
    {
        private int _radio;
        private int _time;
        private string _name;

        public int Radio
        {
            get
            {
                return this._radio;
            }
            set
            {
                this._radio = value;
            }
        }

        public int Time
        {
            get
            {
                return this._time;
            }
            set
            {
                this._time = value;
            }
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        public Track(int radio, int time, string name)
        {
            this._radio = radio;
            this._time = time;
            this._name = name;


            /*
            string[] data = new string[4];
            char[] split = { ' ' };
            data = trackLine.Split(split, 4);
           
            this._radio = data[0];
            this._time = data[1];
            this._name = data[2];
            */
        }




    }
}
