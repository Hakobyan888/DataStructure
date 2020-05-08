using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DataStructureProblems
{
    class PassedTimusProblems
    {
        static void Timus1000()
        {
            string[] a = Console.ReadLine().Split();
            int b = int.Parse(a[0]);
            int c = int.Parse(a[1]);
            Console.WriteLine(c + b);
        }

        static void Timus1001()
        {
            string[] s = Console.In.ReadToEnd()
                .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = s.Length - 1; i >= 0; i--)
            {
                Console.WriteLine("{0:0.0000}", Math.Sqrt(double.Parse(s[i])));
            }


        }

        static void Timus1002()
        {
            Dictionary<char, string> dict = new Dictionary<char, string>();
            List<string> answer = new List<string>();
            dict.Add('1', "ij");
            dict.Add('2', "abc");
            dict.Add('3', "def");
            dict.Add('4', "gh");
            dict.Add('5', "kl");
            dict.Add('6', "mn");
            dict.Add('7', "prs");
            dict.Add('8', "tuv");
            dict.Add('9', "wxy");
            dict.Add('0', "oqz");
            string line = "";

            string number = "";
            while ((line = Console.ReadLine()) != "-1")
            {
                int count = 0;
                number = line;
                int n = int.Parse(Console.ReadLine());
                List<string> words = new List<string>();

                for (int k = 0; k < n; k++)
                {
                    words.Add(Console.ReadLine());
                }

                words = words.OrderByDescending(x => x.Length).ToList();
                int i = 0;
                while (i < number.Length)
                {

                    var str = dict[number[i]];

                    string answerStr = "";
                    foreach (var word in words)
                    {
                        for (int f = 0; f < word.Length; f++)
                        {

                            if (str.Contains(word[f]))
                            {
                                if (i < number.Length - 1)
                                    str = dict[number[++i]];
                            }
                            else
                            {
                                count++;
                                break;
                            }

                            if (f == word.Length - 1)
                            {
                                if (i == number.Length - 1)
                                {
                                    answerStr += word;
                                    i++;
                                    break;
                                }
                                else
                                {
                                    answerStr += word + " ";
                                    break;
                                }

                            }
                        }


                    }

                    if (answerStr == "")
                    {
                        answerStr = "No solution.";
                    }

                    answer.Add(answerStr);
                }

            }

            foreach (var ans in answer)
            {
                Console.WriteLine(ans);
            }
        }

        static void Timus1293()
        {
            string[] values = Console.ReadLine().Split();
            int n = int.Parse(values[0]);
            int a = int.Parse(values[1]);
            int b = int.Parse(values[2]);

            Console.WriteLine(2 * n * a * b);


        }

        static void Timus1787()
        {
            string[] input = Console.ReadLine().Split();
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);


            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));

            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += k - arr[i];
                if (sum > 0)
                {
                    sum = 0;
                }
            }

            Console.WriteLine(Math.Abs(sum));
        }

        static void Timus1820()
        {
            string[] value = Console.ReadLine().Split();
            int n = int.Parse(value[0]);
            int k = int.Parse(value[1]);
            int answer;
            if (n <= k)
            {
                answer = 2;
            }
            else
            {
                if ((n * 2) % k == 0)
                {
                    answer = (int)n * 2 / k;
                }
                else
                {
                    answer = n * 2 / k + 1;
                }
            }

            Console.WriteLine(answer);
        }

        static void Timus2066()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            List<int> arr = new List<int>();

            arr.Add(a);
            arr.Add(b);
            arr.Add(c);

            arr.Sort();
            int answer = 0;
            if (arr[0] - arr[1] * arr[2] > arr[0] - arr[1] - arr[2])
            {
                answer = arr[0] - arr[1] - arr[2];
            }
            else
            {
                answer = arr[0] - arr[1] * arr[2];
            }

            Console.WriteLine(answer);
        }

        static void Timus1785()
        {
            int n = int.Parse(Console.ReadLine());
            if (n <= 4)
            {
                Console.WriteLine("few");
            }
            else if (n <= 9)
            {
                Console.WriteLine("several");
            }
            else if (n <= 19)
            {
                Console.WriteLine("pack");
            }
            else if (n <= 49)
            {
                Console.WriteLine("lots");
            }
            else if (n <= 99)
            {
                Console.WriteLine("horde");
            }
            else if (n <= 249)
            {
                Console.WriteLine("throng");
            }
            else if (n <= 499)
            {
                Console.WriteLine("swarm");
            }
            else if (n <= 999)
            {
                Console.WriteLine("zounds");
            }
            else if (n >= 1000)
            {
                Console.WriteLine("legion");
            }

        }

        static void Timus1409()
        {
            string[] input = Console.ReadLine().Split();
            int harry = int.Parse(input[0]);
            int larry = int.Parse(input[1]);
            int n = harry + larry;
            Console.WriteLine(n - harry - 1 + " " + (n - larry - 1));

        }

        static void Timus2012()
        {
            int n = int.Parse(Console.ReadLine());
            int p = 12;
            int t = 240;
            int b = 45;

            int a = p - n;
            if (a * b <= 240)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }

        static void Timus1877()
        {
            int f = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            if (f % 2 == 0 || s % 2 != 0)
                Console.WriteLine("yes");
            else if (f % 2 != 0 || s % 2 == 0)
                Console.WriteLine("no");
        }

        static void Timus2001()
        {
            string[] input1 = Console.ReadLine().Split();
            string[] input2 = Console.ReadLine().Split();
            string[] input3 = Console.ReadLine().Split();
            int a1 = int.Parse(input1[0]);
            int b1 = int.Parse(input1[1]);
            int a2 = int.Parse(input2[0]);
            int b2 = int.Parse(input2[1]);
            int a3 = int.Parse(input3[0]);
            int b3 = int.Parse(input3[1]);
            int ans1 = a1 - a3;
            int ans2 = b1 - b2;
            Console.WriteLine(ans1 + " " + ans2);
        }

        static void Timus1264()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int answer = 0;
            for (int i = 0; i <= b; i++)
            {
                answer += a;
            }

            Console.WriteLine(answer);
        }

        static void Timus1197()
        {
            int n = int.Parse(Console.ReadLine());
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                answer = 0;
                var input = Console.ReadLine();
                var text = input[0];
                var rank = int.Parse(input[1].ToString());
                if (text + 2 <= 'h')
                {
                    if (rank + 1 <= 8) answer++;
                    if (rank - 1 >= 1) answer++;
                }

                if (text - 2 >= 'a')
                {
                    if (rank + 1 <= 8) answer++;
                    if (rank - 1 >= 1) answer++;
                }
                if (rank + 2 <= 8)
                {
                    if (text + 1 <= 'h') answer++;
                    if (text - 1 >= 'a') answer++;
                }

                if (rank - 2 >= 1)
                {
                    if (text + 1 <= 'h') answer++;
                    if (text - 1 >= 'a') answer++;
                }

                Console.WriteLine(answer);
            }
        }

        static void Timus2100()
        {
            int n = int.Parse(Console.ReadLine());
            int count = n;
            for (int i = 0; i < n; i++)
            {
                if (Console.ReadLine().Contains('+'))
                {
                    count++;
                }
            }
            count += 2;

            if (count == 13)
            {
                count++;
            }

            Console.WriteLine(count * 100);
        }

        static void Timus1880()
        {
            int n1 = int.Parse(Console.ReadLine());
            int[] arr1 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int n2 = int.Parse(Console.ReadLine());
            int[] arr2 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int n3 = int.Parse(Console.ReadLine());
            int[] arr3 = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            int answer = 0;
            for (int i = 0; i < n1; i++)
            {
                if (arr2.Contains(arr1[i]) && arr3.Contains(arr1[i]))
                {
                    answer++;
                }
            }

            Console.WriteLine(answer);
        }

        static void Timus1639()
        {
            string[] input = Console.ReadLine().Split();
            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);
            if ((m * n) % 2 != 0)
            {
                Console.WriteLine("[second]=:]");

            }
            else
            {
                Console.WriteLine("[:=[first]");
            }

        }

        static void Timus1910()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            Dictionary<int, int> allAnswers = new Dictionary<int, int>();
            int i = 0;


            while (i + 3 <= n)
            {
                var value = arr[i] + arr[i + 1] + arr[i + 2];
                if (!allAnswers.ContainsKey(value))
                    allAnswers.Add(value, i + 2);
                i++;
            }
            var answer = allAnswers.Aggregate((l, r) => l.Key > r.Key ? l : r);
            Console.WriteLine(answer.Key + " " + answer.Value);

        }

        static void Timus1924()
        {
            int n = int.Parse(Console.ReadLine());
            if (n % 2 != 0)
            {
                Console.WriteLine("grimy");
            }
            else
            {
                Console.WriteLine("black");
            }
        }

        static void Timus2023()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, List<string>> casesDictionary = new Dictionary<int, List<string>>();
            casesDictionary.Add(1, new List<string> { "Alice", "Ariel", "Aurora", "Phil", "Peter", "Olaf", "Phoebus", "Ralph", "Robin" });
            casesDictionary.Add(2, new List<string> { "Bambi", "Belle", "Bolt", "Mulan", "Mowgli", "Mickey", "Silver", "Simba", "Stitch" });
            casesDictionary.Add(3, new List<string> { "Dumbo", "Genie", "Jiminy", "Kuzko", "Kida", "Kenai", "Tarzan", "Tiana", "Winnie" });
            int currentPos = 1;
            int newPos = 0;
            int answer = 0;
            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                foreach (var cases in casesDictionary)
                {
                    var exists = cases.Value.Exists(x => x.Equals(name));
                    if (exists)
                    {
                        newPos = cases.Key;
                        break;
                    }
                }

                answer += Math.Abs(newPos - currentPos);
                currentPos = newPos;
            }

            Console.WriteLine(answer);
        }

        static void Timus1209()
        {
            int n = int.Parse(Console.ReadLine());
            string answer = "";
            for (int i = 0; i < n; i++)
            {
                long a = int.Parse(Console.ReadLine());
                var ans = Math.Sqrt(8 * a - 7);
                if (ans % 1 == 0) Console.Write("1 ");

                else
                    Console.Write("0 ");
            }
        }

        static void Timus1313()
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = arr[j];
                }

            }
            List<int> answer = new List<int>();

            for (int i = 0; i < n; i++)
            {
                int temp = i;
                for (int j = 0; j <= i; j++)
                {
                    answer.Add(matrix[temp, j]);
                    Console.WriteLine(matrix[temp, j]);
                    temp--;
                }
            }

            for (int j = 1; j < n; j++)
            {
                var temp = j;
                for (int i = n - 1; i > j - 1; i--)
                {
                    answer.Add(matrix[i, temp]);
                    Console.WriteLine(matrix[i, temp]);
                    temp++;
                }
            }

        }

        private static long sum = 0;
        private static long answer = long.MaxValue;
        static void Timus1005()
        {
            long n = int.Parse(Console.ReadLine());
            List<long> arr = new List<long>();
            long[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));
            arr.AddRange(arrRead);
            sum = arr.Sum();
            List<long> comb = new List<long>();
            PrintComb(arr, n, 0, comb);
            Console.WriteLine(answer);
        }
        private static void PrintComb(List<long> arr, long k, int start, List<long> comb)
        {
            Print(comb);

            for (int i = start; i < arr.Count; i++)
            {
                comb.Add(arr[i]);
                PrintComb(arr, k, i + 1, comb);
                comb.RemoveAt(comb.Count - 1);
            }

        }

        private static void Print(List<long> comb)
        {
            var a = sum - comb.Sum();
            if (Math.Abs(a - comb.Sum()) < answer)
            {
                answer = Math.Abs(a - comb.Sum());
            }
            //foreach (var i in comb)
            //{
            //    Console.Write(i);
            //}

            //Console.WriteLine();
        }

        static void Timus1068()
        {
            int n = int.Parse(Console.ReadLine());
            bool minus = n >= 0 ? false : true;
            int answer = 0;
            if (n == 1 || n == 0)
            {
                answer = 1;
                Console.WriteLine(answer);
                return;
            }
            for (int i = 0; i <= Math.Abs(n); i++)
            {
                answer += i;
            }

            if (minus)
            {
                answer = -answer;
                answer++;

            }
            Console.WriteLine(answer);
        }

        static void Timus1319()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int num = 1;
            for (int i = 0; i < n; i++)
            {
                int temp = i;
                for (int j = n - 1; j >= n - 1 - i; j--)
                {
                    matrix[temp, j] = num;
                    temp++;
                    num++;
                }
            }

            for (int j = 1; j < n; j++)
            {
                var temp = j;
                for (int i = n - 1; i > j - 1; i--)
                {
                    matrix[temp, i] = num;
                    temp++;
                    num++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        static void Timus1567()
        {
            var values = new Dictionary<char, int>();
            string input = Console.ReadLine();

            values.Add('a', 1);
            values.Add('b', 2);
            values.Add('c', 3);
            values.Add('d', 1);
            values.Add('e', 2);
            values.Add('f', 3);
            values.Add('g', 1);
            values.Add('h', 2);
            values.Add('i', 3);
            values.Add('j', 1);
            values.Add('k', 2);
            values.Add('l', 3);
            values.Add('m', 1);
            values.Add('n', 2);
            values.Add('o', 3);
            values.Add('p', 1);
            values.Add('q', 2);
            values.Add('r', 3);
            values.Add('s', 1);
            values.Add('t', 2);
            values.Add('u', 3);
            values.Add('v', 1);
            values.Add('w', 2);
            values.Add('x', 3);
            values.Add('y', 1);
            values.Add('z', 2);
            values.Add('.', 1);
            values.Add(',', 2);
            values.Add('!', 3);
            values.Add(' ', 1);

            int answer = 0;

            foreach (var c in input)
            {
                answer += values[c];
            }
            Console.WriteLine(answer);
        }

        static void Timus1581()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            Dictionary<int, int> values = new Dictionary<int, int>();
            List<Tuple<int, int>> items = new List<Tuple<int, int>>();
            int j = 1;

            for (int i = 0; i < arrRead.Length; i++)
            {
                if (i > 0 && items[i - j].Item1 == arrRead[i])
                {
                    int count = items[i - j].Item2;
                    items[i - j] = Tuple.Create(arrRead[i], ++count);
                    j++;
                }
                else
                {
                    items.Add(Tuple.Create(arrRead[i], 1));
                }
            }
            foreach (var val in items)
            {
                Console.Write(val.Item2 + " " + val.Item1 + " ");
            }

        }

        static void Timus1585()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, int> penguins = new Dictionary<string, int> { { "Emperor Penguin", 0 }, { "Little Penguin", 0 }, { "Macaroni Penguin", 0 } };

            for (int i = 0; i < n; i++)
            {
                penguins[Console.ReadLine()]++;
            }

            var answer = penguins.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine(answer);
        }

        static void Timus1263()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            Dictionary<int, int> elections = new Dictionary<int, int>();
            for (int i = 1; i < n + 1; i++)
            {
                elections.Add(i, 0);
            }

            for (int i = 0; i < m; i++)
            {
                int elected = int.Parse(Console.ReadLine());
                elections[elected]++;
            }

            for (int i = 1; i < n + 1; i++)
            {
                decimal a = (decimal)elections[i] / (decimal)m * 100;
                Console.WriteLine(a.ToString("f2") + "%");
            }

        }

        static void Timus1991()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            int unusedBooms = 0;
            int unkilledSoldiers = 0;

            foreach (var item in arrRead)
            {
                if (item - k >= 0)
                {
                    unusedBooms += item - k;
                }
                else
                {
                    unkilledSoldiers += k - item;
                }
            }
            Console.WriteLine(unusedBooms + " " + unkilledSoldiers);

        }

        static void Timus1100()
        {
            int n = int.Parse(Console.ReadLine());
            List<Tuple<int, int>> teams = new List<Tuple<int, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int id = int.Parse(input[0]);
                int m = int.Parse(input[1]);
                teams.Add(Tuple.Create(id, m));
            }
            for (int i = 100; i >= 0; i--)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == teams[j].Item2) Console.WriteLine(teams[j].Item1 + " " + teams[j].Item2);
                }
            }
        }

        static void Timus2056()
        {
            int n = int.Parse(Console.ReadLine());
            List<double> arr = new List<double>();
            for (int i = 0; i < n; i++)
            {
                var mark = double.Parse(Console.ReadLine());
                arr.Add(mark);
            }
            var average = arr.Sum() / n;
            bool isExcelent = arr.All(item => item == 5);
            if (arr.Contains(3))
            {
                Console.WriteLine("None");
            }
            else if (isExcelent)
            {
                Console.WriteLine("Named");
            }
            else if (average >= 4.5)
            {
                Console.WriteLine("High");
            }

            else
            {
                Console.WriteLine("Common");
            }
        }

        static void Timus1493()
        {
            int ticket = int.Parse(Console.ReadLine()) + 1;
            int firstNum = ticket / 1000;
            int secondNum = ticket % 1000;
            int firstSum = 0;
            int secondSum = 0;

            for (int i = 0; i < 3; i++)
            {
                firstSum += firstNum % 10;
                firstNum = firstNum / 10;
                secondSum += secondNum % 10;
                secondNum = secondNum / 10;
            }
            if (firstSum == secondSum)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                ticket = ticket - 2;
                firstNum = ticket / 1000;
                secondNum = ticket % 1000;
                firstSum = 0;
                secondSum = 0;
                for (int i = 0; i < 3; i++)
                {
                    firstSum += firstNum % 10;
                    firstNum = firstNum / 10;
                    secondSum += secondNum % 10;
                    secondNum = secondNum / 10;
                }
                if (firstSum == secondSum)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
        }

        static void Timus1607()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int c = int.Parse(input[2]);
            int d = int.Parse(input[3]);
            if (a > c)
            {
                c = a;
            }
            while (a < c)
            {
                a += b;
                if (c - d < a)
                {
                    break;
                }
                c -= d;
            }
            Console.WriteLine(Math.Min(a, c));
        }

        static void Timus1876()
        {
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            int answer = 0;
            if (a > b)
            {
                answer = 2 * a + 39;
            }
            else
            {
                answer = 2 * b + 40;
            }
            Console.WriteLine(answer);
        }

        static void Timus1110()
        {
            string[] input = Console.ReadLine().Split();
            BigInteger n = int.Parse(input[0]);
            BigInteger m = int.Parse(input[1]);
            BigInteger y = int.Parse(input[2]);
            string ans = "";
            for (int i = 1; i < m; i++)
            {
                if (BigInteger.ModPow(i, n, m) == y)
                {
                    if (ans == "")
                    {
                        ans += i.ToString();
                    }
                    else
                    {
                        ans += " " + i.ToString();
                    }
                }
            }
            if (ans == "")
            {
                Console.WriteLine("-1");
                return;
            }
            Console.WriteLine(ans);

        }

        static void Timus1349()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("1 2 3");
            }
            else if (n == 2)
            {
                Console.WriteLine("3 4 5");
            }
            else
            {
                Console.WriteLine("-1");
            }
        }

        static void Timus1545()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> lines = new List<string>();
            for (int i = 0; i < n; i++)
            {
                lines.Add(Console.ReadLine());
            }

            char character = char.Parse(Console.ReadLine());
            List<string> answer = new List<string>();
            foreach (var item in lines)
            {
                if (item[0] == character)
                {
                    answer.Add(item);
                }
            }
            answer.Sort();
            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }
        }

        static void Timus1496()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            Dictionary<string, int> answer = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                if (pairs.ContainsKey(input))
                {
                    if (!answer.ContainsKey(input))
                    {
                        answer.Add(input, i);
                    }
                }
                else
                {
                    pairs.Add(input, i);
                }
            }
            foreach (var item in answer)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Timus1893()
        {
            char[] alpha = "LABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray();
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 4)
                    {
                        pairs.Add(a, "window");

                    }
                    else
                    {
                        pairs.Add(a, "aisle");
                    }
                }
            }

            for (int i = 3; i < 21; i++)
            {
                for (int j = 1; j < 7; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 6)
                    {
                        pairs.Add(a, "window");
                    }
                    else if (j % 2 == 0 || j % 2 == 1)
                    {
                        pairs.Add(a, "aisle");
                    }
                }

            }

            for (int i = 21; i < 66; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    string a = $"{i}{alpha[j]}";
                    if (j == 1 || j == 10)
                    {
                        pairs.Add(a, "window");
                    }
                    else if (j == 3 || j == 4 || j == 7 || j == 8)
                    {
                        pairs.Add(a, "aisle");
                    }
                    else
                    {
                        pairs.Add(a, "neither");
                    }
                }
            }

            string input = Console.ReadLine();

            Console.WriteLine(pairs[input]);


        }

        static void Timus1881()
        {
            string[] input = Console.ReadLine().Split();
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            int n = int.Parse(input[2]);

            List<string> words = new List<string>();
            int pages = 1;
            int currentLine = 1;

            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine() + " ");
            }
            string a = "";
            for (int i = 0; i < n; i++)
            {
                if (a.Length + words[i].Length - 1 <= w)
                {
                    a += words[i];
                }
                else
                {
                    currentLine++;
                    a = words[i];
                }
                if (currentLine > h)
                {
                    pages++;
                    currentLine = 1;
                }
            }
            Console.WriteLine(pages);
        }

        static void Timus1196()
        {
            long n = long.Parse(Console.ReadLine());
            HashSet<long> dates = new HashSet<long>();
            for (int i = 0; i < n; i++)
            {
                dates.Add(long.Parse(Console.ReadLine()));
            }
            long m = int.Parse(Console.ReadLine());
            int res = 0;
            for (long i = 0; i < m; i++)
            {
                long value = long.Parse(Console.ReadLine());
                if (dates.Contains(value))
                {
                    res++;
                }
            }
            Console.WriteLine(res);
        }

        static void Timus1837()
        {
            int n = int.Parse(Console.ReadLine());
            List<List<string>> groups = new List<List<string>>();
            for (int i = 0; i < n; i++)
            {
                var value = new List<string>();
                value.AddRange(Console.ReadLine().Split());
                groups.Add(value);
            }
        }

        static void Timus1563()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                set.Add(Console.ReadLine());
            }
            Console.WriteLine(n - set.Count);

        }

        static void Timus1636()
        {
            string[] input = Console.ReadLine().Split();
            int T1 = int.Parse(input[0]);
            int T2 = int.Parse(input[1]);
            int answer = 0;
            int[] arrRead = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            for (int i = 0; i < 10; i++)
            {
                answer += arrRead[i] * 20;
            }
            if (T1 <= T2 - answer)
            {
                Console.WriteLine("No chance.");
            }
            else
            {
                Console.WriteLine("Dirty debug :(");
            }
        }

        static void Timus1654()
        {
            string input = Console.ReadLine();
            Stack<char> set = new Stack<char>();
            for (int i = input.Length - 1; i > -1; i--)
            {
                if (set.Count > 0 && set.Peek() == input[i])
                {
                    set.Pop();
                }
                else
                {
                    set.Push(input[i]);
                }
            }
            int n = set.Count;
            for (int i = 0; i < n; i++)
            {
                Console.Write(set.Pop());
            }
        }

        static void Timus1925()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            int difference = (n + 1) * 2;
            int sumNum = k;
            int ansNum = 0;
            for (int i = 0; i < n; i++)
            {
                string[] inp = Console.ReadLine().Split();

                sumNum += int.Parse(inp[0]);
                ansNum += int.Parse(inp[1]);
            }
            if (sumNum - ansNum - difference > 0)
            {
                Console.WriteLine(sumNum - ansNum - difference);
            }
            else
            {
                Console.WriteLine("Big Bang!");
            }
        }

        static void Timus1617()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (pairs.ContainsKey(input))
                {
                    pairs[input]++;
                }
                else
                {
                    pairs.Add(input, 1);
                }
            }
            int count = 0;
            foreach (var item in pairs)
            {
                if (item.Value >= 4)
                {
                    count += item.Value / 4;
                }
            }
            Console.WriteLine(count);
        }

        static void Timus2002()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();
            bool[] isLogged = new bool[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                string user = input[1];
                string password = "";
                if (input.Length == 3)
                    password = input[2];
                int userLoggedIndex = users.Keys.ToList().IndexOf(user);
                switch (command)
                {
                    case "register":
                        if (!users.ContainsKey(user))
                        {
                            users.Add(user, password);
                            Console.WriteLine("success: new user added");
                        }
                        else
                        {
                            Console.WriteLine("fail: user already exists");
                        }
                        break;
                    case "login":
                        if (!users.ContainsKey(user))
                        {
                            Console.WriteLine("fail: no such user");
                        }
                        else if (users[user] != password)
                        {
                            Console.WriteLine("fail: incorrect password");
                        }
                        else if (isLogged[userLoggedIndex])
                        {
                            Console.WriteLine("fail: already logged in");
                        }
                        else
                        {
                            isLogged[userLoggedIndex] = true;
                            Console.WriteLine("success: user logged in");
                        }
                        break;
                    case "logout":
                        if (!users.ContainsKey(user))
                        {
                            Console.WriteLine("fail: no such user");
                        }
                        else if (!isLogged[userLoggedIndex])
                        {
                            Console.WriteLine("fail: already logged out");
                        }
                        else
                        {
                            isLogged[userLoggedIndex] = false;
                            Console.WriteLine("success: user logged out");
                        }
                        break;
                }
            }
        }

        static void Timus1518()
        {
            string[] input = Console.ReadLine().Split();
            long n = long.Parse(input[0]);
            long x = long.Parse(input[1]);
            long y = long.Parse(input[2]);

            List<long> k = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            List<long> c = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            while (k.Count != x)
            {
                long answer = 0;
                for (long i = c.Count - 1; i > -1; i--)
                {
                    answer += k[(int)(i)] * c[(int)(i)];
                }
                answer %= y;
                k.Add(answer);
                k.RemoveAt(0);
                x--;
            }
            Console.WriteLine(k.Last());
        }

        static void Timus1152()
        {

        }

        static void Timus1651()
        {

        }

        static void Timus1133()
        {

        }

        static void Timus1518Working()
        {
            var nxy = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var n = nxy[0];
            var x = nxy[1];
            var y = nxy[2];
            var k = Console.ReadLine().Split(' ').Select(long.Parse).Reverse().ToArray();
            var c = Console.ReadLine().Split(' ').Select(long.Parse).Reverse().ToArray();
            var matrix = new long[n, n];
            for (int i = 1; i < n; i++)
            {
                matrix[i, i - 1] = 1;
            }
            for (int i = 0; i < n; i++)
            {
                matrix[0, i] = c[i];
            }
            var f = FindPow(matrix, x - n, y, n);
            long ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += f[0, i] * k[i];
                ans %= y;
            }
            Console.WriteLine(ans);
        }
        static long[,] FindPow(long[,] matrix, long a, long mod, long n)
        {
            var res = new long[n, n];
            for (int i = 0; i < n; i++)
                res[i, i] = 1;
            while (a > 0)
            {
                if ((a & 1) == 1)
                    res = MatrixMul(res, matrix, mod, n);
                matrix = MatrixMul(matrix, matrix, mod, n);
                a /= 2;
            }
            return res;
        }
        static long[,] MatrixMul(long[,] a, long[,] b, long mod, long n)
        {
            var res = new long[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    long current = 0;
                    for (int k = 0; k < n; k++)
                    {
                        current += a[i, k] * b[k, j];
                        current %= mod;
                    }
                    res[i, j] = current;
                }
            }
            return res;
        }

        static void Timus1343()
        {
            int n = int.Parse(Console.ReadLine());
            string number;
            if (n > 0)
                number = Console.ReadLine();
            else
                number = "0";
            number = number.PadRight(12, '0');
            long num = long.Parse(number);
            while (true)
            {
                if (IsPrime(num))
                {
                    var ans = num.ToString();
                    Console.WriteLine(ans.PadLeft(12, '0'));
                    break;
                }
                ++num;
            }
        }

        static bool IsPrime(long n)
        {
            for (long i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return n > 1;
        }

        static void Timus1146()
        {
            int n = int.Parse(Console.ReadLine());
            Matrix matrix = new Matrix(n);
            matrix.Input();
            matrix.PrecalcPrefixSums();
            int max = Matrix.el[0, 0];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    for (int l = i; l < n; l++)
                        for (int r = j; r < n; r++)
                        {
                            int sum = matrix.GetSubmatrixSum(i, j, l, r);
                            max = Math.Max(sum, max);
                        }
            Console.WriteLine(max);
        }

    }
}
