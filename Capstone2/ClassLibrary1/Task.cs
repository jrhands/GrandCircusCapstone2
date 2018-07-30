using System;

namespace Capstone2.Library
{
    public class Task
    {
        public Task(string teamMembersName, string briefDescription, DateTime dueDate)
        {
            completeFlag = false;
            this.teamMembersName = teamMembersName;
            this.briefDescription = briefDescription;
            this.dueDate = dueDate;
        }
        public bool completeFlag;
        public string teamMembersName;
        public string briefDescription;
        public DateTime dueDate;
    }
}
