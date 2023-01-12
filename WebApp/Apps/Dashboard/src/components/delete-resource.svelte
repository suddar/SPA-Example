<script>
  import ModalContent from "./modal/modal-content.svelte";
  import ModalOverlay from "./modal/modal-overlay.svelte";

  let isOpen = true;
  let newImageFile;
  export let imageName;
</script>

{#if isOpen}
  <div class="edit-popup">
    <ModalOverlay />
    <ModalContent>
      <label for="image-file">File: {imageName}</label>
      <input
        type="file"
        id="image-file"
        accept="image/*"
        bind:value={newImageFile}
      />
      <div class="button-container">
        <button>Submit</button>
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
