using DKBS.Data;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DKBS.Domain;

namespace DKBS.Repository
{
    public interface IChoiceRepository
    {
        List<RegionDTO> GetRegions();
    }

    public class ChoiceRepository : IChoiceRepository
    {
        DKBSDbContext _dbContext;
        public ChoiceRepository(DKBSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<RegionDTO> GetRegions()
        {
          return  _dbContext.Regions.Select( p  =>  new RegionDTO { Name = p.Name, RegionId = p.RegionId }).ToList();
        }
    }
}
