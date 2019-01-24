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
        void UpdateUserState();

        void SendEmail(List<UserProfile> users);

        List<UserProfile> GetUsers();
    }
}
