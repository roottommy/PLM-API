using Aras.IOM;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using PLM_API.Infrastructure.Mongo;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.Mongo;
using PLM_API.PLM.Models.SPCAn;
using PLM_API.PLM.Repositories;
using PLM_API.Utilities;
using System;
using System.Collections.Generic;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PLM_API.Services
{
    public class InspectionBaseService : IInspectionBaseService
    {
        private readonly AppSettings _settings;
        private readonly IInspectionBaseRepository _inspectionBaseRepository;
        private readonly IMongoRepository _mongoRepository;
        public InspectionBaseService(IOptions<AppSettings> settings, IInspectionBaseRepository inspectionBaseRepository, IMongoRepository mongoRepository)
        {
            _settings = settings.Value;
            _inspectionBaseRepository = inspectionBaseRepository;
            _mongoRepository = mongoRepository;
        }
        public async Task<ServiceResult> InsertInspectionBase(string actID)
        {
            ServiceResult result = new ServiceResult();
            result.Status = CommonEnums.ResultType.scuuess;
            string pwd = Innovator.ScalcMD5(_settings.PLMPassword);
            HttpServerConnection conn = IomFactory.CreateHttpServerConnection(_settings.PLMServer, _settings.PLMDB, _settings.PLMUser, pwd);
            if (actID.Trim() == string.Empty)
            {
                result.Status = CommonEnums.ResultType.error;
                result.Code = StatusCodes.Status400BadRequest;
                result.Message = "缺少主要代碼";
            }

            if (result.Status == CommonEnums.ResultType.scuuess)
            {                
                Item loginResult = conn.Login();
                if (loginResult.isError())
                {
                    result.Status = CommonEnums.ResultType.error;
                    result.Code = StatusCodes.Status400BadRequest;
                    result.Message = "PLM登入失敗";
                }
            }

            if (result.Status == CommonEnums.ResultType.scuuess)
            {
                Innovator inn = IomFactory.CreateInnovator(conn);
                //取得審查站點資料
                Item wfProcAct = null; //ItemType : WORKFLOW PROCESS ACTIVITY
                Item wfProc = null; //ItemType : WORKFLOW PROCESS 
                Item wf = null; //ItemType : WORKFLOW
                Item docFlow = null; //ItemType : Document Flow
                Item doc = null; //ItemType : Document
                Item part = null; //ItemType : Part
                string wfProcActSID = string.Empty; //WORKFLOW PROCESS ACTIVITY : SOURCE_ID
                string wpId = string.Empty; //WORKFLOW PROCESS : ID
                string wfSId = string.Empty; //WORKFLOW : SOURCE_ID
                string docNbr = string.Empty; //DOCUMENT FLOW : DOC_NUMBER
                string partNbr = string.Empty; //DOCUMENT : PART_NUMBER
                string classification = string.Empty; //DOCUMENT : CLASSIFICATION
                string pNo = string.Empty; //Part : ITEM_NUMBER

                wfProcAct = inn.newItem("WORKFLOW PROCESS ACTIVITY", "get");
                wfProcAct.setProperty("related_id", actID);
                wfProcAct = wfProcAct.apply();
                
                if (!wfProcAct.isError())
                {
                    wfProcActSID = wfProcAct.getProperty("source_id", "");
                }
                else
                {
                    result.Status = CommonEnums.ResultType.error;
                    result.Code = StatusCodes.Status400BadRequest;
                    result.Message = string.Format("審查工作處理流程來源代碼錯誤({0})", actID);
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    wfProc = inn.getItemById("WORKFLOW PROCESS", wfProcActSID); //ItemType : WORKFLOW PROCESS 

                    if (!wfProc.isError())
                    {
                        wpId = wfProc.getProperty("id", "");
                    }
                    else
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status404NotFound;
                        result.Message = "API取得處理中工作流程ID資料錯誤";
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    //依處理中工作流程ID去得工作流程Source ID
                    wf = inn.newItem("WORKFLOW", "get");
                    wf.setProperty("related_id", wpId);
                    wf = wf.apply();
                    if (!wf.isError())
                    {
                        wfSId = wf.getProperty("source_id", "");
                    }
                    else
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status404NotFound;
                        result.Message = "取得工作流程SourceID資料錯誤";                        
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    docFlow = inn.getItemById("DOCUMENT FLOW", wfSId);
                    if (!docFlow.isError())
                    {
                        docNbr = docFlow.getProperty("doc_number", "");
                    }
                    else
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status404NotFound;
                        result.Message = "取得文件送審DocNumber資料錯誤";
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    doc = inn.getItemById("DOCUMENT", docNbr);
                    if (!doc.isError())
                    {
                        partNbr = doc.getProperty("part_number", "");
                        classification = doc.getProperty("classification", "");
                    }
                    else
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status404NotFound;
                        result.Message = "取得文件PartNumber或Classification資料錯誤";
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    part = inn.getItemById("PART", partNbr);
                    if (!part.isError())
                    {
                        pNo = part.getProperty("item_number", "");
                    }
                    else
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status404NotFound;
                        result.Message = "取得品號資料ItemNumber資料錯誤";
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                {
                    if (classification != "05_規格/產品規格書" && classification != "06_標準/檢驗基準書")
                    {
                        result.Status = CommonEnums.ResultType.error;
                        result.Code = StatusCodes.Status422UnprocessableEntity;
                        result.Message = "非產規書、檢基書不處理";
                    }
                }

                if (result.Status == CommonEnums.ResultType.scuuess)
                { 
                    List<Cs1dataPicture> cs1DataPictures = await _inspectionBaseRepository.QuerySPCPicture(pNo);

                    Item chrMain = null;

                    if (classification == "05_規格/產品規格書")
                    {
                        chrMain = inn.newItem("Characteristic maintain RD", "get");
                        chrMain.setProperty("part_id", partNbr);
                        Item charRD = inn.newItem("Maintain_Part_Char_RD", "get");
                        chrMain.addRelationship(charRD);
                        chrMain = chrMain.apply();

                        if (chrMain.isError())
                        {
                            result.Status = CommonEnums.ResultType.error;
                            result.Code = StatusCodes.Status404NotFound;
                            result.Message = string.Format("取得產品規格書資料錯誤，品號 : {0}， {1}", part.getProperty("item_number", ""), chrMain.getErrorString());
                        }
                    }

                    if (classification == "06_標準/檢驗基準書")
                    {
                        chrMain = inn.newItem("Characteristic maintain QC", "get");
                        chrMain.setProperty("part_id", partNbr);
                        Item charQC = inn.newItem("Maintain_Part_Char_QC", "get");
                        chrMain.addRelationship(charQC);
                        chrMain = chrMain.apply();

                        if (chrMain.isError())
                        {
                            result.Status = CommonEnums.ResultType.error;
                            result.Code = StatusCodes.Status404NotFound;
                            result.Message = string.Format("取得檢驗基準書資料錯誤，品號 : {0}，{1}", part.getProperty("item_number", ""), chrMain.getErrorString());
                        }
                    }

                    if (result.Status == CommonEnums.ResultType.scuuess)
                    {
                        string jsonStr = string.Empty;
                        string partNumber = part.getProperty("name", "");
                        string version = doc.getProperty("major_rev", "");
                        string itemNumber = doc.getProperty("item_number", ""); //Document 流水編號
                        string dcNbr = doc.getProperty("dc_number", ""); //Document 文管編號
                        DateTime date = DateTime.Now;
                        XmlDocument xDoc = new XmlDocument();
                        xDoc.LoadXml(chrMain.ToString());
                        XmlNode rsNodes = null;
                        XmlNodeList itemList = null;
                        try
                        {
                            rsNodes = xDoc.SelectSingleNode("//Relationships");
                            itemList = rsNodes.SelectNodes("Item");
                        }
                        catch (Exception ex)
                        {
                            result.Status = CommonEnums.ResultType.error;
                            result.Code = StatusCodes.Status404NotFound;
                            result.Message = string.Format("XML格式錯誤，錯誤訊息 : {0}", ex.Message);
                        }

                        if (result.Status == CommonEnums.ResultType.scuuess)
                        {
                            JArray checkItemArray = new JArray();
                            JArray drawingsArray = new JArray();

                            try
                            {
                                #region Load Relationships

                                JProperty checkItems = new JProperty(jsonStr);                                
                                List<CheckItemProperty> pNameList = CreatePropertyContentList();
                                foreach (XmlNode item in itemList)
                                {
                                    JObject objArray = new JObject();

                                    foreach (CheckItemProperty pName in pNameList)
                                    {
                                        //if (pName.PlmName == "FREQUENCY_p0_product")
                                        //{ 
                                            
                                        //}

                                        var nodes = item.ChildNodes.Cast<XmlNode>().Where(x => x.Name.ToLower() == pName.PlmName.ToLower()).FirstOrDefault();

                                        if (nodes != null)
                                        {
                                            if (pName.GetValueType == "Text")
                                            {
                                                objArray.Add(new JProperty(pName.NewName, ConvertValue(nodes.InnerText.Replace("\r", string.Empty).Replace("\n", string.Empty), pName.PType)));
                                            }
                                            else
                                            {
                                                objArray.Add(new JProperty(pName.NewName, ConvertValue(nodes.Attributes[pName.GetValueType].Value.Replace("\r", string.Empty).Replace("\n", string.Empty), pName.PType)));
                                            }
                                        }
                                        else
                                        {
                                            objArray.Add(new JProperty(pName.NewName, ConvertValue(string.Empty, pName.PType)));
                                        }
                                    }


                                    //for (int i = 0; i < item.ChildNodes.Count; i++)
                                    //{

                                    //    Tuple<bool, CheckItemProperty> propTuple = ConfirmPropertyName(item.ChildNodes[i].Name);
                                    //    //回傳True才需要拋轉
                                    //    if (propTuple.Item1)
                                    //    {
                                    //        CheckItemProperty pContent = propTuple.Item2;
                                    //        string val = string.Empty;
                                    //        if (pContent.GetValueType == "Text")
                                    //        {
                                    //            val = item.ChildNodes[i].InnerText.Replace("\r", string.Empty).Replace("\n", string.Empty);
                                    //        }
                                    //        else
                                    //        {
                                    //            val = item.ChildNodes[i].Attributes[pContent.GetValueType].Value.Replace("\r", string.Empty).Replace("\n", string.Empty);
                                    //        }

                                    //        if (pContent.PType == typeof(string))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, val));
                                    //        }
                                    //        else if (pContent.PType == typeof(DateTime))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, Convert.ToDateTime(val)));
                                    //        }
                                    //        else if (pContent.PType == typeof(bool))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, val == "0" ? false : true));
                                    //        }
                                    //        else if (pContent.PType == typeof(int))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, Convert.ToInt32(val)));
                                    //        }
                                    //        else if (pContent.PType == typeof(Double))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, Convert.ToDouble(val)));
                                    //        }
                                    //        else if (pContent.PType == typeof(long))
                                    //        {
                                    //            objArray.Add(new JProperty(pContent.NewName, (long)Convert.ToDouble(val)));
                                    //        }
                                    //    }

                                    //}

                                    checkItemArray.Add(objArray);
                                }

                                #endregion

                                #region Process Spc Picture
                                
                                List<Cs1dataPicture> cs1dataPicList = await _inspectionBaseRepository.QuerySPCPicture(pNo);
                                List<string> pathList = cs1dataPicList.Select(x => x.Path.Trim()).ToList();
                                drawingsArray.Add(pathList);

                                #endregion
                            }
                            catch (Exception ex)
                            {
                                result.Status = CommonEnums.ResultType.error;
                                result.Code = StatusCodes.Status404NotFound;
                                result.Message = string.Format("取得XML格式錯誤，錯誤訊息 : {0}", ex.Message);
                            }

                            if (result.Status == CommonEnums.ResultType.scuuess)
                            {
                                JObject mainJObj = new JObject
                                {
                                    new JProperty("partNumber", pNo.Trim()),
                                    new JProperty("version", Convert.ToInt32(version)),
                                    new JProperty("createdAt", new JRaw(@"new ISODate(""" + date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + @""")")),
                                    new JProperty("updatedAt", new JRaw(@"new ISODate(""" + date.ToString("yyyy-MM-ddTHH:mm:ss.fffZ") + @""")")),
                                    new JProperty("drawings", drawingsArray),
                                    new JProperty("checkItems", checkItemArray),
                                    new JProperty("docNumber", itemNumber),
                                    new JProperty("dmsNumber", dcNbr)
                                };

                                try
                                {
                                    // 轉為 BsonDocument
                                    var bsonDoc = BsonSerializer.Deserialize<BsonDocument>(mainJObj.ToString());
                                    // 將 createdAt/updatedAt 改為真正的 BsonDateTime (避免 mongo shell ISODate 表達式)
                                    bsonDoc["createdAt"] = new BsonDateTime(date);
                                    bsonDoc["updatedAt"] = new BsonDateTime(date);

                                    // 寫入 MongoDB，collection name 使用 "sips"（依你設定調整）
                                    await _mongoRepository.InsertOneAsync<BsonDocument>("sips", bsonDoc);

                                    result.Status = CommonEnums.ResultType.scuuess;
                                    result.Code = StatusCodes.Status200OK;
                                    result.Message = $"品號 : {pNo}，新增成功";
                                }
                                catch (Exception ex)
                                {
                                    result.Status = CommonEnums.ResultType.error;
                                    result.Code = StatusCodes.Status500InternalServerError;
                                    result.Message = $"寫入MongoDB失敗，錯誤訊息 : {ex.Message}";
                                }
                            }
                        }
                    }
                }

                //登出PLM
                try
                {
                    conn.Logout();
                }
                catch
                {
                    //ignore logout error
                }
            }




            return result;
        }

        /// <summary>
        /// 確認PLM欄位是否為要拋轉資料
        /// </summary>
        /// <param name="pName">PropertyName</param>
        /// <returns></returns>
        public Tuple<bool, CheckItemProperty> ConfirmPropertyName(string pName)
        {
            List<CheckItemProperty> pNameList = CreatePropertyContentList();
            if (pName.Trim() != string.Empty)
            {

                CheckItemProperty pContent = (from temp in pNameList
                                            where temp.PlmName.ToLower() == pName.ToLower()
                                            select temp).FirstOrDefault();

                if (pContent != null)
                {
                    return Tuple.Create(true, pContent);
                }
                else
                {
                    return Tuple.Create(false, new CheckItemProperty());
                }

            }
            else
            {
                return Tuple.Create(false, new CheckItemProperty());
            }
        }

        public List<CheckItemProperty> CreatePropertyContentList()
        {
            List<CheckItemProperty> pNameList = new List<CheckItemProperty>();
            pNameList.Add(new CheckItemProperty() { PlmName = "order_by", NewName = "orderBy", PType = typeof(int), PCName = "排序", GetValueType = "Text" }); //排序
            pNameList.Add(new CheckItemProperty() { PlmName = "part_characteristic", NewName = "itemName", PType = typeof(string), PCName = "檢查項目", GetValueType = "keyed_name" }); //檢查項目
            pNameList.Add(new CheckItemProperty() { PlmName = "characteristic_class", NewName = "importance", PType = typeof(string), PCName = "重要度", GetValueType = "Text" }); //特性等級
            pNameList.Add(new CheckItemProperty() { PlmName = "gz_symbol", NewName = "symbol", PType = typeof(string), PCName = "符號", GetValueType = "Text" }); //符號
            pNameList.Add(new CheckItemProperty() { PlmName = "target", NewName = "target", PType = typeof(string), PCName = "規格", GetValueType = "Text" }); //規格
            pNameList.Add(new CheckItemProperty() { PlmName = "unit", NewName = "unit", PType = typeof(string), PCName = "單位", GetValueType = "Text" }); //單位
            pNameList.Add(new CheckItemProperty() { PlmName = "tolerance", NewName = "upperTolerance", PType = typeof(string), PCName = "上公差", GetValueType = "Text" }); //上公差
            pNameList.Add(new CheckItemProperty() { PlmName = "tolerance2", NewName = "lowerTolerance", PType = typeof(string), PCName = "下公差", GetValueType = "Text" }); //下公差
            pNameList.Add(new CheckItemProperty() { PlmName = "m_i0", NewName = "checkMethod_i0", PType = typeof(string), PCName = "初期檢查方法", GetValueType = "keyed_name" }); //初期檢查方法
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_i0_FIRST", NewName = "isFirstInspect_i0", PType = typeof(bool), PCName = "初期首末件", GetValueType = "Text" }); //初期首末件
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_i0_process", NewName = "freqProcess_i0", PType = typeof(string), PCName = "初期製程頻度", GetValueType = "Text" }); //初期製程頻度
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_i0_product", NewName = "freqProduct_i0", PType = typeof(string), PCName = "初期進貨/成品/出貨頻度", GetValueType = "Text" }); //初期進貨/成品/出貨頻度
            pNameList.Add(new CheckItemProperty() { PlmName = "SAMPLE_i0", NewName = "sampleNum_i0", PType = typeof(int), PCName = "排序", GetValueType = "Text" }); //初期樣本數
            pNameList.Add(new CheckItemProperty() { PlmName = "m_p0", NewName = "checkMethod_p0", PType = typeof(string), PCName = "checkMethod_p0", GetValueType = "keyed_name" }); //量產檢查方法
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_p0_FIRST", NewName = "isFirstInspect_p0", PType = typeof(bool), PCName = "量產首末件", GetValueType = "Text" }); //量產首末件
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_p0_process", NewName = "freqProcess_p0", PType = typeof(string), PCName = "量產製程頻度", GetValueType = "Text" }); //量產製程頻度
            pNameList.Add(new CheckItemProperty() { PlmName = "FREQUENCY_p0_product", NewName = "freqProduct_p0", PType = typeof(string), PCName = "量產進貨/成品/出貨頻度", GetValueType = "Text" }); //量產進貨/成品/出貨頻度 
            pNameList.Add(new CheckItemProperty() { PlmName = "SAMPLE_p0", NewName = "sampleNum_p0", PType = typeof(int), PCName = "量產樣本數", GetValueType = "Text" }); //量產樣本數
            pNameList.Add(new CheckItemProperty() { PlmName = "value_type", NewName = "recordType", PType = typeof(string), PCName = "紀錄型式", GetValueType = "Text" }); //數值型式
            pNameList.Add(new CheckItemProperty() { PlmName = "station_income_i0", NewName = "isStationIncoming_i0", PType = typeof(bool), PCName = "進料初期", GetValueType = "Text" }); //進料初期
            pNameList.Add(new CheckItemProperty() { PlmName = "station_income_p0", NewName = "isStationIncoming_p0", PType = typeof(bool), PCName = "進料量產", GetValueType = "Text" }); //進料量產
            pNameList.Add(new CheckItemProperty() { PlmName = "station_process_i0", NewName = "isStationProcess_i0", PType = typeof(bool), PCName = "製程初期", GetValueType = "Text" }); //製程初期
            pNameList.Add(new CheckItemProperty() { PlmName = "station_process_p0", NewName = "isStationProcess_p0", PType = typeof(bool), PCName = "製程量產", GetValueType = "Text" }); //製程量產
            pNameList.Add(new CheckItemProperty() { PlmName = "station_product_i0", NewName = "isStationProduct_i0", PType = typeof(bool), PCName = "成品初期", GetValueType = "Text" }); //成品初期
            pNameList.Add(new CheckItemProperty() { PlmName = "station_product_p0", NewName = "isStationProduct_p0", PType = typeof(bool), PCName = "成品量產", GetValueType = "Text" }); //成品量產
            pNameList.Add(new CheckItemProperty() { PlmName = "station_ship", NewName = "isStationShip", PType = typeof(bool), PCName = "出貨", GetValueType = "Text" }); //出貨
            pNameList.Add(new CheckItemProperty() { PlmName = "comments", NewName = "comment", PType = typeof(string), PCName = "檢查項目備註", GetValueType = "Text" }); //檢查項目備註
            return pNameList;
        }

        object ConvertValue(string value, Type type)
        {

            if (type == typeof(DateTime))
                return value.Trim() == string.Empty ? new DateTime() : DateTime.Parse(value);

            if (type == typeof(string))
                return value;

            if (type == typeof(bool))
                return value.Trim() == string.Empty ? false : value.Trim() ==  "0" ? false : true;

            if (type == typeof(int))
                return value.Trim() == string.Empty ? 0 : int.Parse(value);

            return Convert.ChangeType(value, type);
        }
    }
}
