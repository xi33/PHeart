﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Domain.Repositories;

namespace Domain.Services
{
    public class NewsService
    {
        #region ctor
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
        #endregion

        #region FstClass
        public IQueryable<FstClass> FstClasses
        {
            get { return fstClassRepository.GetAll(); }
        }

        public FstClass GetFstClassById(int id)
        {
            return fstClassRepository.Get(id);
        }

        public void UpdateFstClass(FstClass fstClassToUpdate)
        {
            fstClassRepository.Update(fstClassToUpdate);
        }
        #endregion

        #region SndClass
        public SndClass GetSndClassById(int id)
        {
            return sndClassRepository.Get(id);
        }

        public void UpdateSndClass(SndClass sndClassToUpdate)
        {
            sndClassRepository.Update(sndClassToUpdate);
        }

        public IQueryable<SndClass> GetSndClassesByFstClassId(int fstClassId)
        {
            return sndClassRepository.GetAll()
                .Where(snd => snd.FstClassId == fstClassId)
                .OrderBy(snd => snd.Id);
        }

        public void AddSndClass(SndClass sndClassToAdd)
        {
            sndClassRepository.Insert(sndClassToAdd);
        }
        #endregion

        public IQueryable<News> GetNewsListBySndClassId(int sndClassId)
        {
            return newsRepository.GetAll()
                .Where(news => news.SndClassId == sndClassId)
                .OrderBy(news => news.Id);
        }

        public News GetNewsById(int id)
        {
            return newsRepository.Get(id);
        }

        public void CreateNews(News newsToAdd)
        {
            newsRepository.Insert(newsToAdd);

        }

        public void AddNewsView(int newsId)
        {
            var news = newsRepository.Get(newsId);
            news.Views++;
            newsRepository.Update(news);
        }
    }
}
