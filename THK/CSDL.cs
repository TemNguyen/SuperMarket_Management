using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THK
{
    class CSDL
    {
        public DataTable DSMH { get; set; }
        public DataTable DSSP { get; set; }
        public static CSDL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static CSDL _Instance;

        private CSDL()
        {
            DSSP = new DataTable();
            DSSP.Columns.AddRange(new DataColumn[]
            {
                new DataColumn( "ID_SP", typeof(int)),
                new DataColumn( "Ten", typeof(string)),
                new DataColumn( "TrangThai", typeof(bool)),
                new DataColumn( "NSX", typeof(DateTime)),
                new DataColumn( "ID_MH", typeof(string))
            });
            DataRow dr = DSSP.NewRow();
            dr["ID_SP"] = 101;
            dr["Ten"] = "Gao";
            dr["TrangThai"] = true;
            dr["NSX"] = DateTime.Now;
            dr["ID_MH"] = "1";
            DSSP.Rows.Add(dr);

            DataRow dr1 = DSSP.NewRow();
            dr1["ID_SP"] = 102;
            dr1["Ten"] = "Bot Giat";
            dr1["TrangThai"] = true;
            dr1["NSX"] = DateTime.Now;
            dr1["ID_MH"] = "2";
            DSSP.Rows.Add(dr1);

            DataRow dr2 = DSSP.NewRow();
            dr2["ID_SP"] = 103;
            dr2["Ten"] = "Duong";
            dr2["TrangThai"] = false;
            dr2["NSX"] = DateTime.Now;
            dr2["ID_MH"] = "1";
            DSSP.Rows.Add(dr2);

            DSMH = new DataTable();
            DSMH.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("ID_MH", typeof(string)),
                new DataColumn("TenMH", typeof(string))
            });

            DataRow dr3 = DSMH.NewRow();
            dr3["ID_MH"] = "1";
            dr3["TenMH"] = "Thuc Pham";
            DSMH.Rows.Add(dr3);

            DataRow dr4 = DSMH.NewRow();
            dr4["ID_MH"] = "2";
            dr4["TenMH"] = "Tieu Dung";
            DSMH.Rows.Add(dr4);
        }
    }
}
