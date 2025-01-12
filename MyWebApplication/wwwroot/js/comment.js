
$(document).ready(function () {
    console.log("Script yüklendi");
    const form = $("#commentForm");
    const submitButton = $("#submitComment");

    if (form.length === 0) {
        console.error("Comment form not found");
        return;
    }

    submitButton.click(function () {
        const formData = new FormData(form[0]);

        $.ajax({
            url: '/Comment/AddComment',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            beforeSend: function () {
                submitButton.prop('disabled', true);
            },
            success: function (response) {

                $('#commentList').prepend(response);

                $.get('/Comment/GetCommentsComponent', {
                    gameId: formData.get('GameId')
                }, function (result) {
                    $('#commentsComponent').html(result);
                    form[0].reset();
                });
            },
            error: function (xhr) {
                if (xhr.status === 401) {
                    alert("Bu işlem için giriş yapmalısınız!");
                }
                console.error(xhr.responseText);
            },
            complete: function () {
                submitButton.prop('disabled', false);
            }
        });
    });
});