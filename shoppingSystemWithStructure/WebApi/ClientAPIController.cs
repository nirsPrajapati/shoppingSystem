using BAL.Service;
using DAL.Entity;
using DAL.ViewModel;
using shoppingSystemWithStructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace shoppingSystemWithStructure.WebApi
{
    public class ClientAPIController : ApiController
    {
        IcategoryMasterService _IcategoryMasterService;
        IproductMasterService _IproductMasterService;
        IMasterPageService _IMasterPageService;
        IUserMasterService _IUserMasterService;
        IcartMasterService _IcartMasterService;
        IShippingAddressMasterService _IShippingAddressMasterService;
        IorderMasterService _IorderMasterService;

        public ClientAPIController()
        {
            _IproductMasterService = new productMasterService();
            _IcategoryMasterService = new categoryMasterService();
            _IMasterPageService = new MasterPageService();
            _IUserMasterService = new UserMasterService();
            _IcartMasterService = new cartMasterService();
            _IShippingAddressMasterService = new ShippingAddressMasterService();
            _IorderMasterService = new orderMasterService();

        }

        [Route("api/ClientAPIController/selectProductMaster")]

        [HttpGet]
        public List<ProductMasterVM> selectProductMaster()
        {
            var data = _IproductMasterService.SelectProductMaster();
            return data;
        }



        [Route("api/ClientAPIController/selectCategoryMaster")]

        [HttpGet]
        public List<categoryMaster> selectCategoryMaster()
        {
            var data = _IcategoryMasterService.selectCategoryMaster();

            return data;
        }


        [Route("api/ClientAPIController/GetAllCategory")]

        [HttpGet]
        public List<categoryMaster> GetAllCategory()
        {

            var data = _IMasterPageService.getAllGategory();
            return data;
        }


        [Route("api/ClientAPIController/selectUserMasterByemailAndPassword")]


        [HttpGet]
        public int selectUserMasterByemailAndPassword(string email, string password)
        {
            var data = _IUserMasterService.selectUserMasterByemailAndPassword(email, password);

            return data;


        }


        [Route("api/ClientAPIController/selectUserMasterById")]


        [HttpGet]
        public UserMaster selectUserMasterById(int userid)
        {
            var data = _IUserMasterService.selectUserMasterById(userid);

            return data;


        }



        [Route("api/ClientAPIController/InserUpdateCardMaster")]
        public int InserUpdateCardMaster(cartMasterModel model)
        {
            CartMaster eModel = new CartMaster();
            eModel.productId = model.productId;
            eModel.UserId = model.UserId;
            eModel.Quantity = model.Quantity;
            eModel.byNow = 0;

            var data = _IcartMasterService.insertUpdateCartMaster(eModel);
            return data;
        }




        [Route("api/ClientAPIController/selectCartMasterByUserId")]


        [HttpGet]
        public List<CartMasterVM> selectCartMasterByUserId(int userid)
        {
            var data = _IcartMasterService.selectCartMasterByUserId(userid);

            return data;


        }

        [Route("api/ClientAPIController/CartMasterCountbyUserId")]


        [HttpGet]
        public int CartMasterCountbyUserId(int userid)
        {
            var data = _IcartMasterService.CartMasterCountbyUserId(userid);
            return data;
        }

        [Route("api/ClientAPIController/insertUpdateShippinAddressMaster")]
        [HttpPost]
        public int insertUpdateShippinAddressMaster(ShippingAddressModel model)
        {
            ShippingAdderessMaster eModel = new ShippingAdderessMaster();
            eModel.fullName = model.fullName;
            eModel.Address = model.Address;
            eModel.pincod = model.pincod;
            eModel.city = model.city;
            eModel.UserId = model.UserId;
            var data = _IShippingAddressMasterService.insertUpdateShippinAddressMaster(eModel);
            return data;
          
        }

        [Route("api/ClientAPIController/insertUpdateOredrMasterAndCartMaster")]
        [HttpGet]
        public int insertUpdateOredrMasterAndCartMaster(int pid,int qty,int userid,int shid)
        {
            OrderMaster eModel = new OrderMaster();

            eModel.productId = pid;
            eModel.shippingId = shid;
            eModel.UserId = userid;
            eModel.OrdrDate = System.DateTime.Now.ToString() ;
           var data = _IorderMasterService.InsertUpdateOrderMaster(eModel);

            CartMaster cModel = new CartMaster();
            cModel.productId = pid;
            cModel.UserId = userid;
            cModel.Quantity = qty;
            cModel.byNow = 1;

            _IcartMasterService.insertUpdateCartMaster(cModel);
                       
            return 1;

        }
    }
}