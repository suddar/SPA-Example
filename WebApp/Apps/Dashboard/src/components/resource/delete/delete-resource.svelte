<script>
  import { hostName } from "../../../scripts/store";
  import ModalContent from "../../modal/modal-content.svelte";
  import ModalOverlay from "../../modal/modal-overlay.svelte";

  export let isOpen = false;
  export let data;
  export let refesh;

  async function onDelete() {
    const response = await fetch(`${hostName}Resource/${data.id}`, {
      method: "DELETE",
    });
    console.log(response);
    isOpen = false;
    refesh();
  }
</script>

{#if isOpen}
  <div class="edit-popup">
    <ModalOverlay />
    <ModalContent>
      <label for="image-file">File: {data.fileName}</label>
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
