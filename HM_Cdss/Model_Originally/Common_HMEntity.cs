using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    /// <summary>
    /// 通用删除对象模型
    /// </summary>
    public class Common_HMEntity
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
        private int QCRemind = 1;
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
    }  
}