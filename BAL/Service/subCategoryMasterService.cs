using DAL;
using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Service
{
    public class subCategoryMasterService:IsubCategoryMasterService
    {
        EdbContext db = new EdbContext();

        public int InsertUpdateSubCategoryMaster(subCategoryMaster eModel)
        {
            if (eModel.subCatId>0)
            {
                try
                {

                   var data= db.subCategoryMasters.Where(m=>m.subCatId==eModel.subCatId).FirstOrDefault();
                    data.subCatName = eModel.subCatName;
                    data.status = eModel.status;
                    data.updateOn=eModel.updateOn;
                    data.catId = eModel.catId;
                    db.Entry(data).State = EntityState.Modified;
                    db.SaveChanges();
                    db.SaveChanges();
                    return 2;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
                try
                {

                    db.subCategoryMasters.Add(eModel);
                    db.SaveChanges();
                    return 1;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }


        public List<subCategoryVM> selectSubCategoryMaster()
        {
            var data = db.Database.SqlQuery<subCategoryVM>("proc_select_subCategoryMaster");
            return data.ToList();
        }

        public subCategoryMaster selectSubcatMasterbyid(int sid)
        {
            try
            {
                var data = db.subCategoryMasters.Where(m => m.subCatId == sid).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<subCategoryMaster> selectSubCatMasterByCatId(int catId)
        {
            var data = db.subCategoryMasters.Where(m => m.catId == catId).ToList();

            return data.ToList();
        }
    }
}
