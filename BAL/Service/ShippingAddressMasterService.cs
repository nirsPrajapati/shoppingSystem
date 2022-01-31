using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class ShippingAddressMasterService: IShippingAddressMasterService
    {
        EdbContext db = new EdbContext();
        public int insertUpdateShippinAddressMaster(ShippingAdderessMaster eModel)
        {
            var data = db.ShippingAdderessMasters.Add(eModel);
            db.SaveChanges();

            return data.ShippingAddressId;
        }
    }
}
