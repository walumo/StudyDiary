using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.WriteLine("Tasks: \n");
                if (topic.Tasks.NotesList.Count() > 0)
                {
                    foreach (string note in topic.Tasks.Notes)
                    {
                        Console.WriteLine("{0}. {1}",topic.Tasks.NotesList.IndexOf(note)+1 , note);
                    }

                } Console.WriteLine("\nSource(s) used: {0}\n", topic.Source);
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
                    if (String.IsNullOrWhiteSpace(str)) { buffer.EstimatedTimeToMaster = default; break; }
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
                    Console.Write("Enter date for completion (dd.mm.yyyy): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str)) { buffer.CompletionDate = new DateTime(DateTime.Now.Year + 1, 1, 1); break; }
                    else
                    {
                        string[] dtParser = new string[3];
                        dtParser = str.Split('.');
                        buffer.CompletionDate = new DateTime(Convert.ToInt32(dtParser[2]), Convert.ToInt32(dtParser[1]), Convert.ToInt32(dtParser[0]));
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter time for completion (hh:mm): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str)) { buffer.CompletionDate.AddHours(12); break; }
                    else
                    {
                        string[] dtParser = new string[2];
                        dtParser = str.Split(':');
                        buffer.CompletionDate.AddHours(Convert.ToDouble(dtParser[0])).AddMinutes(Convert.ToDouble(dtParser[1]));
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }


            Console.Write("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
            return buffer;

           
        }
        public static Task NewTask(int taskCount)
        {
            Task buffer = new Task();

            buffer.Id = taskCount + 1;

            Console.Clear();
            Console.Write("Give a title for task: ");

            buffer.Title = Console.ReadLine();

            buffer.Done = false;

            while (true)
            {
                try
                {
                    Console.Write("\nEnter notes for this task (blank note to move on): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str)) break;
                    else buffer.NotesList.Add(str);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            while (true)
            {
                try
                {
                    Console.Write("Enter date for completion (dd.mm.yyyy): ");
                    string str = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(str)) { buffer.Deadline = new DateTime(DateTime.Now.Year + 1, 1, 1); break;}
                    else
                    {
                        string[] dtParser = new string[3];
                        dtParser = str.Split('.');
                        buffer.Deadline = new DateTime(Convert.ToInt32(dtParser[2]), Convert.ToInt32(dtParser[1]), Convert.ToInt32(dtParser[0]));
                    }
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Something went wrong, try again");
                    Console.ReadKey();
                }
            }

            Console.Write("Press enter to continue...");
            Console.ReadKey();
            Console.Clear();
            return buffer;

        }
    }
}