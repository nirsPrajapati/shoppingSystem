var Qurproductid;
var Qurquantity;
$(window).ready(function () {
    debugger;
    const params = new URLSearchParams(window.location.search)

    Qurproductid = params.get("ProductId");
    Qurquantity = params.get("Quantity");
   
        
    //for (var param of params) {
    //    console.log(param)
    //}

    //var splitParametersFromUrl = window.location.href.split('?');
    //var spliteParameters = splitParametersFromUrl[1].split('&');
    //Qurproductid = spliteParameters[0];
    //Qurquantity = spliteParameters[1];

  

    productDetailsList();
});

$("#btnOrder").on('click', function () {
    var shid=sessionStorage.getItem("ShippingId");
    var userid=sessionStorage.getItem("UserId");
    $.ajax({

        type: "Get",
        url: "/api/ClientAPIController/insertUpdateOredrMasterAndCartMaster",
        data: { pid: Qurproductid, qty: Qurquantity, userid: userid, shid: userid},
        dataType: "json",
        success: function (retData) {
            alertify.success("<span class='text-white'>Successfully your Order Add</span>");

        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }
    });
});

$("#btnSave").on('click', function () {

    //var _this = $(this);
    //console.log(_this);
    //var _form = $("#formProduct");
    //console.log(_form);
    //var validator = _form.validate(); // obtain validator
    //var anyError = false;
    //_form.find("input,select,textarea").each(function () {
    //    if (!validator.element(this)) { // validate every input element inside this step
    //        anyError = true;
    //    }
    //});
    //console.log(anyError);
    //if (anyError) {
    //    return false;
    //}
    var uid = sessionStorage.getItem("UserId");
    if (uid != null) {
        debugger;
        var model = {
            

            fullName: $("#fullName").val(),
            pincod: $("#pincod").val(),
            city: $("#city").val(),
            Address: $("#Address").val(),
            UserId: uid,

        };


        $.ajax({

            type: "POST",
            url: "/api/ClientAPIController/insertUpdateShippinAddressMaster",
            data: model,
            dataType: "json",
            success: function (retData) {
                alertify.success("<span class='text-white'>Successfully Save Address</span>");
                sessionStorage.ShippingId=retData;

            },
            beforeSend: function () {
                $(".pp").fadeIn(600);
            },
            complete: function () {
                $(".pp").fadeOut(600);
            }
        });
    }
    else {
        window.location.href = "/Client/Login";
    }
 

});


function productDetailsList() {

  
    var pid = Qurproductid;

    $.ajax({

        type: "GET",
        url: "/api/categoryMasterAPI/selectProductMasterById",
        data: { ProductId: pid },
        dataType: "json",
        success: function (retData) {
            $("#productList").append('<li class="list-group-item">'+
										'<div class="row align-items-center">'+
											'<div class="col-3">'+
												'<!-- Image -->'+
												'<a href="product.html"><img src="' + retData.ProductImage.replace("~","") + '"  class="img-fluid"></a>' +
											'</div>'+
											'<div class="col d-flex align-items-center">'+
												'<div class="cart_single_caption pl-2">'+
													'<h4 class="product_title fs-md ft-medium mb-1 lh-1">' + retData.ProductName + '</h4>' +
													'<p class="mb-1 lh-1"><span class="text-dark">Size: 40</span></p>'+
													'<p class="mb-3 lh-1"><span class="text-dark">Color: Blue</span></p>'+
													'<h4 class="fs-md ft-medium mb-3 lh-1">' + retData.ProductPrice + '</h4>' +
												'</div>'+
											'</div>'+
										'</div>'+
									'</li>');

        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }
    });
}