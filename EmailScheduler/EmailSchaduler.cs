using EmailScheduler.Interface;

namespace EmailScheduler
{
	public class EmailSchaduler : IEmailScheduler
    {
        private readonly User user;

        public EmailSchaduler()
        {
            user = new User();
        }

        public void Run()
        {
			//TODO: Update all the users based on date
			user.UpdateUserState();

			//TODO: Get the list of users
			var listOfUser = user.GetUsers();

			//TODO: Send email to users
            user.SendEmail(listOfUser);
        }
    }
}
