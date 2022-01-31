using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public interface IUserMasterService
    {
        int selectUserMasterByemailAndPassword(string email, string password);
        UserMaster selectUserMasterById(int uid);
    }
}
