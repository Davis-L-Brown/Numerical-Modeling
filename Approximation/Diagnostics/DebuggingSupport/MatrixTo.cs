using MathNet.Numerics.LinearAlgebra;
using System.Data;
using System.Diagnostics;

namespace Approximation.Diagnostics.DebuggingSupport
{
    /// <summary>
    /// Defines a static class that allows the conversion of a 
    /// <see cref="Matrix{T}"/> to a <see cref="System.Data.DataTable"/>.
    /// </summary>
    internal static class MatrixTo
    {
        /// <summary>
        /// Convert a <see cref="Matrix{T}"/> to 
        /// a <see cref="System.Data.DataTable"/> for an easier veiwing
        /// experience in the debugger.
        /// </summary>
        /// <param name="m">
        /// The Matrix you would like to view in the debugger.
        /// </param>
        public static DataTable DataTable(Matrix<double> m)
        {
            if (Debugger.IsAttached)
            {
                var table = new DataTable();

                for (int c = 0; c < m.ColumnCount; c++)
                    table.Columns.Add();

                for (int r = 0; r < m.RowCount; r++)
                {
                    var row = table.NewRow();

                    for (int c = 0; c < m.ColumnCount; c++)
                        row[c] = m[r, c];
                    table.Rows.Add(row);
                }

                return table;
            }

            return null;
        }
    }
}
