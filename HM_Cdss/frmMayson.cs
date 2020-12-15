using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HMCSoft.Mayson;
using HM_Cdss.HMUtil;
using Newtonsoft.Json.Linq;
using WK_EMR.BLL;
using HM_Cdss.Model_Originally;
using System.Web.Script.Serialization;
using WK_EMR.Models;
namespace HM_Cdss
{
    public class frmMayson
    {
        private TCPClient MyTcpClient = null;//客户端TCPClient
        private StaMayson myMayson = null;
        private bool ThreadControl = false;
        delegate void AdddataTxbReceiveDelegate(string str);
        public frmMayson()
        {
            CreatmyMayson();
        }
        private void CreatmyMayson()
        {
            myMayson = StaMayson.GetStaMayson(GlobalConfigFile.UrlAddress);
         // myMayson.VisibleChanged += FrmMayson_VisibleChanged;
            myMayson.WritebackEvent += FrmMayson_WritebackEvent;
        }
        /// <summary>
        /// 接收服务器数据(返回的数据功能头command会以英文的逗号隔开)--DLL窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private string FrmMayson_WritebackEvent(string content)
        {
            //if (MessageBox.Show("是否引用数据?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification) == DialogResult.Yes)
           // AdddataTxbReceive(content);
            try
            {
                string[] splitString = content.Split(',');
                string command = splitString[0];
                string HMDataBack = content.Substring(splitString[0].Length + 1);
                switch (command)
                {
                    case "maysonToNa"://新版本
                        ManageMaysonToNaInfo(HMDataBack);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 初始化惠每
        /// </summary>
        public void Init(string dataToSend)
        {
            myMayson.Init(dataToSend, "m");
        }
        /// <summary>
        /// 医嘱开立
        /// </summary>
        public void OpenArticleDetail( string data)
        {
            myMayson.OpenArticleDetail(data);
        }
        /// <summary>
        /// 医嘱提交
        /// </summary>
        public void Send(string data)
        {
            myMayson.Send(data);
        }
        /// <summary>
        /// 在txbReceive中追加信息
        /// 收到的信息
        /// </summary>
        /// <param name="str">要追加的信息</param>
        //private void AdddataTxbReceive(string str)
        //{
        //    try
        //    {
        //        if (txbRecv.InvokeRequired)
        //        {
        //            AdddataTxbReceiveDelegate d = AdddataTxbReceive;
        //            txbRecv.Invoke(d, str);
        //        }
        //        else
        //        {
        //            txbRecv.Text += str + "\r\n";
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        /// <summary>
        /// 处理接收到的数据
        /// </summary>
        /// <param name="str"></param>
        private void ManageMaysonToNaInfo(string str)
        {
            JObject jobStr = JObject.Parse(str) as JObject;

            if (jobStr.Property("currentEntity") != null)
            {
                foreach (JObject obj in jobStr["currentEntity"])
                {
                    string Type = obj["type"].ToString();
                    //疑似危重疾病
                    if (Type == "1")
                    {


                    }
                    //推荐检查
                    else if (Type == "2")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();
                        }
                    }
                    //推荐用药
                    else if (Type == "3")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();
                        }
                    }
                    //检查解读
                    else if (Type == "4")
                    {

                    }
                    //推荐治疗方案
                    else if (Type == "5")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();
                        }
                    }
                    //推荐评估表
                    else if (Type == "6")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();
                        }
                    }
                    //疑似常见诊断
                    else if (Type == "7")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();
                        }
                    }
                    //疑似因子
                    else if (Type == "8")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();

                        }
                    }
                    //文献地址
                    else if (Type == "11")
                    {
                        JArray items = JArray.Parse(obj["items"].ToString()) as JArray;
                        foreach (JObject item in items)
                        {
                            string itemStr = item["text"].ToString();

                        }
                    }
                }
            }
        }


        /// <summary>
        /// 断开cdss服务
        /// </summary>
        private void CloseConnectToCdssServer()
        {
            try
            {
                ThreadControl = true;
                MyTcpClient.Close();
            }
            catch
            {

            }
        }

        /// <summary>
        /// 查看药品、检查、检验详情
        /// </summary>
        /// <param name="YPMC">药品名称</param>
        /// <param name="DLID">大类id</param>
        /// <param name="NM">药品内码</param>
        /// <returns></returns>
        public void OpenArticleDetail(string YPMC, string DLID, string NM)
        {
            try
            {
                JObject jObject = new JObject();
                jObject["name"] = YPMC;
                jObject["type"] = DLID;
                jObject["id"] = NM;
                myMayson.OpenArticleDetail(jObject.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 开遗嘱时调用 
        /// </summary>
        /// <param name="brid">病人id</param>
        /// <param name="zyh">住院号</param>
        /// <param name="yzyp_hmEntity">医嘱参数</param>
        public void SendYpSendJson(string brid, string zyh, YZYP_HMEntity yzyp_hmEntity)
        {
            try
            {
                Common_HMEntity _common_HMEntity = InitPatitenBaseInfo(brid, zyh);
                JavaScriptSerializer ja = new JavaScriptSerializer();
                ja.MaxJsonLength = Int32.MaxValue;
                JObject obj = JObject.Parse(ja.Serialize(yzyp_hmEntity));
                JObject obj1 = JObject.Parse(ja.Serialize(_common_HMEntity));
                obj.Merge(obj1);
                string dataToSend = obj.ToString();
                myMayson.Send(dataToSend);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 新建或修改病史调用
        /// </summary>
        /// <param name="strZyh">住院号</param>
        /// <param name="brid">病人ID</param>
        /// <param name="strBrxm">病人姓名</param>
        /// <param name="strMedRecId"></param>
        /// <param name="strBsfl"></param>
        /// <param name="progressTempalteName"></param>
        /// <param name="nsOffXml"></param>
        public void SendHuiMei_UpdateBs(string strZyh, string brid, string strBrxm, string strMedRecId, string strBsfl, string progressTempalteName, string nsOffXml)
        {
            try
            {
                WS_HMEntity _hmWS = new WS_HMEntity();
                //病人基本信息
                _hmWS.userGuid = strZyh;
                _hmWS.serialNumber = brid;
                _hmWS.patientName = strBrxm;
                _hmWS.progressNoteList = new List<ProgressNote>();
                ProgressNote pn = new ProgressNote();
                pn.progressGuid = strMedRecId;
                pn.progressType = GetProgressType(strBsfl);
                pn.progressTempalteName = progressTempalteName;
                pn.msgType = 1; //0: text,通过progressMessage传递文本内容 1:xml，通过progressMessage传递xml内容 2：map,通过messageList传递病程信息的键值对
                pn.progressMessage = nsOffXml;
                _hmWS.progressNoteList.Add(pn);
                Common_HMEntity _common_HMEntity = InitPatitenBaseInfo(brid, strZyh);
                JavaScriptSerializer ja = new JavaScriptSerializer();
                ja.MaxJsonLength = Int32.MaxValue;
                JObject obj = JObject.Parse(ja.Serialize(_hmWS));
                JObject obj1 = JObject.Parse(ja.Serialize(_common_HMEntity));
                obj.Merge(obj1);
                myMayson.Send(obj.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 删除病史调用
        /// </summary>
        /// <param name="strZyh"></param>
        /// <param name="brid"></param>
        /// <param name="strBrxm"></param>
        /// <param name="strMedRecId"></param>
        /// <param name="strBsfl"></param>
        /// <param name="strYsgh"></param>
        public void SendHuiMei_DeleteBs(string strZyh, string brid, string strBrxm, string strMedRecId, string strBsfl, string strYsgh)
        {
            try
            {
                WS_HMEntity _hmWS = new WS_HMEntity();
                //病人基本信息
                _hmWS.userGuid = strZyh;
                _hmWS.serialNumber = brid;
                _hmWS.patientName = strBrxm;

                _hmWS.deleteProgressNoteList = new List<deleteProgressNote>();
                deleteProgressNote pn = new deleteProgressNote();
                pn.progressGuid = strMedRecId;
                pn.progressType = GetProgressType(strBsfl);
                pn.doctorGuid = strYsgh;
                pn.recordTime = DateTime.Now.ToString();
                _hmWS.deleteProgressNoteList.Add(pn);
                Common_HMEntity _common_HMEntity = InitPatitenBaseInfo(brid, strZyh);
                JavaScriptSerializer ja = new JavaScriptSerializer();
                ja.MaxJsonLength = Int32.MaxValue;
                JObject obj = JObject.Parse(ja.Serialize(_hmWS));
                JObject obj1 = JObject.Parse(ja.Serialize(_common_HMEntity));
                obj.Merge(obj1);
                myMayson.Send(obj.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        #region 结构化参数
        /// <summary>
        /// 参数病人数据和诊断
        /// </summary>
        /// <param name="brid"></param>
        /// <param name="zyh"></param>
        private Common_HMEntity InitPatitenBaseInfo(string brid, string zyh)
        {
            ClsBrInfoBLL hmbll = new ClsBrInfoBLL();
            ClsBrInfo clsBrInfo = hmbll.GetBrInfo(int.Parse(brid), zyh)[0];
            DataTable dt1 = hmbll.GetHmDiagnose(Convert.ToInt32(brid));
            //病人基本信息
            Common_HMEntity _common_HMEntity = new Common_HMEntity();
            string strZyh = clsBrInfo.ZYID;
            _common_HMEntity.userGuid = clsBrInfo.ZYID;
            _common_HMEntity.serialNumber = brid;
            _common_HMEntity.patientName = clsBrInfo.XM;
            _common_HMEntity.doctorGuid = Convert.ToString(clsBrInfo.ZYYS);
            _common_HMEntity.doctorName = clsBrInfo.YSXM;
            _common_HMEntity.enableQCRemind = 1;
            _common_HMEntity.admissionTime = clsBrInfo.RYSJ;
            _common_HMEntity.inpatientDepartment = clsBrInfo.KSMC;
            _common_HMEntity.patientInfo = new PatientInfo();
            _common_HMEntity.patientInfo.age = double.Parse(clsBrInfo.NL);
            string ageType = GetAge(clsBrInfo.CSRQ, DateTime.Now);
            _common_HMEntity.patientInfo.ageType = ageType;
            if (clsBrInfo.XBMC == "男")
            {
                _common_HMEntity.patientInfo.gender = 1;
            }
            else if (clsBrInfo.XBMC == "女")
            {
                _common_HMEntity.patientInfo.gender = 0;
            }
            else
            {

                _common_HMEntity.patientInfo.gender = 2;

            }
            if (clsBrInfo.HYZK == "已婚")
            {
                _common_HMEntity.patientInfo.maritalStatus = 1;
            }
            else if (clsBrInfo.HYZK == "未婚")
            {
                _common_HMEntity.patientInfo.maritalStatus = 0;
            }
            else
            {
                _common_HMEntity.patientInfo.maritalStatus = 2;
            }
            //ClsHuiMei._common_HMEntity.patientInfo.pregnancyStatus = int.Parse(clsBrInfo.Rows[0][""].ToString());
            //已经明确诊断
            if (dt1 != null && dt1.Rows.Count > 0)
            {
                _common_HMEntity.definiteDiagnosis = new List<DefiniteDiagnosis>();
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    DefiniteDiagnosis dd = new DefiniteDiagnosis();
                    dd.diseaseType = int.Parse(dt1.Rows[i]["DiagnoseType"].ToString());
                    dd.id = dt1.Rows[i]["ICDCode"].ToString();
                    dd.name = dt1.Rows[i]["ICDTitle"].ToString();
                    dd.narecordTimeme = dt1.Rows[i]["DiagnoseDate"].ToString();
                    _common_HMEntity.definiteDiagnosis.Add(dd);
                }
            }
            return _common_HMEntity;
        }
        private static string strAge = string.Empty; // 年龄的字符串表示
        /// <summary>
        /// 年龄的字符串
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <param name="dtNow"></param>
        /// <returns></returns>
        private static string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            int intYear = 0;
            int intMonth = 0; // 月
            int intDay = 0; // 天


            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }

            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }

            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;

            // 格式化年龄输出
            if (intYear >= 1) // 年份输出
            {
                strAge = "岁";


            }
            else
            {
                if (intMonth > 0 && intYear <= 5) // 五岁以下可以输出月数
                {
                    strAge = "月";

                }
                else
                {
                    if (intDay >= 0 && intYear < 1) // 一岁以下可以输出天数
                    {
                        if (strAge.Length == 0 || intDay > 0)
                        {
                            strAge = "天";

                        }
                    }
                }
            }
            return strAge;

        }
        //获取对应惠每的病史类型
        private static int GetProgressType(string strBsfl)
        {
            int progressType = 1;
            switch (strBsfl)
            {
                case "0":
                    progressType = 1;//入院记录
                    break;
                case "1":
                    progressType = 2;//首次病程
                    break;
                case "2":
                    progressType = 10;//出院小结
                    break;
                case "3":
                    progressType = 11;//各类报告卡
                    break;
                case "4":
                    progressType = 11;//各类告知
                    break;
                case "5":
                    progressType = 4;//日常病程
                    break;
                case "6":
                    progressType = 11;//其他记录
                    break;
                case "7":
                    progressType = 13;//手术文书
                    break;
                case "8":
                    progressType = 11;//麻醉文书
                    break;
                case "9":
                    progressType = 7;//讨论记录
                    break;
            }
            return progressType;
        }

        /// <summary>
        /// 获取病人初始化信息参数
        /// </summary>
        /// <returns></returns>
        public string GetPatientInitInfo()
        {
            JObject jInitData = new JObject();
            jInitData["userGuid"] = ClsModuleMain.ZYID;//患者ID(患者唯一标识)
            jInitData["serialNumber"] = ClsModuleMain.BRID;//就诊编号（一次就诊或住院产生的唯一标识）
            jInitData["doctorGuid"] = "10481";//ClsModuleMain.UserGH;//医生编号(工号)
            jInitData["doctorName"] = "贺子建";//ClsModuleMain.UserName;//医生姓名
            jInitData["department"] = ClsModuleMain.CurDepartmentName;//科室名称
            jInitData["hospitalGuid"] = "42504704X00";//医院编号
            jInitData["hospitalName"] = "上海闵行区中心医院";//医院名称
            jInitData["autherKey"] = GlobalConfigFile.AutherKey;//客户秘钥
            return jInitData.ToString();

            //HMBrInfo HMBrxx = new HMBrInfo();
            //HMBrxx.autherKey = "AF795E021AFB44882F285AAD725960D4";//由惠每提供的认证密钥7195F12825788F09375C2DB1E922F108
            //HMBrxx.userGuid = WK_HISYZ.clsConst.Brid.ToString();
            //HMBrxx.serialNumber = WK_HISYZ.clsConst.Zyid;
            //HMBrxx.doctorGuid = clsConst.Kdysgh;// : _BrInfo.ZzysId.ToString();
            //HMBrxx.doctorName = clsConst.Kdysxm;//: _BrInfo.ZzysMc;
            //HMBrxx.department = WK_HISYZ.clsConst.SybqMc.ToString();
            //HMBrxx.hospitalGuid = "42504704x00";
            //HMBrxx.hospitalName = "复旦大学附属闵行医院上海市闵行区中心医院";
            //HMBrxx.customEnv = 1;//
            //HMBrxx.flag = "m";
            //string json = JsonConvert.SerializeObject(HMBrxx);
            //return JsonConvert.SerializeObject(HMBrxx);
        }
        #endregion
    }
}
