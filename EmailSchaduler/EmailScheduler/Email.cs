using EmailScheduler.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailScheduler
{
    public class Email : IEmail
    {
        public bool SendEmail()
        {
            return true;
        }
    }
}
