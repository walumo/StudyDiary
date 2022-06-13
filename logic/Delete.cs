using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    static class Delete
    {
        public static List<Topic> Topic(List<Topic> list)
        {
            while (true)
            {
                Console.Clear();
                foreach (Topic topic in list)
                {
                    topic.Id = list.IndexOf(topic)+1;
                    Console.WriteLine(topic.Id + ". " + topic.Title);
                }
                Console.Write("\nChoose topic to delete (blank to return, 'all' to delete all topics): ");
                string input = Console.ReadLine();
                if (string.Equals(input, "all", StringComparison.OrdinalIgnoreCase)) { Delete.All(list); return list; }
                if (String.IsNullOrWhiteSpace(input)) return list;
                if (!String.IsNullOrWhiteSpace(input) && !int.TryParse(input, out int result) || Convert.ToInt32(input) < 0 || Convert.ToInt32(input) > list.Count())
                {
                    Console.WriteLine("Invalid input!");
                    Console.ReadKey();
                }
                else
                {
                    list.Remove(list[Convert.ToInt32(input)]);
                }
            }
        }
        public static void Tasks(List<Topic> list)
        {
            //delete tasks
        }
        public static List<Topic> All(List<Topic> list)
        {
            list.Clear();
            return list;
        }

        public static IEnumerable<Topic> CleanUp(List<Topic> list)
        {
            return list.Where(topic => topic.CompletionDate.CompareTo(DateTime.Now) > 0);
        }
    }
}
