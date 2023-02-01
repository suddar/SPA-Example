<script>
  import EditResource from "./edit/edit-resource.svelte";
  import ResourceCard from "./resource-card.svelte";

  let imageList = [];
  let showEdit = false;
  let currentImageData = {};
</script>

{#each imageList as imageData}
  <ResourceCard
    data={imageData.thumbnai}
    onEdit={() => {
      showEdit = true;
      currentImageData = imageData;
    }}
  />
{/each}

<EditResource bind:isShow={showEdit} resourceName={currentImageData.name} />
