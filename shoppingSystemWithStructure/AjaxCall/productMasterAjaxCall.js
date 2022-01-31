


$(document).ready(function () {

    fillCategory();
    var productId = window.location.href.split('/').slice(-1);
    if (parseInt(productId) > 0 && productId != null && productId != undefined && productId != "" || !isNaN(productId)) {

        editCatMaster(productId);

    }

});



function editCatMaster(productId) {
    debugger;

    console.log(productId);

    $.ajax({

        type: "GET",
        url: "/api/categoryMasterAPI/selectProductMasterById",
        data: { ProductId: productId },
        dataType: "json",
        success: function (retData) {
            debugger;
            console.log(retData);
            $("#productId").val(retData.productId)
            $("#dropCatId").val(retData.CategoryId);
            $("#dropThirdcatId").val(retData.thirdCatId);
            $("#ProductPrice").val(retData.ProductPrice);
            $("#ProductName").val(retData.ProductName);
            $("#Color").val(retData.Color);
            $("#Discription").val(retData.Discription);
            $("#showImg").val(retData.ProductImage);
            $("#imgPreview").attr("src", retData.ProductImage.replace("~", ""));




            subcatEdit(retData.CategoryId, retData.subCatId);

            editThirdCategory(retData.CategoryId, retData.subCatId, retData.thirdCatId);


        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }
    });
}


function fillCategory() {

    $.ajax({
        type: 'GET',
        url: '/api/categoryMasterAPI/selectCategoryMaster',
        data: {},
        success: function (retData) {
            for (var i = 0; i < retData.length; i++) {
                $("#dropCatId").append($("<option></option>").val(retData[i].catId).html(retData[i].catName));
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

function bindsubCategory(category) {
    console.log(category);
    var cid = $(category).val();

    subcatEdit(cid, 0);


}

function subcatEdit(categoryId, subCid) {
    debugger;
    //var cid = categoryId.value;
    $.ajax({
        type: 'GET',
        url: '/api/categoryMasterAPI/selectSubCatMasterByCatId',
        data: { catId: categoryId },
        success: function (retData) {
            $("#dropsubCatId").html("");
            $("#dropsubCatId").append($("<option></option>").val("").html("--select--"));


            for (var i = 0; i < retData.length; i++) {
                if (subCid == retData[i].subCatId) {
                    $("#dropsubCatId").append($("<option selected></option>").val(retData[i].subCatId).html(retData[i].subCatName));
                }
                else {
                    $("#dropsubCatId").append($("<option></option>").val(retData[i].subCatId).html(retData[i].subCatName));
                }

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




function bindthirdCategory(CatID, SubID) {
    debugger;

    var cid = CatID.value;
    var sid = SubID.value;
    console.log(cid);
    console.log(sid);

    editThirdCategory(cid, sid, 0);




}

function editThirdCategory(catid, subcatid, thirdcatid) {
    $.ajax({
        type: 'GET',
        url: '/api/categoryMasterAPI/selectthirdCategoryMasterByCatIdandSubCatiD',
        data: { CategoryId: catid, SunCatId: subcatid },
        success: function (retData) {
            $("#dropThirdcatId").html("");
            $("#dropThirdcatId").append($("<option></option>").val("").html("--select--"));



            for (var i = 0; i < retData.length; i++) {

                if (retData[i].thirdCatId == thirdcatid) {
                    $("#dropThirdcatId").append($("<option selected option>").val(retData[i].thirdCatId).html(retData[i].thirdCatName));

                }
                else {
                    $("#dropThirdcatId").append($("<option></option>").val(retData[i].thirdCatId).html(retData[i].thirdCatName));

                }

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


$("#btnSave").click(function () {
    debugger; 
       var formdataformpage = new FormData();
    //var Form = document.getElementById("formProduct").getAttribute("action");
    var pid = window.location.href.split('/').splice(-1);
    if (!isNaN(parseInt(pid[0]))) {
        formdataformpage.append("productId", productId.value);

    }

    var files = $("#ProductImage").get(0).files;
    formdataformpage.append("showImg", showImg.value)
    formdataformpage.append("CategoryId", dropCatId.value);
    formdataformpage.append("subCatId", dropsubCatId.value);
    formdataformpage.append("thirdCatId", dropThirdcatId.value);
    formdataformpage.append("ProductName", ProductName.value);
    formdataformpage.append("ProductPrice", ProductPrice.value);
    formdataformpage.append("Color", Color.value);
    formdataformpage.append("Discription", Discription.value);
    formdataformpage.append("ProductImage", files[0]);
    $.ajax({
        type: 'POST',
        url: '/api/categoryMasterAPI/insertUpdateProductMaster',
        data: formdataformpage,
        cache: false,
        contentType: false,
        processData: false,
        success: function (retdata) {
            debugger;
            if (parseInt(retdata) > 0) {
                window.location.href = '/admin/productList';

            }

        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        },
        error: function (data) {
            console.log(data);
        }

    });
});


