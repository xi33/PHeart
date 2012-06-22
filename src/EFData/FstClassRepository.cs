using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace EFData
{
    public class SndClassRepository :Repository<SndClass>, ISndClassRepository
    {
        public SndClassRepository(PHeartDbContext context):base(context)
        {
            
        }
    }
}
