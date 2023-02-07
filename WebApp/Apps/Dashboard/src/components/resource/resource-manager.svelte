<script>
  import EditResource from "./edit/edit-resource.svelte";
  import ResourceCard from "./resource-card.svelte";

  export let imageList = [];
  let showEdit = false;
  let currentImageData = {};
</script>

{#each imageList as imageData}
  <ResourceCard
    data={imageData}
    onEdit={() => {
      showEdit = true;
      currentImageData = imageData;
    }}
    onDelete={() => {}}
  />
{/each}

<EditResource bind:isShow={showEdit} resourceName={currentImageData.name} />
