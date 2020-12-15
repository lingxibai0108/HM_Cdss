using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    public class HMEntity
    {
        /// <summary>
        /// 既往史
        /// </summary>
        public string previousHistory { get; set; }
        /// <summary>
        /// 个人史
        /// </summary>
        public string personalHistory { get; set; }
        /// <summary>
        ///  过敏史
        /// </summary>
        public string allergyHistory { get; set; }
        /// <summary>
        ///  家族史
        /// </summary>
        public string familyHistory { get; set; }
        /// <summary>
        ///    体重
        /// </summary>
        public string weight { get; set; }
        /// <summary>
        ///  性别1 男,0 女
        /// </summary>
        public string gender { get; set; }
        /// <summary>
        ///  体温，如：37
        /// </summary>
        public string bodyTempr { get; set; }
        /// <summary>
        /// 舒张压
        /// </summary>
        public string lowBldPress { get; set; }
        /// <summary>
        /// 收缩压
        /// </summary>
        public string highBldPress { get; set; }
        /// <summary>
        ///  心率
        /// </summary>
        public string heartRate { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public string age { get; set; }
        /// <summary>
        ///  年龄类型值为：岁、月、天（缺省值为岁）
        /// </summary>
        public string ageType { get; set; }
        /// <summary>
        /// 身高
        /// </summary>
        public string Height { get; set; }
        /// <summary>
        ///   现病史
        /// </summary>
        public string presentHistory { get; set; }
        /// <summary>
        /// 主诉
        /// </summary>
        public string symptom { get; set; }
        /// <summary>
        /// 确诊诊断对象数组{key: 诊断id,value: 诊断名}
        /// </summary>
        public List<confirmDiagnosisMap> confirmDiagnosisMap { get; set; }
        /// <summary>
        /// 检验结果
        /// </summary>
        public List<examItems> examItems { get; set; }
    }

    public class confirmDiagnosisMap
    {
        /// <summary>
        /// ICD 编码
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string value { get; set; }
    }
}