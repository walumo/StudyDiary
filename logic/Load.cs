using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    class Load
    {
        public static List<Topic> LoadAll()
        {
            List<Topic> buffer = new List<Topic>();

            foreach (string item in File.ReadAllLines(Environment.CurrentDirectory + @"\topics\topic.txt").ToList())
            {
                Topic dsTopic = JsonConvert.DeserializeObject<Topic>(item);
                buffer.Add(dsTopic);
            }
            return buffer;
        }
    }
}
