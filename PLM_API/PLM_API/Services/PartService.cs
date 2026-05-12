using Aras.IOM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.ERP;
using PLM_API.PLM.Models.LogDB;
using PLM_API.PLM.Repositories;
using PLM_API.Utilities;
using System;
using System.Collections.Generic;
using System.Net;

namespace PLM_API.Services
{
    public class PartService : IPartService
    {
        private readonly AppSettings _settings;
        private readonly IPartRepository _partRepository;
        private readonly IAppLogService _logger;
        public PartService(IOptions<AppSettings> settings, IPartRepository partRepository, IAppLogService logger)
        {
            _settings = settings.Value;
            _partRepository = partRepository;
            _logger = logger;
        }

        public async Task<ServiceResult> GetMappedNumberQC(string partNo)
        {
            ServiceResult serResult = new ServiceResult();
            serResult.Status = CommonEnums.ResultType.scuuess;

            if (partNo.Trim() == string.Empty)
            {
                serResult.Status = CommonEnums.ResultType.error;
                serResult.Code = StatusCodes.Status400BadRequest;
                serResult.Message = "沒有品號";
            }

            if (serResult.Status == CommonEnums.ResultType.scuuess)
            {
                string pwd = Innovator.ScalcMD5(_settings.PLMPassword);


                HttpServerConnection conn = IomFactory.CreateHttpServerConnection(_settings.PLMServer, _settings.PLMDB, _settings.PLMUser, pwd);
                Item loginResult = conn.Login();

                if (loginResult.isError())
                {
                    serResult.Status = CommonEnums.ResultType.error;
                    serResult.Message = "登入PLM失敗";
                }

                if (serResult.Status == CommonEnums.ResultType.scuuess)
                {
                    Innovator inn = new Innovator(conn);
                    Item part = inn.newItem("part", "get");
                    //part.setProperty("item_number", partNo);
                    //part = part.apply();

                    Item charQCMapped = inn.newItem("maintain_part_char_QC_mapped", "get");
                    Item charQC = inn.newItem("Characteristic maintain QC", "get");
                    part.setProperty("item_number", partNo);
                    part = part.apply();

                    if (part.isError())
                    {
                        serResult.Status = CommonEnums.ResultType.error;
                        serResult.Message = "找不到Part資料";
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        charQCMapped.setProperty("part_id", part.getID());
                        charQCMapped = charQCMapped.apply();

                        if (charQCMapped.isError())
                        {
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Message = "找不到maintain part char QC mapped資料";
                        }
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        charQC.setAttribute("id", charQCMapped.getProperty("char_id", ""));
                        charQC = charQC.apply();

                        if (charQC.isError())
                        {
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Message = "找不到Characteristic maintain QC資料";
                        }
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        Item retPart = inn.getItemById("Part", charQC.getProperty("part_id", ""));
                        List<Dictionary<string, string>> partList = new List<Dictionary<string, string>>();
                        Dictionary<string, string> partNumber = new Dictionary<string, string>();
                        Dictionary<string, string> mappedNumber = new Dictionary<string, string>();
                        partNumber.Add("PartNumber", partNo);
                        mappedNumber.Add("MappedNumber", retPart.getProperty("item_number", ""));
                        partList.Add(partNumber);
                        partList.Add(mappedNumber);
                        serResult.Data = partList;
                    }
                }
            }

            return serResult;
        }

        /// <summary>
        /// 設定品號作廢
        /// </summary>
        /// <param name="partNo">品號</param>
        /// <param name="partName">品名</param>
        /// <param name="product">商品</param>
        /// <param name="warehouse">庫別</param>
        /// <param name="expiryDate">失效日</param>
        /// <param name="itemNo">品號維護單號</param>
        /// <param name="pLMApiTrace">LOG檔</param>
        /// <returns></returns>
        public async Task<ServiceResult> SetPartObsolete(string partNo, string partName, string product, string warehouse, DateTime expiryDate, string itemNo, PLMApiTrace pLMApiTrace)
        {
            ServiceResult serResult = new ServiceResult();
            serResult.Status = CommonEnums.ResultType.scuuess;
            INVMB invmb = new INVMB();

            if (partNo.Trim() == string.Empty)
            {
                serResult.Status = CommonEnums.ResultType.error;
                serResult.Code = StatusCodes.Status400BadRequest;
                serResult.Message = "沒有品號";

                pLMApiTrace.StepName = "Checking itemNo exists";
                pLMApiTrace.Message = serResult.Message;
                _logger.LogErrorAsync(pLMApiTrace);
            }

            if (serResult.Status == CommonEnums.ResultType.scuuess)
            {
                string pwd = Innovator.ScalcMD5(_settings.PLMPassword);
                HttpServerConnection conn = IomFactory.CreateHttpServerConnection(_settings.PLMServer, _settings.PLMDB, _settings.PLMUser, pwd);
                Item loginResult = conn.Login();

                if (loginResult.isError())
                {
                    serResult.Status = CommonEnums.ResultType.error;
                    serResult.Code = StatusCodes.Status400BadRequest;
                    serResult.Message = "登入PLM失敗";
                    pLMApiTrace.StepName = "PLM System Login";
                    pLMApiTrace.Message = serResult.Message;
                    _logger.LogErrorAsync(pLMApiTrace);
                }

                if (serResult.Status == CommonEnums.ResultType.scuuess)
                {
                    Innovator inn = IomFactory.CreateInnovator(conn);
                    Item part = inn.newItem("PART", "get");
                    part.setProperty("ITEM_NUMBER", partNo);
                    part = part.apply();

                    if (part.isError())
                    {
                        serResult.Status = CommonEnums.ResultType.error;
                        serResult.Code = StatusCodes.Status400BadRequest;
                        serResult.Message = "PLM Part品號不存在";
                        pLMApiTrace.StepName = "Checking PLM Part exists";
                        pLMApiTrace.Message = serResult.Message;
                        _logger.LogErrorAsync(pLMApiTrace);
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        CheckItemStatusResult chkItemSt = await _partRepository.CheckItemStatus(part.getProperty("item_number", ""));

                        if (!chkItemSt.IsValid)
                        {
                            CodeService codeService = new CodeService();
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Code = StatusCodes.Status422UnprocessableEntity;
                            serResult.Message = codeService.GetItemStatusMsg(chkItemSt.Code);
                            pLMApiTrace.StepName = "Checking ERP Item Status For SQL Method : fn_CheckItemStatus";
                            pLMApiTrace.Message = serResult.Message;
                            _logger.LogErrorAsync(pLMApiTrace);
                        }
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        invmb = await _partRepository.GetPart(partNo);
                        if (invmb.MB001 == null || invmb.MB001 == string.Empty)
                        { 
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Code = StatusCodes.Status404NotFound;
                            serResult.Message = "ERP品號不存在";
                            pLMApiTrace.StepName = "Checking ERP itemNo exists";
                            pLMApiTrace.Message = serResult.Message;
                            _logger.LogErrorAsync(pLMApiTrace);
                        }
                    }

                    //檢查變更單是否已新增透過備註欄位看是否有相同的docNo，若有代表已新增過變更單
                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        if (await _partRepository.CheckingItemChangeOrderExist(itemNo))
                        {
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Code = StatusCodes.Status200OK;
                            serResult.Message = "變更單已存在不再新增";
                            pLMApiTrace.StepName = "Checking ERP ChangeOrder exists";
                            pLMApiTrace.Message = serResult.Message;
                            _logger.LogErrorAsync(pLMApiTrace);
                        }
                    }

                    if (serResult.Status == CommonEnums.ResultType.scuuess)
                    {
                        #region 建立品號變更單單頭

                        INVTL invtl = new INVTL();
                        invtl.COMPANY = "GIZMO";
                        invtl.CREATOR = "PLM";
                        invtl.USR_GROUP = "000";
                        invtl.CREATE_DATE = DateTime.Now.ToString("yyyyMMdd");
                        invtl.MODIFIER = "PLM";
                        invtl.MODI_DATE = invtl.CREATE_DATE;
                        invtl.FLAG = 1;
                        invtl.TL001 = invmb.MB001.Trim();
                        invtl.TL002 = invmb.MB002.Trim();
                        invtl.TL003 = invmb.MB003.Trim();
                        invtl.TL005 = invtl.CREATE_DATE;
                        invtl.TL006 = "N";
                        invtl.TL007 = partName; //string.Format("報廢:{0}", invtl.TL002);
                        invtl.TL008 = invmb.MB003.Trim();
                        invtl.TL009 = "PLM";
                        invtl.TL010 = string.Format("Part Maintain:{0}", itemNo);
                        invtl.TL011 = "1";
                        invtl.TL012 = "PLM";
                        invtl.TL013 = invtl.CREATE_DATE;
                        invtl.TL014 = "Y";
                        invtl.TL015 = "N"; //不執行電子簽核
                        invtl.TL016 = 0;
                        invtl.TL017 = 0;
                        invtl.TL018 = 0;
                        invtl.TL019 = 0;
                        invtl.TL020 = string.Empty;
                        invtl.TL021 = string.Empty;
                        invtl.TL022 = string.Empty;
                        invtl.TL023 = string.Empty;
                        invtl.UDF01 = string.Empty;
                        invtl.UDF02 = string.Empty;
                        invtl.UDF03 = string.Empty;
                        invtl.UDF04 = string.Empty;
                        invtl.UDF05 = string.Empty;
                        invtl.UDF06 = 0;
                        invtl.UDF07 = 0;
                        invtl.UDF08 = 0;
                        invtl.UDF09 = 0;
                        invtl.UDF10 = 0;

                        #endregion

                        #region 建立品號變更單單身

                        List<INVMA> iNVMAs = await _partRepository.GetPartType();
                        List<INVTM> iNVTMs = new List<INVTM>();
                        //商品
                        iNVTMs.Add(CreateINVTM(invtl.TL001, 1, "MB005", "商品", product, invmb.MB005,
                        iNVMAs.Where(e => e.MA001.Trim() == "1" && e.MA002.Trim() == product).Select(e => e.MA003.Trim()).FirstOrDefault(),
                        iNVMAs.Where(e => e.MA001.Trim() == "1" && e.MA002.Trim() == invmb.MB005.Trim()).Select(e => e.MA003.Trim()).FirstOrDefault()));
                        ////機能
                        //iNVTMs.Add(CreateINVTM(invtl.TL001.Trim(), 2, "MB006", "機能", "ZZZ", invmb.MB006.Trim(),
                        //iNVMAs.Where(e => e.MA001.Trim() == "2" && e.MA002.Trim() == "ZZZ").Select(e => e.MA003.Trim()).FirstOrDefault(),
                        //iNVMAs.Where(e => e.MA001.Trim() == "2" && e.MA002.Trim() == invmb.MB006.Trim()).Select(e => e.MA003.Trim()).FirstOrDefault()));
                        ////生管
                        //iNVTMs.Add(CreateINVTM(invtl.TL001.Trim(), 3, "MB008", "生管", "4999", invmb.MB008.Trim(),
                        //iNVMAs.Where(e => e.MA001.Trim() == "4" && e.MA002.Trim() == "4999").Select(e => e.MA003.Trim()).FirstOrDefault(),
                        //iNVMAs.Where(e => e.MA001.Trim() == "4" && e.MA002.Trim() == invmb.MB008.Trim()).Select(e => e.MA003.Trim()).FirstOrDefault()));
                        //主要庫別
                        iNVTMs.Add(CreateINVTM(invtl.TL001.Trim(), 4, "MB017", "主要庫別", warehouse, invmb.MB017.Trim(),
                        (await _partRepository.GetWarehouse(warehouse)).MC002.Trim(),
                        (await _partRepository.GetWarehouse(invmb.MB017.Trim())).MC002.Trim()));
                        //失效日期
                        iNVTMs.Add(CreateINVTM(invtl.TL001, 5, "MB031", "失效日期", expiryDate.ToString("yyyyMMdd"), string.Empty,
                        expiryDate.ToString("yyyyMMdd"),
                        string.Empty));

                        #endregion

                        try
                        {
                            serResult = await _partRepository.CreateItemChangeOrder(invtl, iNVTMs, new INVMB());
                        }
                        catch (Exception ex)
                        {
                            serResult.Status = CommonEnums.ResultType.error;
                            serResult.Code = StatusCodes.Status500InternalServerError;
                            serResult.Message = ex.Message;

                            pLMApiTrace.StepName = "Insert Data";
                            pLMApiTrace.Message = serResult.Message;
                            _logger.LogErrorAsync(pLMApiTrace);
                        }
                    }
                }
            }

            return serResult;
        }

        private INVTM CreateINVTM(string partNo, int num, string colume, string columeName, string newProd, string oldProd, string newPName, string oldPName)
        {
            INVTM invtm = new INVTM();
            invtm.COMPANY = "GIZMO";
            invtm.CREATOR = "PLM";
            invtm.USR_GROUP = "000";
            invtm.CREATE_DATE = DateTime.Now.ToString("yyyyMMdd");
            invtm.MODIFIER = "PLM";
            invtm.MODI_DATE = invtm.CREATE_DATE;
            invtm.FLAG = 1;
            invtm.TM001 = partNo;
            invtm.TM003 = num.ToString().PadLeft(4, '0');
            invtm.TM004 = colume;
            invtm.TM005 = columeName;
            invtm.TM006 = newProd;
            invtm.TM007 = oldProd;
            invtm.TM008 = 0;
            invtm.TM009 = 0;
            invtm.TM010 = "V";
            invtm.TM011 = string.Empty;
            invtm.TM012 = string.Empty;
            invtm.TM013 = "Y";
            invtm.TM014 = newPName;
            invtm.TM015 = oldPName;
            invtm.TM016 = 0;
            invtm.TM017 = 0;
            invtm.TM018 = string.Empty;
            invtm.TM019 = string.Empty;
            invtm.TM020 = string.Empty;
            invtm.UDF01 = string.Empty;
            invtm.UDF02 = string.Empty;
            invtm.UDF03 = string.Empty;
            invtm.UDF04 = string.Empty;
            invtm.UDF05 = string.Empty;
            invtm.UDF06 = 0;
            invtm.UDF07 = 0;
            invtm.UDF08 = 0;
            invtm.UDF09 = 0;
            invtm.UDF10 = 0;
            return invtm;
        }

        private INVTM CreateINVTM(string partNo, int num, string colume, string columeName, string newProd, string oldProd, string newPName, string oldPName, string chkCode)
        {
            INVTM invtm = new INVTM();
            invtm.COMPANY = "GIZMO";
            invtm.CREATOR = "DS";
            invtm.USR_GROUP = "000";
            invtm.CREATE_DATE = DateTime.Now.ToString("yyyyMMdd");
            invtm.MODIFIER = "";
            invtm.MODI_DATE = invtm.CREATE_DATE;
            invtm.FLAG = 1;
            invtm.TM001 = partNo;
            invtm.TM003 = num.ToString().PadLeft(4, '0');
            invtm.TM004 = colume;
            invtm.TM005 = columeName;
            invtm.TM006 = newProd;
            invtm.TM007 = oldProd;
            invtm.TM008 = 0;
            invtm.TM009 = 0;
            invtm.TM010 = "V";
            invtm.TM011 = string.Empty;
            invtm.TM012 = string.Empty;
            invtm.TM013 = chkCode;
            invtm.TM014 = newPName;
            invtm.TM015 = oldPName;
            invtm.TM016 = 0;
            invtm.TM017 = 0;
            invtm.TM018 = string.Empty;
            invtm.TM019 = string.Empty;
            invtm.TM020 = string.Empty;
            invtm.UDF01 = string.Empty;
            invtm.UDF02 = string.Empty;
            invtm.UDF03 = string.Empty;
            invtm.UDF04 = string.Empty;
            invtm.UDF05 = string.Empty;
            invtm.UDF06 = 0;
            invtm.UDF07 = 0;
            invtm.UDF08 = 0;
            invtm.UDF09 = 0;
            invtm.UDF10 = 0;
            return invtm;
        }


        /// <summary>
        /// 設定品號作廢
        /// </summary>
        /// <param name="partNo">品號</param>
        /// <param name="partName">品名</param>
        /// <param name="product">商品</param>
        /// <param name="warehouse">庫別</param>
        /// <param name="expiryDate">失效日</param>
        /// <param name="chkCode">檢查碼</param>
        /// <param name="db">資料庫</param>
        /// <param name="pLMApiTrace">LOG檔</param>
        /// <returns></returns>
        public async Task<ServiceResult> SetPartObsolete(string partNo, string oldPartName, string partName, string spec, string oldProduct, string product, string oldWarehouse, string warehouse, string oldPName, string pName, string expiryDate, string chkCode, string db, PLMApiTrace pLMApiTrace)
        {
            ServiceResult serResult = new ServiceResult();
            serResult.Status = CommonEnums.ResultType.scuuess;
            INVMB invmb = new INVMB();

            #region 建立品號變更單單頭

            INVTL invtl = new INVTL();
            invtl.COMPANY = db;
            invtl.CREATOR = "DS";
            invtl.USR_GROUP = "000";
            invtl.CREATE_DATE = DateTime.Now.ToString("yyyyMMdd");
            invtl.MODIFIER = "";
            invtl.MODI_DATE = invtl.CREATE_DATE;
            invtl.FLAG = 1;
            invtl.TL001 = partNo;
            invtl.TL002 = partName;
            invtl.TL003 = spec;
            invtl.TL005 = invtl.CREATE_DATE;
            invtl.TL006 = "N";
            invtl.TL007 = partName; //string.Format("報廢:{0}", invtl.TL002);
            invtl.TL008 = spec;
            invtl.TL009 = "DS";
            invtl.TL010 = $"{invtl.CREATE_DATE}整批報廢";
            invtl.TL011 = "1";
            invtl.TL012 = "";
            invtl.TL013 = invtl.CREATE_DATE;
            invtl.TL014 = chkCode.ToUpper();
            invtl.TL015 = "N"; //不執行電子簽核
            invtl.TL016 = 0;
            invtl.TL017 = 0;
            invtl.TL018 = 0;
            invtl.TL019 = 0;
            invtl.TL020 = string.Empty;
            invtl.TL021 = string.Empty;
            invtl.TL022 = string.Empty;
            invtl.TL023 = string.Empty;
            invtl.UDF01 = string.Empty;
            invtl.UDF02 = string.Empty;
            invtl.UDF03 = string.Empty;
            invtl.UDF04 = string.Empty;
            invtl.UDF05 = string.Empty;
            invtl.UDF06 = 0;
            invtl.UDF07 = 0;
            invtl.UDF08 = 0;
            invtl.UDF09 = 0;
            invtl.UDF10 = 0;

            #endregion

            #region 建立品號變更單單身

            List<INVMA> iNVMAs = await _partRepository.GetPartType();
            List<INVTM> iNVTMs = new List<INVTM>();
            //商品
            iNVTMs.Add(CreateINVTM(invtl.TL001, 1, "MB005", db == "GIZMO" ? "商品" : "會計", product, oldProduct, pName, oldPName, chkCode));
            //主要庫別
            iNVTMs.Add(CreateINVTM(invtl.TL001.Trim(), 2, "MB017", "主要庫別", warehouse, oldWarehouse,
                        (await _partRepository.GetWarehouse(warehouse, db)).MC002.Trim(),
                        oldWarehouse != string.Empty ? (await _partRepository.GetWarehouse(oldWarehouse, db)).MC002.Trim() : string.Empty));
            //失效日期
            iNVTMs.Add(CreateINVTM(invtl.TL001, 3, "MB031", "失效日期", expiryDate, string.Empty,
            expiryDate,
            string.Empty, chkCode));

            #endregion

            try
            {
                if (db == "GIZMO")
                {
                    serResult = await _partRepository.CreateItemChangeOrder(invtl, iNVTMs, new INVMB());
                }
                else
                {
                    serResult = await _partRepository.CreateModelItemChangeOrder(invtl, iNVTMs, new INVMB());
                }
            }
            catch (Exception ex)
            {
                serResult.Status = CommonEnums.ResultType.error;
                serResult.Code = StatusCodes.Status500InternalServerError;
                serResult.Message = ex.Message;

                pLMApiTrace.StepName = "Insert Data";
                pLMApiTrace.Message = serResult.Message;
                _logger.LogErrorAsync(pLMApiTrace);
            }
                        
            

            return serResult;
        }

    }
}
