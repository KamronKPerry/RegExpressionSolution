using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssessmentClasses;

namespace VinSolutionsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStringModifier customStringModifier = new CustomStringModifier();
            Console.WriteLine("This Console Application will divide an inputed string into words and output each word's first and last letter,\n seperated by the number of distinct letters between the first and last letters.");
            Console.WriteLine("Please input a string");
            customStringModifier.CreateModifiedStrings(Console.ReadLine());
        }
    }
}
