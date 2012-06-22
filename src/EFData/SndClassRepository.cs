using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace EFData
{
    public class FstClassRepository :Repository<FstClass>, IFstClassRepository
    {
        public FstClassRepository(PHeartDbContext context):base(context)
        {
            
        }
    }
}
