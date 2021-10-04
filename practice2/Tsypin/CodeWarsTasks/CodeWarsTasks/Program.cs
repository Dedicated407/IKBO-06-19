using System.Collections.Generic;
using System.Linq;

namespace CodeWarsTasks
{
    public class Program
    {
        public static string ToCamelCase(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
                return sentence;

            string result = sentence[0].ToString();

            for (int i = 1; i < sentence.Length; i++)
            {
                if (sentence[i] is '_' or '-')
                    continue;
                result += sentence[i - 1] is '_' or '-'
                    ? char.ToUpper(sentence[i]).ToString()
                    : sentence[i].ToString();
            }

            return result;
        }
        
        public static int[] ArrayDiff(IEnumerable<int> firstArray, IEnumerable<int> secondArray) =>
            firstArray.Where(x => !secondArray.Contains(x)).ToArray();
        
        public static string GetReadableTime(int seconds)
        {
            /*
             * HH = hours, padded to 2 digits, range: 00 - 99
             * MM = minutes, padded to 2 digits, range: 00 - 59
             * SS = seconds, padded to 2 digits, range: 00 - 59
             */
            int hours = seconds / 3600;
            int minutes = seconds / 60 - hours * 60;
            seconds = seconds - minutes * 60 - hours * 60 * 60;

            return (hours < 10
                ? "0" + hours
                : hours) + ":" + (minutes < 10
                ? "0" + minutes
                : minutes) + ":" + (seconds < 10
                ? "0" + seconds
                : seconds);
        }
        
        public static bool IsValidWalk(IReadOnlyCollection<string> walk)
        {
            int x = 0;
            int y = 0;
            foreach (var item in walk)
            {
                _ = item switch
                {
                    "n" => x++,
                    "s" => x--,
                    "e" => y++,
                    "w" => y--,
                    _ => default
                };
            }

            return x == 0 && y == 0 && walk.Count == 10;
        }
        
        public static string RomanConvert(int number)
        {
            char[] alphabet = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            string result = "";
            int count = 0;

            while (number > 0)
            {
                int end = number % 10;
                string temp = "";

                while (end > 0)
                {
                    if (end < 4)
                    {
                        temp += alphabet[count];
                        end--;
                    }
                    else if (5 <= end && end < 9)
                    {
                        temp += alphabet[count + 1];
                        end -= 5;
                    }
                    else if (end == 4)
                    {
                        temp += alphabet[count].ToString() + alphabet[count + 1].ToString();
                        end -= 4;
                    }
                    else if (end == 9)
                    {
                        temp += alphabet[count].ToString() + alphabet[count + 2].ToString();
                        end -= 9;
                    }

                }

                result = result.Insert(0, temp);

                count += 2;
                number /= 10;
            }

            return result;
        }

        public static string Extract(int[] array)
        {
            string result = "";
            string begin = "";
            int count = 0;
            
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (begin == "" && array[i] + 1 == array[i + 1])
                {
                    begin = array[i].ToString();
                    count++;
                }
                else if (array[i] + 1 == array[i + 1])
                {
                    count++;
                }

                switch (count)
                {
                    case >= 2 when array[i] + 1 != array[i + 1]:
                        result += begin + "-" + array[i] + ",";
                        count = 0;
                        begin = "";
                        break;
                    case 1 when array[i] + 1 != array[i + 1]:
                        result += array[i - 1] + "," + array[i] + ",";
                        begin = "";
                        count = 0;
                        break;
                    default:
                    {
                        if (array[i] + 1 != array[i + 1])
                        {
                            result += array[i] + ",";
                        }

                        break;
                    }
                }
            }

            if (begin != "" && count >= 2)
                result += begin + "-" + array[^1];
            else if (count == 1 && array.Length - 1 > 0)
            {
                result += array[^2] + "," + array[^1];
            } 
            else if (array.Length > 0)
            {
                result += array[^1];
            }
            
            return result;
        }
    }
}
