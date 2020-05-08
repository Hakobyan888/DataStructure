using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;

namespace DataStructureProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Timus1280();
        }

        //Not solved
        //static void Timus1732()
        //{
        //    string first = Console.ReadLine();
        //    string second = Console.ReadLine();
        //    List<string> firstArr = string.Join(" ", first.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Split().ToList();
        //    List<string> secondArr = string.Join(" ", second.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).Split().ToList();
        //    string answer = "";
        //    List<ulong> hashes = new List<ulong>();
        //    List<int> indexes = new List<int>();
        //    for (int i = 0; i < firstArr.Count; i++)
        //    {
        //        var createdHashes = StringHash.CreateAllHashes(firstArr[i]);
        //        hashes.AddRange(createdHashes);
        //        for (int j = 0; j < createdHashes.Length; j++)
        //        {
        //            indexes.Add(i);
        //        }
        //    }
        //    for (int i = 0; i < (secondArr.Count > firstArr.Count ? secondArr.Count : firstArr.Count); i++)
        //    {
        //        var firstHash = StringHash.CreateAllHashes(firstArr[i]).Last();
        //        var hash = StringHash.CreateAllHashes(secondArr[i]).Last();
        //        if (firstHash != hash)
        //        {
        //            var hashIndex = hashes.IndexOf(firstHash);
        //            var index = indexes[hashIndex];
        //            var firstWord = firstArr[index];
        //            for (int j = 0; j < firstWord.Length; j++)
        //            {
        //                answer += "_";
        //            }
        //            answer += " ";
        //        }
        //        if (hashes.Contains(hash))
        //        {
        //            var hashIndex = hashes.IndexOf(hash);
        //            var index = indexes[hashIndex];
        //            var firstWord = firstArr[index];
        //            answer += secondArr[i];
        //            for (int j = secondArr[i].Length; j < firstWord.Length; j++)
        //            {
        //                answer += "_";
        //            }
        //            answer += " ";
        //        }
        //    }
        //    Console.WriteLine(answer);
        //}


        #region Timus1115 not solved
        static List<int> shipLengths = new List<int>();
        static bool[] visited;
        static void Timus1115()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);
            List<int> rowsLength = new List<int>();


            for (int i = 0; i < n; i++)
            {
                shipLengths.Add(int.Parse(Console.ReadLine()));
            }
            shipLengths.Sort();
            shipLengths.Reverse();
            for (int i = 0; i < m; i++)
            {
                rowsLength.Add(int.Parse(Console.ReadLine()));
            }
            rowsLength.Sort();
            for (int i = 0; i < m; i++)
            {
                var ships = new List<int>();
                ships.AddRange(shipLengths);
                var comb = new List<int>();
                visited = new bool[ships.Count];
                CalculateShips(rowsLength[i], ships, 0, 0, comb);
            }
        }
        static void CalculateShips(int rowLength, List<int> ships, int start, int answer, List<int> comb)
        {
            if (rowLength == answer)
            {
                foreach (var item in comb)
                {
                    shipLengths.Remove(item);
                }
                comb.Sort();
                comb.Reverse();
                PrintShips(comb);
                return;
            }

            if (rowLength < answer)
            {
                return;
            }

            for (int i = start; i < ships.Count; i++)
            {
                //while (ships[i] + answer > rowLength && i < ships.Count - 1)
                //{
                //    i++;
                //}
                if (rowLength == answer) return;
                comb.Add(ships[i]);
                CalculateShips(rowLength, ships, i + 1, answer + ships[i], comb);
                comb.Remove(ships[i]);
            }

        }

        static void PrintShips(List<int> ships)
        {
            Console.WriteLine(ships.Count);
            foreach (var item in ships)
            {
                if (item == ships.Last()) Console.Write(item);
                else Console.Write(item + " ");
            }
            Console.WriteLine();
        }
        #endregion


        static void Timus2035()
        {
            string[] input = Console.ReadLine().Split();

            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            int c = int.Parse(input[2]);

            if (x + y < c)
            {
                Console.WriteLine("Impossible");
            }
            else
            {
                int a = Math.Min(x, y);
                int b = c - a;
                while (b < 0 && a > 0)
                {
                    a--;
                    b = c - a;
                }
                if (b > y || a > x)
                {
                    int temp = a;
                    a = b;
                    b = temp;
                }
                Console.WriteLine($"{a} {b}");
            }

        }

        static void Timus1025()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> groups = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();

            groups.Sort();

            int minGroups = 0;

            if (groups.Count % 2 == 1)
            {
                minGroups = groups.Count / 2;
            }
            else
            {
                minGroups = groups.Count / 2 - 1;
            }

            int answer = 0;

            for (int i = 0; i <= minGroups; i++)
            {
                answer += groups[i] / 2 + 1;
            }

            Console.WriteLine(answer);
        }

        static void Timus1224()
        {
            string[] input = Console.ReadLine().Split();
            long n = int.Parse(input[0]);
            long m = int.Parse(input[1]);

            long answer = Math.Min(2 * (n - 1), 2 * m - 1);
            Console.WriteLine(answer);

        }


        static void Timus1457()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp));
            double answer = 0;
            foreach (var item in items)
            {
                answer += item;
            }

            answer /= n;
            Console.WriteLine(string.Format("{0:0.000000}", answer));

        }

        static void Timus1083()
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            string factors = input[1];
            int answer = n;
            var a = n % factors.Length;
            int i = 1;
            while (n - i * factors.Length > 0)
            {
                answer *= n - i * factors.Length;
                i++;
            }
            Console.WriteLine(answer);
        }

        static void Timus1638()
        {
            string[] input = Console.ReadLine().Split();


        }


        static void Timus1935()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();
            items.Sort();
            int answer = items[0];

            for (int i = 1; i < n; i++)
            {
                answer += Math.Max(items[i], items[i - 1]);
            }
            answer += items.Last();
            Console.WriteLine(answer);
        }

        static void Timus2031()
        {
            int n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                Console.WriteLine("11");
            }
            else if (n == 2)
            {
                Console.WriteLine("11 01");
            }
            else if (n == 3)
            {
                Console.WriteLine("06 68 88");
            }
            else if (n == 4)
            {
                Console.WriteLine("16 06 68 88");
            }
            else
            {
                Console.WriteLine("Glupenky Pierre");
            }
        }

        static void Timus2111()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));
            items = mergeSort(items);
            long answer = 0;
            long sum = items.Sum();
            for (int i = 0; i < n; i++)
            {
                answer += sum * items[i];
                sum -= items[i];
                answer += sum * items[i];
            }
            Console.WriteLine(answer);
        }

        public static long[] mergeSort(long[] array)
        {
            long[] left;
            long[] right;
            long[] result = new long[array.Length];
            if (array.Length <= 1)
                return array;
            long midPoint = array.Length / 2;
            left = new long[midPoint];
            if (array.Length % 2 == 0)
                right = new long[midPoint];
            else
                right = new long[midPoint + 1];
            for (long i = 0; i < midPoint; i++)
                left[i] = array[i];
            long x = 0;
            for (long i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        public static long[] merge(long[] left, long[] right)
        {
            long resultLength = right.Length + left.Length;
            long[] result = new long[resultLength];
            long indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] >= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        static void Timus1502()
        {
            long n = int.Parse(Console.ReadLine());

            Console.WriteLine(n * (n + 1) * (n + 2) / 2);
        }

        static void Timus1131()
        {
            string[] input = Console.ReadLine().Split();
            long n = int.Parse(input[0]);
            long k = int.Parse(input[1]);
            long currentComps = 2;
            long time = 1;
            if (k == 1)
            {
                time = n - 1;
                Console.WriteLine(time);
                return;
            }
            if (n == 1)
            {
                Console.WriteLine("0");
                return;
            }
            while (currentComps < Math.Min(k, n))
            {
                currentComps += currentComps;
                time += 1;
            }
            if (currentComps < n)
            {
                if ((n - currentComps) % k == 0)
                    time += (n - currentComps) / k;
                else
                    time += (n - currentComps) / k + 1;
            }
            Console.WriteLine(time);
        }

        static void Timus1792()
        {
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp));

            long count = 0;
            for (int i = 0; i < 7; i++)
            {
                items[i] = items[i] == 1 ? 0 : 1;
                if (items[4] == (items[1] + items[2] + items[3]) % 2)
                {
                    count++;
                }
                if (items[5] == (items[0] + items[2] + items[3]) % 2)
                {
                    count++;
                }
                if (items[6] == (items[0] + items[1] + items[3]) % 2)
                {
                    count++;
                }
                if (count == 3)
                {
                    break;
                }
                else
                {
                    items[i] = items[i] == 1 ? 0 : 1;
                    count = 0;
                }
            }
            foreach (var item in items)
            {
                Console.Write(item + " ");
            }


        }

        static void Timus1139()
        {
            string[] input = Console.ReadLine().Split();
            int divider = int.Parse(input[0]) - 1;
            int divident = int.Parse(input[1]) - 1;

            int answer = divider + divident - FindCrossesOnTheWay(divident, divider);
            Console.WriteLine(answer);
        }

        static int FindCrossesOnTheWay(int divider, int divident)
        {
            if (divider < divident)
            {
                int temp = divider;
                divider = divident;
                divident = temp;
            }
            int crosses = 0;
            for (int i = 1; i <= divider; i++)
            {
                if ((divident * i) % divider == 0) crosses++;
            }
            return crosses;
        }

        static void Timus1290()
        {
            int n = int.Parse(Console.ReadLine());
            long[] arr = new long[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            arr = mergeSort(arr);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        static void Timus1404()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string input = Console.ReadLine();
            int[] arr = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                arr[i] = alphabet.IndexOf(input[i]);
            }
            for (int i = 1; i < arr.Length; i++)
            {
                int secStep = 0;
                while ((secStep + arr[i - 1]) % 26 != arr[i])
                {
                    secStep++;
                }
                arr[i] = arr[i - 1] + secStep;
            }
            for (int i = arr.Length - 1; i > 0; i--)
            {
                arr[i] -= arr[i - 1];
            }
            arr[0] -= 5;
            if (arr[0] < 0)
            {
                arr[0] += 26;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(alphabet[arr[i]]);
            }
        }

        static void Timus2011()
        {
            int n = int.Parse(Console.ReadLine());

            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            items.Sort();
            if (items.All(x => x == items.First()) || items.Count < 3)
            {
                Console.WriteLine("No");
                return;
            }

            if (items.Count >= 6)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                if (items.Contains(1) && items.Contains(2) && items.Contains(3))
                {
                    Console.WriteLine("Yes");
                    return;
                }
                else if (items.Count == 4)
                {
                    if (items.First() == items[2] || items[1] == items.Last())
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else if (items.Count == 5)
                {
                    if (items.Last() != items[items.Count - 2])
                    {
                        Console.WriteLine("No");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Yes");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No");
                    return;
                }
            }
        }

        static void Timus2025()
        {
            int t, n, k, i, a, b, x, res;
            t = int.Parse(Console.ReadLine());
            for (i = 0; i < t; i++)
            {
                string[] input = Console.ReadLine().Split();
                n = int.Parse(input[0]);
                k = int.Parse(input[1]);
                if (n % k == 0)
                {
                    x = n / k;
                    res = n * (n - x) / 2;
                    Console.WriteLine(res);
                }
                else
                {
                    x = n / k;
                    b = n - k * x;
                    a = k - b;
                    res = ((n - x) * a * x + (n - x - 1) * (x + 1) * b) / 2;
                    Console.WriteLine(res);
                }
            }
        }

        static void Timus1353()
        {
            //int[] ways = new int[1000];
            //long sum = 0;
            //long s = long.Parse(Console.ReadLine());
            //long n = (long)Math.Pow(10, 9);
            //int i = 1;
            //if (s == 1) sum++;
            //if (s > 69)
            //{
            //    i = 8;
            //}
            //for (int i = 0; i <= 10; i++)
            //{
            //    //sum += findCount(i, s);
            //    dfs(i, s);
            //}
            //Console.WriteLine(count);
            var s = Convert.ToInt32(Console.ReadLine());
            var VF = new long[s + 1];
            VF[0] = 1;
            if (s == 1)
                Console.WriteLine(10);
            else
            {
                for (int i = 1; i < 10; i++)
                    for (int j = s; j >= 0; j--)
                        for (int d = 1; d <= Math.Min(9, j); d++)
                            VF[j] += VF[j - d];
                Console.WriteLine(VF[s]);
            }
        }
        static int count = 0;

        public static long[] VF;
        //public static long f(int N, long S)
        //{
        //    if (S < 0) return 0;
        //    if (N == 0)
        //        return S == 0 ? 1 : 0;
        //    if (memo[N, S] != 0)
        //        return memo[N, S];
        //    long ans = 0;
        //    for (int k = 0; k <= 9; k++)
        //        ans += f(N - 1, S - k);
        //    return memo[N, S] = ans;
        //}

        //public static long g(int N, long S)
        //{
        //    return f(N, S) - f(N - 1, S);
        //}

        static void Timus2068()
        {
            int n = int.Parse(Console.ReadLine());
            var items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();
            items.Sort();
            var comb = items;
            bool firstPlayer = true;

            foreach (var item in items)
            {
                if (item / 2 % 2 == 0)
                {
                    firstPlayer = !firstPlayer;
                }
            }
            if (firstPlayer)
                Console.WriteLine("Daenerys");
            else
                Console.WriteLine("Stannis");
        }

        //static void Timus1297()
        //{
        //    string input = Console.ReadLine();
        //    var inputReverse = input.Reverse().ToList();
        //    string inReverse = "";
        //    for (int i = 0; i < inputReverse.Count(); i++)
        //    {
        //        inReverse += inputReverse[i];
        //    }
        //    StringHashStruct inputHash = new StringHashStruct(input);
        //    StringHashStruct inputReverseHash = new StringHashStruct(inReverse);

        //    List<string> result = new List<string>();

        //    for (int i = 0; i < input.Length; i++)
        //    {
        //        for (int j = i; j < input.Length; j++)
        //        {
        //            if (inputHash.GetSubstringHash(i, j) == inputReverseHash.GetSubstringHash(input.Length - j - 1, input.Length - i - 1))
        //            {
        //                result.Add(input.Substring(i, j - i + 1));
        //            }
        //        }
        //    }
        //    if (result[0].First() != result[0].Last())
        //        result.Remove(result[0]);
        //    Console.WriteLine(result.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur));

        //}

        static void Timus1837()
        {
            int n = int.Parse(Console.ReadLine());
            Graph<string> graph = new Graph<string>();
            GraphAlgorithms<string> algorithms = new GraphAlgorithms<string>();
            string name = "Isenbaev";
            bool isIsenbayev = false;
            double dist = 1;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (!isIsenbayev && input.Contains("Isenbaev")) isIsenbayev = true;
                graph.AddVertexToList(input[0]);
                graph.AddVertexToList(input[1]);
                graph.AddVertexToList(input[2]);
                graph.AddEdgeToList(Tuple.Create(input[0], input[1], dist));
                graph.AddEdgeToList(Tuple.Create(input[0], input[2], dist));
                graph.AddEdgeToList(Tuple.Create(input[1], input[2], dist));
            }
            var names = new List<string>(graph.AdjacencyList.Keys.ToList());
            names.Sort();
            if (!isIsenbayev)
            {
                foreach (var vertex in names)
                {
                    Console.WriteLine($"{vertex} undefined");
                }
                return;
            }

            var bfs = algorithms.BFS(graph, name);
            foreach (var vertex in names)
            {
                if (bfs.ContainsKey(vertex))
                {
                    Console.WriteLine($"{vertex} {bfs[vertex]}");
                }
                else
                {
                    Console.WriteLine($"{vertex} undefined");
                }
            }
        }

        static void KingEscape()
        {
            int n = int.Parse(Console.ReadLine());
            Graph<KeyValuePair<int, int>> graph = new Graph<KeyValuePair<int, int>>((n + 1) * (n + 1));
            GraphAlgorithms<KeyValuePair<int, int>> graphAlgorithms = new GraphAlgorithms<KeyValuePair<int, int>>();
            int[,] matrix = new int[n, n];
            var input = Console.ReadLine().Split();
            var queenPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            input = Console.ReadLine().Split();
            var kingPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            input = Console.ReadLine().Split();
            var finalPoint = new KeyValuePair<int, int>(int.Parse(input[0]), int.Parse(input[1]));
            graph.AddVertexToList(kingPoint);
            int[] directionRow = new int[] { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] directionColumn = new int[] { 0, 0, -1, 1, -1, 1, -1, 1 };
            int x = queenPoint.Key;
            int y = queenPoint.Value;
            while (x > -1 && y > -1)
            {
                matrix[x, y] = -1;
                x--;
                y--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x < n && y < n)
            {
                matrix[x, y] = -1;
                x++;
                y++;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x > -1)
            {
                matrix[x, y] = -1;
                x--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (y > -1)
            {
                matrix[x, y] = -1;
                y--;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (x < n)
            {
                matrix[x, y] = -1;
                x++;
            }
            x = queenPoint.Key;
            y = queenPoint.Value;
            while (y < n)
            {
                matrix[x, y] = -1;
                y++;
            }
            int i;
            int j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (matrix[i, j] == -1) continue;
                    graph.AddVertexToList(new KeyValuePair<int, int>(i, j));
                    for (int k = 0; k < 8; k++)
                    {
                        int rr = i + directionRow[k];
                        int cc = j + directionColumn[k];
                        if (rr < 0 || cc < 0 || rr > n - 1 || cc > n - 1 || matrix[rr, cc] == -1) continue;
                        graph.AddVertexToList(new KeyValuePair<int, int>(rr, cc));
                        graph.AddEdgeToList(Tuple.Create(new KeyValuePair<int, int>(i, j), new KeyValuePair<int, int>(rr, cc), 1d), true);
                    }
                }
            }

            var ans = graphAlgorithms.ShortestPathFunction(graph, kingPoint);
            var answer = ans.Invoke(finalPoint);
            if (answer == null) Console.WriteLine("NO");
            else Console.WriteLine("YES");
        }

        static void Timus1982()
        {
            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);
            double[,] matrix = new double[n, n];

            List<int> builtStations = new List<int>();
            if (k > 0)
                builtStations = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => int.Parse(arrTemp)).ToList();


            for (int i = 0; i < n; i++)
            {
                graph.AddVertexToList(i + 1);
                var inp = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(inp[j]);
                }
            }

            foreach (var item in builtStations)
            {
                for (int j = 0; j < n; j++)
                {
                    if (item == j + 1 || builtStations.Contains(j + 1)) continue;
                    graph.AddVertexToList(j + 1);
                    graph.AddEdgeToList(Tuple.Create(item, j + 1, matrix[item - 1, j]), true);
                }
            }

            for (int i = 1; i < n + 1; i++)
            {
                if (builtStations.Contains(i)) continue;
                for (int j = 0; j < n; j++)
                {
                    if (graph.AdjacencyList.ContainsKey(j + 1) && graph.AdjacencyList[j + 1].Where(x => x.EdgeTo == i).ToList().Count > 0 || builtStations.Contains(i) && builtStations.Contains(j + 1) || i == j + 1) continue;
                    graph.AddEdgeToList(Tuple.Create(i, j + 1, matrix[i - 1, j]), true);
                }
            }

            Dictionary<int, double> answer = new Dictionary<int, double>();
            var a = graphAlgorithms.Kruskal(graph, builtStations);
            int l = n - k;
            a.Sort();
            double sum = 0;
            for (int i = 0; i < n - k; i++)
            {
                sum += a[i].Weight;
            }

            Console.WriteLine(sum);

        }

        static void Bakery()
        {
            Graph<long> graph = new Graph<long>();
            GraphAlgorithms<long> graphAlgorithms = new GraphAlgorithms<long>();
            var firstLine = Console.ReadLine().Split();
            long n = long.Parse(firstLine[0]);
            long m = long.Parse(firstLine[1]);
            long k = long.Parse(firstLine[2]);

            for (long i = 0; i < m; i++)
            {
                var input = Console.ReadLine().Split();
                var u = long.Parse(input[0]);
                var v = long.Parse(input[1]);
                var l = double.Parse(input[2]);
                graph.AddVertexToList(u);
                graph.AddVertexToList(v);
                graph.AddEdgeToList(Tuple.Create(u, v, l));
            }
            List<long> items = new List<long>();
            if (k > 0)
                items = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => long.Parse(arrTemp)).ToList();

            List<long> otherCities = new List<long>();
            for (long i = 1; i < n + 1; i++)
            {
                if (items.Contains(i)) continue;
                otherCities.Add(i);
            }

            double answer = long.MaxValue;
            if (items.Count > 0)
                foreach (var item in items)
                {
                    for (int i = 0; i < otherCities.Count; i++)
                    {
                        if (!graph.AdjacencyList.ContainsKey(item)) continue;
                        var ans = graphAlgorithms.OrderedListShortesDistance(graph, otherCities[i], item);
                        if (ans == null) continue;
                        answer = Math.Min(answer, ans.Last().Item2);
                    }
                }
            else
            {
                answer = -1;
            }
            if (answer == long.MaxValue)
                answer = -1;
            Console.WriteLine(answer);
        }

        static void Timus1280()
        {
            Graph<int> graph = new Graph<int>();
            GraphAlgorithms<int> graphAlgorithms = new GraphAlgorithms<int>();
            var input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            for (int i = 1; i < n + 1; i++)
            {
                graph.AddVertexToList(i);
            }
            double l = 1;
            for (int i = 0; i < m; i++)
            {
                var inp = Console.ReadLine().Split();
                graph.AddEdgeToList(Tuple.Create(int.Parse(inp[0]), int.Parse(inp[1]), l), true);
            }
            var answer = Console.ReadLine().Split().Select(int.Parse).ToHashSet();
            if (m == 0)
            {
                Console.WriteLine("YES");
                return;
            }
            var myAnswer = graphAlgorithms.IsTopologicalSortValid(graph, answer);

            if (myAnswer)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

    }


    public class Edge<T> : IComparable<Edge<T>>
    {
        public Edge()
        {

        }

        public Edge(T edgeTo, double weight = 0)
        {
            EdgeTo = edgeTo;
            Weight = weight;
        }
        public Edge(T edgeFrom, T edgeTo, double weight = 0)
        {
            EdgeFrom = edgeFrom;
            EdgeTo = edgeTo;
            Weight = weight;
        }

        public T EdgeFrom { get; set; }
        public T EdgeTo { get; set; }
        public double Weight { get; set; }

        public int CompareTo(Edge<T> compareEdge)
        {
            if (compareEdge == null)
                return 1;

            else
                return (int)(this.Weight - compareEdge.Weight);
        }
        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var edge = obj as Edge<T>;
            if (edge == null)
            {
                return false;
            }

            // Return true if the fields match:
            return EdgeFrom.Equals(edge.EdgeFrom) && EdgeTo.Equals(edge.EdgeTo) && Weight == edge.Weight;
        }
        public override int GetHashCode()
        {
            return EdgeTo.GetHashCode() ^ EdgeFrom.GetHashCode();
        }
    }

    public class Graph<T>
    {
        public Graph() { }
        public Graph(int n)
        {
            AdjacencyList = new Dictionary<T, HashSet<Edge<T>>>(n);
        }

        public Graph(IEnumerable<T> vertices, IEnumerable<Tuple<T, T, double>> edges, bool isDirected = false)
        {
            foreach (var vertex in vertices)
                AddVertexToList(vertex);

            foreach (var edge in edges)
                AddEdgeToList(edge, isDirected);
        }

        public Dictionary<T, HashSet<Edge<T>>> AdjacencyList { get; } = new Dictionary<T, HashSet<Edge<T>>>();

        public HashSet<Edge<T>> Edges { get; } = new HashSet<Edge<T>>();
        public SortedSet<Tuple<T, T>> UnWeightedEdges { get; } = new SortedSet<Tuple<T, T>>();

        public void AddVertexToList(T vertex)
        {
            if (AdjacencyList.ContainsKey(vertex)) return;
            AdjacencyList[vertex] = new HashSet<Edge<T>>();
        }

        public void AddEdgeToList(Tuple<T, T, double> edge, bool isDirected = false)
        {
            AdjacencyList[edge.Item1].Add(new Edge<T>(edge.Item2, edge.Item3));
            Edges.Add(new Edge<T>(edge.Item1, edge.Item2, edge.Item3));
            UnWeightedEdges.Add(Tuple.Create(edge.Item1, edge.Item2));
            if (!isDirected)
            {
                AdjacencyList[edge.Item2].Add(new Edge<T>(edge.Item1, edge.Item3));
                Edges.Add(new Edge<T>(edge.Item2, edge.Item1, edge.Item3));
                UnWeightedEdges.Add(Tuple.Create(edge.Item2, edge.Item1));
            }
        }

    }

    public class GraphAlgorithms<T>
    {
        public T Infinity { get; set; }
        public Dictionary<T, int> BFS(Graph<T> graph, T start)
        {
            var visited = new Dictionary<T, int>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var queue = new Queue<Tuple<T, int>>();
            queue.Enqueue(Tuple.Create(start, 0));
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();

                if (visited.ContainsKey(vertex.Item1))
                    continue;

                visited.Add(vertex.Item1, vertex.Item2);

                foreach (var neighbor in graph.AdjacencyList[vertex.Item1])
                    if (!visited.ContainsKey(neighbor.EdgeTo))
                    {
                        queue.Enqueue(Tuple.Create(neighbor.EdgeTo, vertex.Item2 + 1));
                    }
            }

            return visited;
        }

        public HashSet<T> DFS(Graph<T> graph, T start, object end = null)
        {
            bool isFinished = false;
            var visited = new HashSet<T>();

            if (!graph.AdjacencyList.ContainsKey(start))
                return visited;

            var stack = new Stack<T>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var vertex = stack.Pop();

                if (visited.Contains(vertex))
                    continue;

                visited.Add(vertex);
                if (!isFinished)
                    foreach (var neighbor in graph.AdjacencyList[vertex])
                        if (!visited.Contains(neighbor.EdgeTo))
                        {
                            stack.Push(neighbor.EdgeTo);
                            if (end != null && neighbor.EdgeTo.Equals(end)) isFinished = true;
                        }

            }

            return visited;
        }

        public Func<T, IEnumerable<T>> ShortestPathFunction(Graph<T> graph, T start)
        {
            var previous = new Dictionary<T, T>();

            var queue = new Queue<T>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbor in graph.AdjacencyList[vertex])
                {
                    if (previous.ContainsKey(neighbor.EdgeTo))
                        continue;

                    previous[neighbor.EdgeTo] = vertex;
                    queue.Enqueue(neighbor.EdgeTo);
                }
            }

            Func<T, IEnumerable<T>> shortestPath = v =>
            {
                var path = new List<T> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    try
                    {
                        current = previous[current];
                    }
                    catch
                    {
                        return null;
                    }
                };

                path.Add(start);
                path.Reverse();

                return path;
            };

            return shortestPath;
        }

        public Dictionary<int, List<T>> FindComponents(Graph<T> graph)
        {
            int count = 0;
            bool visited;
            Dictionary<int, List<T>> components = new Dictionary<int, List<T>>();
            foreach (var item in graph.AdjacencyList)
            {
                visited = false;
                for (int i = 0; i < count; i++)
                {
                    if (count > 0 && components[i].Contains(item.Key))
                    {
                        visited = true;
                        break;
                    }
                }
                if (visited) continue;
                var dfs = DFS(graph, item.Key);
                foreach (var dItem in dfs)
                {
                    if (!components.ContainsKey(count))
                        components.Add(count, new List<T>() { dItem });
                    else
                        components[count].Add(dItem);
                }
                count++;
            }

            return components;
        }

        public T[] TopologicalSort(Graph<T> graph, string type = "dfs")
        {
            int n = graph.AdjacencyList.Count;
            List<T> ordering = new List<T>();
            T[] order = new T[n];
            int i = n - 1;
            switch (type)
            {
                case "bfs":
                    foreach (var item in graph.AdjacencyList)
                    {
                        if (ordering.Contains(item.Key)) continue;
                        var dfs = BFS(graph, item.Key);
                        if (dfs.Count < 2) continue;
                        List<T> thumb = new List<T>();
                        foreach (var dItem in dfs)
                        {
                            if (ordering.Contains(dItem.Key)) continue;
                            thumb.Add(dItem.Key);
                        }
                        for (int k = thumb.Count - 1; k > -1; k--)
                        {
                            order[i] = thumb[k];
                            i--;
                        }
                        ordering.AddRange(thumb);
                    }
                    break;
                default:
                    foreach (var item in graph.AdjacencyList)
                    {
                        if (ordering.Contains(item.Key)) continue;
                        var dfs = DFS(graph, item.Key);
                        if (dfs.Count < 2) continue;
                        List<T> thumb = new List<T>();
                        foreach (var dItem in dfs)
                        {
                            if (ordering.Contains(dItem)) continue;
                            thumb.Add(dItem);
                        }
                        for (int k = thumb.Count - 1; k > -1; k--)
                        {
                            order[i] = thumb[k];
                            i--;
                        }
                        ordering.AddRange(thumb);
                    }
                    break;
            }
            return order;
        }

        public List<T> TopologicalSortKahn(Graph<T> graph)
        {
            var nodes = graph.AdjacencyList.Keys;
            var edges = graph.UnWeightedEdges;
            var L = new List<T>(); // will contain the sorted elements
            var S = new SortedSet<T>(nodes.Where(n => edges.All(e => !e.Item2.Equals(n)))); // no incoming edges
            while (S.Any())
            {
                var n = S.First();
                S.Remove(n);
                L.Add(n);
                foreach (var e in edges.Where(e => e.Item1.Equals(n)).ToList())
                {
                    var m = e.Item2;
                    edges.Remove(e);
                    if (edges.All(incoming => !incoming.Item2.Equals(m)))
                        S.Add(m);
                }
            }
            return edges.Any() ? null : L;
        }

        public bool IsTopologicalSortValid(Graph<T> graph, HashSet<T> sorted)
        {
            var edges = graph.UnWeightedEdges;

            var dict = new Dictionary<T, int>();

            int i = 0;
            foreach (var item in sorted)
            {
                dict[item] = i++;
            }

            foreach (var edge in edges)
            {
                if (dict[edge.Item1] > dict[edge.Item2])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Shortest distance for every graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public Dictionary<T, double> ShortestDistance(Graph<T> graph, T start)
        {
            int n = graph.AdjacencyList.Count;
            var topSort = TopologicalSortKahn(graph);
            Dictionary<T, double> distance = new Dictionary<T, double>();
            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }
            distance[start] = 0;

            for (int i = 0; i < n; i++)
            {
                var nodeIndex = topSort[i];
                if (distance[nodeIndex] != int.MaxValue - 1000)
                {
                    var edges = graph.AdjacencyList[nodeIndex];
                    if (edges != null)
                    {
                        foreach (var edge in edges)
                        {
                            double newDist = distance[nodeIndex] + edge.Weight;
                            if (distance[edge.EdgeTo] == int.MaxValue - 1000) distance[edge.EdgeTo] = newDist;
                            else distance[edge.EdgeTo] = Math.Min(distance[edge.EdgeTo], newDist);
                        }
                    }
                }
            }
            return distance;
        }

        /// <summary>
        /// Longest distance for every graph
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public Dictionary<T, double> LongestDistance(Graph<T> graph, T start)
        {
            int n = graph.AdjacencyList.Count;
            var topSort = TopologicalSortKahn(graph);
            Dictionary<T, double> distance = new Dictionary<T, double>();
            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }
            distance[start] = 0;

            for (int i = 0; i < n; i++)
            {
                var nodeIndex = topSort[i];
                if (distance[nodeIndex] != int.MaxValue - 1000)
                {
                    var edges = graph.AdjacencyList[nodeIndex];
                    if (edges != null)
                    {
                        foreach (var edge in edges)
                        {
                            double newDist = distance[nodeIndex] + edge.Weight * -1;
                            if (distance[edge.EdgeTo] == int.MaxValue - 1000) distance[edge.EdgeTo] = newDist;
                            else distance[edge.EdgeTo] = Math.Min(distance[edge.EdgeTo], newDist);
                        }
                    }
                }
            }
            foreach (var k in distance.Keys.ToList())
            {
                distance[k] *= -1;
            }
            return distance;
        }

        /// <summary>
        /// The shortest distance for graph with non-negative numbers
        /// Dijkstra's Algorithm
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public Tuple<Dictionary<T, double>, Dictionary<T, T>> NonNegativeShortestDistance(Graph<T> graph, T start)
        {
            Dictionary<T, double> distance = new Dictionary<T, double>();
            Dictionary<T, T> ordering = new Dictionary<T, T>();

            distance[start] = 0;
            List<T> visited = new List<T>();

            foreach (var item in graph.AdjacencyList)
            {
                distance[item.Key] = int.MaxValue - 1000;
            }

            distance[start] = 0;
            Queue<Tuple<T, double>> queue = new Queue<Tuple<T, double>>();
            queue.Enqueue(Tuple.Create(start, 0d));

            while (queue.Count > 0)
            {
                var tuple = queue.Dequeue();
                var item = tuple.Item1;
                var minValue = tuple.Item2;
                if (distance[item] < minValue) continue;
                if (!graph.AdjacencyList.ContainsKey(item)) return null;
                foreach (var edge in graph.AdjacencyList[item])
                {
                    visited.Add(edge.EdgeTo);
                    double newDist = distance[item] + edge.Weight;
                    if (distance.ContainsKey(edge.EdgeTo) && newDist < distance[edge.EdgeTo])
                    {
                        ordering[edge.EdgeTo] = item;
                        distance[edge.EdgeTo] = newDist;
                        queue.Enqueue(Tuple.Create(edge.EdgeTo, newDist));
                    }
                }

            }

            return Tuple.Create(distance, ordering);
        }

        public List<Tuple<T, double>> OrderedListShortesDistance(Graph<T> graph, T start, T end)
        {
            var shortesPath = NonNegativeShortestDistance(graph, start);
            if (shortesPath == null) return null;
            var distance = shortesPath.Item1;
            var ordering = shortesPath.Item2;
            List<Tuple<T, double>> orderedDist = new List<Tuple<T, double>>(ordering.Count + 50);
            for (var i = end; i != null; i = ordering[i])
            {
                orderedDist.Add(Tuple.Create(i, distance[i]));
                if (!ordering.ContainsKey(i)) break;
            }
            orderedDist.Reverse();

            return orderedDist;
        }

        public List<Edge<T>> Kruskal(Graph<T> graph, List<T> comb = null)
        {
            var edges = new HashSet<Edge<T>>(graph.Edges).ToList();
            var numberOfVertices = graph.AdjacencyList.Count;
            edges.Sort();

            Dictionary<T, T> parent = new Dictionary<T, T>(numberOfVertices);
            if (comb != null)
            {
                foreach (var station in comb)
                {
                    var start = FindRoot(station, parent);
                    var end = FindRoot(comb[0], parent);
                    parent[end] = start;
                }
            }
            var spanningTree = new List<Edge<T>>();
            foreach (var edge in edges)
            {
                var startNodeRoot = FindRoot(edge.EdgeFrom, parent);
                var endNodeRoot = FindRoot(edge.EdgeTo, parent);

                if (!startNodeRoot.Equals(endNodeRoot))
                {
                    spanningTree.Add(edge);
                    parent[endNodeRoot] = startNodeRoot;
                }
            }
            return spanningTree;
        }

        private static T FindRoot(T node, Dictionary<T, T> parent)
        {
            var root = node;
            if (parent.ContainsKey(root))
                while (!root.Equals(parent[root]))
                {
                    root = parent[root];
                    if (!parent.ContainsKey(root)) break;

                }

            while (!node.Equals(root))
            {
                var oldParent = parent[node];
                parent[node] = root;
                node = oldParent;
            }

            return root;
        }

    }

}
