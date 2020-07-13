using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicShop.service
{
    class DBService
    {
        public static int getSelectedProduct(DataGridView data)
        {
            int index;

            index = int.Parse(data.Rows[data.SelectedCells[0].RowIndex].Cells[0].Value.ToString());
            return index;
        }
    }
}
