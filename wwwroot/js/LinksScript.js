$(function () {

    var userLinksButton = $("#UserLinksModel button[name='save']").click(onUserLinksClick);

    /* start Disable the button if all input fields is empty*/

    $("#UserLinksModel button[name = 'save']").prop("disabled", true);
    var textFields = $("#UserLinksModel input[type = 'text']");
    textFields.on('input', function () {
        var isAnyFieldNoEmpty = false;
        textFields.each(function () {
            if ($(this).val().trim() !== '') {
                isAnyFieldNoEmpty = true;
            }
        })
        if (isAnyFieldNoEmpty) {
            $("#UserLinksModel button[name = 'save']").prop("disabled", false);
        } else {
            $("#UserLinksModel button[name = 'save']").prop("disabled", true);
        }
    })
    
     /* end Disable the button if all input fields is empty*/

    function onUserLinksClick() {

        var url = "/Profile/AddLinks";

        var antiForgeryToken = $("#UserLinksModel input[name='__RequestVerificationToken']").val();

        var website       = $("#UserLinksModel input[name = 'Website']").val();
        var linkedin      = $("#UserLinksModel input[name = 'LinkedIn']").val();
        var stackoverflow = $("#UserLinksModel input[name = 'StackoverFlow']").val();
        var github        = $("#UserLinksModel input[name = 'Github']").val();
        var facebook      = $("#UserLinksModel input[name = 'Facebook']").val();
        var twitter       = $("#UserLinksModel input[name = 'Twitter']").val();

        var userInput = {
            __RequestVerificationToken: antiForgeryToken,
            Website: website,      
            LinkedIn: linkedin,     
            StackoverFlow: stackoverflow,
            Github: github,       
            Facebook: facebook,     
            Twitter: twitter,      
        };

        $.ajax({
            type: "POST",
            url: url,
            data: userInput,
            success: function (data) {

                var parsed = $.parseHTML(data);

                var hasErrors = $(parsed).find("input[name='LinkesInValid']").val() == "true";

                if (hasErrors == true) {
                    $("#UserLinksModel").html(data);

                    userLinksButton = $("#UserLinksModel button[name='save']").click(onUserLinksClick);

                    var form = $("#UserLinkForm");

                    $(form).removeData("validator");
                    $(form).removeData("unobtrusiveValidation");
                    $.validator.unobtrusive.parse(form);

                }
                else {
                    location.href = '/Profile/Index';
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var errorText = "Status: " + xhr.status + " - " + xhr.statusText;
                console.error(errorText);
                //PresentClosableBootstrapAlert("#alert_placeholder_login", "danger", "Error!", errorText);

                console.error(thrownError + "\r\n" + xhr.statusText + "\r\n" + xhr.responseText);
            }
        });
    }
    
});