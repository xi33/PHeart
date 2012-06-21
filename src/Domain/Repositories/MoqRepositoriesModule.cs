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
                                    {Id = 1, Name = "sa", Email = "sa@pheart.com", Username = "sa", Password = "sa"},
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


        }
    }
}
