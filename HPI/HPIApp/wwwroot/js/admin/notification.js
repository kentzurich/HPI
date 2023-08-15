var connectionNotification = new signalR
    .HubConnectionBuilder()
    .withUrl("/hubs/notification", signalR.HttpTransportType.ServerSentEvents)
    .build();

connectionNotification.on("LoadNotification", function (messages, counter) {
    document.getElementById("notificationList").innerHTML = "";
    var notificationCounter = document.getElementById("notificationCounter");
    notificationCounter.innerHTML = counter;

    for (let x = messages.length - 1; x >= 0; x--) {
        let message = messages.length > 50 ? messages[x] + "..." : messages[x];

        $('#notificationList').append(`<li class="notification-item">
                                            <i class="bi bi-info-circle text-primary"></i>
                                            <div>
                                                <h4>New message</h4>
                                                <p>${message}</p>
                                            </div>
                                        </li>
                                        <li>
                                            <hr class="dropdown-divider">
                                        </li>`);
    }
});

connectionNotification.on("newMessageNotification", () => {
    toastr.success(`New message arrived. Please see notification.`);
});

connectionNotification.start().then(function () {
    connectionNotification.send("LoadMessages");
});