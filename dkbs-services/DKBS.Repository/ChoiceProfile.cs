using AutoMapper;
using DKBS.Domain;
using DKBS.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKBS.Repository
{
   public class ChoiceProfile :Profile
    {
        public ChoiceProfile()
        {
            CreateMap<Region, RegionDTO>();
            CreateMap<TableSet, TableSetDTO>();
        }
    }
}
