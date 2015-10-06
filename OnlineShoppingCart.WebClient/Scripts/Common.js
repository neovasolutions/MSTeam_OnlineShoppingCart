$(document).ready(function () {
    $('#category').on('click', function () {
        if ($('#cssmenu').css('display') == 'none') {
            $('#cssmenu').show();
        }
        else
            $('#cssmenu').hide();
    });

});

//$(document).ready(function () {
//function hideMenu()
//{
//    $('#cssmenu').hide();
//}
var isImageValid = false;
var proID;
function testImageType() {
    $("#fuIMGAdd1").change(function () {
        var file = this.files[0];
        fileName = file.name;
        size = file.size;
        type = file.type;
        if (type.toLowerCase() == "image/png" || type.toLowerCase() == "image/jpeg") {
            $("#txtuploadedMsgAdd").text("Uploaded");
            isImageValid = true;
        }
        else {
            $("#txtuploadedMsgAdd").text("Error: Please select image file (png,jpeg,bmp).");
            isImageValid = false;
        }
    });
}

//});

function onChange(arg) {
    var grid = $("#allProductsListGrid").data("kendoGrid");
    var selectedItem = grid.dataItem(grid.select());
    proID = selectedItem.ID
}

function LoadProductNew() {
    $("#divMessage").text("");
    $.ajax({
        url: "/Product/GetProductEntryForm",
        type: "GET",
        data: null,
        success: function (responseData) {
            $("#div_ProdListPage").html(responseData);
        },
        error: renderErrorMessage

    });
}

function LoadProductEdit() {
    $("#divMessage").text("");
    if (proID == "" || proID == null || proID == undefined) {
        alert("Please select Product to Edit !");
        return;
    }
    $.ajax({
        url: "/Product/GetProduct?proID=" + proID,
        type: "GET",
        success: function (responseData) {
            $("#div_ProdListPage").html(responseData);
            proID = null;
        },
        error: renderErrorMessage

    });
}

function InsertProduct() {

    if (!$("#productForm").kendoValidator().data("kendoValidator").validate()) {
        return;
    }
        // if (isImageValid) {

    else {
        var formData = new FormData($('#productForm')[0]);
        $.ajax({
            url: 'Product/InsertProduct',  //Server script to process data
            type: 'POST',
            data: formData,
            success: function (responseData) {
                var completeMessage = responseData.Message;
                if (responseData.Success == true) {
                    $("#divMessage").html(completeMessage);
                    CallGetPartial();
                }
                else {
                    $("#divMessage").html(completeMessage);
                }
            },
            //Options to tell jQuery not to process data or worry about content-type.
            cache: false,
            contentType: false,
            processData: false,
            error: renderErrorMessage
        });
    }
    //}

}

function UpdateProduct() {
    
    if (!$("#productForm").kendoValidator().data("kendoValidator").validate()) {
        return;
    }
    else {
        //if (isImageValid) {
        var formData = new FormData($('#productForm')[0]);
        $.ajax({
            url: 'Product/UpdateProduct',  //Server script to process data
            type: 'POST',
            data: formData,
            success: function (responseData) {
                var completeMessage = responseData.Message;
                if (responseData.Success == true) {
                    $("#divMessage").html(completeMessage);
                    CallGetPartial();
                }
                else {
                    $("#divMessage").html(completeMessage);
                }
            },
            //Options to tell jQuery not to process data or worry about content-type.
            cache: false,
            contentType: false,
            processData: false,
            error: renderErrorMessage
        });
    }
    //}
}

function DeleteProduct() {
    if (proID == "" || proID == null || proID == undefined) {
        alert("Please select Product to Delete.");
        return;
    }
    else if (confirm("Are you sure? You want to delete a Product")) {
        $.ajax({
            type: "POST",
            url: "Product/DeleteProduct?proID=" + proID,
            data: null,
            success: function (responseData) {
                var completeMessage = responseData.Message;
                if (responseData.Success == true) {
                    $("#divMessage").html(completeMessage);
                    CallGetPartial();
                }
                else {
                    $("#divMessage").html(completeMessage);
                }
            },
            error: renderErrorMessage

        });
    }
}

//function SearchProduct() {
//    $.ajax({
//        type: "POST",
//        url: "Product/SearchProduct",
//        data: $("#productSearchForm").serialize(),
//        success: function (responseData) {
//            var completeMessage = responseData.Message;
//            if (responseData.Success == true) {
//                //$("#divDeletedMessage").html(completeMessage);
//                CallGetPartial();
//            }
//            else {
//                //$("#divDeletedMessage").html(completeMessage);
//            }
//        },
//        error: renderErrorMessage

//    });
//}

function SearchProduct() {
    $('#allProductsListGrid').data('kendoGrid').dataSource.read()

}
function ClearSearchParams()
{
    $("#productCode").val("");
    $("#productName").val("");
    $("#productDescription").val("");
    var dropdownlist = $("#CategoryID").data("kendoDropDownList");
    dropdownlist.select(0);
    $("#brand").val("");
    $("#model").val("");
}



function AddNewProductCategory()
{
    $.ajax({
        type: "GET",
        url: "Product/GetProductCategoryForm",
        data: null,
        success: function (response) {
            $("#div_ProdListPage").html(response);
        },
        error: renderErrorMessage

    });
}
function AddCategory()
{
    var formData = new FormData($('#prodCategory')[0]);
    $.ajax({
        type: "POST",
        url: "Product/AddCategory",
        data: formData,
        success: function (response) {
            var completeMessage = response.Message;
            if (response.Success == true)
                CallGetPartial();
            else            
                $("#divCatErrorMessage").html(completeMessage);            
        },
        cache: false,
        contentType: false,
        processData: false,
        error: renderErrorMessage

    });
}

function CallGetPartial() {
    $.ajax({
        type: "GET",
        url: "Product/LoadProductListGridPartialView",
        data: null,
        success: function (response) {
            $("#div_ProdListPage").html(response);
        },
        error: renderErrorMessage

    });
}

function renderErrorMessage() {
    hideLoader();
    var dv = $('#dvError');
    //var ErrortMessage;
    console.log("Error: in renderErrorMessage() ");
    dv.html(ErrorMessage);
}





