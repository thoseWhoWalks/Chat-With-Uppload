var notificationBlock;

let submitBtn = $("#submitBtn");
let licences = $("#licences");
var formContainer = $(".form");

function showError(errorMessage, element) {
    let msg = $(".notification");
    if (msg.length > 0)
        return;
    element.parent().after(notificationBlock);
    notificationBlock.text(errorMessage);
}
  
$(function () {
    formValidationSubscription();
    let emailLogin = $("#emailLogin");
    let passwordLogin = $("#passwordLogin");
    let modalLoginBtn = $("#modalLogin");
    let closeModalLogin = $("#closeModalLogin");

    keyEventSubscriber(emailLogin);

    keyEventSubscriber(passwordLogin);

});

$(function () {
    submitBtn.addClass("disabled");

    licences.change(function () {
        if ($(this).prop("checked") == true) {
            submitBtn.removeAttr("disabled");
            submitBtn.removeClass("disabled");
        } else
            submitBtn.attr("disabled", "true");
    })
})

function formValidationSubscription() {

    let form = $("#signUpForm");
    var validator = form.validate();
    let fName = $("#firstName");
    let lName = $("#lastName");
    let email = $("#email");
    let password = $("#password");
    let repeatPassword = $("#repeatPassword");

    var avatar = $(".ava");
    var fileDialog = $("#fileDialog");

    fName.on("invalid", function () {
        $(this)[0].setCustomValidity('Only alphbetic chars');
    });

    fName.on("keydown", function () {
        $(this)[0].setCustomValidity('');
    });

    lName.on("invalid", function () {
        $(this)[0].setCustomValidity('Only alphbetic chars');
    });

    lName.on("keydown", function () {
        $(this)[0].setCustomValidity('');
    });

    password.on("invalid", function () {
        $(this)[0].setCustomValidity('Password mast conntain at least 6 characters');

    });

    password.on("keydown", function () {
        $(this)[0].setCustomValidity('');
    });

    form.submit(function (e) {
        notificationBlock = $("<div></div>").addClass("offset-lg-3 col-lg-2 notification d-flex align-items-center").hide();
        postFormAjax($(this));

        var fd = document.getElementById("fileDialog");

        var formdata = new FormData();

        formdata.append(fd.files[0].name, fd.files[0]);

        $.ajax({
            url: 'Image/Uppload',
            method: "post",
            data: formdata
        });

        if (emailUniqueCheck() && paswordValidation()) {
            e.preventDefault();
            form.reset();
            return;
        }
        e.preventDefault();
    })

    function paswordValidation() {
        if (currentUser != null)
            if (password.val() != currentUser.Password) {
                showError("Current password is incorrect.", repeatPassword);
                return false;
            }
        else if (password.val() != repeatPassword.val()) {
            showError("Passwords differ.", repeatPassword);
            return false;
        }
        return true;
    }

    function emailExistsError(email) {
        showError("E-mail exists in database.", email);
        return false;
    }

    function emailUniqueCheck() {
        if (currentUser != null)
            for (let i = 0; i < userData.length; i++) {
                if (userData[i]["Email"] == email.val() && userData[i].Id != currentUser.Id) {
                    return emailExistsError(email);
                }
            }
        else
            for (let i = 0; i < userData.length; i++) {
                if (userData[i]["Email"] == email.val()) {
                    return emailExistsError(email);
                }
            }
        return true;
    }

    keyEventSubscriber(email);
    keyEventSubscriber(password);
    keyEventSubscriber(repeatPassword);

    //template
    avatar.click(function () {
        fileDialog.click()
    })

    fileDialog.change(ReadSetImage)

    function ReadSetImage() {
         
        if ($("#fileDialog").prop('files')[0] != undefined) {
            var reader = new FileReader();
            reader.onload = function (e) {
                avatar.children("img")
                    .attr('src', e.target.result)
                    .height(200);
            };
            reader.readAsDataURL($("#fileDialog").prop('files')[0]);
        }
        
     }

}

function keyEventSubscriber(element) {
    element.keyup(function () {
        let msg = $(".notification");
        if (msg.length > 0)
            msg.remove();
    });
}
