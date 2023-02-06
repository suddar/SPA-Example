<script>
  import { onMount } from "svelte";
  import ResourceManager from "../../components/resource/resource-manager.svelte";
  import { Pagination, PaginationItem, PaginationLink } from "sveltestrap";

  var hostName = "https://localhost:6060";
  let images = [];

  onMount(async () => {
    //https://localhost:6060/resource/2
    const pageTotal = await fetch("https://localhost:6060/resource/2");
    const response = await fetch(`${hostName}/Resource?pageIndex=1&size=3`);
    images = await response.json();
    let count = await pageTotal.json();
    console.log(images[0]);
    console.log(count);
  });
</script>

<ResourceManager imageList={images} />

<Pagination ariaLabel="Page navigation example">
  <PaginationItem disabled>
    <PaginationLink first href="#" />
  </PaginationItem>
  <PaginationItem disabled>
    <PaginationLink previous href="#" />
  </PaginationItem>
  <PaginationLink href="#">1</PaginationLink>
  <PaginationItem>
    <PaginationLink href="#">2</PaginationLink>
  </PaginationItem>
  <PaginationItem>
    <PaginationLink href="#">3</PaginationLink>
  </PaginationItem>
</Pagination>

<!-- {
  "fileName": null,
  "filePath": "/images/b69127a3-d0ed-4344-9978-55a6189e3ccf.jpg",
  "contentType": "image/jpeg",
  "thumbnai": ""
  "data": null,
  "id": 8,
  "name": "1.jpg"
} -->
