<script>
  import { Router } from "@roxi/routify";
  import { routes } from "../.routify/routes";
</script>

<svelte:head>
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css">
</svelte:head>

<Router {routes} />
