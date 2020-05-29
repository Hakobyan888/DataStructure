using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructureProblems
{
    class Program
    {
        static void Main(string[] args)
        {
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
