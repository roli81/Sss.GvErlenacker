using Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sss.GvErlenacker.Services.Impl
{
    public class NewsletterRegisterService : INewsletterRegisterService
    {


        public bool IsAlreadyRegistered(string email)
        {
            using (var ctx = new NewsletterContext())
            {
                return ctx.Users.Any(u => u.Email == email);
            }
        }

        public void Subscribe(Sss.Mutobo.Poco.NewsletterUser user)
        {
            var entity = new Sss.GvErlenacker.Newsletter.DomainLayer.DataLayer.Entities.NewsletterUser()
            {
                Email = user.EMail,
                Firstname = user.FirstName,
                NewsletterUserID = Guid.NewGuid(),
                Lastname = user.Name,
                RegisterDate = DateTime.Now
            };

            using (var ctx = new NewsletterContext())
            {
                ctx.Users.Add(entity);
                ctx.SaveChanges();
            }
        }



        public void Unsubscribe(string email)
        {
            using (var ctx = new NewsletterContext())
            {
                var entity = ctx.Users.FirstOrDefault(u => u.Email == email);

                if (entity != null)
                {
                    ctx.Users.Remove(entity);
                }

                ctx.SaveChanges();
            }
        }


    }
}
