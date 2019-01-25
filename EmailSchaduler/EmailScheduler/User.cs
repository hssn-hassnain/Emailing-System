using EmailScheduler.Interface;
using EmailSchedulerData;
using System;
using System.Collections.Generic;

namespace EmailScheduler
{
    class User : IUser
    {
        private readonly EmailSchedulerData.emailSenderEntities context;

        public User()
        {
            context = new EmailSchedulerData.emailSenderEntities();
        }

        public List<UserProfile> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmailSentDate(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserState()
        {
            using (var context = new EmailSchedulerData.emailSenderEntities())
            {
                //var result = (from p in context.UserProfiles select p);
            }
            return true;
        }
    }
}
