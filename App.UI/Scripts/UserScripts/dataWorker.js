
function postFormAjax(form) {
    var serializedData = form.serialize();

    var inputs = form.find("input, select, button, textarea");

    inputs.prop("disabled", true);

    request = $.ajax({
        url: 'Post',
        method: "post",
        data: serializedData
    });

    request.always(function () {
        inputs.prop("disabled", false);
    });
}
 

function putFormAjax(form) {
    var serializedData = form.serialize();

    var inputs = form.find("input, select, button, textarea");

    inputs.prop("disabled", true);

    $.ajax({
        url: '@(Url.Action("Post", "Home"))',
        type: "put",
        data: serializedData
    });

    request.always(function () {
        inputs.prop("disabled", false);
    });
}
