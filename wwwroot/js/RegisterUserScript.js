$(function () {
    //Regestration Ckeck Box
    $("#UserRegisterModel input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);
    $("#UserRegisterModel button[name = 'register']").prop("disabled", true);

    function onAcceptUserAgreementClick()
    {
        if ($(this).is(":checked")) {
            $("#UserRegisterModel button[name = 'register']").prop("disabled", false);
        } else {
            $("#UserRegisterModel button[name = 'register']").prop("disabled", true);
        }
    }
    // Check if the Email Is Exist
    $("#UserRegisterModel input[name = 'Email']").blur(function () {
        var email = $("#UserRegisterModel input[name = 'Email']").val();
        var url = "UserAuth/UserNameExist?userName=" + email;
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                if (data == true) {
                    var alertHtml = '<div class="alert alert-warning alert-dismissible fade show" role="alert">' +
                        '<strong>Invalid Email</strong><br>This Email Address Is Exist<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close">' +
                        '</button>' +
                        '</div>';
                    $("#alert_placeholder_register").html(alertHtml);
                } else {
                    $("#alert_placeholder_register").html("");
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {                
                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }
        });
    });
    var registerUserButton = $("#UserRegisterModel button[name = 'register']").click(onUserRegisterClick);



    function onUserRegisterClick() {
        var url = "UserAuth/RegisterUser";

        var antiForgeryToken = $("#UserRegisterModel input[name='__RequestVerificationToken']").val();
        var email = $("#UserRegisterModel input[name='Email']").val();
        var password = $("#UserRegisterModel input[name='Password']").val();
        var confirmPassword = $("#UserRegisterModel input[name='ConfirmPassword']").val();
        var firstName = $("#UserRegisterModel input[name='FirstName']").val();
        var lastName = $("#UserRegisterModel input[name='LastName']").val();
        var address1 = $("#UserRegisterModel input[name='Address1']").val();
        var address2 = $("#UserRegisterModel input[name='Address2']").val();
        var postCode = $("#UserRegisterModel input[name='PostCode']").val();
        var phoneNumber = $("#UserRegisterModel input[name='PhoneNumber']").val();
        //var categoryId = $("#UserRegisterModel input[name='CategoryId']").val();

        var user = {
            __RequestVerificationToken: antiForgeryToken,
            Email: email,
            Password: password,
            ConfirmPassword: confirmPassword,
            FirstName: firstName,
            LastName: lastName,
            Address1: address1,
            Address2: address2,
            PostCode: postCode,
            PhoneNumber: phoneNumber,
            AcceptUserAgreement: true,
            //CategoryId: categoryId
        };

        $.ajax({
            type: "POST",
            url: url,
            data: user,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='RegistrationInValid']").val() == 'true';

                if (hasErrors) {

                    $("#UserRegisterModel").html(data);
                    var registerUserButton = $("#UserRegisterModel button[name = 'register']").click(onUserRegisterClick);
                    //$("#UserRegisterModel input[name = 'AcceptUserAgreement']").click(onAcceptUserAgreementClick);

                    $("#UserRegistrationForm").removeData("validator");
                    $("#UserRegistrationForm").removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse("#UserRegistrationForm");
                }
                else {
                    location.href = '/Home/Index';
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(errorText);
                //PresentClosableBootstrapAlert("#alert_placeholder_register", "danger", "Error!", errorText);

                console.error(thrownError + '\r\n' + xhr.statusText + '\r\n' + xhr.responseText);
            }

        });

    }

});