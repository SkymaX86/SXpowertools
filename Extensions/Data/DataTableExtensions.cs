using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace SXpowertools.Extensions
{
    public static class DataTableExtensions
    {
        /// <summary>
        /// <para>DE: Kippt ein DataTable. Spalten werden zu Reihen und vice versa.</para>
        /// <para>EN: Flip a datatable. Columns become Rows and vice versa.</para>
        /// </summary>
        /// <param name="_value">the datatable</param>
        /// <returns>Returns the flipped datatable.</returns>
        public static DataTable FlipDataTable(this DataTable _dataTable)
        {
            DataTable table = new DataTable();

            for (int i = 0; i <= _dataTable.Rows.Count; i++)
            {
                table.Columns.Add(Convert.ToString(i));
            }

            DataRow r;

            for (int k = 0; k < _dataTable.Columns.Count; k++)
            {
                r = table.NewRow();
                r[0] = _dataTable.Columns[k].ToString();

                for (int j = 1; j <= _dataTable.Rows.Count; j++)
                {
                    r[j] = _dataTable.Rows[j - 1][k];
                }

                table.Rows.Add(r);
            }

            return table;
        }
    }
}
