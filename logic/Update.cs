﻿using System;
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
            Console.WriteLine("UPDATING:");
            Console.BackgroundColor = ConsoleColor.Black;

            if (list.Count() == 0) Console.WriteLine("No topics in your list.\n");


            Console.ForegroundColor = ConsoleColor.Blue;
           // Console.WriteLine("Topic number: {0}", list[index].Id);
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
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Leave option blank to retain old value");


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
                Console.Write("Update topic title: ");
                string title = Console.ReadLine();
                if(!String.IsNullOrWhiteSpace(title)) list[index].Title = title;

                Refresh(list, index);
                Console.Write("Update topic description: ");
                string description = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(description))list[index].Description = description;


                Refresh(list, index);
                Console.Write("Update estimated time to master: ");
                string toMaster = Console.ReadLine();
                if (!String.IsNullOrWhiteSpace(toMaster)) list[index].EstimatedTimeToMaster = Convert.ToDouble(toMaster);
                    

                Refresh(list, index);
                Console.Write("Update source used: ");
                string source = Console.ReadLine();
                if(!String.IsNullOrWhiteSpace(source))list[index].Source = source;

                while (true)
                {
                    try
                    {
                        Refresh(list, index);
                        Console.Write("Update date for completion (dd.mm.yyyy): ");
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
                        Console.Write("Update time for completion (hh:mm): ");
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
        public static List<Topic> Tasks(List<Topic> list)
        {
            string input;
            List<string> commands = new List<string>();
            List<string> pointers = new List<string>();
            bool commandsValid = false;
            Console.Clear();

            foreach (Topic topic in list)
            {
                if(topic.Tasks.Notes.Count > 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("TOPIC {0}: {1}", topic.Id, topic.Title.ToUpper());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(topic.Tasks.Title.ToUpper());
                    foreach (string task in topic.Tasks.Notes)
                    {
                        Console.WriteLine("{0}.{1} {2}", topic.Id, topic.Tasks.Notes.IndexOf(task) + 1, topic.Tasks.Notes[topic.Tasks.Notes.IndexOf(task)]);
                    }
                    Console.WriteLine(Environment.NewLine);

                }
            }

            Console.WriteLine("'remove topic.task' (ex. remove 2.1) to remove task,");
            Console.WriteLine("'update topic.task' (ex. update 2.1) to update task,");
            Console.Write("Enter commands: ");
            input = Console.ReadLine().Trim().ToLower();

            if (String.IsNullOrWhiteSpace(input)) return list;
            if (input.Contains(" ") && input.Contains("."))
            {
                commands = input.Split(' ').ToList();
                pointers = commands[1].Split('.').ToList();
                commandsValid = true;
            }

            if (commandsValid == true && (commands[0] == "remove" || commands[0] == "update") && int.TryParse(pointers[0], out int r1) && int.TryParse(pointers[1], out int r2))
            {
                if(commands[0]=="remove") list[r1-1].Tasks.Notes.RemoveAt(r2-1);
                if (commands[0] == "update")
                {
                    Console.Write("Update task value: ");
                    list[r1-1].Tasks.Notes[r2-1] = Console.ReadLine();
                }
            }
            
            else
            {
                Console.WriteLine("Invalid command!!!");
                Console.ReadKey();
            }
            return list;
        }
    }
}