using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zene
{
    public class Track
    {
        private int _rad;
        private int _sec;
        private int _min;
        private string _name;

        public int Rad
        {
            get
            {
                return this._rad;
            }
            set
            {
                this._rad = value;
            }
        }

        public int Sec
        {
            get
            {
                return this._sec;
            }
            set
            {
                this._sec = value;
            }
        }

        public int Min
        {
            get
            {
                return this._min;
            }
            set
            {
                this._min = value;
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

        public Track(int rad, int min,int sec, string name)
        {
            this._rad = rad;
            this._min = min;
            this._sec = sec;
            this._name = name;



            
        }




    }
}
