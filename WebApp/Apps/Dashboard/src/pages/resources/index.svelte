<script>
  import { onMount } from "svelte";
  import ResourceCard from "../../components/resource-card.svelte";

  var hostName = "https://localhost:6060";
  let images = [];

  onMount(async () => {
    const response = await fetch(`${hostName}/api/Resources/GetResources`);
    images = await response.json();
  });
</script>

{#each images as image}
  <ResourceCard bind:model={image.thumbnai} />
{/each}
