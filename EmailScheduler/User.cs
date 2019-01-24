using EmailScheduler.Interface;
using EmailSchedulerData;
using System;
using System.Collections.Generic;
using System.Linq;
using static EmailSchedulerCommon.Enums;
using System.Configuration;

namespace EmailScheduler
{
	public class User : IUser
	{
		private readonly Email email;
		private readonly int activeDaysLimit;
		private readonly int notResponsiveDaysLimit;
		private readonly int notResponsiveToActivate;
		private readonly int notResponsiveToInavtive;
		private readonly int activeToNotResponsive;

		public User()
		{
			email = new Email();
			activeDaysLimit = Convert.ToInt32(ConfigurationManager.AppSettings["ActiveDaysLimit"]);
			notResponsiveDaysLimit = Convert.ToInt32(ConfigurationManager.AppSettings["NotResponsiveDaysLimit"]);

			notResponsiveToActivate = Convert.ToInt32(ConfigurationManager.AppSettings["NotResponsiveToActivate"]);
			notResponsiveToInavtive = Convert.ToInt32(ConfigurationManager.AppSettings["NotResponsiveToInavtive"]);
			activeToNotResponsive = Convert.ToInt32(ConfigurationManager.AppSettings["ActiveToNotResponsive"]);
		}

		public List<UserProfile> GetUsers()
		{
			using (var context = new emailSchedulerEntities())
			{
				var result = (from p in context.UserProfiles
							  select p).ToList();
				return result;
			}
		}

		public void SendEmail(List<UserProfile> users)
		{
			using (var context = new emailSchedulerEntities())
			{
				foreach (var item in users)
				{
					var userProfile = context.UserProfiles.Where(x => x.id == item.id).FirstOrDefault();

					if (userProfile.Status == Status.Active.ToString("G")
						&& (DateTime.Now.Date - userProfile.LastEmailSent.Value).TotalDays >= activeDaysLimit)
					{
						email.Send();
					}

					if (userProfile.Status == Status.NotResponsive.ToString("G")
						&& (DateTime.Now.Date - userProfile.LastEmailSent.Value).TotalDays > notResponsiveDaysLimit)
					{
						email.Send();
					}

					userProfile.LastEmailSent = DateTime.Now.Date;
				}
				context.SaveChanges();
			}
		}

		public void UpdateUserState()
		{
			using (var context = new emailSchedulerEntities())
			{
				var usersList = context.UserProfiles.Select(x => x).ToList();

				UpdatedUserStates(usersList, context);
			}
		}

		private void UpdatedUserStates(List<UserProfile> users, emailSchedulerEntities context)
		{
			foreach (var item in users)
			{
				if (item.Status == Status.Active.ToString("G")
				&& (DateTime.Now.Date - item.LastLogin.Value.Date).TotalDays > activeToNotResponsive)
				{
					item.Status = Status.NotResponsive.ToString("G");
				}

				if (item.Status == Status.NotResponsive.ToString("G")
				&& (DateTime.Now.Date - item.LastLogin.Value.Date).TotalDays > notResponsiveToInavtive)
				{
					item.Status = Status.InAvtive.ToString("G");
				}

				if (item.Status == Status.NotResponsive.ToString("G")
				&& (DateTime.Now.Date - item.LastLogin.Value.Date).TotalDays < notResponsiveToActivate)
				{
					item.Status = Status.Active.ToString("G");
				}
			}
			context.SaveChanges();
		}
	}
}
