using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeDesignMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var booksComposite = new CompositeComponent<ILibrary> { Node = new Category("Books") };

            var scienceBooks = booksComposite.Add(new Category("Science"));

            var bk1 = scienceBooks.Add(new Book("Vakıf"));
            var bk2 = scienceBooks.Add(new Book("Kaplan Kaplan!"));

            var fantasticComposite = booksComposite.Add(new Category("Fantastic"));
            var fl = fantasticComposite.Add(new Book("Yüzüklerin Efendisi"));

            booksComposite.List(1);


            //Category books = new Category("Kitap");
            //Category science = new Category("Bilim Kurgu");
            //Category fantastic = new Category("Fantastik");

            //Book scienceBook1 = new Book("Vakıf");
            //Book scienceBook2 = new Book("Kaptan Kaptan");
            //Book scienceBook3 = new Book("Yüzüklerin Efendisi");

            //books.Add(science);
            //books.Add(fantastic);

            //science.Add(scienceBook1);
            //science.Add(scienceBook2);

            //fantastic.Add(scienceBook3);
            //books.Show(1);
            Console.ReadLine(); 

        }
    }

    public interface ILibrary:IComposite
    {
        void Show(int charapterLenght);
    }

    public class Book : ILibrary
    {
        public string Name { get; set; }
        public Book(string name)
        {
            Name = name;
        }

        public void Show(int charapterLenght)
        {
            String line = new string('-',charapterLenght);
            Console.WriteLine(line+ Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Category : ILibrary
    {
        public string Name { get; set; }
        public Category(string name)
        {
            Name = name;
        }

        private List<ILibrary> subLibraries = new List<ILibrary>();

        public void Add(ILibrary library)
        {
            subLibraries.Add(library);
        }

        public void Show(int charapterLenght)
        {
            String line = new string('-',charapterLenght++);
            Console.WriteLine("{0}{1}{2}", line,Name,subLibraries.Count);

            foreach (var item in subLibraries)
            {
                item.Show(charapterLenght);
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public interface IComposite
    {

    }

    public class CompositeComponent<T> where T:IComposite
    {
        private List<CompositeComponent<T>> subComponents = new List<CompositeComponent<T>>();

        public T Node { get; set; }

        public CompositeComponent<T> Add(T componentObje)
        {
            CompositeComponent<T> newNode = new CompositeComponent<T> { Node = componentObje };
            subComponents.Add(newNode);
            return newNode;
        }

        public void List(int charapterCount)
        {
            string line = new string('-', charapterCount++);
            Console.WriteLine("{0}{1}{2}",line,Node.ToString(), subComponents.Count);

            foreach (var item in subComponents)
            {
                item.List(charapterCount);
            }
        }
    }

}
