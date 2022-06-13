using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StudyDiary
{

    static class Program
    {
        static void Main(string[] args)
        {
            int option;
            List<Topic> myTopics = new List<Topic>();
            //List<Topic> searchResults = new List<Topic>();

            try
            {
                if (File.Exists(Environment.CurrentDirectory + @"\topics\topic.txt")) myTopics = Load.LoadAll();
            }
            catch (Exception ex)
            {
                Console.Write("Something went wrong: " + ex.Message);
                Console.ReadKey();
            }



            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Study Diary v.1.0.0");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1) Enter new topic");
                Console.WriteLine("2) List your topics");
                Console.WriteLine("3) Add notes to topics");
                Console.WriteLine("4) Search");
                Console.WriteLine("5) Delete topics");
                Console.WriteLine("6) Exit application\n");
                Console.Write("Your selection: ");

                try
                {
                    string getValue = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(getValue) || Convert.ToInt32(getValue) < 1 || Convert.ToInt32(getValue) > 6) continue;
                    option = Convert.ToInt32(getValue);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    Console.Write("Press enter to continue...");
                    Console.ReadKey();
                    continue;
                }



                switch (option)
                {
                    case 1:
                        myTopics.Add(Diary.NewTopic(myTopics));
                        break;
                    case 2:
                        Diary.ShowTopics(myTopics);
                        break;
                    case 3:
                        int topicIndex;
                        Console.Clear();
                        Console.WriteLine("TOPICS: ");
                        Console.WriteLine("---------");
                        Console.WriteLine("Choose a topic to add notes to: ");
                        foreach (Topic topic in myTopics)
                        {
                            Console.WriteLine("{0}. {1}", topic.Id, topic.Title.ToUpper());
                        }
                        Console.Write("\nYour selection: ");
                        try
                        {
                            topicIndex = Convert.ToInt32(Console.ReadLine());
                            if (topicIndex > 0 || topicIndex <= myTopics.Count())
                            {
                                myTopics[topicIndex - 1].Tasks = Diary.NewTask(myTopics[topicIndex - 1].Tasks.Notes.Count());
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Search.Topic(myTopics);
                        break;
                    case 5:
                        Delete.Topic(myTopics);
                        break;
                    case 6:
                        Save.SaveAll(myTopics);
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
