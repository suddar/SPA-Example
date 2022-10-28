<script>
    import { redirect } from "@roxi/routify";
    import sendCommand from "../../services/command-sender";
    var res;
    var msg;
    async function sayHello() {
        var command = {
            name: "CreateTopic",
        };

        res = await sendCommand(command);
        console.log(res);
        msg = res.message;
        //$redirect("/maps");
    }
</script>

<p>Message: {msg || "nothing"}!</p>

<button on:mouseup={sayHello}> Send </button>
