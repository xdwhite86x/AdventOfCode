using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    internal class DiagReport
    {
        private List<List<int>>_report;
        private int _rows;
        private int _cols;


        public List<int> this[int i]
        {
            get => _report[i];
            set => _report[i] = value;
        }
        public DiagReport(int[][] report)
        {
            _report = new();
            var temp = report.ToList();
            List<int> list = new();
            foreach (int[] intArr in temp)
            {
                foreach(int i in intArr)
                    list.Add(i);
                
                _report.Add(list);
            }
            
            _rows = _report.Count;
            _cols = _report[0].Count;
        }
        public DiagReport(List<List<int>> report)
        {
            _report = report;
            _rows = report.Count;
            _cols = report[0].Count;
        }
        public List<List<int>> Columns
        {
            
            get
            {
                List<List<int>> retval = new();
                for (int c = 0; c < _cols; ++c)
                {
                    List<int> col = new();
                    for (int r = 0; r < _rows; ++r)
                    {
                        col.Add(_report[r][c]);
                    }
                    retval.Add(col);
                }
                return retval;
            }
        }

        public  List<List<int>> Rows
        {
            get
            {
                List<List<int>> retval = new();
                foreach (var l in _report)
                {
                    List<int> row = new();
                    foreach (var i in l)
                    {
                        row.Add(i);
                    }
                    retval.Add(row);
                }
                return retval;
            }
        }

        public DiagReport GetWithBitSetInIndex(int index, int bit)
        {
            List<List<int>> report = new();
            
            for (int r = 0; r < _rows; ++r )
            {
                if (_report[r][index] == bit)
                {
                    List<int> line = new();
                    for (int i = 0; i < _cols; ++i)
                    {
                        line.Add(_report[r][i]);
                    }
                    report.Add(line);
                }
            }

            return new DiagReport(report);
        }
        public int GetColumnMostCommon(int col)
        {
            if (col > _cols)
                throw new ArgumentOutOfRangeException(nameof(col));

            int one = 0;
            int zero = 0;
            for (int i = 0; i < _rows; ++i)
            {
                if (_report[i][col] >= 1)
                    ++one;
                else
                    ++zero;
            }

            if (one == zero)
                return 1;
            return one > zero ? 1 : 0;
        }
    }
}