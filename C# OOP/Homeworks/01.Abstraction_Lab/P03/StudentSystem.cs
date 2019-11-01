namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo { get; private set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            switch (args[0]?.ToLower())
            {
                case "create":
                    CreateStudent(args);
                    break;
                case "show":
                    ShowStudent(args);
                    break;
                case "exit":
                    Exit();
                    break;
                default:
                    Console.WriteLine("Wrong command");
                    break;
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }

        private void ShowStudent(string[] args)
        {
            var name = args[1];
            if (Repo.ContainsKey(name))
            {
                var student = Repo[name];
                Console.WriteLine(student);
            }
        }

        private void CreateStudent(string[] args)
        {
            var name = args[1];
            var age = int.Parse(args[2]);
            var grade = double.Parse(args[3]);
            if (!Repo.ContainsKey(name))
            {
                var student = new Student(name, age, grade);
                Repo[name] = student;
            }
        }
    }
}