using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Domain.Models;
using Domain.Models.Authentication;
using Domain.Repositories.Authentication;
using Moq;

namespace Domain.Repositories
{
    public class MoqRepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region mock IPostRepository
            Mock<IPostRepository> mockPost = new Mock<IPostRepository>();
            var posts = new List<Post>()
                            {
                                new Post() {Id = 1, Title = "first blog", Published = DateTime.Now.AddDays(-1)},
                                new Post() {Id = 2, Title = "second blog", Published = DateTime.Now.AddDays(-2)},
                                new Post() {Id = 3, Title = "third blog", Published = DateTime.Now.AddDays(-3)},

                            };
            mockPost.Setup(m => m.GetAll()).Returns(posts.AsQueryable());
            mockPost.Setup(m => m.Get(It.IsAny<int>())).Returns(posts.SingleOrDefault(p => p.Id == 1));
            builder.RegisterInstance(mockPost.Object).As<IPostRepository>().SingleInstance();
            #endregion

            #region mock IUserRepository
            Mock<IUserRepository> mockUser = new Mock<IUserRepository>();
            var users = new List<User>
                            {
                                new User()
                                    {Id = 1, Name = "sa", Email = "sa@pheart.com", Password = "sa"},
                                //new User()
                                //    {
                                //        Id = 2,
                                //        Name = "admin",
                                //        Email = "amdin@pheart.com",
                                //        Username = "admin",
                                //        Password = "admin"
                                //    }
                            };
            mockUser.Setup(m => m.GetAll()).Returns(users.AsQueryable());
            builder.RegisterInstance(mockUser.Object).As<IUserRepository>().SingleInstance();
            #endregion

            #region mock IFstClassRepository

            Mock<IFstClassRepository> mockFstClass = new Mock<IFstClassRepository>();
            var fstClasses = new List<FstClass>
                                 {
                                     new FstClass() {Id = 1, Name = "心闻快报"},
                                     new FstClass() {Id = 2, Name = "中心简介"},
                                     new FstClass() {Id = 3, Name = "心理辅导"},
                                     new FstClass() {Id = 4, Name = "心理百科"},
                                     new FstClass() {Id = 5, Name = "影音图片"},
                                     new FstClass() {Id = 6, Name = "资源下载"},
                                     new FstClass() {Id = 7, Name = "心理自助中心"},
                                     new FstClass() {Id = 8, Name = "心理课堂"},
                                 };
            mockFstClass.Setup(m => m.GetAll()).Returns(fstClasses.AsQueryable());
            builder.RegisterInstance(mockFstClass.Object).As<IFstClassRepository>().SingleInstance();
            #endregion

            #region mock ISndClassRepository

            Mock<ISndClassRepository> mockSndClass = new Mock<ISndClassRepository>();
            var sndClasses = new List<SndClass>
                                 {
                                     new SndClass(){Id=1,Name = "校园新闻",FstClassId = 1},
                                     new SndClass(){Id=2,Name = "社会新闻",FstClassId = 1},
                                 };
            mockSndClass.Setup(m => m.GetAll()).Returns(sndClasses.AsQueryable());
            builder.RegisterInstance(mockSndClass.Object).As<ISndClassRepository>().SingleInstance();
            #endregion

            #region mock INewsReposiory
            Mock<INewsRepository> mockNews = new Mock<INewsRepository>();
            var newses = new List<News>
                            {
                                new News(){Id=1,Title = "祝贺开版",Author = "心理自助中心",Published = DateTime.Now,Views = 10,Body = "祝贺开版,祝贺开版",SndClassId = 1},
                                new News(){Id=2,Title = "祝贺开版",Author = "心理自助中心",Published = DateTime.Now,Views = 10,Body = "祝贺开版,祝贺开版",SndClassId = 1},
                            };
            mockNews.Setup(m => m.GetAll()).Returns(newses.AsQueryable());
            builder.RegisterInstance(mockNews.Object).As<INewsRepository>().SingleInstance();
            #endregion
        }
    }
}
