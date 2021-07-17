using System;
using System.Linq;
using Sss.Mutobo.DataLayer.Context;
using Sss.Mutobo.Interfaces.Services;
using Sss.Mutobo.Poco;

namespace Sss.Mutobo.Services
{
    public class NewsletterService : INewsLetterService
    {

        

        public bool IsAlreadyRegistered(string email)
        {
            using (var ctx = new NewsletterContext())
            {
                return ctx.Users.Any(u => u.Email == email);
            }
        }

        public void Subscribe(NewsletterUser user)
        {
            var entity = new DataLayer.Entities.NewsletterUser()
            {
                Email = user.EMail,
                Firstname = user.FirstName,
                ID = Guid.NewGuid(),
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
