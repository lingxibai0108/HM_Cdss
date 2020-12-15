using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    /// <summary>
    /// 药品医嘱模型
    /// </summary>
    public class YZYP_HMEntity
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
        /// </summary>
        private int pagesoure = 4;
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
        ///// <summary>
        ///// 患者信息
        ///// </summary>
        //public PatientInfo patientInfo { get; set; }
        /// <summary>
        /// 生命体征（查体）
        /// </summary>
        public PhysicalSign PhysicalSign { get; set; }
        ///// <summary>
        ///// 已明确诊断(每次提交全量诊断)
        ///// </summary>
        //public List<DefiniteDiagnosis> definiteDiagnosis { get; set; }
        /// <summary>
        /// 处方集合
        /// </summary>
        public List<Prescription> prescriptions{get;set;}


        public List<medicalOrders> medicalOrders { get; set; }

    }

    public class medicalOrders
    {
        /// <summary>\
        /// 医嘱单编号
        /// </summary>
        public string orderId { get; set; }

        public string doctorGuid { get; set; }
        public int timelinessFlag { get; set; }
        public int orderClass { get; set; }
        public int orderType { get; set; }
        public string orderCode { get; set; }
        public string orderContent { get; set; }

        public string dosage { get; set; }
        public string unit { get; set; }
        public string frequency { get; set; }
        public string pathway { get; set; }
        public string createTime { get; set; }
        public string executeTime { get; set; }
        public int orderFlag { get; set; }


    }

    /// <summary>
    /// 处方类
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        public string prescriptionNumber { get; set; }
        /// <summary>
        /// 医生编号（当次记录提交人）
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 处方创建时间（格式：yyyy-MM-ddHH:mm:ss）
        /// </summary>
        public string recordTime { get; set; }
        /// <summary>
        /// 处方修改时间（格式：yyyy-MM-ddHH:mm:ss）
        /// </summary>
        public string modifyTime { get; set; }


        /// <summary>
        /// 药品集合
        /// </summary>
        public List<Drug> drugList { get; set; }
    }

    /// <summary>
    /// 药品类
    /// </summary>
    public class Drug
    {
        /// <summary>
        /// 药品Id
        /// </summary>
        public string drugId { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string drugName { get; set; }
        /// <summary>
        /// 每次给药剂量
        /// </summary>
        public string dosage { get; set; }
        /// <summary>
        /// 频率
        /// </summary>
        public string frequency { get; set; }
        /// <summary>
        /// 剂型
        /// </summary>
        public string dosageForm { get; set; }
        /// <summary>
        /// 用药途径
        /// </summary>
        public string pathway { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string specification { get; set; }
    }
}