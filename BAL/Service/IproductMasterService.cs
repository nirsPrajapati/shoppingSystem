using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
   public interface IproductMasterService
    {
         int insertUpdateProductMaster(productMaster eModel);
        List<thirdcategoryMaster> selectThirdCatMasterByCidandSid(int catid, int subid);
      List<ProductMasterVM> SelectProductMaster();
        productMaster SelectProductMasterById(int productId);


    }
}
