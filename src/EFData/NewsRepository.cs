using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace EFData
{
    public class NewsRepository :Repository<News>, INewsRepository
    {
        //public NewsRepository(PHeartDbContext context):base(context)
        //{
            
        //}
    }
}
