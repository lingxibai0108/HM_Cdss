using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    public class ZJICDM
    {
        public ZJICDM(string code, string name)
        {
            this.Code = code;
            this.Name = name;
        }
        public ZJICDM(string name)
        {
            this.Name = name;
        }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
