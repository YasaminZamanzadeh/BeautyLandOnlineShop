var connection = new signalR.HubConnectionBuilder()
    .withUrl("/GuestUserOnline")
    .build();

connection.start();