using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

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
            Console.WriteLine("Sikeres beolvasas: '{0}'", readText);
        }

        //2.
        public void GroupByRadio()
        {
            for (int i = 1; i <=3; i++)
            { 
            Console.WriteLine("{0}. Ado : {1} szam", i,
                TrackList.Where(x => x.Rad == i).Count());
            }
        }

        //3
        public void ClaptonTime(string ec)
        {
            List<Track> listRadioOne = TrackList.FindAll(x => x.Rad == 1);
        var firstClapton = listRadioOne.Find
                (x => x.Name.Contains(ec));             
        var lastClapton= listRadioOne.FindLast(x =>  x.Name.Contains(ec));
            var firstClaptonIndex = listRadioOne.FindIndex
                (i=>i.Name==firstClapton.Name);
            var lastClaptonIndex = listRadioOne.FindIndex
                (i => i.Name == lastClapton.Name);
            var range = listRadioOne.GetRange(firstClaptonIndex, lastClaptonIndex-firstClaptonIndex);
            var time = 0;
            foreach (Track t in range)
            {
                time += t.Min * 60 + t.Sec; 
            }
            time += lastClapton.Min * 60 + lastClapton.Sec;
            Console.WriteLine("Elso es utolso Clapton szam kozti ido 1. Adon:\n{0}",TimeConvert(time));                      
        } 
        
        //4
        public void Omega(string omegaName)
        {
            var omegaObj = TrackList.Find(o => o.Name == omegaName);
            var omegaRadio = TrackList.Contains(omegaObj);            
            Console.WriteLine("A(z) '{0}' szam a(z) {1}. adon volt hallhato",omegaName,omegaObj.Rad);
            List<Track> listRadioOne = TrackList.FindAll(x => x.Rad == 1);
            List<Track> listRadioTwo = TrackList.FindAll(x => x.Rad == 2);
            List<Track> listRadioThree = TrackList.FindAll(x => x.Rad == 3);    
            var omegaIndex=listRadioThree.IndexOf(omegaObj);           
            var omegaListRange = listRadioThree.GetRange(0, omegaIndex);
            int omegaTime = (TimePassed(omegaListRange));
            string omegaTimeString = TimeConvert(omegaTime);
            Track elementOne=ListTime(listRadioOne, omegaTime);
            Track elementTwo=ListTime(listRadioTwo, omegaTime);
            Console.WriteLine(elementOne != null ?
                "1. adon hallhato szam: " + elementOne.Name :
                "1. adon nincs talalat");
            Console.WriteLine(elementTwo != null ?
                "2. adon hallhato szam: " + elementTwo.Name :
                "2. adon nincs talalat");  
        }

        //5
        public void SearchSms(string smsInput)
        {
            List<Track> searchList = TrackList.FindAll(s => s.Name.ToLower().Contains(smsInput));
            string textFile = "keres.txt";                    
            if (!File.Exists(textFile))
            {
                string createText = smsInput + Environment.NewLine;
                File.WriteAllText(textFile, createText);                       
            }
            string minta = ".*";
            for (int i = 0; i < smsInput.Length; i++)
            {
                minta = minta + Convert.ToString(smsInput[i]).ToLower() + ".*";
            }
            Regex mint = new Regex(minta);                       
                foreach (Track t in TrackList)
                {
                    if (mint.IsMatch(t.Name.ToLower()))
                    {
                        string appendText = t.Name + Environment.NewLine;
                        File.AppendAllText(textFile, appendText);
                    }
                }
            using (StreamReader sr = File.OpenText(textFile))
            {
                string s = "";
                Console.WriteLine("A(z) '{0}' allomany tartalma:",textFile);
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }            
        }

        //6
        public void Change()
        {
            List<Track> listRadioOne = TrackList.FindAll(x => x.Rad == 1);
            int newTime = 180;
            int breakList = 3420;
            foreach (Track t in listRadioOne)
            {
                if (breakList < (t.Min * 60 + t.Sec + 60))
                {
                    newTime += breakList + 180;
                    breakList = 3420;
                }
                newTime += t.Min * 60 + t.Sec + 60;
                breakList -= t.Min * 60 + t.Sec + 60;
            }
            string newList = TimeConvert(newTime);
            Console.WriteLine("Adas vege: {0}", newList);
        }

        //helper methods         
        private int TimePassed(List<Track> list)
        {                        
                int listTime = 0;
                foreach (Track t in list)
                {
                int trackTime = 0;
                trackTime = t.Min * 60 + t.Sec;
                    listTime += trackTime;                    
                }
                return listTime;           
        }
        private string TimeConvert(int seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string str = time.ToString(@"hh\:mm\:ss");
            return str;                     
        }

        private Track ListTime(List<Track> searchedList, int searchedTime)
        {
            Track tmp = null;
            int listTime = 0;
            foreach (Track t in searchedList)
            {
                int trackTime = 0;
                trackTime = t.Min * 60 + t.Sec;
                listTime += trackTime;
                if (listTime > searchedTime)
                {
                    tmp = t;
                    break;
                }
            }
            return tmp;            
        }
    }
}


 
