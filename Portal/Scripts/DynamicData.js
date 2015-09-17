var updateList = $('#nt-example1');
$.ajax({
    type: "GET",
    url: "http://localhost:1781/api/FetchUpdates/AllLTUpdates",
    contentType: "application/json;charset=utf-8",
    dataType: "json",

    success: function (result) {
        $.each(result, function (index, element) {

            var entry = "<li><b>Title:</b>" + element.Title + "  <b>Created By:</b>" + element.CreatedBy + "</li>";
            updateList.append(entry);
        });
    },
    error: function (msg) {
        alert(msg);
    }

});


var ltupdateimage = $('#LTUpdateImage');
var lt1 = $('#smallTile1');
var lt2 = $('#smallTile2');

$.ajax({
    type: "GET",
    url: "http://localhost:1781/api/Azure/GetBlob/",
    contentType: "application/json;charset=utf-8",
    dataType: "json",
    success: function (result) {
        $.each(result, function (index, element) {
            ltupdateimage.attr("src", element);
            lt1.attr("src", element);
            lt2.attr("src", element);
            setTimeout(function () {
                alert(element);
                
            }, 3000);
        });



    },
    error: function (msg) {
        alert("Images not loaded!");
    }
});
