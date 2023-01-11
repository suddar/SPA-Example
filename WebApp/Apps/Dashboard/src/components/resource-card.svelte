<script>
  import { Button, Modal } from "sveltestrap";
  export let model;
  let thumbnai = `data:image/jpeg;base64,${model}`;
  let open = false;
  const toggle = () => (open = !open);
</script>

<div>
  <!-- svelte-ignore a11y-click-events-have-key-events -->
  <img class="thumbnai" on:click={toggle} src={thumbnai} alt="" />
  <div class="button-group">
    <!-- <Button color="danger" on:click={toggle}>Open Modal</Button> -->
    <Button size="sm" color="light">Edit</Button>
    <Button size="sm" color="light">Delete</Button>
  </div>
  <Modal body header="Modal title" isOpen={open} {toggle}>
    <p>{model}</p>
  </Modal>
</div>

<style>
  .thumbnai {
    position: absolute;
    top: 0px;
    left: 0px;
  }

  .button-group {
    position: absolute;
    top: 80px;
    left: 8px;
  }
</style>
