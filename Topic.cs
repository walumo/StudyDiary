using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDiary
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; } = "New Topic";
        public string Description { get; set; } = "-";
        public double EstimatedTimeToMaster { get; set; } = 1;
        public double TimeSpent { get; set; } = 0;
        public string Source { get; set; }
        public DateTime StartLearningDate { get; set; }
        public bool inProgress { get; set; } = false;
        public DateTime CompletionDate { get; set; } = DateTime.Now;

    }
}