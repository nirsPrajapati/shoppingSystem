
//var Categories = new Array({
//    catgory: new Array(),
//    subcat: new Array()
//});

var Categories = new Array();

$(document).ready(function () {

    //getCategory();
    //getSubCategory();
    //hii();
    DaynamicNavbar();

    UserName();
    getAddtocart();
    getAddtoCartCount();

});


function openWishlist() {
    document.getElementById("Wishlist").style.display = "block";
    getAddtocart();
    getAddtoCartCount();
}
function closeWishlist() {
    document.getElementById("Wishlist").style.display = "none";
}
function getAddtoCartCount() {
    var uid = sessionStorage.getItem("UserId");

    if (uid>0) {
        $.ajax({
            type: 'GET',
            url: '/api/ClientAPIController/CartMasterCountbyUserId',
            data: { userid: uid },
            success: function (retData) {

                if (parseInt(retData) > 0) {
                    $("#cartcount").html(retData);
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
 
 
}

function getAddtocart()
{
    var uid = sessionStorage.getItem("UserId");
    var price = 0;
    $.ajax({
        type: 'GET',
        url: '/api/ClientAPIController/selectCartMasterByUserId',
        data: { userid: uid},
        success: function (retData) {
            $("#cartId").html("");
            for (var i = 0; i < retData.length; i++) {
        
               
                    price= price + retData[i].ProductPrice;
                $("#cartId").append('<div class="d-flex align-items-center justify-content-between br-bottom px-3 py-3">' +
                     '<div class="cart_single d-flex align-items-center">' +
                         '<div class="cart_selected_single_thumb">' +
                             '<a href="#"><img height="60" width="77" src="' + retData[i].ProductImage.replace("~","") + '" width="60" class="img-fluid" alt="" /></a>' +
                         '</div>' +
                         '<div class="cart_single_caption pl-2">' +
                             '<h4 class="product_title fs-sm ft-medium mb-0 lh-1">' + retData[i].ProductName + '</h4>' +
                             '<p class="mb-2"><span class="text-dark ft-medium small">Quantity:' + retData[i].Quantity + '</span></p>' +
                             '<h4 class="fs-md ft-medium mb-0 lh-1">'+retData[i].ProductPrice+'</h4>' +
                         '</div>' +
                     '</div>' +
                     '<div class="fls_last"><button class="close_slide gray"><i class="ti-close"></i></button></div>' +
                 '</div>'
         );
            }
            
            $("#subTotal").html(price);
     
                
              


        },
        beforeSend: function () {
            $(".pp").fadeIn(600);
        },
        complete: function () {
            $(".pp").fadeOut(600);
        }

    });
}


function UserName()
{
 
    var uid = sessionStorage.getItem("UserId");
    if (uid!=null) {
        $.ajax({
            type: 'GET',
            url: '/api/ClientAPIController/selectUserMasterById',
            data: { userid: uid },
            success: function (retData) {
                $("#userName").html(retData.UserName);
                


            },
            beforeSend: function () {
                $(".pp").fadeIn(600);
            },
            complete: function () {
                $(".pp").fadeOut(600);
            }

        });
    }

}



function DaynamicNavbar() {

    $.ajax({
        type: 'GET',
        url: '/api/ClientAPIController/GetAllCategory',
        data: {},
        success: function (retData) {
        
            console.log(retData);
            for (var i = 0; i < retData.length; i++) {
                var liTagCat = document.createElement("li");
                //ATag Category Start
                var aTagCat = document.createElement("a");
                aTagCat.innerHTML = retData[i].catName;
                liTagCat.appendChild(aTagCat);
                //ATag Category End

                if (retData[i].subcatList.length > 0) {


                    //UlTag SubCategory Start
                    var ulTagSubCat = document.createElement("ul");
                    ulTagSubCat.classList.add("nav-dropdown");
                    ulTagSubCat.classList.add("nav-submenu");

                    for (var j = 0; j < retData[i].subcatList.length; j++) {


                        //LiTag SubCat Start
                        var liTagSubCat = document.createElement("li");
                        //ATag Category Start
                        var aTagSubCat = document.createElement("a");
                        aTagSubCat.innerHTML = retData[i].subcatList[j].subCatName;
                        liTagSubCat.appendChild(aTagSubCat);
                        //ATag Category End



                        if (retData[i].subcatList[j].ThirdCatList.length > 0) {
                            //UlTag ThirdCategory Start
                            var ulTagThirdCat = document.createElement("ul");
                            ulTagThirdCat.classList.add("nav-dropdown");
                            ulTagThirdCat.classList.add("nav-submenu");
                            for (var k = 0; k < retData[i].subcatList[j].ThirdCatList.length; k++) {
                                //LiTag ThCat Start
                                var liTagThirdCat = document.createElement("li");
                                //ATag ThCategory Start
                                var aTagThirdCat = document.createElement("a");
                                aTagThirdCat.innerHTML = retData[i].subcatList[j].ThirdCatList[k].thirdCatName;
                                liTagThirdCat.appendChild(aTagThirdCat);
                                //ATag ThCategory End

                                ulTagThirdCat.appendChild(liTagThirdCat);
                                //LiTag SubCat Start

                            }



                            liTagSubCat.appendChild(ulTagThirdCat);
                            //UlTag ThirdCategory End
                        }



                        ulTagSubCat.appendChild(liTagSubCat);
                        //LiTag SubCat Start
                    }


                    liTagCat.appendChild(ulTagSubCat);
                    //UlTag SubCategory End
                } 





                document.getElementById("DynamicMenu").appendChild(liTagCat);
                //var htmldataaa = $("#DynamicMenu").append('<li><a>' + retData[i].catName + '</a><ul class="nav-dropdown nav-submenu"><li><a>' + data.subCatName + '</a><ul class="nav-dropdown nav-submenu"><li><a>Nirav3</a></li></ul></li></ul></li>');

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




//        console.log(Categories["category"][i]["catName"]);

//    }

//    console.log("To Category Function");
//}

//function getCategory() {
//    $.ajax({
//        type: 'GET',
//        url: '/api/ClientAPIController/selectCategoryMaster',
//        data: {},
//        success: function (retData) {
//            //debugger;
//            //console.log(retData);
//            //for (var i = 0; i < retData.length; i++) {
//            //    $("#DynamicMenu").append('<li><a href="#">' + retData[i].catName + '</a>');

//            //}

//            Categories["category"] = new Array();

//            for (var i = 0; i < retData.length; i++) {

//                Categories["category"].push({
//                    "catId": retData[i].catId,
//                    "catName": retData[i].catName
//                });
//            }

//            console.log("From Category Function");


//            console.log(Categories["category"]);

//            for (var i = 0; i < Categories["category"].length; i++) {
//                console.log(Categories["category"][i]["catId"]);

//                console.log(Categories["category"][i]["catName"]);

//            }

//            console.log("End Category Function");

//            getSubCategory();
//        },
//        beforeSend: function () {
//            $(".pp").fadeIn(600);
//        },
//        complete: function () {
//            $(".pp").fadeOut(600);
//        }

//    });
//}

//function getSubCategory() {

//    console.log("Inseide sub category");



//    //console.log(Categories["category"]);

//    //for (var i = 0; i < Categories.category.length; i++) {
//    //    console.log("nirav");
//    //    console.log(Categories["category"][i]["catId"]);

//    //    console.log(Categories["category"][i]["catName"]);

//    //}

//    try {
//        for (var dataval of Categories["category"]) {
//            console.log(dataval.catId + " , " + dataval.catName);

//            $.ajax({
//                type: 'GET',
//                url: '/api/categoryMasterAPI/selectSubCatMasterByCatId',
//                data: { catId: dataval.catId },
//                success: function (retData) {


//                    for (var i = 0; i < retData.length; i++) {
//                        Categories["Subcategory"] = new Array();

//                        for (var i = 0; i < retData.length; i++) {

//                            Categories["Subcategory"].push({
//                                "subCatId": retData[i].subCatId,
//                                "subCatName": retData[i].subCatName
//                            });
//                        }

//                    }

//                    for (var dataval of Categories["category"]) {

//                        for (var datasubcat of Categories["Subcategory"]) {
//                            $("#DynamicMenu").append('<li><a href="javascript:void(0);">' + dataval.catName + '</a><ul class="nav-dropdown nav-submenu"><li><a href="javascript:void(0);">' + datasubcat.subCatName + '</a><ul class="nav-dropdown nav-submenu"><li><a href="javascript:void(0);">Nirav</a></li></ul<</li></ul><li>');

//                        }
//                    }
//                    //for (var datavalue of Categories["Subcategory"]) {
//                    //    console.log(datavalue.subCatId + " , " + datavalue.subCatName);

//                    //}


//                },
//                beforeSend: function () {
//                    $(".pp").fadeIn(600);
//                },
//                complete: function () {
//                    $(".pp").fadeOut(600);
//                }
//            });




//        }

//        //for (var dataval of Categories["category"]) {
//        //    debugger;
//        //    for (var datasubcat of Categories["Subcategory"]) {
//        //        $("#DynamicMenu").append('<li><a href="javascript:void(0);">' + dataval.catName + '</a><ul class="nav-dropdown nav-submenu"><li><a>' + datasubcat.subCatName + '</a><ul class="nav-dropdown nav-submenu"><li><a>Nirav</a></li></ul<</li></ul><li>');

//        //    }

//        //var htmldataaa = $("#DynamicMenu").append('<li><a>' + dataval.catName + '</a><ul class="nav-dropdown nav-submenu"><li><a>Nirav</a></li></ul></li>');
//            //var dropSubMenu
//            //$("#DynamicMenu").append('<li>' +
//            //  '' + dataval.catName + '' +
//            //+'</li>');
//           // $("#DynamicMenu").append(dropSubMenu);
//        //console.log(htmldataaa);
//            //+'<a href="#">' + dataval.catName + '</a>' +
//            //      +'<ul class="nav-dropdown nav-submenu">' +
//            //          +'<li>' +
//            //              +'<a>Nirav</a>' +
//            //          +'</li>' +
//            //      +'</ul>' +




//    } catch (e) {
//        console.log(e);
//    }




//    //$.ajax({
//    //    type: 'GET',
//    //    url: '/api/categoryMasterAPI/selectSubCategoryMaster',
//    //    data: {},
//    //    success: function (retData) {






//    //    },
//    //    beforeSend: function () {
//    //        $(".pp").fadeIn(600);
//    //    },
//    //    complete: function () {
//    //        $(".pp").fadeOut(600);
//    //    }

//    //});






//    //debugger;





//}


//function thirdCategoryList() {

//    $.ajax({
//        type: 'GET',
//        url: '/api/categoryMasterAPI/selectthirdCategoryMaster',
//        data: {},
//        success: function (retData) {






//        },
//        beforeSend: function () {
//            $(".pp").fadeIn(600);
//        },
//        complete: function () {
//            $(".pp").fadeOut(600);
//        }

//    });
//}
