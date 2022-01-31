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
    public class MasterPageService:IMasterPageService
    {
        EdbContext db = new EdbContext();
        public List<categoryMaster> getAllGategory()
        {
            List<categoryMaster> catList;
            List<subCategoryMaster> SubcatList;
            List<thirdcategoryMaster> thirdcatList;
          //  catList = new List<categoryMaster>();
            List<categoryMaster> catListDual = db.categoryMasters.ToList();
            catList = new List<categoryMaster>();


            foreach (var cat in catListDual)
            {
                SubcatList = new List<subCategoryMaster>();
                List<subCategoryMaster>subCatDual = db.subCategoryMasters.Where(m => m.catId == cat.catId).ToList();
                


                foreach (var sub in subCatDual)
                {
                    
                    List<thirdcategoryMaster>thirdcatdul = db.thirdcategoryMasters.Where(m => m.subCatId == sub.subCatId).ToList();
                    thirdcatList = new List<thirdcategoryMaster>();

                    foreach (var third in thirdcatdul)
                    {
                        thirdcatList.Add(new thirdcategoryMaster
                        {
                            thirdCatId=third.thirdCatId,
                            subCatId=third.subCatId,
                            thirdCatName=third.thirdCatName
                        });
                    }

                    SubcatList.Add(new subCategoryMaster
                    {
                        catId = sub.catId,
                        subCatId=sub.subCatId,
                        subCatName=sub.subCatName,
                        
                        ThirdCatList= thirdcatList


                    });



                }


                catList.Add(new categoryMaster
                {
                    catId = cat.catId,
                    catName = cat.catName,
                    subcatList = SubcatList
                });

            }



            return catList;
        }

    }
}
