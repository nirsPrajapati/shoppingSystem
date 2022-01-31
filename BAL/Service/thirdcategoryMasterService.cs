using DAL;
using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class thirdcategoryMasterService: IthirdcategoryMasterService
    {
        EdbContext db = new EdbContext();

        public int InsertUpdateThirdCatMaster(thirdcategoryMaster eModel)
        {
           var data= db.thirdcategoryMasters.Add(eModel);
            db.SaveChanges();
            return 1;
        }
        public List<thirdCatMasterVM> selectThirdCategoryMaster()
        {
            var data = db.Database.SqlQuery<thirdCatMasterVM>("Proc_select_third_Cat_Master");
            return data.ToList();
        }
    }
}
