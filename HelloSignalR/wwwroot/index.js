(async function () {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/app")
        .build();

    const app = new Vue({
        el: "#app",
        data: {
            messages: [],
            logs: [],
            newMessage: null,
            registered: false,
            username: null,
        },
        methods: {
            async addMessage() {
                await connection.invoke("Send", app.newMessage);
                app.newMessage = null;
            },
            
            async register() {
                await connection.invoke("Register", app.username);
            },
            
            async unregister() {
                await connection.invoke("UnRegister");
            },
        }
    });

    connection.on("Send", message => {
        app.messages.push(message);
    });
    
    connection.on("RespondToRegister", (error) => {
        if (error != null){
            app.logs.push(error);
        }
    });
    
    connection.on("RespondToUnRegister", (error) => {
        if (error != null){
            app.logs.push(error);
        }
    });

    await connection.start();
})();