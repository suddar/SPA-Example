<script>
  import { onMount } from "svelte";
  import ResourceCardList from "../../components/resource/resource-card-list.svelte";
  import Paging from "../../components/ui/paging.svelte";
  import { hostName } from "../../scripts/store";

  let imageDataList = [];
  let pageTotal;
  let pageSize = 3;
  let currentPage;

  onMount(async () => {
    // get page total by count
    const pageTotalResponse = await fetch(`${hostName}Resource/${pageSize}`);
    pageTotal = await pageTotalResponse.json();

    await onLoadPage(1);
  });

  // get image data list
  async function getImageList(index, size) {
    const resourceResponse = await fetch(
      `${hostName}Resource?pageIndex=${index}&size=${size}`
    );
    return await resourceResponse.json();
  }

  async function onLoadPage(index) {
    currentPage = index;
    imageDataList = await getImageList(index, pageSize);
    console.log(imageDataList[0]);
  }

  async function refesh() {
    const pageTotalResponse = await fetch(`${hostName}Resource/${pageSize}`);
    pageTotal = await pageTotalResponse.json();
    onLoadPage(currentPage);
  }
</script>

<ResourceCardList bind:imageDataList {refesh} />
<Paging bind:pageTotal {onLoadPage} />
