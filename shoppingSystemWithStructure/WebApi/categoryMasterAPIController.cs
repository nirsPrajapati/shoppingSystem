using BAL.Service;
using DAL.Entity;
using DAL.ViewModel;
using shoppingSystemWithStructure.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using static System.Net.WebRequestMethods;

namespace shoppingSystemWithStructure.WebApi
{
    public class categoryMasterAPIController : ApiController
    {
        IcategoryMasterService _IcategoryMasterService;
        IsubCategoryMasterService _IsubCategoryMasterService;
        IthirdcategoryMasterService _IthirdcategoryMasterService;
        IproductMasterService _IproductMasterService;
     
        public categoryMasterAPIController()
        {
            _IcategoryMasterService = new categoryMasterService();
            _IsubCategoryMasterService = new subCategoryMasterService();
            _IthirdcategoryMasterService = new thirdcategoryMasterService();
            _IproductMasterService = new productMasterService();
            
        }
        [Route("api/categoryMasterAPI/InsertUpdateCategoryMaster")]
        [HttpPost]

        public int InsertUpdateCategoryMaster(categoryMasterModel model)
        {

            if (ModelState.IsValid)
            {
                categoryMaster eModel = new categoryMaster();
                eModel.catId = model.catId;
                eModel.catName = model.catName;
                eModel.status = model.status;
                try
                {
                    var data = _IcategoryMasterService.InsertUpdateCategoryMaster(eModel);
                    return data;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return 0;
        }

        [Route("api/categoryMasterAPI/selectCategoryMaster")]

        [HttpGet]
        public List<categoryMaster> selectCategoryMaster()
        {
            var data = _IcategoryMasterService.selectCategoryMaster();

            return data;
        }
        [Route("api/categoryMasterAPI/categoryMasterByid")]
        [HttpGet]
        public categoryMaster categoryMasterByid(int CatId)
        {
            var data = _IcategoryMasterService.categoryMasterByid(CatId);
            return data;
        }


        [Route("api/categoryMasterAPI/InsertUpdateSubCategoryMaster")]
        [HttpPost]
        public int InsertUpdateSubCategoryMaster(subCategoryMasterModel model)
        {
            subCategoryMaster eModel = new subCategoryMaster();
            eModel.subCatId = model.subCatId;
            eModel.catId = model.catId;
            eModel.subCatName = model.subCatName;
            eModel.status = model.status;
            eModel.updateOn = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

            if (ModelState.IsValid)
            {
                try
                {
                    var data = _IsubCategoryMasterService.InsertUpdateSubCategoryMaster(eModel);
                    return data;

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return 0;
        }

        [Route("api/categoryMasterAPI/selectSubCategoryMaster")]
        [HttpGet]
        public List<subCategoryVM> selectSubCategoryMaster()
        {
            var data = _IsubCategoryMasterService.selectSubCategoryMaster();
            return data;
        }

        [Route("api/categoryMasterAPI/selectSubCatMasterById")]

        [HttpGet]
        public subCategoryMaster selectSubCatMasterById(int sid)
        {
            var data = _IsubCategoryMasterService.selectSubcatMasterbyid(sid);
            return data;
        }

        [Route("api/categoryMasterAPI/selectSubCatMasterByCatId")]

        [HttpGet]
        public List<subCategoryMaster> selectSubCatMasterByCatId(int catId)
        {
            var data = _IsubCategoryMasterService.selectSubCatMasterByCatId(catId);
            return data;
        }


        [Route("api/categoryMasterAPI/InsertUpdatethirdCategoryMaster")]
        [HttpPost]
        public int InsertUpdatethirdCategoryMaster(thirdcategoryMaster model)
        {
            thirdcategoryMaster eModel = new thirdcategoryMaster();
            eModel.thirdCatId = model.thirdCatId;
            eModel.thirdCatName = model.thirdCatName;
            eModel.subCatId = model.subCatId;
            eModel.catId = model.catId;
            eModel.status = model.status;
            eModel.UpdateOn = Convert.ToDateTime(System.DateTime.Now.ToShortDateString());

            if (ModelState.IsValid)
            {
                try
                {
                    var data = _IthirdcategoryMasterService.InsertUpdateThirdCatMaster(eModel);
                    return data;

                }
                catch (Exception)
                {

                    throw;
                }
            }

            return 0;
        }
        [Route("api/categoryMasterAPI/selectthirdCategoryMaster")]
        [HttpGet]
        public List<thirdCatMasterVM> selectthirdCategoryMaster()
        {
            var data = _IthirdcategoryMasterService.selectThirdCategoryMaster();
            return data;
        }

        [Route("api/categoryMasterAPI/selectthirdCategoryMasterByCatIdandSubCatiD")]
        [HttpGet]
        public List<thirdcategoryMaster> selectthirdCategoryMasterByCatIdandSubCatiD(int CategoryId, int SunCatId)
        {
            var data = _IproductMasterService.selectThirdCatMasterByCidandSid(CategoryId, SunCatId);
            return data.ToList();
        }


        [Route("api/categoryMasterAPI/insertUpdateProductMaster")]
        [HttpPost]
        public int insertUpdateProductMaster()
        {
            var productDetails = HttpContext.Current.Request;
            productMaster eModel = new productMaster();
            eModel.productId = Convert.ToInt32(productDetails["productId"]);
            eModel.CategoryId = Convert.ToInt32(productDetails["CategoryId"]);
            eModel.subCatId = Convert.ToInt32(productDetails["subCatId"]);
            eModel.thirdCatId = Convert.ToInt32(productDetails["thirdCatId"]);
            eModel.ProductPrice = Convert.ToDecimal(productDetails["ProductPrice"]);
            eModel.ProductName = Convert.ToString(productDetails["ProductName"]);
            eModel.Color = Convert.ToString(productDetails["Color"]);
            eModel.Discription = Convert.ToString(productDetails["Discription"]);
            



            eModel.EnteryDate = System.DateTime.Now;

            if (productDetails.Files.Count > 0)
            {
                foreach (string item in productDetails.Files)
                {
                    var postedfile = productDetails.Files[item];
                    if (postedfile.FileName != null)
                    {
                        //Guid gn = new Guid();
                        var fileName = Guid.NewGuid().ToString().Replace("-", "");
                        //var fileName = gn.ToString();
                        var extns = Path.GetExtension(postedfile.FileName);
                        var fnamewithaouext = Path.GetFileNameWithoutExtension(postedfile.FileName);
                        fileName = fileName + fnamewithaouext + "" + extns;
                        eModel.ProductImage = "~/Admin/ProductImg/" + fileName;
                        postedfile.SaveAs(HttpContext.Current.Server.MapPath("~/Admin/ProductImg/" + fileName));
                    }
                   

                }

            }
            else
            {
                eModel.ProductImage = productDetails["showImg"];

            }


            // eModel.ProductImage = productDetails["showImg"];

            var data = _IproductMasterService.insertUpdateProductMaster(eModel);
            return data;
        }


        [Route("api/categoryMasterAPI/selectProductMaster")]

        [HttpGet]
        public List<ProductMasterVM> selectProductMaster()
        {
            var data = _IproductMasterService.SelectProductMaster();
            return data;
        }

        [Route("api/categoryMasterAPI/selectProductMasterById")]

        [HttpGet]
        public productMaster selectProductMasterById(int ProductId)
        {
            var data = _IproductMasterService.SelectProductMasterById(ProductId);
            return data;
        }
        

    

    }
}