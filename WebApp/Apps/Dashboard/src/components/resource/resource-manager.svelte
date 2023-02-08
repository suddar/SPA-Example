<script>
  import DeleteResource from "./delete/delete-resource.svelte";
  import EditResource from "./edit/edit-resource.svelte";
  import ResourceCard from "./resource-card.svelte";

  export let imageList = [];
  let isShowEdit = false;
  let isShowDelete = false;
  let currentImageData = {};
</script>

{#each imageList as imageData}
  <ResourceCard
    data={imageData}
    onEdit={() => {
      isShowEdit = true;
      currentImageData = imageData;
    }}
    onDelete={() => {
      isShowDelete = true;
    }}
  />
{/each}

<EditResource bind:isOpen={isShowEdit} resourceName={currentImageData.name} />
<DeleteResource
  bind:isOpen={isShowDelete}
  resourceName={currentImageData.name}
/>
