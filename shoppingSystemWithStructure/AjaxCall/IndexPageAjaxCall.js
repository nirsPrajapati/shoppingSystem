$(document).ready(function () {
    debugger;
    
    //alert(sessionStorage.getItem("UserId"));
    productList();

   // getCategory();

});
function productList() {

    $.ajax({
        type: 'GET',
        url: '/api/ClientAPIController/selectProductMaster',
        data: {},
        success: function (retData) {
            var dataa = $("#hhh").html();

            for (var i = 0; i < retData.length; i++) {
              
                


                $("#hhh").append('<div  class="col-xl-3 col-lg-4 col-md-6 col-6">'+
                '<div class="product_grid card b-0">'+
                   ' <div class="badge bg-info text-white position-absolute ft-regular ab-left text-upper">' + sessionStorage.getItem("UserId") + '</div>' +
                   ' <div class="card-body p-0">'+
                        '<div class="shop_thumb position-relative">'+
                            '<a class="card-img-top d-block overflow-hidden" href="/Client/productDetails/' + retData[i].productId + '"><img height="270" width="297" class="card-img-top" src="' + retData[i].ProductImage.replace("~", "") + '" alt="..."></a>' +
                           ' <div class="product-left-hover-overlay">'+
                               ' <ul class="left-over-buttons">'+
                                   ' <li><a href="javascript:void(0);" class="d-inline-flex circle align-items-center justify-content-center"><i class="fas fa-expand-arrows-alt position-absolute"></i></a></li>'+
                                   ' <li><a href="javascript:void(0);" class="d-inline-flex circle align-items-center justify-content-center snackbar-wishlist"><i class="far fa-heart position-absolute"></i></a></li>'+
                                   ' <li><a href="javascript:void(0);" class="d-inline-flex circle align-items-center justify-content-center snackbar-addcart"><i class="fas fa-shopping-basket position-absolute"></i></a></li>'+
                               ' </ul>'+
                           ' </div>'+
                        '</div>'+
                    '</div>'+
                    '<div class="card-footer b-0 p-0 pt-2 bg-white d-flex align-items-start justify-content-between">'+
                        '<div class="text-left">'+
                            '<div class="text-left">'+
                                '<div class="elso_titl"><span class="small">' + retData[i].thirdCatName + '</span></div>' +
                               ' <h5 class="fs-md mb-0 lh-1 mb-1"><a href="shop-single-v1.html">' + retData[i].ProductName + '</a></h5>' +
                               ' <div class="star-rating align-items-center d-flex justify-content-left mb-2 p-0">'+
                                   ' <i class="fas fa-star filled"></i>'+
                                   ' <i class="fas fa-star filled"></i>'+
                                   ' <i class="fas fa-star filled"></i>'+
                                   ' <i class="fas fa-star filled"></i>'+
                                   ' <i class="fas fa-star"></i>'+
                               ' </div>'+
                               ' <div class="elis_rty"><span id="cls"  class="ft-bold text-dark fs-sm"><i class="fas fa-rupee-sign"></i>' + retData[i].ProductPrice + '</span></div>' +
                                
                            '</div>'+
                       ' </div>'+
                   ' </div>'+
               ' </div>'+
            '</div>')




            }
           

        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }

    });
}

