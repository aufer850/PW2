using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW2
{
    internal class Project
    {
        private string name; // приватні поля класу
        private string client;
        private DateTime startDate;
        private DateTime endDate;
        private List<string> tasks = new List<string>();

        public Project() // конструктор за замовчуванням
        {
            this.name = "";
            this.client = "";
            this.startDate = DateTime.Now;
            this.endDate = DateTime.Now;
        }
        public Project(string Name, string Client, DateTime StartDate, DateTime EndDate) // параметризований конструктор
        {
            if (StartDate > EndDate) // перевірка дат, при наявності проблеми об'єкт не буде створено
            {
                Console.WriteLine("Task cannot be created!\nStartDate must be earlier than EndDate!");
                return;
            }

            this.name = Name;
            this.client = Client;
            this.startDate = StartDate;
            this.endDate = EndDate;
        }

        public Project(Project P) // конструктор копіювання
        {
            this.name = P.Name;
            this.client = P.Client;
            this.startDate = P.StartDate;
            this.endDate = P.EndDate;
            this.Tasks = P.Tasks;
        }
        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        public string Client
        {
            get { return client; }
            set { client = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public List<string> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }

        public void AddTask(string S)
        {
            tasks.Add(S);
        }

        public void RemoveTask(string T)
        {
            tasks.Remove(T);
        }

        public int GetTaskCount()
        {
            return tasks.Count;
        }

        public void PrintInfo()
        {
            Console.WriteLine("Project: " + name);
            Console.WriteLine("Client: " + client);
            Console.WriteLine("Starting date: " + Convert.ToString(startDate));
            Console.WriteLine("Deadline: " + Convert.ToString(endDate));
        }

        public String GetTaskSummary()
        {
            string Summary = "";
            for(int i = 0; i < this.GetTaskCount(); i ++)
            {
                Summary = Summary + Convert.ToString(i + 1) + "." + tasks[i] + " ";
            }
            return Summary;
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            DateTime End = new DateTime(2025,8,21);
            Project P = new Project("Main Project","Client",DateTime.Now,End);
            P.AddTask("Make design"); // створення завдань,
            P.AddTask("Write code");
            P.AddTask("Create errors"); 
            P.AddTask("Test project");
            P.AddTask("Publish project");
            P.RemoveTask("Create errors"); // видалення зайвого завдання з проекту
            P.PrintInfo();
            Console.WriteLine("---===============---");
            Console.WriteLine("Total tasks: " + Convert.ToString(P.GetTaskCount()));
            Console.WriteLine(P.GetTaskSummary());
            Console.WriteLine("---===============---");
            Project P2 = new Project(P);
            Console.WriteLine("Cloned Project info: ");
            P2.PrintInfo();
            Console.ReadLine();
        }
    }
}
