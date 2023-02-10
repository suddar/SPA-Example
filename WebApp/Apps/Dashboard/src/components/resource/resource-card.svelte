<script>
  import { hostName } from "../../scripts/store";

  export let onEdit;
  export let onDelete;
  export let data;
  let showButtons = false;
</script>

<div
  class="image-container"
  on:mouseenter={() => (showButtons = true)}
  on:mouseleave={() => (showButtons = false)}
>
  <img src={hostName + data.thumbnailPath} alt="" style="position: relative;" />
  {#if showButtons}
    <div class="button-group">
      <i
        class="fa-sharp fa-solid fa-square-pen"
        style="font-size: 26px; color:white;"
        on:mouseup={() => onEdit(data)}
      />
      <i
        class="fa-solid fa-trash"
        style="font-size: 26px; color:white;"
        on:mouseup={() => onDelete(data)}
      />
    </div>
  {/if}
</div>

<style>
  .image-container {
    position: relative;
    display: inline-block;
    background-color: antiquewhite;
  }
  .button-group {
    position: absolute;
    bottom: 6px;
    right: 6px;
    cursor: pointer;
  }
</style>
