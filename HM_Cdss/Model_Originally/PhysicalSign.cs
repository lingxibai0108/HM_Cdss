using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    /// <summary>
    /// 生命体征（查体）
    /// </summary>
    public class PhysicalSign
    {
        /// <summary>
        /// 体温（单位：°C）
        /// </summary>
        public double bodyTempr{set;get;}
        /// <summary>
        /// 心率（单位：次/分）
        /// </summary>
        public int heartRate{set;get;}
        /// <summary>
        /// 舒张压-低压（单位：mmHg）
        /// </summary>
        public double lowBldPress{set;get;}
        /// <summary>
        /// 收缩压-高压（单位：mmHg）
        /// </summary>
        public double highBldPress{set;get;}
        /// <summary>
        /// 测量时间（格式：yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string recordTime{set;get;}
    }
}
