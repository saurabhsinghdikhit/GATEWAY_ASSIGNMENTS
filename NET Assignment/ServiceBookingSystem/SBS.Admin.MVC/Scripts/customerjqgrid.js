$(function () {
    debugger;
    $("#grid").jqGrid
        ({
            url: "/Admin/getCustomers",
            datatype: 'json',
            mtype: 'Get',
            //table header name   
            colNames: ['Id', 'Name', 'Address', 'City', 'State', 'Zipcode', 'Email', 'Mobile', 'Password', 'Confirm Password', 'Question', 'Answer'],
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
                    name: 'Address',
                    index: 'Address',
                    editable: true
                }, {
                    key: false,
                    name: 'City',
                    index: 'City',
                    editable: true
                }, {
                    key: false,
                    name: 'State',
                    index: 'State',
                    editable: true
                }, {
                    key: false,
                    name: 'Zipcode',
                    index: 'Zipcode',
                    editable: true
                }, {
                    key: false,
                    name: 'Email',
                    index: 'Email',
                    editable: true
                }, {
                    key: false,
                    name: 'Mobile',
                    index: 'Mobile',
                    editable: true
                }, {
                    key: false,
                    name: 'Password',
                    index: 'Password',
                    edittype: "password",
                    editable: true
                }, {
                    key: false,
                    name: 'ConfirmPassword',
                    index: 'ConfirmPassword',
                    edittype: "password",
                    editable: true
                }, {
                    key: false,
                    name: 'Question',
                    index: 'Question',
                    editable: true,
                    edittype: "select",
                    editoptions: {
                        value: "first pet name?:first pet name?;first School?:first School?;Where parent meet?:Where parent meet?"
                    }
                }, {
                    key: false,
                    name: 'Answer',
                    index: 'Answer',
                    editable: true
                }],

            pager: jQuery('#pager'),
            rowNum: 10,
            rowList: [10, 20, 30, 40],
            height: '100%',
            viewrecords: true,
            caption: 'Customer Records',
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
                url: '/Admin/EditCustomer',
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
                url: "/Admin/CreateCustomer",
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
                url: "/Admin/DeleteCustomer",
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