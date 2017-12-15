using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//    PP 1.6: In C#, write a method that modifies a string using the following rules:
//1. Each word in the input string is replaced with the following: the first letter of the word, the count of
//distinct letters between the first and last letter, and the last letter of the word.For example,
//“Automotive parts" would be replaced by "A6e p3s".
//2. A "word" is defined as a sequence of alphabetic characters, delimited by any non-alphabetic
//characters.
//3. Any non-alphabetic character in the input string should appear in the output string in its original
//relative location.
//We are looking for accuracy, efficiency and solution completeness. Please include this problem
//description in the comment at the top of your solution. The problem is designed to take approximately
//1-2 hours.
namespace VinSolutionsClasses
{
    public class CustomStringModifier
    {
        //regex for checking for all characters that are non-alphabetic (note: non-alphabetic is not the same as non-alphanumeric)
        Regex alphabeticCharacters = new Regex(@"[0-9\s\W_]+"); //'+' helps prevent empty string splits
        //method for creating the modified strings from the input
        public void CreateModifiedStrings(string input)
        {
            List<string> leter = new List<string>();
            //string array to hold split strings from the input
            string[] wordSubstrings = alphabeticCharacters.Split(input);
            foreach (var word in wordSubstrings)
            {
                
                //prevents an empty string created by a split at the end of the input string from trying to create a newWord and causing an exeption.
                if (word != "" && word.Length > 1) //.Length > 1 cannot remove first and last from a single character string. So leaving them as is to prevent exception. Considered > 2 since it's 0, for readability.
                {
                    //create a new string newWord with the current word, last letter removed
                    string newWord = word.Remove((word.Length - 1), 1);
                    //removes first letter from the newWord
                    newWord = newWord.Remove(0, 1);
                    
                    //get the count of unique letters left in the newWord .toLower() to remove uppercase and lowercase (e, E) identifying as different letters.
                    int unique = (newWord.ToLower()).Distinct().Count();
                    //reBuild newWord with first letter of current word, number of unique letters, and last letter of current word.
                    newWord = (word.First() + unique.ToString() + word.Last());
                    //replaces the specific word with the newWord in the input
                    input = Regex.Replace(input, @"(?<=\d|^|\b)" + word + @"(?=\d|$|\b)", newWord);
                    //for testing
                    //Console.WriteLine(newWord);
                }
            }
            Console.WriteLine(input);
        }//end CreateModifiedStrings
    }
}
