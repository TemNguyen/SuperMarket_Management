using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            setCbbMatHang();
            setSbbSort();
            dataGridView1.DataSource = CSDL_OOP.Instance.getAllSP("0", "");
        }
        private void setCbbMatHang()
        {
            cbb_MH.Items.Add(new CBBItem
            {
                Text = "All",
                Value = "0"
            });
            foreach(DataRow dr in CSDL.Instance.DSMH.Rows)
            {
                cbb_MH.Items.Add(new CBBItem
                {
                    Text = dr["TenMH"].ToString(),
                    Value = dr["ID_MH"].ToString()
                });
            }
            cbb_MH.SelectedIndex = 0;
        }
        private void setSbbSort()
        {
            int propertyID = 0;
            foreach(DataColumn d in CSDL.Instance.DSSP.Columns)
            {
                cbb_Sort.Items.Add(new CBBItem
                {
                    Text = d.ColumnName,
                    Value = propertyID.ToString()
                });
                propertyID++;
            }
            cbb_Sort.SelectedIndex = 0;
        }
        private void cbb_MH_SelectedIndexChanged(object sender, EventArgs e)
        {
            reloadDatagrid();
        }
        private void tb_Search_TextChanged(object sender, EventArgs e)
        {
            reloadDatagrid();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Sender(-1);
            f2.ShowDialog();
            this.Hide();
        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int ID_SP = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_SP"].Value);
            Form2 f2 = new Form2();
            f2.Sender(ID_SP);
            f2.ShowDialog();
            this.Hide();
        }
        private void btn_Del_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa SP này không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            switch(d)
            {
                case DialogResult.Yes:
                    int ID_SP = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID_SP"].Value);
                    CSDL_OOP.Instance.deleteSPByID(ID_SP);
                    reloadDatagrid();
                    break;
                case DialogResult.No:
                    break;
            }    
            
        }
        private void btn_Sort_Click(object sender, EventArgs e)
        {
            string property = ((CBBItem)cbb_Sort.SelectedItem).Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_OOP.Instance.SortSPBy(property);
        }
        public void reloadDatagrid()
        {
            string ID_MH = ((CBBItem)cbb_MH.SelectedItem).Value;
            string TenSP = tb_Search.Text;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = CSDL_OOP.Instance.getAllSP(ID_MH, TenSP);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
