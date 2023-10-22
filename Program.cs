/*
using System.Text;

YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                List<IList<int>> missingRanges = new List<IList<int>>(); // Initialize a list to store missing ranges.
                long currentRangeStart = lower; // Initialize the current range start.

                foreach (int num in nums) // Iterate through the numbers in the input array.
                {
                    if (num > currentRangeStart) // If the number is greater than the current range start.
                    {
                        if (num - currentRangeStart == 1) // If the missing range is just one number.
                        {
                            missingRanges.Add(new List<int> { (int)currentRangeStart, (int)currentRangeStart }); // Add the single missing number.
                        }
                        else if (num - currentRangeStart > 1) // If the missing range is more than one number.
                        {
                            missingRanges.Add(new List<int> { (int)currentRangeStart, (int)(num - 1) }); // Add the missing range.
                        }
                    }

                    currentRangeStart = (long)num + 1; // Update the current range start.
                }

                if (currentRangeStart <= upper) // Check if there is a range extending to the upper limit.
                {
                    if (upper - currentRangeStart == 0) // If the missing range is just one number.
                    {
                        missingRanges.Add(new List<int> { (int)currentRangeStart, (int)currentRangeStart }); // Add the single missing number.
                    }
                    else if (upper - currentRangeStart > 0) // If the missing range is more than one number.
                    {
                        missingRanges.Add(new List<int> { (int)currentRangeStart, (int)upper }); // Add the missing range.
                    }
                }

                return missingRanges; // Return the list of missing ranges.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self-reflection for Question 1:
           - This question involves iterating through the 'nums' array and finding missing ranges.
           
        Recommendations:
           - The code is well-structured and easy to understand.
           - Ensure that the input constraints are met, especially for large inputs.
        */

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {
                Stack<Char> stack = new Stack<Char>(); // Initialize a stack to track open brackets.

                var charArray = s.ToCharArray(); // Convert the input string to a character array.

                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == '(' || charArray[i] == '[' || charArray[i] == '{') // If an open bracket is encountered.
                    {
                        stack.Push(charArray[i]); // Push it onto the stack.
                        continue;
                    }
                    else if (stack.Count == 0) // If a close bracket is encountered, but the stack is empty.
                    {
                        return false; // It's an invalid expression, return false.
                    }
                    Char top = stack.Pop(); // Pop the top element from the stack.

                    // Check if the close bracket matches the open bracket.
                    if (top == '(' && charArray[i] != ')')
                    {
                        return false;
                    }
                    else if (top == '[' && charArray[i] != ']')
                    {
                        return false;
                    }
                    else if (top == '{' && charArray[i] != '}')
                    {
                        return false;
                    }
                }

                // After processing all characters, if the stack is empty, it's a valid expression.
                return stack.Count == 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self-reflection for Question 2:
           - This question involves checking the validity of a string with brackets.
           - The code uses a stack data structure for efficient bracket matching.
           
           Recommendations:
           - The code is well-implemented for the given task.
           - Validate that the string only contains valid characters as per the constraints.
        */

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        {
            try
            {
                int maxProfit = 0; // Initialize the maximum profit to zero.
                int minPrice = prices[0]; // Initialize the minimum price to the first price.

                for (int i = 1; i < prices.Length; i++) // Iterate through the prices.
                {
                    if (prices[i] < minPrice) // If a lower price is found.
                    {
                        minPrice = prices[i]; // Update the minimum price.
                    }
                    else if ((prices[i] - minPrice) > maxProfit) // If a better profit is found.
                    {
                        maxProfit = prices[i] - minPrice; // Update the maximum profit.
                    }
                }

                return maxProfit; // Return the maximum profit.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self-reflection for Question 3:
           - This question involves finding the maximum profit from buying and selling stocks.
           - The code efficiently tracks the minimum price and computes the maximum profit.
          
           Recommendations:
           - The code is well-optimized for the task.
           - Verify that the input array adheres to the constraints.
        */

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string s)
        {
            try
            {
                Dictionary<char, char> strobogrammaticPairs = new Dictionary<char, char>
        {
            { '0', '0' },
            { '1', '1' },
            { '6', '9' },
            { '8', '8' },
            { '9', '6' }
        };
                int left = 0;
                int right = s.Length - 1;

                while (left <= right)
                {
                    char leftChar = s[left];
                    char rightChar = s[right];

                    if (!strobogrammaticPairs.ContainsKey(leftChar) || strobogrammaticPairs[leftChar] != rightChar)
                    {
                        return false; // If a non-strobogrammatic pair is found, return false.
                    }

                    left++;
                    right--;
                }

                return true; // If all pairs are strobogrammatic, return true.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self-reflection for Question 4:
           - This question involves checking if a number is strobogrammatic.
           - The code uses a dictionary to define strobogrammatic pairs and compares characters.
           
           Recommendations:
           - The code is well-structured and efficient.
           - Ensure that the string 'num' only contains valid characters as per the constraints.
        */

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                Dictionary<int, int> countDictionary = new Dictionary<int, int>();
                int goodPairs = 0;

                foreach (int num in nums)
                {
                    if (countDictionary.ContainsKey(num))
                    {
                        goodPairs += countDictionary[num]; // Increase the count of good pairs.
                        countDictionary[num]++;
                    }
                    else
                    {
                        countDictionary[num] = 1; // Initialize the count for this number.
                    }
                }

                return goodPairs; // Return the total count of good pairs.
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Self-reflection for Question 5:
           - This question involves finding the number of good pairs in an array.
           - The code efficiently uses a dictionary to count identical elements.
           
           Recommendations:
           - The code is well-implemented for the task.
           - Ensure that the array 'nums' adheres to the constraints.
        */


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

        public static int ThirdMax(int[] nums)
        {
            try
            {
                HashSet<int> distinctMax = new HashSet<int>();

                foreach (int num in nums)
                {
                    distinctMax.Add(num);

                    if (distinctMax.Count > 3)
                    {
                        distinctMax.Remove(distinctMax.Min()); // Remove the smallest max if there are more than 3.
                    }
                }

                if (distinctMax.Count < 3)
                {
                    return distinctMax.Max(); // If there are less than 3 distinct max numbers, return the maximum.
                }

                return distinctMax.Min(); // Return the third distinct maximum.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self-reflection for Question 6:
           - This question involves finding the third distinct maximum number in an array.
           - The code efficiently uses a HashSet to track distinct maximums.
           
           Recommendations:
           - The code is well-optimized for the task.
           - Verify that the array 'nums' adheres to the constraints.
        */

        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                List<string> possibleStates = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+') // If there's a valid move.
                    {
                        string newState = currentState.Substring(0, i) + "--" + currentState.Substring(i + 2);
                        possibleStates.Add(newState); // Add the new state after the move.
                    }
                }

                return possibleStates; // Return the list of possible next states.
            }
            catch (Exception)
            {
                throw;
            }
        }
        /* Self-reflection for Question 7:
           - This question involves generating possible next moves in a game.
           - The code efficiently identifies and updates the possible states.
          
           Recommendations:
           - The code is well-structured and suited for the task.
           - Validate that the 'currentState' string only contains valid characters as per the constraints.
        */
        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                StringBuilder result = new StringBuilder();
                foreach (char character in s)
                {
                    if (character != 'a' && character != 'e' && character != 'i' && character != 'o' && character != 'u')
                    {
                        result.Append(character);
                    }
                }
                return result.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }

        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
        /* Self-reflection for Question 8:
           - This question involves removing vowels from a string.
           - The code efficiently iterates through the string and builds the result.
        
           Recommendations:
           - The code is well-optimized for the task.
           - Ensure that the string 's' only contains valid characters as per the constraints.
        */
    }
}