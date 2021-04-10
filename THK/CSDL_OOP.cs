using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THK
{
    class CSDL_OOP
    {
        public delegate bool Compare(SP s1, SP s2);
        public static CSDL_OOP Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CSDL_OOP();
                }
                return _Instance;
            }
            private set
            {

            }
        }
        private static CSDL_OOP _Instance;
        public List<SP> getAllSP(string ID_MH, string TenSP)
        {
            List<SP> s = new List<SP>();
            foreach(DataRow dr in CSDL.Instance.DSSP.Rows)
            {
                if (ID_MH == "0")
                {
                    if (TenSP == "")
                    {
                        s.Add(get1SP(dr));
                    }
                    else
                    {
                        if (dr["Ten"].ToString().Contains(TenSP))
                            s.Add(get1SP(dr));
                    }
                }
                else
                {
                    if (TenSP == "")
                    {
                        if (dr["ID_MH"].ToString() == ID_MH)
                            s.Add(get1SP(dr));
                    }
                    else
                    {
                        if (dr["ID_MH"].ToString() == ID_MH && dr["Ten"].ToString().Contains(TenSP))
                            s.Add(get1SP(dr));
                    }
                }
                
            }
            return s;
        }
        private SP get1SP(DataRow dr)
        {
            SP s = new SP();
            s.ID_SP = Convert.ToInt32(dr["ID_SP"]);
            s.Ten = dr["Ten"].ToString();
            s.TrangThai = Convert.ToBoolean(dr["TrangThai"]);
            s.NSX = Convert.ToDateTime(dr["NSX"]);
            s.ID_MH = dr["ID_MH"].ToString();
            return s;
        }
        public SP getSPByID(int ID_SP)
        {
            SP s = new SP();
            List<SP> list = cloneDSSP();
            foreach (var i in list)
            {
                if (i.ID_SP == ID_SP)
                    return i;
            }
            return s;
        }
        public bool setSP(SP s)
        {
            List<SP> list = cloneDSSP();
            list.Add(s);
            CSDL.Instance.setDSSP(list);
            return true;
        }
        public bool setSPByID(int ID_SP, SP s)
        {
            List<SP> list = cloneDSSP();
            int index = 0;
            foreach (var i in list)
            {
                if (i.ID_SP == ID_SP)
                {
                    list[index] = s;
                    break;
                }
                index++;
            }
            CSDL.Instance.setDSSP(list);
            return true;
        }
        public bool deleteSPByID(int ID_SP)
        {
            List<SP> list = cloneDSSP();
            foreach(var i in list)
            {
                if (i.ID_SP == ID_SP)
                {
                    list.Remove(i);
                    break;
                }
            }
            CSDL.Instance.setDSSP(list);
            return true;
        }
        public List<SP> SortSPBy(string property)
        {
            Compare cmp;
            List<SP> list = cloneDSSP();
            switch(property)
            {
                case "ID_SP":
                    cmp = SP.CompareIDSP;
                    break;
                case "Ten":
                    cmp = SP.CompareTen;
                    break;
                case "TrangThai":
                    cmp = SP.CompareTT;
                    break;
                case "NSX":
                    cmp = SP.CompareNSX;
                    break;
                case "ID_MH":
                    cmp = SP.CompareIDMH;
                    break;
                default:
                    cmp = SP.CompareIDSP;
                    break;
            }    
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (cmp(list[i], list[j]))
                    {
                        SP temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
            return list;
        }
        private List<SP> cloneDSSP()
        {
            List<SP> s = new List<SP>();
            foreach(DataRow dr in CSDL.Instance.DSSP.Rows)
            {
                s.Add(get1SP(dr));
            }
            return s;
        }
        public bool isExist(int ID_SP)
        {
            List<SP> list = cloneDSSP();
            foreach(var i in list)
            {
                if (i.ID_SP == ID_SP) return true;
            }
            return false;
        }
    }
}
