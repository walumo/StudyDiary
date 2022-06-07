using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{

    class Program
    {

        static void Main(string[] args)
        {
            int option;
            List<Topic> myTopics = new List<Topic>();

            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Study Diary v.1.0.0");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1) to enter new topic");
                Console.WriteLine("2) to list your topics");
                Console.WriteLine("3) to exit application\n");
                Console.Write("Your selection: ");
              
                try
                {
                    string getValue = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(getValue) || Convert.ToInt32(getValue) < 1 || Convert.ToInt32(getValue) > 3) continue;
                    option = Convert.ToInt32(getValue);
                }
                catch (Exception e)
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
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
