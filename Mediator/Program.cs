using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            var mediator = new Mediator();
            var teacher = new Teacher(mediator);
            teacher.Name = "Selçuk";
            mediator.Teacher = teacher;

            var student = new Student(mediator) { Name = "Mahmut" };
            var student2 = new Student(mediator) { Name = "Faruk" };

            mediator.Students = new List<Student> { student, student2 };

            teacher.ReceiveQuestion("doğru mu ?",student);
            teacher.AnswerQuestion("evet", student);
            //teacher.SendNewImageUrl("slide1.jpg");

            

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator)
            : base(mediator)
        {

        }

        public void ReceiveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher received a question from {0}, {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
            
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher answered question : {0}, {1}", student.Name, answer);
        }

        public string Name { get; set; }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator)
            : base(mediator)
        {

        }

        public string Name { get; set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine(Name +" received image : {0}",url);
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine(Name +" received answer : {0}", answer);
        }


    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer);
        }
    }
}