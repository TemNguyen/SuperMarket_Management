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
    public partial class Form2 : Form
    {
        public delegate void MyDel(int ID_SP);
        public MyDel Sender;
        int ID_SP = 0;
        public void getID(int ID)
        {
            ID_SP = ID;
        }
        public Form2()
        {
            InitializeComponent();
            Sender = new MyDel(getID);
            setCbbMH();
            rbtn_Con.Checked = true;
        }
        private void setCbbMH()
        {
            foreach (DataRow dr in CSDL.Instance.DSMH.Rows)
            {
                cbb_MH.Items.Add(new CBBItem
                {
                    Text = dr["TenMH"].ToString(),
                    Value = dr["ID_MH"].ToString()
                });
            }
            cbb_MH.SelectedIndex = 0;
        }
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (ID_SP == -1)
            {
                if (tb_IDSP.Text == "" || tb_Ten.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                foreach(char c in tb_IDSP.Text)
                {
                    if (c > '9' || c < '0')
                    {
                        MessageBox.Show("ID_SP chỉ chứa ký tự số", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (CSDL_OOP.Instance.isExist(Convert.ToInt32(tb_IDSP.Text)))
                {
                    MessageBox.Show("ID_SP = " + tb_IDSP.Text + " đã tồn tại!", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                CSDL_OOP.Instance.setSP(getSP());
            }
            else
            {
                CSDL_OOP.Instance.setSPByID(ID_SP, getSP());
            }
            this.Dispose();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }
        private SP getSP()
        {
            SP s = new SP();
            s.ID_SP = Convert.ToInt32(tb_IDSP.Text);
            s.Ten = tb_Ten.Text;
            if (rbtn_Con.Checked) s.TrangThai = true;
            else s.TrangThai = false;
            s.NSX = dateTimePicker1.Value;
            s.ID_MH = ((CBBItem)cbb_MH.SelectedItem).Value;
            return s;
        }
        private void setSP(SP s)
        {
            tb_IDSP.Text = s.ID_SP.ToString();
            tb_Ten.Text = s.Ten;
            if (s.TrangThai) rbtn_Con.Checked = true;
            else rbtn_Het.Checked = true;
            dateTimePicker1.Value = s.NSX;
            cbb_MH.SelectedItem = Convert.ToInt32(s.ID_MH);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (ID_SP != -1)
            {
                setSP(CSDL_OOP.Instance.getSPByID(ID_SP));
                tb_IDSP.Enabled = false;
            }
        }
    }
}
