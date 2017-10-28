using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simplex.Expressions;

namespace Simplex
{
    public class SimplexCalculator
    {
        private const int cprecision = 8;

        private double[,] _simplex;
        private int[] _ccolumns;
        private int[] _base;
        private List<Variable> _lvar;
        private bool _maximize;

        public SimplexCalculator(Expression target, List<ExConstraint> constraints, bool maximize)
        {
            _maximize = maximize;
            CreateArray(target, constraints);
            foreach (Variable v in _lvar)
            {
                v.Value = 0;
            }
        }

        public double Calculate()
        {
            while (PerformStep()) ;
            if (_maximize)
            {
                for (int ib = 0; ib < _base.Length; ib++)
                {
                    if (_base[ib] < _lvar.Count)
                    {
                        _lvar[_base[ib]].Value = _simplex[ib, _simplex.GetLength(1) - 1];
                    }
                }
            }
            else
            {
                for (int iv = 0; iv < _lvar.Count; iv++)
                {
                    _lvar[iv].Value = -_simplex[_simplex.GetLength(0) - 1, iv + _ccolumns.Length];
                }
            }
            return -Math.Round(_simplex[_simplex.GetLength(0) - 1, _simplex.GetLength(1) - 1], cprecision);
        }

        private void CreateArray(Expression target, List<ExConstraint> constraints)
        {
            int row = 0;
            int col = 0;
            int ib = 0;
            _lvar = target.Variables;
            if (_maximize)
            {
                _simplex = new double[1 + constraints.Count, 1 + _lvar.Count + constraints.Count];
                _base = new int[constraints.Count];
                _ccolumns = new int[_lvar.Count];
                foreach (ExConstraint c in constraints)
                {
                    col = 0;
                    foreach (Variable v in _lvar)
                    {
                        _simplex[row, col] = c.Coeficient(v);
                        col++;
                    }
                    _base[ib++] = col + row;
                    _simplex[row, col + row] = 1;
                    _simplex[row, _simplex.GetLength(1) - 1] = c.Value;
                    row++;
                }
                col = 0;
                foreach (Variable v in _lvar)
                {
                    _simplex[row, col++] = target.Coeficient(v);
                }
            }
            else
            {
                _simplex = new double[1 + _lvar.Count, 1 + _lvar.Count + constraints.Count];
                _base = new int[_lvar.Count];
                _ccolumns = new int[constraints.Count];
                foreach (Variable v in _lvar)
                {
                    col = 0;
                    foreach (ExConstraint c in constraints)
                    {
                        _simplex[row, col] = c.Coeficient(v);
                        col++;
                    }
                    _base[ib++] = col + row;
                    _simplex[row, col + row] = 1;
                    _simplex[row, _simplex.GetLength(1) - 1] = target.Coeficient(v);
                    row++;
                }
                col = 0;
                foreach (ExConstraint c in constraints)
                {
                    _simplex[row, col++] = c.Value;
                }
            }
            for (int cc = 0; cc < _ccolumns.Length; cc++)
            {
                _ccolumns[cc] = cc;
            }
        }

        private bool PerformStep()
        {
            Point pivot = SelectPivot();
            if ((pivot.X < 0) && (pivot.Y < 0))
            {
                return false;
            }
            for (int col = 0; col < _simplex.GetLength(1); col++)
            {
                if (col != pivot.X)
                {
                    _simplex[pivot.Y, col] = Math.Round(_simplex[pivot.Y, col] / _simplex[pivot.Y, pivot.X], cprecision);
                }                
            }
            _simplex[pivot.Y, pivot.X] = 1;
            for (int row = 0; row < _simplex.GetLength(0); row++)
            {
                if (row != pivot.Y)
                {
                    for (int col = 0; col < _simplex.GetLength(1); col++)
                    {
                        if (col != pivot.X)
                        {
                            _simplex[row, col] = Math.Round(_simplex[row, col] - (_simplex[pivot.Y, col] * _simplex[row, pivot.X]), cprecision);
                        }
                    }
                    _simplex[row, pivot.X] = 0;
                }
            }
            int tmp = _base[pivot.Y];
            _base[pivot.Y] = pivot.X;
            for (int ix = 0; ix < _ccolumns.Length; ix++)
            {
                if (_ccolumns[ix] == pivot.X)
                {
                    _ccolumns[ix] = tmp;
                    break;
                }
            }

            for (int col = 0; col < _simplex.GetLength(1) - 1; col++)
            {
                if (_simplex[_simplex.GetLength(0) - 1, col] > 0)
                {
                    return true;
                }
            }
            return false;
        } 

        private Point SelectPivot()
        {
            Point cmm = new Point(-1,-1);
            double mmval = double.MinValue;
            for (int col = 0; col < _ccolumns.Length; col++)
            {
                if (_simplex[_simplex.GetLength(0) - 1, _ccolumns[col]] > 0)
                {
                    int row;
                    double tn = Math.Round(ThetaN(_ccolumns[col], out row) * _simplex[_simplex.GetLength(0) - 1, _ccolumns[col]], cprecision);
                    if (tn > mmval)
                    {
                        mmval = tn;
                        cmm = new Point(_ccolumns[col], row);
                    }
                }
            }
            return cmm;
        }

        private double ThetaN(int col, out int row)
        {
            row = -1;
            double min = double.MaxValue;
            for (int r = 0; r < _simplex.GetLength(0) - 1; r++)
            {
                if (_simplex[r, col] > 0)
                {
                    double m = Math.Round(_simplex[r, _simplex.GetLength(1) - 1] / _simplex[r, col], cprecision);
                    if (m < min)
                    {
                        min = m;
                        row = r;
                    }
                }
            }
            return min;
        }
    }
}