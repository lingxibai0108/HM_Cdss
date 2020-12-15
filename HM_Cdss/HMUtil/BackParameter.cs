using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Cdss.HMUtil
{
    /// <summary>
    /// 返回参数类
    /// </summary>
   public  class BackParameter
    {
        /// <summary>
        /// 返回function
        /// </summary>
        public string Fun { get; set; }
        /// <summary>
        /// 返回data
        /// </summary>
        public BackParameter_data data { get; set; }

    }
    public class BackParameter_data {
        /// <summary>
        /// 状态码（可根据状态码设置窗体位置及可见性）
        /// </summary>
        public string state { get; set; }
        /// <summary>
        ///  窗口位置（备用）
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 0:不需要阻断，1：阻断
        /// </summary>
        public string interventionProcess { get; set; }
        public string smallFormColor { get; set; }

    }
}
