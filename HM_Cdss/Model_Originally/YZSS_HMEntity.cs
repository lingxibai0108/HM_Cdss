using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    public class YZSS_HMEntity
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
        //病程页面：2
        //检验医嘱：3 
        //处方医嘱：4
        //手术医嘱：5
        //护理页面：6
        //报告单页面（RIS）：7
        /// </summary>
        private int pagesoure = 5;
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

        public OperationRecord operationRecord { get; set; }


    }
    /// <summary>
    /// 手术医嘱，对应pageSource=5
    /// </summary>
    public class OperationRecord
    {
        /// <summary>
        /// 手术单编码
        /// </summary>
        public string recordNumber { get; set; }
        /// <summary>
        /// 手术部位
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 切口类型
        /// </summary>
        public string incisionType { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string anesthesia { get; set; }
        /// <summary>
        /// 术前诊断
        /// </summary>
        public string preoperativeDiagnose { get; set; }
        /// <summary>
        /// 手术列表
        /// </summary>
        public List<Operation> operationList { get; set; }
    
    }

    /// <summary>
    /// 手术
    /// </summary>
    public  class Operation
    {
        /// <summary>
        /// 手术id
        /// </summary>
        public string operationId{ get; set; }
        /// <summary>
        /// 手术名称
        /// </summary>
        public string operationName { get; set; }
        /// <summary>
        /// 1.治疗性操作，2.诊断性操作，3.介入治疗，4.手术
        /// </summary>
        public int operationType { get; set; }
        /// <summary>
        /// 手术描述
        /// </summary>
        public string operationDesc { get; set; }
        /// <summary>
        /// 手术医生
        /// </summary>
        public string doctorId { get; set; }
        /// <summary>
        /// 手术时间yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string operationTime { get; set; }
        /// <summary>
        /// 手术时间yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string operationLevel { get; set; }
    }
}