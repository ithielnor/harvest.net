using Harvest.Net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest.Net
{
    public partial interface IHarvestRestClient
    {
        IList<User> ListUsers(DateTime? updatedSince = null);
        
        User User(long userId);

        User User(string email);

        User CreateUser(string email, string firstName, string lastName, bool isActive = true, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null);

        User CreateUser(UserOptions options);

        bool DeleteUser(long userId);

        User ToggleUser(long userId);
        
        User ResetPassword(long userId);
 
        User UpdateUser(long userId, string email = null, string firstName = null, string lastName = null, string timezone = null, bool? isAdmin = null, string telephone = null, string department = null, bool? isContractor = null, bool? hasAccessToAllFutureProjects = null, bool? wantsNewsletter = null, bool? wantsWeeklyDigest = null, decimal? defaultHourlyRate = null, decimal? costRate = null);

        User UpdateUser(long userId, UserOptions options);
    }
}
