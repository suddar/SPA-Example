<script>
  import { Router } from "@roxi/routify";
  import { routes } from "../.routify/routes";

  import { provide } from "svelte";
  const myValue = "Hello, World!";
  provide("myValue", myValue);

</script>

<Router {routes} />
