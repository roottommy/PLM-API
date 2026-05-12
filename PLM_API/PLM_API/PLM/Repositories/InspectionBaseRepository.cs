using Microsoft.EntityFrameworkCore;
using PLM_API.Infrastructure.MSSql;
using PLM_API.PLM.Models.SPCAn;

namespace PLM_API.PLM.Repositories
{
    public class InspectionBaseRepository : IInspectionBaseRepository
    {
        private readonly AppSPCDbContext _db;

        public InspectionBaseRepository(AppSPCDbContext db)
        {
            _db = db;
        }

        public async Task<List<Cs1dataPicture>> QuerySPCPicture(string pdid)
        {
            // 修正：使用 FromSqlInterpolated 並傳入 FormattableString
            return await _db.Cs1dataPictureRecords.FromSqlInterpolated($@"SELECT [pdid],ISNULL([sn],'') AS 'sn',ISNULL([path],'') AS 'path',ISNULL([path2],'') AS 'path2',ISNULL([path3],'') AS 'path3' FROM [cs1data_picture] WHERE [pdid]={pdid}").AsNoTracking().ToListAsync();
        }
    }
}
