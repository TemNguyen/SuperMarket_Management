using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THK
{
    class SP
    {
        public int ID_SP { get; set; }
        public string Ten { get; set; }
        public bool TrangThai { get; set; }
        public DateTime NSX { get; set; }
        public string ID_MH { get; set; }
        public static bool CompareIDSP(SP s1, SP s2)
        {
            if (s1.ID_SP >= s2.ID_SP) return true;
            else return false;
        }
        public static bool CompareTen(SP s1, SP s2)
        {
            if (string.Compare(s1.Ten, s2.Ten) > 0) return true;
            else return false;
        }
        public static bool CompareTT(SP s1, SP s2)
        {
            if (!s1.TrangThai && s2.TrangThai) return true;
            return false;
        }
        public static bool CompareNSX(SP s1, SP s2)
        {
            if (string.Compare(s1.NSX.ToString(), s2.NSX.ToString()) > 0) return true;
            else return false;
        }
        public static bool CompareIDMH(SP s1, SP s2)
        {
            if (string.Compare(s1.ID_MH, s2.ID_MH) > 0) return true;
            else return false;
        }
    }
}
