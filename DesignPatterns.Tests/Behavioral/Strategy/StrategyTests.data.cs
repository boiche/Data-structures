using Algorithms.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Tests.Behavioral.Strategy
{
    public partial class StrategyTests
    {
        List<ISorting<int>> _sortingIntegers = new List<ISorting<int>>()
        {
            new BubbleSort<int>(),
            new SelectionSort<int>(),
            new InsertionSort<int>(),
            new MergeSort<int>(),
            new QuickSort<int>(),
        };
        List<ISorting<string>> _sortingStrings = new List<ISorting<string>>()
        {
            new BubbleSort<string>(),
            new SelectionSort<string>(),
            new InsertionSort<string>(),
            new MergeSort<string>(),
            new QuickSort<string>(),
        };
        List<ISorting<Product>> _sortingProducts = new List<ISorting<Product>>()
        {
            new BubbleSort<Product>(),
            new SelectionSort<Product>(),
            new InsertionSort<Product>(),
            new MergeSort<Product>(),
            new QuickSort<Product>(),
        };

        IList<int> _integers = new List<int>()
        {
            876,
            12,
            -9532,
            9531,
            int.MinValue,
            int.MaxValue,
            4,
            1234565,
            -5432,
            0
        };
        IList<int> _sortedIntegers = new List<int>()
        {
            int.MinValue,
            -9532,
            -5432,
            0,
            4,
            12,
            876,
            9531,
            1234565,
            int.MaxValue
        };

        IList<string> _strings = new List<string>()
        {
            string.Empty,
            "hellot",
            "WhAt",
            "wHaT",
            "  ensured",
            "_sort it",
            "sort_it"
        };
        IList<string> _sortedStrings = new List<string>()
        {
            string.Empty, 
            "  ensured", 
            "_sort it", 
            "hellot", 
            "sort_it", 
            "wHaT", 
            "WhAt"
        };

        IList<Product> _products = new List<Product>()
        {
            new Product()
            {
                Price = 300,
                Quality = 5
            },
            new Product()
            {
                Price = 1000,
                Quality = 7
            },
            new Product()
            {
                Price = 50,
                Quality = 2
            },
            new Product()
            {
                Price = 10000,
                Quality = 12
            },
            new Product()
            {
                Price = 2,
                Quality = 2
            },
            new Product()
            {
                Price = 0,
                Quality = 1000,
            },
            new Product()
            {
                Price = 42,
                Quality = 0
            }
        };
        IList<Product> _sortedProducts = new List<Product>()
        {
            new Product()
            {
                Price = 42,
                Quality = 0
            },
            new Product()
            {
                Price = 0,
                Quality = 1000,
            },
            new Product()
            {
                Price = 2,
                Quality = 2
            },
            new Product()
            {
                Price = 50,
                Quality = 2
            },
            new Product()
            {
                Price = 300,
                Quality = 5
            },
            new Product()
            {
                Price = 1000,
                Quality = 7
            },
            new Product()
            {
                Price = 10000,
                Quality = 12
            },
        };
    }

    public class Product : IComparable<Product>
    {
        public int Quality { get; set; }
        public int Price { get; set; }
        public decimal Grade
        {
            get
            {
                try
                {
                    return Price / Quality;
                }
                catch (DivideByZeroException)
                {
                    return -1;
                }
            }
        }
        public int CompareTo(Product other) => Grade.CompareTo(other.Grade);
        public override string ToString()
        {
            return $"Quality: {Quality}, Price: {Price}, Grade: {Grade}";
        }
    }
}
