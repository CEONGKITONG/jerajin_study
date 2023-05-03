using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCommandExam
{
    class Emp
    {
        public String Ename { get; set; }
        public String Job { get; set; }
        public override string ToString()
        {
            return "[" + Ename + "," + Job + "]";
            //base.ToString();
        }


    }
}
