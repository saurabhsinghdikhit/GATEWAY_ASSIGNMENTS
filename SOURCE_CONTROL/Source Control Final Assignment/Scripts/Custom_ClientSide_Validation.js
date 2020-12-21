$("#form").validate({
    rules: {
        Email: "required",
        FirstName: "required",
        LastName: "required",
        Mobile: "required",
        Salary: "required",
        empDOJ: "required",
        employeeImage: "required",
        Password:
        {
            minlength: 6
        },

    },
    messages: {
        Email: "Email is required",
        FirstName: "First Name is required",
        LastName: "Last Name is required",
        Mobile: "Mobile is required",
        Salary: "Salary is required",
        empDOJ: "Employee DOJ is required",
        employeeImage: "Employee Image is required",
        Password: "Please enter atleast 6 digit Password"
    },
}
);
function validate() {
    var email = $("#Email").val();
    var emailreg = new regexp(/^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i);
    var valid = emailreg.test(email);
    if (email == "") {
        $("#div1").text("please enter an email");
    }
    else if (!valid) {
        $("#div1").text(" email is not valid");
    }

    var Phonenumber = $("#Mobile").val();
    var filter = /^[0-9-+]+$/;
    if (!(filter.test(Phonenumber))) {
        $("#div2").text("Please enter valid Phone Number");
    }
}