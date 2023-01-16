<script>
  import { onMount } from "svelte";
  import EditResource from "../../components/edit-resource.svelte";
  import ResourceCard from "../../components/resource-card.svelte";

  var hostName = "https://localhost:6060";
  let images = [];

  onMount(async () => {
    const response = await fetch(`${hostName}/api/Resources/GetResources`);
    images = await response.json();
    console.log(images[0]);
  });

  var showEdit = false;
  var currentImageData = {};
</script>

{#each images as imageData}
  <ResourceCard
    model={imageData.thumbnai}
    onEdit={() => {
      showEdit = true;
      currentImageData = imageData;
    }}
  />
{/each}

<EditResource bind:isShow={showEdit} resourceName={currentImageData.name} />

<!-- {
  "fileName": null,
  "filePath": "/images/b69127a3-d0ed-4344-9978-55a6189e3ccf.jpg",
  "contentType": "image/jpeg",
  "thumbnai": ""
  "data": null,
  "id": 8,
  "name": "1.jpg"
} -->