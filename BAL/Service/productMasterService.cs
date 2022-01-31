using DAL;
using DAL.Entity;
using DAL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BAL.Service
{
    public class productMasterService: IproductMasterService
    {
        EdbContext db = new EdbContext();
        public int insertUpdateProductMaster(productMaster eModel )
        {
            if (eModel.productId>0)
            {
                try
                {
                    var data = db.productMasters.Where(m=>m.productId==eModel.productId).FirstOrDefault();
                    data.CategoryId = eModel.CategoryId;
                    data.subCatId = eModel.subCatId;
                    data.thirdCatId = eModel.thirdCatId;
                    data.ProductName = eModel.ProductName;
                    data.ProductPrice = eModel.ProductPrice;
                    data.Color = eModel.Color;
                    data.Discription = eModel.Discription;
                    data.ProductImage = eModel.ProductImage;
                    data.EnteryDate = System.DateTime.Now;
                    db.Entry(data).State = EntityState.Modified;
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
                    var data = db.productMasters.Add(eModel);
                    db.SaveChanges();
                    return 1;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
    
 
        }

        public List<thirdcategoryMaster> selectThirdCatMasterByCidandSid(int catid,int subid)
        {
           var data= db.thirdcategoryMasters.Where(m => m.catId == catid && m.subCatId == subid).ToList();
           
            return data;
        }

        public List<ProductMasterVM> SelectProductMaster()
        {
            var data = db.Database.SqlQuery<ProductMasterVM>("Proc_Select_ProductMaster");
            return data.ToList();
        }

        public productMaster SelectProductMasterById(int productId)
        {
            var data = db.productMasters.Where(m => m.productId == productId).FirstOrDefault();
            return data;
        }

     
    }
}
