
    var id = $('#CreatedBy').val();
        $.ajax({
        url: "/Admin/VehicleDropdown/" + id,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            datatype: JSON,
            success: function (result) {
        $("#VehicleId").empty();
                $(result).each(function () {
        $("#VehicleId").append($("<option></option>").val(this.Id).html(this.Model));
                });
            },
            error: function (data) { }
        });
        $('#CreatedBy').change(function () {
            var id = $(this).val();
            $.ajax({
        url: "/Admin/VehicleDropdown/" + id,
                type: "GET",
                contentType: "application/json; charset=utf-8",
                datatype: JSON,
                success: function (result) {
        $("#VehicleId").empty();
                    $(result).each(function () {
        $("#VehicleId").append($("<option></option>").val(this.Id).html(this.Model));
                    });
                },
                error: function (data) { }
            });
        });