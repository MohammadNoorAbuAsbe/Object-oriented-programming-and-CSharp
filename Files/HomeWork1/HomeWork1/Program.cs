using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                int choice = ShowMenuAndGetChoice();
                Console.ForegroundColor = ConsoleColor.Blue;

                switch (choice)
                {
                    case 1:
                        ProcessReducingNumber();
                        break;

                    case 2:
                        ProcessPegNumber();
                        break;

                    case 3:
                        ProcessAscendingArraySum();
                        break;

                    case 4:
                        ProcessDescendingArrayMax();
                        break;

                    case 5:
                        ProcessSentenceEncryption();
                        break;

                    case 6:
                        exit = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        static int ShowMenuAndGetChoice()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Reducing Number");
            Console.WriteLine("2. Peg Number");
            Console.WriteLine("3. Ascending Array Sum");
            Console.WriteLine("4. Descending Array Max");
            Console.WriteLine("5. Sentence Encryption");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice (1-6): ");
            return int.Parse(Console.ReadLine());
        }

        static void ProcessReducingNumber()
        {
            Console.Write("\nEnter a positive integer: ");
            int number = int.Parse(Console.ReadLine());
            int reducedNumber = GetReducedNumber(number);
            Console.WriteLine($"Reduced number: {reducedNumber}");
        }

        static void ProcessPegNumber()
        {
            int numberOfElements = 7;
            int[] userArray = new int[numberOfElements];
            Console.WriteLine($"\nYou will need to enter {numberOfElements} elements.");
            for (int i = 0; i < numberOfElements; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                userArray[i] = int.Parse(Console.ReadLine());
            }
            Console.Write("Enter a number to check if it's a peg: ");
            int numberToCheck = int.Parse(Console.ReadLine());
            bool isPeg = IsPeg(userArray, numberToCheck);
            Console.WriteLine($"Is the number a peg? {isPeg}");
        }

        static void ProcessAscendingArraySum()
        {
            int rows = 5;
            int cols = 4;

            double[,] matrix = new double[rows, cols];
            Console.WriteLine($"\nYou will need to enter elements for a {rows}x{cols} matrix.");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"Enter element [{i},{j}]: ");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }

            bool isAscendingSum = IsRectangularWithDecreasingSum(matrix);
            Console.WriteLine($"Is the matrix sum ascending? {isAscendingSum}");
        }

        static void ProcessDescendingArrayMax()
        {
            Console.Write("\nEnter the number of rows for the jagged array: ");
            int jaggedRows = int.Parse(Console.ReadLine());
            int[][] userJaggedArray = new int[jaggedRows][];

            for (int i = 0; i < jaggedRows; i++)
            {
                Console.Write($"Enter the number of elements in row {i + 1}: ");
                int elementsCount = int.Parse(Console.ReadLine());
                userJaggedArray[i] = new int[elementsCount];

                for (int j = 0; j < elementsCount; j++)
                {
                    Console.Write($"Enter element {j + 1} of row {i + 1}: ");
                    userJaggedArray[i][j] = int.Parse(Console.ReadLine());
                }
            }

            bool isDescendingMax = IsJaggedRectangleWithIncreasingMaximum(userJaggedArray);
            Console.WriteLine($"Is the jagged array max descending? {isDescendingMax}");
        }

        static void ProcessSentenceEncryption()
        {
            string predefinedMessage = "HELLO WORLD, HELLO AEIOU";
            string encryptedPredefinedMessage = EncryptMessage(predefinedMessage);
            Console.WriteLine($"\nOriginal message: {predefinedMessage}");
            Console.WriteLine($"Encrypted message: {encryptedPredefinedMessage}");
        }

        static int GetReducedNumber(int number)
        {
            int lastDigit = number % 10;
            int firstDigit = number;
            while (firstDigit >= 10)
            {
                firstDigit /= 10;
            }
            int reducedNumber = firstDigit * 10 + lastDigit;
            return reducedNumber;
        }

        static bool IsPeg(int[] inputArray, int numberToCheck)
        {
            int[] sortedArray = new int[inputArray.Length];
            Array.Copy(inputArray, sortedArray, inputArray.Length);

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                for (int j = 0; j < sortedArray.Length - i - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }

            int indexInOriginal = -1;
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (inputArray[i] == numberToCheck)
                {
                    indexInOriginal = i;
                    break;
                }
            }

            int indexInSorted = -1;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] == numberToCheck)
                {
                    indexInSorted = i;
                    break;
                }
            }

            return indexInOriginal == indexInSorted;
        }

        static bool IsRectangularWithDecreasingSum(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            double previousSum = double.MinValue;

            for (int i = 0; i < rows; i++)
            {
                double currentSum = 0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentSum += matrix[i, j];
                }

                if (currentSum < previousSum)
                {
                    return false;
                }

                previousSum = currentSum;
            }

            return true;
        }

        static bool IsJaggedRectangleWithIncreasingMaximum(int[][] jaggedArray)
        {
            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                int maxCurrentRow = FindMax(jaggedArray[i]);
                int maxNextRow = FindMax(jaggedArray[i + 1]);

                if (maxCurrentRow > maxNextRow)
                {
                    return false;
                }
            }
            return true;
        }

        static int FindMax(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        static string EncryptMessage(string message)
        {
            string encryptedMessage = "";
            foreach (char currentChar in message)
            {
                switch (currentChar)
                {
                    case 'A':
                        encryptedMessage += '*';
                        break;
                    case 'U':
                        encryptedMessage += '%';
                        break;
                    case 'E':
                        encryptedMessage += '#';
                        break;
                    case 'I':
                        encryptedMessage += '&';
                        break;
                    case 'O':
                        encryptedMessage += '$';
                        break;
                    default:
                        encryptedMessage += currentChar;
                        break;
                }
            }
            return encryptedMessage;
        }
    }
}
