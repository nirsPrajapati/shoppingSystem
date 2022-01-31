using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public interface IcartMasterService
    {
        int insertUpdateCartMaster(CartMaster eModel);

        List<CartMasterVM> selectCartMasterByUserId(int Uid);
       int CartMasterCountbyUserId(int uid);
    }
}
