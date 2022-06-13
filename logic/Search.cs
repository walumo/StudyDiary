using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    static class Search
    {
        public static void Topic(List<Topic> list)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("SEARCH:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write("Search for topic by id or name (leave blank to list topics): ");

            string input = Console.ReadLine();
            Console.Clear();

            if (String.IsNullOrWhiteSpace(input)) Diary.ShowTopics(list);
            if (!String.IsNullOrWhiteSpace(input) && int.TryParse(input, out int result))
            {
                var searchResults = list.Where(x => x.Id == Convert.ToInt32(input));
                if (searchResults.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"No results for ID: {input}");
                }
                foreach (var topic in searchResults)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("YOUR TOPICS:");
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Topic number: {0}", topic.Id);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("****************");
                    Console.Write($"Topic: "); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(topic.Title.ToUpper()); Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"To master (hours): {topic.EstimatedTimeToMaster}");
                    Console.WriteLine($"Date to be completed: {topic.CompletionDate}");
                    Console.WriteLine("Time until completion: {0}", topic.CompletionDate - DateTime.Now);
                    Console.WriteLine("Hours spent: {0}", topic.TimeSpent);
                    Console.WriteLine("----------------");
                    Console.WriteLine("Description: {0}\n", topic.Description);

                    if (topic.Tasks.Notes.Count > 0)
                    {
                        Console.WriteLine("Tasks: \n");
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(topic.Tasks.Title.ToUpper());
                        Console.WriteLine(" || Priority: {0}", topic.Tasks.PriorityProperty);
                        Console.ForegroundColor = ConsoleColor.White;
                        foreach (string note in topic.Tasks.Notes)
                        {
                            Console.WriteLine("- {0}", note);
                        }
                    }
                    Console.WriteLine("\nSource(s) used: {0}\n", topic.Source);
                }
                Console.Write("Press enter to continue...");
                Console.ReadKey();

            }
            else if (!String.IsNullOrWhiteSpace(input))
            {
                var searchResults = list.Where(x => System.Text.RegularExpressions.Regex.IsMatch(x.Title, input, System.Text.RegularExpressions.RegexOptions.IgnoreCase));

                if (searchResults.Count() <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"No results for {input}");
                    Console.Write("Press enter to continue...");
                    Console.ReadKey();
                }
                else
                {
                    foreach (var topic in searchResults)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("YOUR TOPICS:");
                        Console.BackgroundColor = ConsoleColor.Black;

                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Topic number: {0}", topic.Id);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("****************");
                        Console.Write($"Topic: "); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(topic.Title.ToUpper()); Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"To master (hours): {topic.EstimatedTimeToMaster}");
                        Console.WriteLine($"Date to be completed: {topic.CompletionDate}");
                        Console.WriteLine("Time until completion: {0}", topic.CompletionDate - DateTime.Now);
                        Console.WriteLine("Hours spent: {0}", topic.TimeSpent);
                        Console.WriteLine("----------------");
                        Console.WriteLine("Description: {0}\n", topic.Description);

                        if (topic.Tasks.Notes.Count > 0)
                        {
                            Console.WriteLine("Tasks: \n");
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                            Console.Write(topic.Tasks.Title.ToUpper());
                            Console.WriteLine(" || Priority: {0}", topic.Tasks.PriorityProperty);
                            Console.ForegroundColor = ConsoleColor.White;
                            foreach (string note in topic.Tasks.Notes)
                            {
                                Console.WriteLine("- {0}", note);
                            }
                        }
                        Console.WriteLine("\nSource(s) used: {0}\n", topic.Source);
                    }
                    Console.Write("Press enter to continue...");
                    Console.ReadKey();
                }
            }
        }
        public static void Task(List<Topic> list)
        {
            //search task by id or string
        }
    }
}
