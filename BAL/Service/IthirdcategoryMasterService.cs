using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public interface IthirdcategoryMasterService
    {
        int InsertUpdateThirdCatMaster(thirdcategoryMaster eModel);
        List<thirdCatMasterVM> selectThirdCategoryMaster();
    }
}
