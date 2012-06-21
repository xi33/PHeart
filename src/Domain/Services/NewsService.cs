using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Services
{
    public class NewsService
    {
        private readonly IFstClassRepository fstClassRepository;
        private readonly ISndClassRepository sndClassRepository;
        private readonly INewsRepository newsRepository;

        public NewsService(
            IFstClassRepository fstClassRepository,
            ISndClassRepository sndClassRepository,
            INewsRepository newsRepository
            )
        {
            this.fstClassRepository = fstClassRepository;
            this.sndClassRepository = sndClassRepository;
            this.newsRepository = newsRepository;

        }

        public IQueryable<FstClass> FstClasses
        {
            get { return fstClassRepository.GetAll(); }
        }

        public IQueryable<SndClass> GetSndClassesByFstClassId(int fstClassId)
        {
            return sndClassRepository.GetAll()
                .Where(snd => snd.FstClassId == fstClassId)
                .OrderBy(snd=>snd.Id);
        }

        public IQueryable<News> GetNewsBySndClassId(int sndClassId)
        {
            return newsRepository.GetAll()
                .Where(news => news.SndClassId == sndClassId)
                .OrderBy(news => news.Id);
        }
    }
}
