<script>
  import { onMount } from "svelte";
  import EditResource from "../../components/edit-resource.svelte";
  import ResourceCard from "../../components/resource-card.svelte";

  var hostName = "https://localhost:6060";
  let images = [];

  onMount(async () => {
    const response = await fetch(`${hostName}/api/Resources/GetResources`);
    images = await response.json();
  });

  function showAlert() {}
</script>

{#each images as image}
  <ResourceCard bind:model={image.thumbnai} onEdit={showAlert} />
{/each}

<EditResource />
