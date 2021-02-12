$(function () {
    debugger;
    $("#grid").jqGrid
        ({
            url: "/Admin/getServices",
            datatype: 'json',
            mtype: 'Get',
            //table header name   
            colNames: ['Id', 'Name', 'Price', 'Duration'],
            //colModel takes the data from controller and binds to grid   
            colModel: [
                {
                    key: true,
                    hidden: true,
                    name: 'Id',
                    index: 'Id',
                    editable: true
                }, {
                    key: false,
                    name: 'Name',
                    index: 'Name',
                    editable: true
                }, {
                    key: false,
                    name: 'Price',
                    index: 'Price',
                    editable: true
                }, {
                    key: false,
                    name: 'Duration',
                    index: 'Duration',
                    editable: true
                }],

            pager: jQuery('#pager'),
            rowNum: 10,
            rowList: [10, 20, 30, 40],
            height: '100%',
            viewrecords: true,
            caption: 'Service Records',
            emptyrecords: 'No records to display',
            jsonReader:
            {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: false,
                Id: "0"
            },
            autowidth: true,
            multiselect: false
            //pager-you have to choose here what icons should appear at the bottom  
            //like edit,create,delete icons  
        }).navGrid('#pager',
            {
                edit: true,
                add: true,
                del: true,
                search: false,
                refresh: true
            }, {
            // edit options  
            zIndex: 100,
                url: '/Admin/EditService',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    $(".notification").show();
                    $(".notification").css("padding", "15px");
                    $(".notification").text(response.responseText);
                    $(".notification").delay(5000).fadeOut('slow');
                }
            }
        }, {
            // add options  
            zIndex: 100,
                url: "/Admin/CreateService",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    $(".notification").show();
                    $(".notification").css("padding", "15px");
                    $(".notification").text(response.responseText);
                    $(".notification").delay(5000).fadeOut('slow');
                }
            }
        }, {
            // delete options  
            zIndex: 100,
                url: "/Admin/DeleteService",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete this task?",
            afterComplete: function (response) {
                if (response.responseText) {
                    $(".notification").show();
                    $(".notification").css("padding", "15px");
                    $(".notification").text(response.responseText);
                    $(".notification").delay(5000).fadeOut('slow');
                }
            }
        });
});  