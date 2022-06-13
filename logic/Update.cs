using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    static class Update
    {
        internal static void Refresh(List<Topic> list, int index)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("UPDATING TOPIC:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Leave option blank to retain old value");

            if (list.Count() == 0) Console.WriteLine("No topics in your list.\n");


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Topic number: {0}", list[index].Id);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("****************");
            Console.Write($"Topic: "); Console.ForegroundColor = ConsoleColor.Blue; Console.WriteLine(list[index].Title.ToUpper()); Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"To master (hours): {list[index].EstimatedTimeToMaster}");
            Console.WriteLine($"Date to be completed: {list[index].CompletionDate}");
            Console.WriteLine("Time until completion: {0}", list[index].CompletionDate - DateTime.Now);
            Console.WriteLine("Hours spent: {0}", list[index].TimeSpent);
            Console.WriteLine("----------------");
            Console.WriteLine("Description: {0}\n", list[index].Description);

            if (list[index].Tasks.NotesList.Count() > 0)
            {
                Console.WriteLine("Tasks: \n");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(list[index].Tasks.Title.ToUpper());
                Console.WriteLine(" || Priority: {0}", list[index].Tasks.PriorityProperty);
                Console.ForegroundColor = ConsoleColor.White;
                foreach (string note in list[index].Tasks.Notes)
                {
                    Console.WriteLine("- {0}", note);
                }

            }
            Console.WriteLine("\nSource(s) used: {0}\n", list[index].Source);

        }
        public static List<Topic> Topics(List<Topic> list)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("UPDATE:");
            Console.BackgroundColor = ConsoleColor.Black;
            
            foreach (Topic topic in list)
            {
                Console.WriteLine(topic.Id + ". " + topic.Title.ToUpper());
            }
            Console.Write("Select topic to update (leave blank to return): ");
            
            string input = Console.ReadLine();
            int index = Convert.ToInt32(input)-1;

            

            if (String.IsNullOrWhiteSpace(input)) return list;
            if (!String.IsNullOrWhiteSpace(input) && int.TryParse(input, out int result))
            {
                List<int> dtHelper = new List<int>();
                int thisYear = DateTime.Today.Year;

                list[index].Id = list.Count() + 1;
                
                Refresh(list, index);
                Console.Write("Give a title for topic: ");
                string title = Console.ReadLine();
                if(!String.IsNullOrWhiteSpace(title)) list[index].Title = title;

                Refresh(list, index);
                Console.Write("Give a description for topic: ");
                string description = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(description))list[index].Description = description;


                Refresh(list, index);
                Console.Write("Enter estimated time to master: ");
                string toMaster = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(toMaster)) list[index].EstimatedTimeToMaster = Convert.ToDouble(toMaster);
                    

                Refresh(list, index);
                Console.Write("Enter source used if any (if not, press Enter): ");
                string source = Console.ReadLine();
                if(!String.IsNullOrWhiteSpace(source))list[index].Source = source;

                while (true)
                {
                    try
                    {
                        Refresh(list, index);
                        Console.Write("Enter date for completion (dd.mm.yyyy): ");
                        string completionDate = Console.ReadLine();
                        if (!String.IsNullOrWhiteSpace(completionDate))
                        {
                            try
                            {
                                Refresh(list, index);
                                string[] dtParser = new string[3];
                                dtParser = completionDate.Split('.');
                                list[index].CompletionDate = new DateTime(Convert.ToInt32(dtParser[2]), Convert.ToInt32(dtParser[1]), Convert.ToInt32(dtParser[0]));
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                        }
                        else break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Date must be formatted dd.mm.yyyy, or you can leave the input blank.");
                        Console.ReadKey();
                    }
                }

                while (true)
                {
                    try
                    {
                        Refresh(list, index);
                        Console.Write("Enter time for completion (hh:mm): ");
                        string completionTime = Console.ReadLine();
                        if (!String.IsNullOrWhiteSpace(completionTime))
                        {
                            try
                            {
                                Refresh(list, index);
                                string[] dtParser = new string[2];
                                dtParser = completionTime.Split(':');
                                list[index].CompletionDate.AddHours(Convert.ToDouble(dtParser[0])).AddMinutes(Convert.ToDouble(dtParser[1]));
                                break;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                        }
                        else break;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Time must be formatted as HH:MM");
                        Console.ReadKey();
                    }
                }
            }
            return list;
        }
    }
}