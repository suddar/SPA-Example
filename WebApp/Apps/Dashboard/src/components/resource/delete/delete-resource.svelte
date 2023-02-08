<script>
  import ModalContent from "../../modal/modal-content.svelte";
  import ModalOverlay from "../../modal/modal-overlay.svelte";

  export let isOpen = false;
  export let imageName;
  export let resourceId;

  async function onDelete() {
    const response = await fetch(`${hostName}Resource/${resourceId}`);
    console.log(response);
  }
</script>

{#if isOpen}
  <div class="edit-popup">
    <ModalOverlay />
    <ModalContent>
      <label for="image-file">File: {imageName}</label>
      <div class="button-container">
        <button on:click={onDelete}>Submit</button>
        <button on:click={() => (isOpen = false)}>Cancel</button>
      </div>
    </ModalContent>
  </div>
{/if}

<style>
  .button-container {
    padding: 10px;
  }
</style>
