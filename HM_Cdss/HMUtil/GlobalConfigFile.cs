using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Cdss.HMUtil
{
    class GlobalConfigFile
    {
        /// <summary>
        /// 当前exe执行目录
        /// </summary>
        public static string currentPath = System.IO.Directory.GetCurrentDirectory();
        /// <summary>
        /// 服务器Url地址
        /// </summary>
        public static string UrlAddress = "http://192.168.128.115/mayson/cs.html?a=1";
        /// <summary>
        /// 服务器用户秘钥
        /// // "AF795E021AFB44882F285AAD725960D4";//由惠每提供的认证密钥7195F12825788F09375C2DB1E922F108
        /// </summary>
        public static string AutherKey = "AF795E021AFB44882F285AAD725960D4";
        /// <summary>
        /// 医院组织机构编码
        /// </summary>
        public static string HospitalGuid = "42504704x00";
        /// <summary>
        /// 医院明后才能
        /// </summary>
        public static string HospitalName = "复旦大学附属闵行医院上海市闵行区中心医院";
    }
}
