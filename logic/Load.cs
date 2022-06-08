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
                string str = (JsonConvert.SerializeObject(item));
                Topic dsTopic = JsonConvert.DeserializeObject<Topic>(str);
                buffer.Add(dsTopic);
            }
            return buffer;
        }
    }
}
