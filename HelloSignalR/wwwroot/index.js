(async function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/app")
        .build();

    const app = new Vue({
        el: "#app",
        data: {
            messages: [],
            newMessage: null
        },
        methods: {
            async addMessage() {
                await connection.invoke("Send", this.newMessage);
                this.newMessage = null;
            }
        }
    });

    connection.on("Send", message => {
        app.messages.push(message);
    });

    await connection.start();
})();