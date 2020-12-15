using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using HMCSoft.Data;
using Newtonsoft.Json;
using WK_HISYZ.Models;
namespace HM_Cdss.HMUtil
{
    /// <summary>
    /// 惠每class
    /// </summary>
    public  class GetHmJsonStr
    {
        #region

        private static ClsBrInfo brInfo = null;

        public GetHmJsonStr(ClsBrInfo _brInfo) 
        {
            brInfo = _brInfo;
        }
        /// <summary>
        /// 返回公共参数对象
        /// </summary>
        /// <param name="brInfo">病人对象信息</param>
        /// <param name="pageSource">页面来源页面来源,病案首页：1;病程页面：2;检验医嘱：3;处方医嘱：4;手术医嘱：5;护理页面：6;报告单页面（RIS）：7</param>
        /// <returns></returns>
        public static HM_Pulic_parameter GetHMJstr(int pageSource)
        {
            HM_Pulic_parameter HmGgcs = new HM_Pulic_parameter();//公共参数
            //病人基本信息
            HmGgcs.userGuid = brInfo.Brid.ToString();//患者编号
            HmGgcs.serialNumber = brInfo.Brid.ToString();//住院就诊号
            HmGgcs.patientName = brInfo.Brxm;//患者名
            HmGgcs.doctorGuid = brInfo.ZzysId.ToString();//医生编号
            HmGgcs.doctorName = brInfo.ZzysMc;//医生姓名
            HmGgcs.admissionTime = brInfo.Zysj;//入院时间
            HmGgcs.inpatientDepartment = brInfo.RY_BqMc;//科室名
            HmGgcs.pageSource = pageSource;//页面来源
            //病人基本信息
            HmGgcs.patientInfo.gender = brInfo.Sex == "男" ? 1 : 0;//性别
            HmGgcs.patientInfo.birthDate = brInfo.CSRQ;//出生日期
            HmGgcs.patientInfo.age = brInfo.Age;//年龄 int
            //HmGgcs.patientInfo.ageType = "岁";//年龄类型  --
            HmGgcs.patientInfo.maritalStatus = 0;//婚姻状况  ---
            HmGgcs.patientInfo.pregnancyStatus = 0;//是否是孕妇 0否1是
            HmGgcs.openInterdict = 0;//开启阻断 ,不开启0
            return HmGgcs;
        }

        /// <summary>
        /// 返回药品和检查的json对象字符串
        /// </summary>
        /// <param name="lstyp">药品</param>
        /// <param name="lstcy">草药</param>
        /// <param name="lstcydy">出院带药</param>
        /// <param name="pageSource">页面来源页面来源,病案首页：1;病程页面：2;检验医嘱：3;处方医嘱：4;手术医嘱：5;护理页面：6;报告单页面（RIS）：7</param>
        /// <returns></returns>
        public string  YZYPandJCcs(List<BQ2YZD01> lstyp, List<BQ2YZD01> lstcy, List<BQ2YZD01> lstcydy, List<BQ2YZD01> JC_BQ2YZD01,int pageSource=4)
        {
            HM_Pulic_parameter hmggcs = GetHMJstr(pageSource);
            hmggcs.medicalOrders = new List<HM_YZLB>();
            HM_YZLB drug = null;
            //药品
            if (lstyp != null && lstyp.Count > 0)
            {
                foreach (BQ2YZD01 item in lstyp)
                {
                    drug = new HM_YZLB();
                    drug.orderId = item.NewItemID;//医嘱编号
                    drug.doctorGuid = item.KDYS.ToString();//医生编号
                    drug.timelinessFlag =Convert.ToInt32( item.YZLX);//长1期临时2
                    drug.orderClass = 1;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 3;//药品
                    drug.orderCode = item.YZID.ToString();//医嘱代码
                    drug.orderContent = item.Content;//医嘱内容
                    drug.dosage = item.SL.ToString();//剂量
                    drug.unit = item.DCDWMC;//="mg";//剂量单位
                    drug.frequency = item.PCDM;//频率
                    drug.dosageForm = item.DCDWMC;//剂型 ,片
                    drug.pathway = item.YFMC;//用药途径 用法 如 口服
                    drug.specification = item.GG;//规格
                    drug.createTime = item.YZRQ;//医嘱日期
                    drug.executeTime =item.YZZXRQ;//医嘱执行时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);
                }
            }
            //草药
            if (lstcy != null && lstcy.Count > 0)
            {
                foreach (BQ2YZD01 item in lstcy)
                {
                    drug = new HM_YZLB();
                    drug.orderId = item.NewItemID;//医嘱编号
                    drug.doctorGuid = item.KDYS.ToString();//医生编号
                    drug.timelinessFlag = Convert.ToInt32(item.YZLX);//长1期临时2
                    drug.orderClass = 1;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 3;//药品
                    drug.orderCode = item.YZID.ToString();//医嘱代码
                    drug.orderContent = item.Content;//医嘱内容
                    drug.dosage = item.SL.ToString();//剂量
                    drug.unit = item.DCDWMC;//="mg";//剂量单位
                    drug.frequency = item.PCDM;//频率
                    drug.dosageForm = item.DCDWMC;//剂型 ,片
                    drug.pathway = item.YFMC;//用药途径 用法 如 口服
                    drug.specification = item.GG;//规格
                    drug.createTime = item.YZRQ;//医嘱日期
                    drug.executeTime = item.YZZXRQ;//医嘱执行时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);
                }
            }
            //出院带药
            if (lstcydy != null && lstcydy.Count > 0)
            {
                foreach (var item in lstcydy)
                {
                    drug = new HM_YZLB();
                    drug.orderId = item.NewItemID;//医嘱编号
                    drug.doctorGuid = item.KDYS.ToString();//医生编号
                    drug.timelinessFlag = Convert.ToInt32(item.YZLX);//长1期临时2
                    drug.orderClass =4;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 3;//药品
                    drug.orderCode = item.YZID.ToString();//医嘱代码
                    drug.orderContent = item.Content;//医嘱内容
                    drug.dosage = item.SL.ToString();//剂量
                    drug.unit = item.DCDWMC;//="mg";//剂量单位
                    drug.frequency = item.PCDM;//频率
                    drug.dosageForm = item.DCDWMC;//剂型 ,片
                    drug.pathway = item.YFMC;//用药途径 用法 如 口服
                    drug.specification = item.GG;//规格
                    drug.createTime = item.YZRQ;//医嘱日期
                    drug.executeTime = item.YZZXRQ;//医嘱执行时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);
                }
            }
            //检查医嘱
            if (JC_BQ2YZD01 != null && JC_BQ2YZD01.Count > 0)
            {
                foreach (var item in JC_BQ2YZD01)
                {
                    drug = new HM_YZLB();
                    drug.orderId = item.NewItemID;//医嘱编号
                    drug.doctorGuid = item.KDYS.ToString();//医生编号
                    drug.timelinessFlag = Convert.ToInt32(item.YZLX);//长1期临时2
                    drug.orderClass = 1;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 2;//检查
                    drug.orderCode = item.YZID.ToString();//医嘱代码
                    drug.orderContent = item.Content;//医嘱内容
                    drug.createTime = item.YZRQ;//医嘱日期
                    drug.executeTime = item.YZZXRQ;//医嘱执行时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);

                }
            }
            string YPJsonStr = JsonConvert.SerializeObject(hmggcs);
            return YPJsonStr;
        }
        public string YZJYcs(List<BQ2YZD01> JY_BQ2YZD01, List<BQ2YZD01> JC_BQ2YZD01, BQ2YZD01 HL_BQ2YZD01, WK_Operation.Models.BQ2SQD01 SSYZBQ2SQD01, int pageSource = 3)
        {
            HM_Pulic_parameter hmggcs = GetHMJstr(pageSource);
            hmggcs.medicalOrders = new List<HM_YZLB>();
            HM_YZLB drug = null;
            //检验
            if (JY_BQ2YZD01 != null && JY_BQ2YZD01.Count > 0)
            {
                foreach (var item in JY_BQ2YZD01)
                {
                    drug = new HM_YZLB();
                    drug.orderId = item.NewItemID;//医嘱编号
                    drug.doctorGuid = item.KDYS.ToString();//医生编号
                    drug.timelinessFlag = Convert.ToInt32(item.YZLX);//长1期临时2
                    drug.orderClass = 1;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 1;//检验
                    drug.orderCode = item.YZID.ToString();//医嘱代码
                    drug.orderContent = item.Content;//医嘱内容
                    drug.createTime = item.YZRQ;//医嘱日期
                    drug.executeTime = item.YZZXRQ;//医嘱执行时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);
                }
            }

            string YPJsonStr = JsonConvert.SerializeObject(hmggcs);
            return YPJsonStr;
        }
        /// <summary>
        /// 手术
        /// </summary>
        /// <param name="SSYZBQ2SQD01">手术申请单</param>
        /// <param name="pageSource"></param>
        /// <returns></returns>
        public string YZSScs(WK_Operation.Models.BQ2SQD01 SSYZBQ2SQD01, int pageSource = 5)
        {
            HM_Pulic_parameter hmggcs = GetHMJstr(pageSource);
            hmggcs.medicalOrders = new List<HM_YZLB>();
            HM_YZLB drug = null;
            //手术
            if (SSYZBQ2SQD01 != null)
            {
                    drug = new HM_YZLB();
                    drug.orderId = SSYZBQ2SQD01.PDAID;//医嘱编号
                    drug.doctorGuid = SSYZBQ2SQD01.BQ2YZF03.ZDYSMC;//医生编号
                    drug.timelinessFlag = 2;//长1期临时2
                    drug.orderClass = 1;//医嘱分类1：住院医嘱3：急诊医嘱4：出院医嘱（出院带药 - 质控依赖）
                    drug.orderType = 6;//手术
                    drug.orderCode = SSYZBQ2SQD01.BQ2YZF03.SSDBH;//医嘱代码
                    drug.orderContent = SSYZBQ2SQD01.;//医嘱内容
                    drug.createTime = SSYZBQ2SQD01.BQ2YZF03.KDRQ;//医嘱日期
                    drug.executeTime = SSYZBQ2SQD01.BQ2YZF03.SSSJ;//手术时间
                    // drug.stopTime = "";//医嘱停止时间
                    drug.orderFlag = 1;//医嘱操作标识 新增1
                    hmggcs.medicalOrders.Add(drug);

            }
            string YPJsonStr = JsonConvert.SerializeObject(hmggcs);
            return YPJsonStr;
        }

        #endregion
        /// <summary>
        /// 惠每初始化结构参数
        /// </summary>
        /// <param name="_BrInfo">病人实体类</param>
        /// <returns></returns>
        public static string GetHMBrInfo_Json(ClsBrInfo _BrInfo)
        {
            HMCSInfo HMBrxx = new HMCSInfo();
            HMBrxx.autherKey = GlobalConfigFile.AutherKey;
            HMBrxx.userGuid = _BrInfo.Brid.ToString();
            HMBrxx.serialNumber = _BrInfo.Brid.ToString();
            HMBrxx.doctorGuid = _BrInfo.ZzysId.ToString();
            HMBrxx.doctorName =_BrInfo.ZzysMc;
            HMBrxx.department = _BrInfo.SybqMc.ToString();
            HMBrxx.hospitalGuid = GlobalConfigFile.HospitalGuid;
            HMBrxx.hospitalName = GlobalConfigFile.HospitalName;
            HMBrxx.customEnv = 1;//
            HMBrxx.flag = "m";
            string json = JsonConvert.SerializeObject(HMBrxx);
            return json;
        }
    }

}
