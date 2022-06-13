using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    class Delete
    {
        public static void Topic(List<Topic> list)
        {
            //delete specific topic
        }
        public static void Tasks(List<Topic> list)
        {
            //delete tasks
        }
        public static void All(List<Topic> list)
        {
            //delete all topics and tasks
        }

        public static void CleanUp(List<Topic> list)
        {
            //clean up topics and tasks that are done or too far past deadline
            //Save to a history file??? Stack()???
        }
    }
}
