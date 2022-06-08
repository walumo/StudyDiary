using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    public static class Save
    {
        public static void SaveAll(List<Topic> list)
        {

            try
            {
                foreach (Topic topic in list)
                {
                    List<string> topicBuffer = new List<string>();
                    List<string> taskBuffer = new List<string>();
                    int counter = 1;
                    topicBuffer.Add(topic.Id.ToString());
                    topicBuffer.Add(topic.Title);
                    topicBuffer.Add(topic.Description);
                    topicBuffer.Add(topic.EstimatedTimeToMaster.ToString());
                    topicBuffer.Add(topic.TimeSpent.ToString());
                    topicBuffer.Add(topic.Source);
                    topicBuffer.Add(topic.StartLearningDate.ToString());
                    topicBuffer.Add(topic.inProgress.ToString());
                    topicBuffer.Add(topic.CompletionDate.ToString());

                    taskBuffer.Add(topic.Tasks.Id.ToString());
                    taskBuffer.Add(topic.Tasks.Title);
                    taskBuffer.Add(topic.Tasks.Description);
                    taskBuffer.Add(topic.Tasks.Deadline.ToString());
                    taskBuffer.Add(topic.Tasks.Done.ToString());
                    taskBuffer.Add(topic.Tasks.PriorityProperty.ToString());
                    foreach (string note in topic.Tasks.Notes)
                    {
                        taskBuffer.Add(counter.ToString() + ". " + note);
                        counter++;
                    }
                    string taskPath = @"C:\Users\MiikkaHakulinen\source\repos\StudyDiary\topics\tasksfortopic" + topic.Id.ToString() +".txt";
                    File.WriteAllLines(taskPath, taskBuffer);

                    string notePath = @"C:\Users\MiikkaHakulinen\source\repos\StudyDiary\topics\topic" + topic.Id.ToString() + ".txt";
                    File.WriteAllLines(notePath, topicBuffer);
                }
            }
            catch (Exception ex)
            {
                Console.Write("There was an error: ");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

