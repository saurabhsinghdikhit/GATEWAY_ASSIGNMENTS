var id = $('#VehicleId').val();
$.ajax({
    url: "/Admin/getVehicleBrandMake/" + id,
    type: "GET",
    contentType: "application/json; charset=utf-8",
    datatype: JSON,
    success: function (result) {
        $("#vehicleName").val(result);
    },
    error: function (data) { }
});
$(function () {
    $('#btnSearchBrandMechanic').click(function () {
        var searchtext = $('#txtSearchBrandMechanic').val();
        $.ajax({
            url: "/Admin/getMechanicFromBrand?search=" + searchtext,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            datatype: JSON,
            success: function (result) {
                $("#searchmechanicId").empty();
                $("#searchmechanicId").val(result.Id);
                $("#searchmechanicName").empty();
                $("#searchmechanicName").val(result.Name);
            },
            error: function (data) { }
        });
        return false;
    });
});