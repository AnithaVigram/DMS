using DMS.Data.EF.Models;

namespace DMS.API.Model;

public class UserConstants
{
    public static readonly List<UserModel> Users = new()
    {
        new UserModel { UserName = "admin", Password = "admin123", Role = "Admin" }
    };
}
