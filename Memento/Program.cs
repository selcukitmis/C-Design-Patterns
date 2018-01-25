using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book
            {
                Title = "Sefiller",
                Author = "Victor Hugo"
            };

            book.ShowBook();

            CareTaker history = new CareTaker();
            history.Memento = book.CreateUndo();

            book.Title = "Title Updated";
            Console.WriteLine("-----------");
            book.ShowBook();

            book.RestoreFromUndo(history.Memento);
            Console.WriteLine("-----------");
            book.ShowBook();

            Console.Read();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private DateTime _lastEdited;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo()
        {
            return new Memento(_title, _author, _lastEdited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Auther;
            _lastEdited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("LastEdited: {0}", _lastEdited);
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Auther { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string auther, DateTime lastEdited)
        {
            Title = title;
            Auther = auther;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento Memento { get; set; }
    }
}
