<script>
  import { onMount } from "svelte";
  import ResourceManager from "../../components/resource/resource-manager.svelte";
  import Paging from "../../components/ui/paging.svelte";
  import { hostName } from "../../scripts/store";

  let imageDataList = [];
  let pageTotal;
  let pageSize = 3;

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
    imageDataList = await getImageList(index, pageSize);
    console.log(imageDataList[0]);
  }
</script>

<ResourceManager imageList={imageDataList} />
<Paging {pageTotal} loadData={onLoadPage} />
