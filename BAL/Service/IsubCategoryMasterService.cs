using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
  public  interface IsubCategoryMasterService
    {
        int InsertUpdateSubCategoryMaster(subCategoryMaster eModel);
        List<subCategoryVM> selectSubCategoryMaster();
        subCategoryMaster selectSubcatMasterbyid(int sid);
        List<subCategoryMaster> selectSubCatMasterByCatId(int catId);
    }
}
