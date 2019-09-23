using System;

/// <summary>
/// Dennis Maya 015850768
/// </summary>
namespace Assignment2
{

    /// <summary>
    /// Each IntegerSet object can hold integers in the range 0–100. 
    /// The set is represented by an array of bools
    /// </summary>
    class IntegerSet
    {
        private int minValue = 0;
        private static int maxValue = 101;
        private bool[] bools = new bool[maxValue];

        /// <summary>
        /// The class constructor
        /// </summary>
        IntegerSet()
        {
            for (int i = 0; i < maxValue; i++)
            {
                bools[i] = false;
            }
        }

        /// <summary>
        /// The class overloaded constructor 
        /// </summary>
        /// <param name="intArray"> An array of integers</param>
        IntegerSet(int[] intArray)
        {
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray[i] >= 0 && intArray[i] <= 100)
                {
                    bools[intArray[i]] = true;
                }
                else Console.WriteLine("Invalid Value of " + intArray[i] + " was not included");

            }
        }

        /// <summary>
        /// Unions two IntegerSets
        /// </summary>
        /// <param name="b2"> the second IntegerSet to Union</param>
        /// <returns>returns a Union of the IntegerSets</returns>
        private IntegerSet Union(IntegerSet b2)
        {
            IntegerSet newSet = new IntegerSet();
            for (int i = 0; i < maxValue; i++)
            {
                if (bools[i] || b2.bools[i]) newSet.InsertElement(i);
            }
            return newSet;
        }

        /// <summary>
        /// Intersects two IntegerSets
        /// </summary>
        /// <param name="b2"> the second IntegerSet to intersect</param>
        /// <returns>returns a Intersection of the IntegerSets</returns>
        private IntegerSet Intersection(IntegerSet b2)
        {
            IntegerSet newSet = new IntegerSet();
            for (int i = 0; i < maxValue; i++)
            {
                if (bools[i] && b2.bools[i]) newSet.InsertElement(i);
            }
            return newSet;
        }

        /// <summary>
        /// Inserts an element to the IntegerSet
        /// </summary>
        /// <param name="i">the integer to be inserted</param>
        private void InsertElement(int i)
        {
            bools[i] = true;
        }

        /// <summary>
        /// Removes an element from the IntegerSet
        /// </summary>
        /// <param name="i">the integer to be removed</param>
        private void DeleteElement(int i)
        {
            bools[i] = false;
        }

        /// <summary>
        /// Determines if two IntegerSets are equal
        /// </summary>
        /// <param name="b2">the second IntegerSet to compare</param>
        /// <returns>returns a boolean that states whether the IntegerSets are equal</returns>
        private bool IsEqualTo(IntegerSet b2)
        {
            for (int i = 0; i < maxValue; i++)
            {
                if (bools[i] != b2.bools[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// Creates a string representation of the IntegerSet
        /// </summary>
        /// <returns>returns a string representation of the IntegerSet</returns>
        private String ToString()
        {
            String str = "";
            for (int i = 0; i < maxValue; i++)
            {
                if (bools[i]) str += i.ToString() + " ";
            }

            if (str.Equals("")) str = "---"; 

            return str;
        }

        /// <summary>
        /// Creates an IntegerSet based off of user input
        /// </summary>
        /// <returns>returns an IntegerSet created by a user</returns>
        private static IntegerSet InputSet()
        {
            IntegerSet set = new IntegerSet();
            int val = 0;
            String userInput;
            while (val >= 0)
            {
                Console.WriteLine("Enter an integer 0-100 or a negative integer to end the program");
                userInput = Console.ReadLine();
                val = Convert.ToInt32(userInput);
                if (val <= 100 && val >= 0)
                {
                    set.InsertElement(val);
                }
                else Console.WriteLine("Input out of range, was not included in set");
            }

            return set;
        }

        /// <summary>
        /// The class tester
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // initialize two sets
            Console.WriteLine("Input Set A");
            IntegerSet set1 = InputSet();
            Console.WriteLine("\nInput Set B");
            IntegerSet set2 = InputSet();

            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);

            // prepare output
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine(
            "\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine(
            "\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // test whether two sets are equal
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // test insert and delete
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // test constructor
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
        }
    }
}