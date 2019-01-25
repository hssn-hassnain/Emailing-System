using EmailScheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailScheduler
{
    class EmailSchaduler : IEmailScheduler
    {
        private readonly Email email;
        private readonly User user;

        public EmailSchaduler()
        {
            email = new Email();
            user = new User();
        }

        public void Run()
        {
            user.UpdateUserState();

            var users = user.GetUsers();

            email.SendEmail();
        }
    }
}
