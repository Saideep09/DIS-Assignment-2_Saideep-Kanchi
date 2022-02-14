using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;

namespace ISM6225_Assignment_2_Spring_2022
{

    class Program
    {
        static void Main(string[] args)
        {

            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.Write("Most frequent word is : ");
            Console.WriteLine(commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.Write("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 9:
            Console.WriteLine("Question 9");
            int[,] grid = { { 0, 1, 2, 3, 4 }, { 24, 23, 22, 21, 5 }, { 12, 13, 14, 15, 16 }, { 11, 17, 18, 19, 20 }, { 10, 9, 8, 7, 6 } };
            int time = SwimInWater(grid);
            Console.WriteLine("Minimum time required is: {0}", time);
            Console.WriteLine();

            //Question 10:
            Console.WriteLine("Question 10");
            string word1 = "horse";
            string word2 = "ros";
            int minLen = MinDistance(word1, word2);
            Console.WriteLine("Minimum number of operations required are {0}", minLen);
            Console.WriteLine();
        }


        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int num1 = 0;
                int num2 = nums.Length - 1;
                int position = -1;
                while (num1 <= num2)
                {                           
                    //while loop is being used for the binary search 
                    int mid = (num1 + num2) / 2;
                    //to get the middle element in an array
                    if (nums[mid] == target) 
                        return mid; 
                    //if the middle element is found initially 
                    else if (nums[mid] > target)
                    //if the middle element is greater than the target
                    {            
                        num2 = mid - 1;
                        position = mid;
                    }
                    else
                    {
                        num1 = mid + 1;
                        position = mid + 1;
                        //finding out the position
                    }
                }

                return position;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
         
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.
        It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the 
        most frequent non-banned word in the paragraph. 
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), 
        and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */
        public static string tolower(string s)
        {
            //turning all letter in a string to lowercase
            return s.ToLower();
        }
        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                Console.WriteLine(paragraph);
                Dictionary<string, int> map = new Dictionary<string, int>();
                //creating a new dictionary
                string word = "";
                for (int l = 0; l < paragraph.Length; l++)
                //Creating a loop to check every char in paragraph
                {
                    if (paragraph[l] == ',') continue;                         
                    if (paragraph[l] == ' ' || paragraph[l] == '.')
                    //If condition to neglate all the puntuations 
                    {            
                        string newpara = tolower(word);
                        //to lowercase each word in the string
                        if (map.ContainsKey(newpara))
                        {
                            //additing the words to new para
                            map[newpara] = map[newpara] + 1;
                        }
                        else
                        {
                            //creating a new map
                            map[newpara] = 1;
                        }
                        word = "";
                    }
                    else
                    {
                        word = word + paragraph[l];
                    }
                }
                for (int b = 0; b < banned.Length; b++)
                {                         
                    //checking to remove the banned word
                    if (map.ContainsKey(tolower(banned[b])))
                    {
                        map[tolower(banned[b])] = 0;
                    }
                }
                var value = map.Keys.ToList();
                int rep = 0;
                string output = "";
                foreach (var key in value)
                {                                   
                    if (map[key] > rep)
                    //to find out the most frequently repeating word
                    {
                        rep = map[key];
                        output = key;
                    }
                }

                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                //creating a new dictionary
                Dictionary<int, int> lucky_number = new Dictionary<int, int>();
                foreach (var eachnum in arr)
                {
                    //looking for each number in an array arr
                    if (lucky_number.ContainsKey(eachnum))
                    {
                        lucky_number[eachnum] = lucky_number[eachnum] + 1;
                    }
                    else
                    {
                        lucky_number[eachnum] = 1;
                    }
                }
                var value = lucky_number.Keys.ToList();
                int output = -1;
                foreach (var key in value)
                {
                    if (lucky_number[key] == key)
                    //using if statement to find out the lucky number
                    {
                        output = (Math.Max(output, key));
                    }
                }
                return output;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your frie
        nd to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
        
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int num1 = 0;
                int num2 = 0;
                bool[] equal = new bool[secret.Length];
                Dictionary<char, int> map = new Dictionary<char, int>();
                //creating a new dectionary for maping
                for (int x = 0; x < secret.Length; x++)
                {                   
                    //reading each word in secret string
                    if (secret[x] == guess[x])
                    {                            
                        num1++;
                        equal[x] = true;
                        //if char in secret match
                    }
                    else
                    {
                        equal[x] = false;                            
                        //mentioned false to repect again
                        if (map.ContainsKey(secret[x]))
                        {                    
                        //creating a new map
                            map[secret[x]] = map[secret[x]] + 1;
                        }
                        else
                        {
                            map[secret[x]] = 1;                                 
                        }
                    }
                }
                /* var val = map.Keys.ToList();
                // foreach (var key in val)
                // {
                //     Console.Write(key);
                //     Console.WriteLine(map[key]);
                    }
                */
                for (int y = 0; y < guess.Length; y++)
                {                   
                    //repeating to check with guess
                    if (equal[y]) continue;                       
                    if (map.ContainsKey(guess[y]) && map[guess[y]] > 0)
                    {
                        num2++;
                        map[guess[y]] = map[guess[y]] - 1;
                    }
                }
                string output = num1 + "A" + num2 + "B";                           
                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*
        Question 5:
        You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
        Return a list of integers representing the size of these parts.
        Example 1:
        Input: s = "ababcbacadefegdehijhklij"
        Output: [9,7,8]
        Explanation:
        The partition is "ababcbaca", "defegde", "hijhklij".
        This is a partition so that each letter appears in at most one part.
        A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
        */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int stringlen = s.Length;
                List<int> output = new List<int>();
                int[] map = new int[26];
                for (int x = stringlen - 1; x >= 0; x--)
                {
                    if (map[s[x] - 97] == 0)
                    {
                        map[s[x] - 97] = x;
                    }
                }

                int index = 0;
                while (index < stringlen)
                {
                    int lownum = index;
                    int highnum = map[s[index] - 97];
                    int difference = highnum - lownum + 1;
                    for (int y = lownum; y <= highnum; y++)
                    {
                        if (map[s[y] - 97] > highnum)
                        {
                            highnum = map[s[y] - 97];
                            difference = highnum - lownum + 1;
                        }
                    }

                    output.Add(difference);
                    index = highnum + 1;
                }


                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /*
        Question 6
        You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, 
        widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
        You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters 
        on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you 
        can on the second line. Continue this process until you have written all of s.
        Return an array result of length 2 where:
             •	result[0] is the total number of lines.
             •	result[1] is the width of the last line in pixels.
 
        Example 1:
        Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
        Output: [3,60]
        Explanation: You can write s as follows:
                     abcdefghij  	 // 100 pixels wide
                     klmnopqrst  	 // 100 pixels wide
                     uvwxyz      	 // 60 pixels wide
                     There are a total of 3 lines, and the last line is 60 pixels wide.
         Example 2:
         Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
         s = "bbbcccdddaaa"
         Output: [2,4]
         Explanation: You can write s as follows:
                      bbbcccdddaa  	  // 98 pixels wide
                      a           	 // 4 pixels wide
                      There are a total of 2 lines, and the last line is 4 pixels wide.
         */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                int linenum = 1;
                int cur = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    //going through each char
                    int x = s[i] - 97;                   
                    /* if (s[i]=='k' || s[i]=='v')
                      {
                         Console.Write(s[i]);
                       }
                    */
                    if (cur + widths[x] <= 100)
                    {             
                        //to check if we have overflow of lines
                        cur= cur + widths[x];   
                    }
                    else
                    {
                        //else fix the line
                        cur = 0;                         
                        cur = cur + widths[x];    
                        linenum++;                
                    }
                }
                List<int> output = new List<int>();                
                output.Add(linenum);
                output.Add(cur);
                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        
        Question 7:
        Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
        An input string is valid if:
            1.	Open brackets must be closed by the same type of brackets.
            2.	Open brackets must be closed in the correct order.
 
        Example 1:
        Input: bulls_string = "()"
        Output: true
        Example 2:
        Input: bulls_string  = "()[]{}"
        Output: true
        Example 3:
        Input: bulls_string  = "(]"
        Output: false
        */

        public static bool IsValid(string bulls_string10)
        {

            try
            {
                Stack<char> st = new Stack<char>();
                for (int x = 0; x < bulls_string10.Length; x++)
                {
                    //using if to go through each char
                    if (bulls_string10[x] == '(' || bulls_string10[x] == '{' || bulls_string10[x] == '[')
                    {    
                        st.Push(bulls_string10[x]);
                    }
                    if (bulls_string10[x] == ')' || bulls_string10[x] == '}' || bulls_string10[x] == ']')
                    {
                        //using if statement to check and repeat the loop if it si flase
                        if (st.Count <= 0)
                        {
                            return false;
                        }
                        else if (bulls_string10[x] == ')')
                        {
                            if (st.Peek() == '(')
                            {
                                st.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (bulls_string10[x] == '}')
                        {
                            if (st.Peek() == '{')
                            {
                                st.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else if (bulls_string10[x] == ']')
                        {
                            if (st.Peek() == '[')
                            {
                                st.Pop();
                            }
                            else
                            {
                                return false;
                            }
                        }

                    }
                }

                return true;

            }
            catch (Exception)
            {
                throw;
            }


        }



        /*
         Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
            •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation 
            the transformation of a word.
        Return the number of different transformations among all words we have.
 
        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                
                //convert every char to index and to build a translated array to count the char's
                //to provide the morse code by a new array - 26
                string[] M_code = new string[] { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };

                HashSet<string> array = new HashSet<string>();

                //using for to go through each char of an array
                for (int x = 0; x < words.Length; x++)
                {
                    var strbuild = new StringBuilder();
                    foreach (var ch in words[x])
                    {
                        strbuild.Append(M_code[ch - 'a']);
                    }
                    array.Add(strbuild.ToString());
                }
                return array.Count();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /*
            
        Question 9:
        You are given an n x n integer matrix grid where each value grid[i][j] represents the elevation at that point (i, j).
        The rain starts to fall. At time t, the depth of the water everywhere is t. You can swim from a square to another 4-directionally 
        adjacent square if and only if the elevation of both squares individually are at most t. You can swim infinite distances in zero time.
        Of course, you must stay within the boundaries of the grid during your swim.
        Return the least time until you can reach the bottom right square (n - 1, n - 1) if you start at the top left square (0, 0).
        Example 1:
        Input: grid = [[0,1,2,3,4],[24,23,22,21,5],[12,13,14,15,16],[11,17,18,19,20],[10,9,8,7,6]]
        Output: 16
        Explanation: The final route is shown.
        We need to wait until time 16 so that (0, 0) and (4, 4) are connected.
        */
        public static int findpath(int[,] grid, int x, int y, bool[,] path)
        {

            int column1 = grid.GetLength(0);
            int row1 = grid.Length / grid.GetLength(0);
            if (x >= row1 || y >= column1 || x < 0 || y < 0) return 0;
            int ot1, ot2, ot3, ot4;
            if (path[x, y])
            {
                path[x, y] = false;
                ot1 = Math.Max(grid[x, y], findpath(grid, x, y + 1, path));//for right side of the matrix
                ot2 = Math.Max(grid[x, y], findpath(grid, x + 1, y, path));//for lower side of the matrix
                ot3 = Math.Max(grid[x, y], findpath(grid, x - 1, y, path));//for upper side of the matrix
                ot4 = Math.Max(grid[x, y], findpath(grid, x, y - 1, path));//for left side of the matrix
            }
            else
            {
                return 0;
            }

            return Math.Max(Math.Max(ot1, ot2), Math.Max(ot3, ot4));

        }
        public static int SwimInWater(int[,] grid)
        {
            try
            {
                bool[,] path = { { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true }, { true, true, true, true, true } };
                return findpath(grid, 0, 0, path);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
         
        Question 10:
        Given two strings word1 and word2, return the minimum number of operations required to convert word1 to word2.
        You have the following three operations permitted on a word:
        •	Insert a character
        •	Delete a character
        •	Replace a character
         Note: Try to come up with a solution that has polynomial runtime, then try to optimize it to quadratic runtime.
        Example 1:
        Input: word1 = "horse", word2 = "ros"
        Output: 3
        Explanation: 
        horse -> rorse (replace 'h' with 'r')
        rorse -> rose (remove 'r')
        rose -> ros (remove 'e')
        */
        public static int MinDistance(string word1, string word2, Dictionary<string, int> memo)
        {
            if (word1 == word2) return 0;
            if (word1 == "") return word2.Length;
            if (word2 == "") return word1.Length;

            string K = word1 + "#" + word2;
            if (memo.ContainsKey(K)) return memo[K];
            //using Ternary operator and the bool
            string st1 = (word1.Length > 1) ? word1.Substring(1) : "";
            string st2 = (word2.Length > 1) ? word2.Substring(1) : "";

            if (word1[0] == word2[0])
            {
                int res = MinDistance(st1, st2, memo);
                memo.Add(K, res);
            }
            else
            {
                int insert = 1 + MinDistance(word2[0] + word1, word2, memo);
                int delete = 1 + MinDistance(st1, word2, memo);
                int replace = 1 + MinDistance(st1, st2, memo);
                int res = Math.Min(insert, Math.Min(delete, replace));
                memo.Add(K, res);
            }
            return memo[K];
        }
        public static int MinDistance(string word1, string word2)
        {
            try
            {
                return MinDistance(word1, word2, new Dictionary<string, int>());

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

