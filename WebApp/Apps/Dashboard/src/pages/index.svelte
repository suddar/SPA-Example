<script>
  import { metatags } from "@roxi/routify";

  metatags.title = "My Routify app";
  metatags.description = "Description coming soon...";
  let file;

  import axios from "axios";
  import { hostName } from "../scripts/store";

  function postFile() {
    console.log(file);

    const formData = new FormData();
    formData.append("file", file);

    axios
      .post(`${hostName}resource/test`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((response) => {
        console.log(response.data);
      })
      .catch((error) => {
        console.log(error);
      });
  }
</script>

<input type="file" bind:value={file} />
<button on:click={postFile}>submit</button>

<h1>Routify Starter Template</h1>

<p>
  To see an example app that shows off a lot of Routify's features, go to <a
    href="/example">/example</a
  >
</p>

<p>
  This template is ready to be used in production! just delete the example app
  at: src/pages/example
</p>
