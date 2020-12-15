using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_Cdss.HMUtil
{
    /// <summary>
    /// 惠每初始化结构参数
    /// </summary>
    public class HMCSInfo
    {
        /// <summary>
        /// 由惠每提供的认证密钥
        /// </summary>
        public string autherKey { get; set; }
        /// <summary>
        /// 患者 唯一标识
        /// </summary>
        public string userGuid { get; set; }
        /// <summary>
        /// 住院就诊流水号
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 医生编码
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string doctorName { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string department { get; set; }
        /// <summary>
        /// 组织机构编码
        /// </summary>
        public string hospitalGuid { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string hospitalName { get; set; }
        /// <summary>
        /// 应用场景：1住院; 2门诊; 3急诊
        /// </summary>
        public int customEnv { get; set; }
        /// <summary>
        /// 接入类型 c门诊版   m住院版
        /// </summary>
        public string flag { get; set; }

    }
    /// <summary>
    /// 公共参数结构
    /// </summary>
    public class HM_Pulic_parameter
    {
        /// <summary>
        ///  患者编号(患者唯一标识)
        /// </summary>
        public string userGuid { get; set; }
        /// <summary>
        /// 住院就诊编号（一次住院产生的唯一标识）；
        /// </summary>
        public string serialNumber { get; set; }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string patientName { get; set; }
        /// <summary>
        /// 医生编号（必填，否则无质控提示）
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 医生姓名
        /// </summary>
        public string doctorName { get; set; }
        /// <summary>
        /// 入院时间(格式：yyyy-MM-dd  HH:mm:ss 或  yyyy-MM-dd)
        /// </summary>
        public DateTime admissionTime { get; set; }
        /// <summary>
        /// 住院科室中文名称（最新的科室名称，用于搜索历史记录）
        /// </summary>
        public string inpatientDepartment { get; set; }
        /// <summary>
        /// 页面来源,病案首页：1,病程页面：2,检验医嘱：3,处方医嘱：4,手术医嘱：5,护理页面：6,住院-检验报告：7
        /// </summary>
        public int pageSource { get; set; }
        /// <summary>
        /// 患者信息
        /// </summary>
        public HM_BRJBXX patientInfo { get; set; }
        /// <summary>
        /// 开启阻断提醒功能,可不填
        /// </summary>
        public int openInterdict { get; set; }//否	开启阻断提醒功能，默认为 0 0：EMR/医嘱系统 保存病历文书/医嘱时，不会触发阻断操作，建议在实时触发设置为 0 ，关闭阻断提醒功能 , 1：EMR/医嘱系统 保存病历文书/医嘱时，触发阻断操作，Dr.Mayson 进行质控，如果审核不通过，EMR/医嘱系统需阻断，弹出式提醒，取消保存病历文书/医嘱,调用Dr.Mayson系统接口继续打开对应的页面（或Dr.Mayson 自行打开窗口）， 医生按提醒进行下一步操作）
        /// <summary>
        /// 药品、护理、处置、会诊、膳食）医嘱列表
        /// </summary>
        public List<HM_YZLB> medicalOrders { get; set; }
        /// <summary>
        ///住院 检验结果列表
        /// </summary>
        public List<HM_JYBG> labTestList { get; set; }
        /// <summary>
        /// 住院 检查单结果列表 
        /// </summary>
        public List<HM_JCJG> examinationList { get; set; }
        /// <summary>
        /// 结构化诊断列表(每次提交全量诊断)
        /// </summary>
        public List<HM_ZDXX> definiteDiagnosis { get; set; }

    }
    /// <summary>
    /// 患者信息
    /// </summary>
    public class HM_BRJBXX
    {
        /// <summary>
        /// 性别 0女，1男, 2 其他
        /// </summary>
        public int gender { get; set; }
        /// <summary>
        /// 出生日期  yyyy-MM-dd 
        /// </summary>
        public string birthDate { get; set; }    //String	是	出生日期,推荐使用,格式： yyyy-MM-dd 或者 yyyyMMdd,说明：【birthDate 与 age,ageType ，选择一种方式必填】
        /// <summary>
        /// 年龄
        /// </summary>
        public string age { get; set; }
        /// <summary>
        /// 取值类型可不写
        /// </summary>
        public string ageType { get; set; }	//String	是	取值类型：岁、月、天
        /// <summary>
        /// 婚姻状况可不填  1.已婚。0.未婚。3.离异。4.丧偶。9.其他 可不填
        /// </summary> 
        public int maritalStatus { get; set; }	//Integer	否	婚姻状况  1.已婚。0.未婚。3.离异。4.丧偶。9.其他（影响推荐和提醒）
        /// <summary>
        /// 妊娠状况可不填  1.怀孕，0.未怀孕 （影响推荐和提醒）
        /// </summary>
        public int pregnancyStatus { get; set; }//Integer	否	妊娠状况  1.怀孕，0.未怀孕 （影响推荐和提醒）

    }
    /// <summary>
    /// 药品、护理、处置、会诊、膳食）医嘱列表
    /// </summary>
    public class HM_YZLB
    {
        /// <summary>
        /// 医嘱编号
        /// </summary>
        public string orderId { get; set; }
        /// <summary>
        /// 医生编号,可不填
        /// </summary>
        public string doctorGuid { get; set; }
        /// <summary>
        /// 长期临时标记1：长期医嘱2：临时医嘱
        /// </summary>
        public int timelinessFlag { get; set; }
        /// <summary>
        /// 医嘱分类 1：住院医嘱2：门诊医嘱3：急诊医嘱4：出院医嘱（出院带药-质控依赖）
        /// </summary>
        public int orderClass { get; set; }
        /// <summary>
        /// 医嘱类型 0. 其他,1. 检验,2. 检查,3. 药品,4. 护理,5. 膳食（食物）6. 手术,7. 处置,8. 会诊,9. 死亡医嘱
        /// </summary>
        public int orderType { get; set; }
        /// <summary>
        /// 医嘱代码
        /// </summary>
        public string orderCode { get; set; }
        /// <summary>
        /// 医嘱内容
        /// </summary>
        public string orderContent { get; set; }
        /// <summary>
        /// 每次给药剂量
        /// </summary>
        public string dosage { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 频率
        /// </summary>
        public string frequency { get; set; }
        /// <summary>
        /// 剂型可不写
        /// </summary>
        public string dosageForm { get; set; } 	//否	剂型（片，支，袋）
        /// <summary>
        /// 用药途径可不写
        /// </summary>
        public string pathway { get; set; } 	//否	用药途径
        /// <summary>
        /// 规格可不写
        /// </summary>
        public string specification { get; set; }	//否	规格
        /// <summary>
        /// 医嘱创建时间 （格式： yyyy-MM-dd HH:mm:ss）
        /// </summary>
        public DateTime createTime { get; set; }
        /// <summary>
        /// 医嘱执行时间可不写
        /// </summary>
        public DateTime executeTime { get; set; } 	//否	医嘱执行时间（格式： yyyy-MM-dd HH:mm:ss）
        /// <summary>
        /// 医嘱停止/作废时间可不写
        /// </summary>
        public DateTime stopTime { get; set; }	//否	医嘱停止/作废时间（格式： yyyy-MM-dd HH:mm:ss）
        /// <summary>
        /// 医嘱操作标识1 ：新增 (已开立)2 :已执行3 :已停止4 :取消5 :作废
        /// </summary>
        public int orderFlag { get; set; }

    }
    /// <summary>
    /// 住院检验列表参数
    /// </summary>
    public class HM_JYBG
    {
        /// <summary>
        /// 检验编号
        /// </summary>
        public string labTestNumber { get; set; }
        /// <summary>
        /// 检验单名称
        /// </summary>
        public string labTestName { get; set; }
        /// <summary>
        /// 检验样本可不填
        /// </summary>
        public string labTestSample { get; set; }	//	否	检验样本
        /// <summary>
        /// 检验采样时间yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string labReceiveTime { get; set; }
        /// <summary>
        /// 检验结果产生时间yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string reportTime { get; set; }
        /// <summary>
        /// 检验结果列表
        /// </summary>
        public List<HM_JYJG> labTestItems { get; set; }

    }
    /// <summary>
    /// 住院检验结果列表参数
    /// </summary>
    public class HM_JYJG
    {
        /// <summary>
        /// 检验结果中文名称
        /// </summary>
        public string abTestItemName { get; set; }
        /// <summary>
        /// 检验结果的值可不填
        /// </summary>
        public string labTestItemEnName { get; set; }	//	否	检验结果的值
        /// <summary>
        /// 检验结果的值
        /// </summary>
        public string labTestResult { get; set; }
        /// <summary>
        /// 检验方法可不填
        /// </summary>
        public string labTestValueUnit { get; set; }	//	否	检验方法
        /// <summary>
        /// 检验方法可不填
        /// </summary>
        public string labTestValueChange { get; set; }	//	否	检验方法,正常：N,偏高：H,偏低：L
        /// <summary>
        /// 检验方法可不填
        /// </summary>
        public string labTestMethod { get; set; }	//	否	检验方法
        /// <summary>
        /// 参考区间可不填
        /// </summary>
        public string normalRange { get; set; }//	否	参考区间
    }
    /// <summary>
    /// 住院 检查单结果列表参数
    /// </summary>
    public class HM_JCJG
    {
        /// <summary>
        /// 检查单编号
        /// </summary>
        public string examinationNumber { get; set; }
        /// <summary>
        /// 检查单名称可不填
        /// </summary>
        public string examinationName { get; set; }	//	否	检查单名称
        /// <summary>
        /// 检查结果可不填
        /// </summary>
        public string examinationResult { get; set; }	//	否	检查结果
        /// <summary>
        /// 检查描述可不填
        /// </summary>
        public string examinationDesc { get; set; }	//	否	检查描述
        /// <summary>
        /// 检查结果产生时间可不填
        /// </summary>
        public string reportTime { get; set; }	//	否	检查结果产生时间（格式： yyyy-MM-dd HH:mm:ss）
        /// <summary>
        /// 设备名称可不填
        /// </summary>
        public string equipment { get; set; }	//	否	设备名称
        /// <summary>
        /// 检查细项可不填
        /// </summary>
        public List<HM_JCMX> examinationItem { get; set; }	//否	检查细项
    }
    /// <summary>
    /// 住院 检查细项
    /// </summary>
    public class HM_JCMX
    {
        /// <summary>
        /// 项目名称可不填
        /// </summary>
        public string examinationItemCode { get; set; }	//	否	项目名称
        /// <summary>
        /// 项目名称可不填
        /// </summary>
        public string examinationItemName { get; set; }	//	否	项目名称
        /// <summary>
        /// 项目结果可不填
        /// </summary>
        public string examinationItemResult { get; set; }	//	否	项目结果
        /// <summary>
        /// 项目单位可不填
        /// </summary>
        public string examinationItemUnit { get; set; }	//	否	项目单位
    }
    /// <summary>
    /// 住院 诊断列表(每次提交全量诊断)
    /// </summary>
    public class HM_ZDXX
    {
        /// <summary>
        /// 诊断ID可不填
        /// </summary>
        public string id { get; set; }//	否	诊断ID
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 诊断类型可不填
        /// </summary>
        public int diseaseType { get; set; }//		否	诊断类型1：入院诊断 （默认值，如果 diseaseType为空，默认为入院诊断）2:门诊诊断        5:初步诊断        6:确诊诊断        7:补充诊断        8:修正诊断        9:出院诊断        10：死亡诊断        11:留观诊断        12:目前诊断        13:术前诊断        14:术中诊断        15:术后诊断        16:转入诊断        17:转出诊断1        8:尸检诊断        19：会诊诊断        20:辅助诊断(超声、放射、病理等)
        /// <summary>可不填
        /// 下诊断时间
        /// </summary>
        public string recordTime { get; set; }//		否	下诊断时间（格式： yyyy-MM-dd HH:mm:ss）
        /// <summary>
        /// 诊断ICD编码可不填
        /// </summary>
        public string diseaseIcd { get; set; }//		否	诊断ICD编码
        /// <summary>
        /// 诊断分类可不填
        /// </summary>
        public int diseaseDoctorType { get; set; }//		否	诊断分类：1.西医诊断。2.中医诊断
        /// <summary>
        /// 诊断医师编码可不填
        /// </summary>
        public string diseaseDoctorGuid { get; set; }//		否	诊断医师编码
        /// <summary>
        /// 诊断医师名称可不填
        /// </summary>
        public string diseaseDoctorName { get; set; }//		否	诊断医师名称
        /// <summary>
        /// 诊断顺序号，正整数：1，2，3 从小到大，表示诊断
        /// </summary>
        public int diseaseSequence { get; set; }
        /// <summary>
        /// 是否为主诊断可不填
        /// </summary>
        public int isMainDisease { get; set; }//		否	是否为主诊断1：是2：否
    }
}
