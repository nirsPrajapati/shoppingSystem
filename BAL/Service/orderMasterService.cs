using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class orderMasterService: IorderMasterService
    {
        EdbContext db = new EdbContext();

        public int InsertUpdateOrderMaster(OrderMaster eModel)
        {
            var data = db.OrderMasters.Add(eModel);
            db.SaveChanges();

            return 1;
        }
    }
}
