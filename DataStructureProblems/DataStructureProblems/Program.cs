using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructureProblems
{
    class Program
    {
        static void Main(string[] args)
        {
        }
       
        static void Timus1542()
        {
            var N = Convert.ToInt32(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split();
                var str = input[0];
                var n = int.Parse(input[1]);
                dict.Add(str, n);
            }
            var words = dict.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
            dict = null;
            var trie = new Trie();
            foreach (var w in words)
                trie.Insert(w.Key);
            var m = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var s = Console.ReadLine();
                trie.AutoSuggestion(trie.root, s);
                var count = 0;
                var all = words.Where(x => trie.AutoCompletedSuggestions.Contains(x.Key));
                foreach (var w in all)
                {
                    count++;
                    Console.WriteLine(w.Key);
                    if (count == 10)
                        break;
                }
                if (i != m - 1)
                    Console.WriteLine();
            }
        }
    }

    public class Job
    {
        public int start;
        public int finish;
        public int profit;
        public Job(int start, int finish, int profit)
        {
            this.start = start;
            this.finish = finish;
            this.profit = profit;
        }
    }
}
