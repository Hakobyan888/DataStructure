using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace DataStructureProblems
{
    public class SegmentTree
    {
        private int[] _tree;
        private int N;
        public SegmentTree(int n)
        {
            var x = (int)(Math.Ceiling(Math.Log(n) / Math.Log(2)));
            N = (int)Math.Pow(2, x + 1) - 1;
            _tree = new int[N];
        }
        public void UpdateValue(int[] arr, int n, int updateIndex, int newValue)
        {
            var diff = newValue - arr[updateIndex];
            arr[updateIndex] = newValue;
            UpdateValue(0, n - 1, updateIndex, diff, 0);
        }
        public void UpdateValue(int left, int right, int updateIndex,
            int diff, int index)
        {
            if (updateIndex < left || updateIndex > right)
                return;
            _tree[index] = _tree[index] + diff;
            if (right == left) return;
            var mid = GetMid(left, right);
            UpdateValue(left, mid, updateIndex, diff, 2 * index + 1);
            UpdateValue(mid + 1, right, updateIndex, diff, 2 * index + 2);
        }
        private int GetMid(int s, int e)
        {
            return s + (e - s) / 2;
        }
        #region Sum
        public int BuildSumTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = BuildSumTree(arr, left, mid, index * 2 + 1) +
                           BuildSumTree(arr, mid + 1, right, index * 2 + 2);
            return _tree[index];
        }
        public int GetSum(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return 0;
            var mid = GetMid(left, right);
            return GetSum(left, mid, queryStart, queryEnd, 2 * index + 1) +
                   GetSum(mid + 1, right, queryStart, queryEnd, 2 * index + 2);
        }
        #endregion
        #region Sub
        public int BuildSubTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = BuildSubTree(arr, left, mid, index * 2 + 1) -
                           BuildSubTree(arr, mid + 1, right, index * 2 + 2);
            return _tree[index];
        }
        public int GetSub(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return 0;
            var mid = GetMid(left, right);
            return GetSub(left, mid, queryStart, queryEnd, 2 * index + 1) -
                   GetSub(mid + 1, right, queryStart, queryEnd, 2 * index + 2);
        }
        #endregion
        #region Max
        public int BuildMaxTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = Math.Max(BuildMaxTree(arr, left, mid, index * 2 + 1),
                BuildMaxTree(arr, mid + 1, right, index * 2 + 2));
            return _tree[index];
        }
        public int GetMax(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return int.MinValue;
            var mid = GetMid(left, right);
            return Math.Max(GetMax(left, mid, queryStart, queryEnd, 2 * index + 1),
                GetMax(mid + 1, right, queryStart, queryEnd, 2 * index + 2));
        }
        #endregion
        #region Min
        public int BuildMinTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return arr[left];
            }
            var mid = GetMid(left, right);
            _tree[index] = Math.Min(BuildMinTree(arr, left, mid, index * 2 + 1),
                BuildMinTree(arr, mid + 1, right, index * 2 + 2));
            return _tree[index];
        }
        public int GetMin(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            if (right < queryStart || left > queryEnd)
                return int.MaxValue;
            var mid = GetMid(left, right);
            return Math.Min(GetMin(left, mid, queryStart, queryEnd, 2 * index + 1),
                GetMin(mid + 1, right, queryStart, queryEnd, 2 * index + 2));
        }
        #endregion
        #region Gcd
        public int BuildGcdTree(int[] arr, int left, int right, int index)
        {
            if (left == right)
            {
                _tree[index] = arr[left];
                return _tree[index];
            }
            int mid = GetMid(left, right);
            _tree[index] = Gcd(BuildGcdTree(arr, left, mid, index * 2 + 1),
                BuildGcdTree(arr, mid + 1, right, index * 2 + 2));
            return _tree[index];
        }
        public int GetGcd(int left, int right, int queryStart, int queryEnd, int index)
        {
            if (left > queryEnd || right < queryStart)
                return 0;
            if (queryStart <= left && queryEnd >= right)
                return _tree[index];
            int mid = left + (right - left) / 2;
            return Gcd(GetGcd(left, mid, queryStart, queryEnd, index * 2 + 1),
                GetGcd(mid + 1, right, queryStart, queryEnd, index * 2 + 2));
        }
        private int Gcd(int a, int b)
        {
            return b == 0 ? a : Gcd(b, a % b);
        }
        #endregion
    }
}