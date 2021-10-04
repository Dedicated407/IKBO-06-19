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

            string res = sentence[0].ToString();

            for (int i = 1; i < sentence.Length; i++)
            {
                if (sentence[i] is '_' or '-')
                    continue;
                res += sentence[i - 1] is '_' or '-'
                    ? char.ToUpper(sentence[i]).ToString()
                    : sentence[i].ToString();
            }

            return res;
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
            int hours = seconds / 3600, minutes = seconds / 60 - hours * 60;
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
            int x = 0, y = 0;
            foreach (var item in walk)
                _ = item switch
                {
                    "n" => x++,
                    "s" => x--,
                    "e" => y++,
                    "w" => y--,
                    _ => default
                };

            return x == 0 && y == 0 && walk.Count == 10;
        }
        
        public static string RomanConvert(int number)
        {
            char[] alphabet = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            string res = "";
            int count = 0;

            while (number > 0)
            {
                int end = number % 10;
                string str = "";

                while (end > 0)
                {
                    if (end < 4)
                    {
                        str += alphabet[count];
                        end--;
                    }
                    else if (5 <= end && end < 9)
                    {
                        str += alphabet[count + 1];
                        end -= 5;
                    }
                    else if (end == 4)
                    {
                        str += alphabet[count].ToString() + alphabet[count + 1].ToString();
                        end -= 4;
                    }
                    else if (end == 9)
                    {
                        str += alphabet[count].ToString() + alphabet[count + 2].ToString();
                        end -= 9;
                    }

                }

                res = res.Insert(0, str);

                count += 2;
                number /= 10;
            }

            return res;
        }

        public static string Extract(int[] args)
        {
            string res = "", begin = "";
            int count = 0;
            
            
            for (int i = 0; i < args.Length - 1; i++)
            {
                if (begin == "" && args[i] + 1 == args[i + 1])
                {
                    begin = args[i].ToString();
                    count++;
                }
                else if (args[i] + 1 == args[i + 1])
                {
                    count++;
                }

                switch (count)
                {
                    case >= 2 when args[i] + 1 != args[i + 1]:
                        res += begin + "-" + args[i] + ",";
                        count = 0;
                        begin = "";
                        break;
                    case 1 when args[i] + 1 != args[i + 1]:
                        res += args[i - 1] + "," + args[i] + ",";
                        begin = "";
                        count = 0;
                        break;
                    default:
                    {
                        if (args[i] + 1 != args[i + 1])
                        {
                            res += args[i] + ",";
                        }

                        break;
                    }
                }
            }

            if (begin != "" && count >= 2)
                res += begin + "-" + args[args.Length - 1];
            else if (count == 1 && args.Length - 1 > 0)
            {
                res += args[args.Length - 2] + "," + args[args.Length - 1];
            } 
            else if (args.Length > 0)
            {
                res += args[args.Length - 1];
            }
            
            return res;
        }
    }
}
