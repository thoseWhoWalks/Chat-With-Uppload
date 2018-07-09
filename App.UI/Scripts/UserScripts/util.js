$(function () {

    var chatBody = $(".bodyChat");
     
    var chat = $.connection.chat; 

    chat.client.addMessage = function (name, message) {
        // Добавление сообщений на веб-страницу 
        chatBody.append(`<div class="message row"><div class="ui col-lg-1">
                    <div class="avaThumbnail"><img src="../images/noAva.png" alt="avaThumbnail"></div>
                        <div class="senderName">${name}</div>
                        <div class="date">23.05.18</div>
                  </div>
            <div class="messageBody offset-lg-2 col">
                <p>${message}</p>
            </div>
        </div>`);
    };


    $.connection.hub.start().done(function () {

        $('#sendMessage').click(function () {
            chat.server.send($('#messageInput').val());
            $('#messageInput').val('');

        });

        chat.server.connect();
    });
 
}); 