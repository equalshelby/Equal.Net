using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equal.Tool.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //绑定数据源
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("Key", typeof(System.String));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("Value", typeof(System.String));
            dt.Columns.Add(dc2);


            for (int i = 0; i < 5; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "星期一";
                dr[1] = "1";
                dt.Rows.Add(dr);
            }
            comCheckBoxList1.DataSource = dt;
            comCheckBoxList1.DisplayMember = "Value";
            comCheckBoxList1.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in comCheckBoxList1.GetSelectedItems())
            {
                label1.Text += ((DataRowView)item)[1];
            }

        }
    }
}
