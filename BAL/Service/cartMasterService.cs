using DAL;
using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
   public class cartMasterService: IcartMasterService
    {
        EdbContext db = new EdbContext();
        public int insertUpdateCartMaster(CartMaster eModel)
        {

           var result= db.CartMasters.Where(m => m.productId == eModel.productId && m.UserId==eModel.UserId).FirstOrDefault();
            if (result!=null)
            {
               var data= db.CartMasters.Where(m => m.productId == eModel.productId && m.UserId==eModel.UserId).FirstOrDefault();
                data.Quantity =data.Quantity+eModel.Quantity;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();

            }
            else
            {
                var data = db.CartMasters.Add(eModel);
                db.SaveChanges();
               
            }
            return 1;

        }

        public List<CartMasterVM> selectCartMasterByUserId(int Uid)
        {
            var data = db.Database.SqlQuery<CartMasterVM>("Proc_Select_CartMasterByUserId @userid", new SqlParameter[] {
                new SqlParameter ("@userid",Uid)

            }).ToList();
            return data;
        }

        public int CartMasterCountbyUserId(int uid)
        {
            var data = db.CartMasters.Where(m=>m.UserId==uid).Count();
            return data;
        }
    }

    
}
