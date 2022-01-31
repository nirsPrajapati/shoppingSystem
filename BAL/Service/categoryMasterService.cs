using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class categoryMasterService: IcategoryMasterService
    {
        EdbContext db = new EdbContext();
        public  int InsertUpdateCategoryMaster(categoryMaster eModel)
        {
            if (eModel.catId>0)
            {
                var data= db.categoryMasters.Where(m => m.catId == eModel.catId).FirstOrDefault();
                data.catName = eModel.catName;
                data.status = eModel.status;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return 2;


            }
            else
            {

                var data = db.categoryMasters.Where(m => m.catName == eModel.catName).FirstOrDefault();
                if (data!=null)
                {
                    return 3;
                }
                else
                {
                    db.categoryMasters.Add(eModel);
                    db.SaveChanges();
                    return 1;
                }
        
            }
 
        }

        public List<categoryMaster> selectCategoryMaster()
        {
           var data= db.categoryMasters.ToList();

            return data.ToList();
        }

        public categoryMaster categoryMasterByid(int catId)
        {
            var data = db.categoryMasters.Where(m => m.catId == catId).FirstOrDefault();
            return data;
        }

        
    }
}
