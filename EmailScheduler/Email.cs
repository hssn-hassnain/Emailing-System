using EmailScheduler.Interface;

namespace EmailScheduler
{
	public class Email : IEmail
    {
        public bool Send()
        {
			return true;
        }
    }
}
