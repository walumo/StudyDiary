using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    static class Diary
    {
        //List topics
        public static void ShowTopics(List<Topic> list)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("YOUR TOPICS:");
            Console.BackgroundColor = ConsoleColor.Black;

            if (list.Count() == 0) Console.WriteLine("No topics in your list.\n");

            foreach (Topic topic in list)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Topic number: {0}", topic.Id);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("-----------------");

                Console.Write($"Topic: "); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(topic.Title); ; Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"To master (hours): {topic.EstimatedTimeToMaster}");
                Console.WriteLine($"Date to be completed: {topic.CompletionDate}");
                Console.WriteLine("Time until completion: {0}", topic.CompletionDate-DateTime.Now);
                Console.WriteLine("Hours spent: {0}", topic.TimeSpent);
                Console.WriteLine("-----------------");

                Console.WriteLine("Description: {0}", topic.Description);
                Console.WriteLine("\nSource(s) used: {0}\n", topic.Source);
            }
            Console.Write("Press enter to continue...");
            Console.ReadKey();

        }
        //Add topics
        public static Topic NewTopic(List<Topic> list)
        {
            List<int> dtHelper = new List<int>();
            Topic buffer = new Topic();
            int thisYear = DateTime.Today.Year;

            buffer.Id = list.Count()+1;

            Console.Clear();
            Console.Write("Give a title for topic: ");

            buffer.Title = Console.ReadLine();

            Console.Write("Give a description for topic: ");

            buffer.Description = Console.ReadLine();

            Console.Write("Enter estimated time to master: ");

            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str)) { buffer.EstimatedTimeToMaster = 0; break; }
                    else if (!String.IsNullOrWhiteSpace(str)) { buffer.EstimatedTimeToMaster = Convert.ToDouble(str); break; }

                    else continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("You can enter only numerical values!");
                    throw;
                }
            }

            Console.Write("Enter source used if any (if not, press Enter): ");

            buffer.Source = Console.ReadLine();

            buffer.inProgress = false;

            while (true)
            {
                try
                {
                    Console.Write("Enter day for completion date (dd): ");
                    string str = Console.ReadLine();
                    if(String.IsNullOrWhiteSpace(str) || Convert.ToInt32(str) < 1 || Convert.ToInt32(str) > 31) {dtHelper.Add(1); break;}
                    else dtHelper.Add(Convert.ToInt32(str));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter month for completion date (mm): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str) || Convert.ToInt32(str) < 1 || Convert.ToInt32(str) > 12) { dtHelper.Add(1); break; }
                    else dtHelper.Add(Convert.ToInt32(str));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter year for completion date (yyyy): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str) || Convert.ToInt32(str) < thisYear || Convert.ToInt32(str) > 2100) { dtHelper.Add(thisYear+1); break; }
                    else dtHelper.Add(Convert.ToInt32(str));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter hour for completion time (hh): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str) || Convert.ToInt32(str) < 00 || Convert.ToInt32(str) > 23) { dtHelper.Add(12); break; }
                    else dtHelper.Add(Convert.ToInt32(str));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter minutes for completion time (mm): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str) || Convert.ToInt32(str) < 00 || Convert.ToInt32(str) > 59) { dtHelper.Add(00); break; }
                    else dtHelper.Add(Convert.ToInt32(str));
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            buffer.CompletionDate = new DateTime(
                dtHelper[2],
                dtHelper[1],
                dtHelper[0],
                dtHelper[3],
                dtHelper[4],
                00);
            Console.Write("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
            return buffer;
        }
    }
}