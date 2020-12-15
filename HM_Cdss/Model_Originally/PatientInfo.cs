using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    /// <summary>
    /// 患者信息
    /// </summary>
    public class PatientInfo
    {
        /// <summary>
        /// 性别0女，1男,  2 其他
        /// </summary>
        public int gender{get;set;}
        /// <summary>
        /// 年龄，必须是正数值
        /// </summary>
        public double age{get;set;}
        /// <summary>
        ///岁、月、天
        /// </summary>
        public string ageType{get;set;}
        /// <summary>
        ///婚姻状况  0：未婚，1: 已婚， 2:其他（影响推荐和提醒）
        /// </summary>
        public int maritalStatus{get;set;}
        /// <summary>
        ///妊娠状况  1: 怀孕  0：未怀孕（影响推荐和提醒）
        /// </summary>
        public int pregnancyStatus{get;set;}
    }
}
