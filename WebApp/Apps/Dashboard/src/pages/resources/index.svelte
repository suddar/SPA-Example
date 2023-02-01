<script>
  import { onMount } from "svelte";
  import ResourceManager from "../../components/resource/resource-manager.svelte";

  var hostName = "https://localhost:6060";
  let images = [];

  onMount(async () => {
    const response = await fetch(`${hostName}/api/Resources/GetResources`);
    images = await response.json();
    console.log(images[0]);
  });
</script>

<ResourceManager imageList={images} />

<!-- {
  "fileName": null,
  "filePath": "/images/b69127a3-d0ed-4344-9978-55a6189e3ccf.jpg",
  "contentType": "image/jpeg",
  "thumbnai": ""
  "data": null,
  "id": 8,
  "name": "1.jpg"
} -->
