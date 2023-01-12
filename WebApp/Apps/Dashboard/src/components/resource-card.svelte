<script>
  export let onEdit;
  export let onDelete;
  export let model;

  let thumbnai = `data:image/jpeg;base64,${model}`;
  let showButtons = false;
</script>

<div
  class="image-container"
  on:mouseenter={() => (showButtons = true)}
  on:mouseleave={() => (showButtons = false)}
>
  <img src={thumbnai} alt="" style="position: relative;" />
  {#if showButtons}
    <div class="button-group">
      <button on:click={onEdit}>Edit</button>
      <button on:click={onDelete}>Delete</button>
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
    bottom: 0;
    right: 0;
  }
</style>
