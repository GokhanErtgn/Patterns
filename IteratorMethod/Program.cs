using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryCarrier categoryCarrier = new CategoryCarrier();
            categoryCarrier.AddCategory(new Category { CategoryName = "Tekstil", Description = "Tekstil ürünleri" });
            categoryCarrier.AddCategory(new Category { CategoryName = "Elektronik", Description = "Elektronik ürünler" });
            categoryCarrier.AddCategory(new Category { CategoryName = "Mobilya", Description = "Mobilya ürünleri" });

            var iterator = categoryCarrier.CreateRepeater();

            while (iterator.NextObje())
            {
                Console.WriteLine(iterator.CurrentObje.CategoryName);
            }
            Console.ReadLine();
        }
    }

    public interface Iterator<T>
    {
        T CurrentObje { get; }
        bool NextObje();
    }

    public interface ICarrier<T>
    {
        Iterator<T> CreateRepeater();
    }

    public class Category
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }

    public class CategoryCarrier : ICarrier<Category>
    {
        public List<Category> AllCategories { get; } = new List<Category>();

        public void AddCategory(Category category) => AllCategories.Add(category);

        public int CategoryCount { get => AllCategories.Count; }

        public Iterator<Category> CreateRepeater()
        {
            return new CategoryIterator(this);
        }
    }

    public class CategoryIterator : Iterator<Category>
    {
        private CategoryCarrier _categoryCarrier;

        public CategoryIterator(CategoryCarrier categoryCarrier)
        {
            this._categoryCarrier = categoryCarrier;
        }

        private int activeIndex = 0;

        public Category CurrentObje { get; private set; }

        public bool NextObje()
        {
            if (activeIndex<_categoryCarrier.CategoryCount)
            {
                CurrentObje = _categoryCarrier.AllCategories[activeIndex++];
                return true;
            }
            return false;
        }
    }

}
