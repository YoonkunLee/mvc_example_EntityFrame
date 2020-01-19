var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ForwardToClients", (user, message) => {
    const msg = message.replace(/&/g, "&amp").replace(/</g, "&alt").replace(/>/g, "&gt;");
    const encoding = user + " says: " + msg;
    const li = documents.createElement("li");
    li.textContent = encoding;
    document.getElementById("#messagesList").appendChild(li);
});

connection.start().catch(er => console.log(er.toString()));

document.getElementById("#sendButton").addEventListener(click, event => {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").Value;

    connection.invoke("SendMessage", user, message).catch(er => console.log(er.toString()));
    event.preventDefault();
});