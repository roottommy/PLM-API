using Microsoft.EntityFrameworkCore;
using PLM_API.Infrastructure.MSSql;
using PLM_API.PLM.Models;
using PLM_API.PLM.Models.ERP;

namespace PLM_API.PLM.Repositories
{
    public class PartRepository : IPartRepository
    {
        private readonly AppERPDbContext _erpDB;
        private readonly AppERPSysDbContext _erpSysDB;
        private readonly AppModelDbContext _modelDB;    


        public PartRepository(AppERPDbContext erpDB, AppERPSysDbContext erpSysDB, AppModelDbContext modelDB)
        {
            _erpDB = erpDB;
            _erpSysDB = erpSysDB;
            _modelDB = modelDB;
        }
        public async Task<CheckItemStatusResult> CheckItemStatus(string partNo)
        {
            var data = await _erpDB.CheckItemStResult.FromSqlInterpolated($@"SELECT * FROM [dbo].[fn_CheckItemStatus]({partNo})").AsNoTracking().FirstOrDefaultAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                CheckItemStatusResult chkItemStResult = new CheckItemStatusResult();
                chkItemStResult.IsValid = false;
                chkItemStResult.Code = "99";
                return chkItemStResult;
            }
        }

        /// <summary>
        /// 取得品號基本資料
        /// </summary>
        /// <param name="partNo">品號</param>
        /// <returns>品號基本資料</returns>
        public async Task<INVMB> GetPart(string partNo)
        {
            var data = await _erpDB.GetItem.FirstOrDefaultAsync(p => p.MB001 == partNo);

            if (data != null)
            {
                return data;
            }
            else
            {
                return new INVMB();
            }
        }

        /// <summary>
        /// 取得品號類別資料
        /// </summary>
        /// <returns>品號類別資料</returns>
        public async Task<List<INVMA>> GetPartType()
        {
            var data = await _erpDB.GetItemType
                .AsNoTracking().ToListAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                return new List<INVMA>();
            }
        }

        /// <summary>
        /// 取得品號類別資料
        /// </summary>
        /// <returns>品號類別資料</returns>
        public async Task<INVMA> GetPartType(string category, string itemCateNo)
        {
            var query = _erpDB.GetItemType.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(category))
            {
                var cat = category.Trim().PadRight(1);
                query = query.Where(x => x.MA001 == cat);
            }

            if (!string.IsNullOrWhiteSpace(itemCateNo))
            {
                var cateNo = itemCateNo.Trim().PadRight(6);
                query = query.Where(x => x.MA002 == cateNo);
            }

            return await query.FirstOrDefaultAsync();
        }

        /// <summary>
        /// 取得庫別資訊
        /// </summary>
        /// <param name="wareHouseCode">庫別</param>
        /// <param name="db">資料庫名稱</param>
        /// <returns></returns>
        public async Task<CMSMC> GetWarehouse(string wareHouseCode)
        {            
            var data = await _erpDB.GetWarehouse
                .AsNoTracking().FirstOrDefaultAsync(p => p.MC001 == wareHouseCode);


            if (data != null)
            {
                return data;
            }
            else
            {
                return new CMSMC();
            }            
        }

        public async Task<CMSMC> GetWarehouse(string wareHouseCode, string db)
        {
            if (db.ToUpper() == "GIZMO")
            {
                var data = await _erpDB.GetWarehouse
                    .AsNoTracking().FirstOrDefaultAsync(p => p.MC001 == wareHouseCode);


                if (data != null)
                {
                    return data;
                }
                else
                {
                    return new CMSMC();
                }
            }
            else
            {
                var data = await _modelDB.GetWarehouse
                   .AsNoTracking().FirstOrDefaultAsync(p => p.MC001 == wareHouseCode);


                if (data != null)
                {
                    return data;
                }
                else
                {
                    return new CMSMC();
                }
            }
        }


        /// <summary>
        /// 取得品號變更單
        /// </summary>
        /// <param name="orderNo">庫別</param>
        /// <returns></returns>
        public async Task<INVTL> GetItemChangeOrder(string orderNo)
        {
            var data = await _erpDB.GetItemChangeOrder
                .Where(p => p.TL001 == orderNo)
                .OrderByDescending(p => p.TL004)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (data != null)
            {
                return data;
            }
            else
            {
                return new INVTL();
            }
        }

        public async Task<ServiceResult> CreateItemChangeOrder(INVTL invtl, List<INVTM> invtms, INVMB invmb)
        {
            ServiceResult serResult = new ServiceResult();
            serResult.Status = CommonEnums.ResultType.scuuess;

            using var transaction = await _erpDB.Database.BeginTransactionAsync();

            try
            {
                string chingeNo = string.Empty;
                var data = await _erpDB.GetItemChangeOrder
                        .Where(p => p.TL001 == invtl.TL001)
                        .OrderByDescending(p => p.TL004)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                if (data != null)
                {
                    chingeNo = data.TL004 ?? string.Empty;
                    int tempNo = 1;
                    if (int.TryParse(chingeNo, out tempNo))
                    {
                        tempNo += 1;
                    }
                    else
                    {
                        tempNo = 1;
                    }

                    chingeNo = tempNo.ToString().PadLeft(4, '0');
                }
                else
                {
                    chingeNo = "0001";
                }

                invtl.TL004 = chingeNo;
                invtms.ForEach(item => item.TM002 = invtl.TL004);
                _erpDB.Add(invtl);
                _erpDB.AddRange(invtms);
                _erpDB.SaveChanges();
                //_erpDB.Update(invmb);

                transaction.Commit();
                serResult.Status = CommonEnums.ResultType.scuuess;
                serResult.Code = StatusCodes.Status200OK;
                serResult.Message = "新增變更單成功";
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                serResult.Status = CommonEnums.ResultType.error;
                serResult.Code = StatusCodes.Status500InternalServerError;
                serResult.Message = string.Format("新增變更單失敗，錯誤訊息 : {0}", ex.Message);
            }

            return serResult;
        }

        public async Task<ServiceResult> CreateModelItemChangeOrder(INVTL invtl, List<INVTM> invtms, INVMB invmb)
        {
            ServiceResult serResult = new ServiceResult();
            serResult.Status = CommonEnums.ResultType.scuuess;

            using var transaction = await _modelDB.Database.BeginTransactionAsync();

            try
            {
                string chingeNo = string.Empty;
                var data = await _modelDB.GetItemChangeOrder
                        .Where(p => p.TL001 == invtl.TL001)
                        .OrderByDescending(p => p.TL004)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                if (data != null)
                {
                    chingeNo = data.TL004 ?? string.Empty;
                    int tempNo = 1;
                    if (int.TryParse(chingeNo, out tempNo))
                    {
                        tempNo += 1;
                    }
                    else
                    {
                        tempNo = 1;
                    }

                    chingeNo = tempNo.ToString().PadLeft(4, '0');
                }
                else
                {
                    chingeNo = "0001";
                }

                invtl.TL004 = chingeNo;
                invtms.ForEach(item => item.TM002 = invtl.TL004);
                _modelDB.Add(invtl);
                _modelDB.AddRange(invtms);
                _modelDB.SaveChanges();
                //_erpDB.Update(invmb);

                transaction.Commit();
                serResult.Status = CommonEnums.ResultType.scuuess;
                serResult.Code = StatusCodes.Status200OK;
                serResult.Message = "新增模具變更單成功";
            }
            catch (DbUpdateException ex)
            {
                transaction.Rollback();
                serResult.Status = CommonEnums.ResultType.error;
                serResult.Code = StatusCodes.Status500InternalServerError;
                serResult.Message = string.Format("新增模具變更單失敗，錯誤訊息 : {0}", ex.Message);
            }

            return serResult;
        }

        public async Task<bool> CheckingItemChangeOrderExist(string docNo)
        {
            try
            {
                var data = await _erpDB.GetItemChangeOrder
                        .Where(p => p.TL010.Contains(docNo))
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                if (data == null)
                {
                    return false;
                }
                else
                { 
                    return true;
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
