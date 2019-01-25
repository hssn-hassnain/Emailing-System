using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSchedulerData;

namespace EmailScheduler.Interface
{
    interface IUser
    {
        bool UpdateUserState();

        bool UpdateEmailSentDate(int userId);

        List<UserProfile> GetUsers();
    }
}
