<script>
  import DeleteResource from "./delete/delete-resource.svelte";
  import EditResource from "./edit/edit-resource.svelte";
  import ResourceCard from "./resource-card.svelte";

  export let imageDataList = [];
  export let refesh;
  let isShowEdit = false;
  let isShowDelete = false;
  let currentImageData = {};

  function onEdit(data) {
    console.log(data);
    isShowEdit = true;
    currentImageData = data;
  }

  function onDelete(data) {
    console.log(data);
    isShowDelete = true;
    currentImageData = data;
  }
</script>

{#each imageDataList as data}
  <ResourceCard {data} {onEdit} {onDelete} />
{/each}

<EditResource bind:isOpen={isShowEdit} data={currentImageData} {refesh}/>
<DeleteResource bind:isOpen={isShowDelete} data={currentImageData} {refesh}/>
