using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HM_Cdss.Model_Originally
{
    public class YZYP_Delete_HMEntity
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
        /// 删除的处方列表（被删除的处方记录）
        /// </summary>
        public List<Prescription_d> deletePrescriptionList { get; set; }
    }
    /// <summary>
    /// 删除用的处方类
    /// </summary>
    public class Prescription_d
    {
        /// <summary>
        /// 处方编号
        /// </summary>
        public string prescriptionNumber { get; set; }
        /// <summary>
        /// 删除的药品集合
        /// </summary>
        public List<Drug_d> drugList { get; set; }
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
    /// 删除用药品类
    /// </summary>
    public class Drug_d
    {
        /// <summary>
        /// 药品Id
        /// </summary>
        public string drugId { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string drugName { get; set; }
    }
}