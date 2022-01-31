using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
  public  class UserMasterService: IUserMasterService
    {
        EdbContext db = new EdbContext();
        public int selectUserMasterByemailAndPassword(string email,string password)
        {
           var data= db.UserMasters.Where(m => m.UserEmail == email && m.Password == password).FirstOrDefault();
            if (data!=null)
            {
                
                return data.UserId;
            }
            else
            {
                return 0;
            }
              
        }
        public UserMaster selectUserMasterById(int uid)
        {
            var data = db.UserMasters.Where(m => m.UserId == uid).FirstOrDefault();
            return data;
        }
    }
}
