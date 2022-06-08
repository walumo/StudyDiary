using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace StudyDiary
{
    public class Save
    {

        public static void SaveAll(List<Topic> list)
        {
            List<string> topics = new List<string>();
            foreach (Topic topic in list)
            {
                topics.Add(JsonConvert.SerializeObject(topic));
            }

            if (!Directory.Exists(@".\topics")) Directory.CreateDirectory("topics");
            string topicPath = Environment.CurrentDirectory + @"\topics\topic.txt";
            File.WriteAllLines(topicPath, topics);
        }
    }
}

