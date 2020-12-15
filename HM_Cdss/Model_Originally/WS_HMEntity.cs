using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    public class WS_HMEntity
    {
        /// <summary>
        /// 患者编号(患者唯一标识)
        /// </summary>
        public String  userGuid	{ get; set; }

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
        private int QCRemind =0;
        public int enableQCRemind 
        {
            get 
            {
                return QCRemind;
            }
            set
            {
                QCRemind=value;
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
        private int pagesoure=2;
        public int pageSource 
        { 
            get
            {
                return pagesoure;
            }
            set
            {
                pagesoure=value;
            }
        }	
        /// <summary>
        /// 患者信息
        /// </summary>
        public PatientInfo patientInfo{get;set;}
        /// <summary>
        /// 生命体征（查体）
        /// </summary>
        public PhysicalSign PhysicalSign {get;set;}
        /// <summary>
        /// 已明确诊断(每次提交全量诊断)
        /// </summary>
        public List<DefiniteDiagnosis> definiteDiagnosis {get;set;}

        /// <summary>
        /// 病程记录列表（新增或有变更的病程记录）
        /// </summary>
        public List<ProgressNote> progressNoteList {get;set;}
        /// <summary>
        /// 删除的病程记录列表（被删除的病程记录）
        /// </summary>
        public List<deleteProgressNote> deleteProgressNoteList { get; set; }
        /// <summary>
        /// 处方集合
        /// </summary>
        public List<prescriptions> prescriptionsList { get; set; }
        /// <summary>
        /// 删除处方集合
        /// </summary>
        public List<prescriptions> deletePrescriptionsList { get; set; }
    }

    /// <summary>
    /// 已明确诊断(每次提交全量诊断)
    /// </summary>
    public class DefiniteDiagnosis
    {
        /// <summary>
        /// 诊断ID
        /// </summary>
        public string id { set; get; }
        /// <summary>
        /// 诊断名称ID
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 诊断类型
        ///1：入院诊断
        ///3：质控诊断
        ///5：初步诊断
        ///6：确定诊断
        ///7：补充诊断
        ///8：更正诊断
        ///9：出院诊断
        ///10：死亡诊断
        ///11：留观诊断
        /// </summary>
        public int diseaseType { set; get; }
        /// <summary>
        /// 下诊断时间（格式：yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string narecordTimeme { set; get; }
    }

    /// <summary>
    /// 病程记录
    /// </summary>
    public class ProgressNote
    {
        /// <summary>
        /// 病程唯一标识（同一份病程记录文档，病程唯一标识应相同）
        /// </summary>
        public string progressGuid { get; set; }
        /// <summary>
        /// 病程类型
        /// 门诊病历：0
        //入院记录：1
        //首次病程：2
        //日常病程：3
        //查房记录：4
        //手术前记录：5
        //手术后小结：6 
        //讨论小结：7
        //阶段小结：8
        //会诊记录：9
        //出院小结：10
        //其他记录：11
        //首次查房记录：12
        //手术记录：13
        //病案首页： 15
        //急诊病历：16
        /// </summary>
        public int progressType { get; set; }
        /// <summary>
        /// 病程模板名称（当同一个病程类型下,有多种不同的模板时，需要设置，模板名称在同一病程类型下应唯一，否则影响模板数据的解析）
        /// </summary>
        public string progressTempalteName { get; set; }
        /// <summary>
        /// 病程内容传递格式
        //0: text,通过progressMessage传递文本内容
        //1:xml，通过progressMessage传递xml内容
        //2：map,通过messageList传递病程信息的键值对
        /// </summary>
        public int msgType { get; set; }
        /// <summary>
        /// 病程文本信息，msgType=1时，必填
        /// </summary>
        public string progressMessage { get; set; }
        /// <summary>
        /// msgType=2时，必填
        /// </summary>
        public List<Message> messageList { get; set; }
        
    }

    public class Message
    {
        /// <summary>
        /// 病程信息的属性名称，如：主诉，现病史
        /// </summary>
        public string key { set; get; }
        /// <summary>
        /// 病程信息的属性值，如：医生填写的主诉内容，现病史内容
        /// </summary>
        public string value { set; get; }
        /// <summary>
        /// 医生编号（当次记录提交人）
        /// </summary>
        public string doctorGuid { set; get; }
        /// <summary>
        ///记录创建时间（格式：yyyy-MM-ddHH:mm:ss
        /// </summary>
        public string recordTime { set; get; }

    }
    /// <summary>
    /// 删除的病程记录列表（被删除的病程记录）
    /// </summary>
    public class deleteProgressNote
    {
        /// <summary>
        /// 病程唯一标识（同一份病程记录文档，病程唯一标识应相同）
        /// </summary>
        public string progressGuid { get; set; }
        /// <summary>
        /// 病程类型
        /// 门诊病历：0
        ///入院记录：1
        ///首次病程：2
        ///日常病程：3
        ///查房记录：4
        ///手术前记录：5
        ///手术后小结：6 
        ///讨论小结：7
        ///阶段小结：8
        ///会诊记录：9
        ///出院小结：10
        ///其他记录：11
        ///首次查房记录：12
        ///手术记录：13
        ///病案首页： 15
        ///急诊病历：16
        /// </summary>
        public int progressType { get; set; }
        /// <summary>
        /// 医生编号（当次记录提交人）
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        public string recordTime { get; set; }
        
    }
    /// <summary>
    /// 处方头集合
    /// </summary>
    public class prescriptions
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        public string prescriptionNumber { get; set; }
        /// <summary>
        ///医生编号（当次记录提交人）
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 处方创建时间（格式：yyyy-MM-ddHH:mm:ss)
        /// </summary>
        public string recordTime { get; set; }
        /// <summary>
        /// 处方修改时间（格式：yyyy-MM-ddHH:mm:ss)
        /// </summary>
        public string modifyTime { get; set; }
        
        /// <summary>
        /// 药品集合
        /// </summary>
        public List<drug> drugList { get; set; }
    }
    /// <summary>
    /// 药品集合
    /// </summary>
    public class drug
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