$(document).ready(function () {
    debugger;
    productDetailsList();

});


$("#btnOrder").on('click', function () {

    if (sessionStorage.getItem("UserId") != null) {
        debugger;
        var pid = window.location.href.split('/').slice(-1);
        var qunty = $("#dropQun").val();
       // window.location.href = "somepage.html?w1=" + hello + "&w2=" + world;

        window.location.href = '/Client/AddNewAddress?ProductId=' + pid + '&Quantity=' + qunty;
    }
    else {
        window.location.href = '/Client/Login';

    }
   
});
$("#btnAddtocart").on('click', function () {
    var pid = window.location.href.split('/').slice(-1);
  

    if (sessionStorage.getItem("UserId")!=null) {

        var model = {
            productId: pid,
            UserId: sessionStorage.getItem("UserId"),
            Quantity: $("#dropQun").val(),
        }

        $.ajax({

            type: "POST",
            url: "/api/ClientAPIController/InserUpdateCardMaster",
            data: model,
            dataType: "json",
            success: function (retData) {
                if (retData != null) {
                  
                    alertify.success("Successfully add to cart");
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
    else {
        window.location.href = "/Client/Login";
    }





});
function productDetailsList() {

    var pid = window.location.href.split('/').slice(-1);

    $.ajax({

        type: "GET",
        url: "/api/categoryMasterAPI/selectProductMasterById",
        data: { ProductId: pid },
        dataType: "json",
        success: function (retData) {
            debugger;
            $("#ProductName").html(retData.ProductName);
            $("#productPrice").html('<i class="fas fa-rupee-sign"></i>' + retData.ProductPrice);
            
            $("#ProductDescriptin").html(retData.Discription);
            console.log(retData.ProductImage.replace("~",""));
            $("#pimg > img").attr("src",retData.ProductImage.replace("~", ""));
        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }
    });
}