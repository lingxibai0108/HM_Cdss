using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    /// <summary>
    /// 检验检查模型
    /// </summary>
    public class YZJYJC_HMEntity
    {
        /// <summary>
        /// 患者编号(患者唯一标识)
        /// </summary>
        public String userGuid { get; set; }

        /// <summary>
        /// 住院就诊编号（一次住院产生的唯一标识）
        /// </summary>
        public String serialNumber { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public String patientName { get; set; }
        /// <summary>
        /// 医生编号
        /// </summary>
        public String doctorGuid { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public String doctorName { get; set; }
        /// <summary>
        /// 是否启用质控提示功能 1：启用 0：不启用默认为0
        /// </summary>
        private int QCRemind = 0;
        public int enableQCRemind
        {
            get
            {
                return QCRemind;
            }
            set
            {
                QCRemind = value;
            }
        }
        /// <summary>
        /// 入院时间(格式：yyyy-MM-ddHH:mm:ss)
        /// </summary>
        public String admissionTime { get; set; }
        /// <summary>
        /// 住院科室名称（最新的科室名称，用于搜索历史记录）
        /// </summary>
        public String inpatientDepartment { get; set; }
        /// <summary>
        /// 页面来源
        /// 病案首页：1
        ///病程页面：2
        ///检验医嘱：3 
        ///处方医嘱：4
        ///手术医嘱：5
        ///护理页面：6
        ///报告单页面（RIS）：7
        //// </summary>
        private int pagesoure = 3;
        public int pageSource
        {
            get
            {
                return pagesoure;
            }
            set
            {
                pagesoure = value;
            }
        }    
        /// <summary>
        /// 患者信息
        /// </summary>
        public PatientInfo patientInfo { get; set; }
        /// <summary>
        /// 生命体征（查体）
        /// </summary>
        public PhysicalSign PhysicalSign { get; set; }
        /// <summary>
        /// 已明确诊断(每次提交全量诊断)
        /// </summary>
        public List<DefiniteDiagnosis> definiteDiagnosis { get; set; }
        /// <summary>
        /// 开立检查/检验医嘱
        /// </summary>
        public List<NewTest> newTestList { get; set; }
    }
    /// <summary>
    /// 检验/检查
    /// </summary>
    public class NewTest
    {
        /// <summary>
        /// 检查/检验编号
        /// </summary>
        public string testId { get; set; }
        /// <summary>
        /// 检查/检验名称
        /// </summary>
        public string testName { get; set; }
        /// <summary>
        /// 检查/检验名称 类型1：检验单 2：检查单
        /// </summary>
        public int testType { get; set; }
        /// <summary>
        ///检验样本
        /// </summary>
        public string testSample { get; set; }
        /// <summary>
        ///检查部位
        /// </summary>
        public string testPosition { get; set; }
        /// <summary>
        ///备注
        /// </summary>
        public string remark { get; set; }

    }
}