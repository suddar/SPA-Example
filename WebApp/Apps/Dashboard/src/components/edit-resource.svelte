<script>
  import {
    Button,
    Modal,
    ModalBody,
    ModalFooter,
    ModalHeader,
  } from "sveltestrap";

  import axios from "axios";

  export let resourceId;
  export let isShow = false;
  export let resourceName;
  let newImageFile;

  async function handleSave() {
    const response = await fetch(`${hostName}/api/Resources/${resourceId}`);

    var data = {
      fileName: null,
      filePath: "/images/b69127a3-d0ed-4344-9978-55a6189e3ccf.jpg",
      contentType: "image/jpeg",
      thumbnai: "",
      data: newImageFile,
      id: 8,
      name: "1.jpg",
    };

    axios
      .put("/api/user", {
        name: "Jane",
      })
      .then((response) => {
        // Update the user object with the new name
        user.name = response.data.name;
        console.log(user); // {name: "Jane", age: 30}
      });
  }
</script>

<div>
  <Modal bind:isOpen={isShow}>
    <ModalHeader>Modal title</ModalHeader>
    <ModalBody>
      <div>
        <label for="image-name">Nhập tên file</label>
        <input type="text" id="image-name" bind:value={resourceName} />
      </div>
      <div>
        <label for="image-file">File:</label>
        <input
          type="file"
          id="image-file"
          accept="image/*"
          bind:value={newImageFile}
        />
      </div>
    </ModalBody>
    <ModalFooter>
      <button on:click={handleSave}>Lưu</button>
      <button on:click={() => (isShow = false)}>Hủy</button>
    </ModalFooter>
  </Modal>
</div>

<!-- <div>
  <Modal isOpen={open} {toggle}>
    <ModalHeader {toggle}>Modal title</ModalHeader>
    <ModalBody>
      Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod
      tempor incididunt ut labore et dolore magna aliqua.
    </ModalBody>
    <ModalFooter>
      <Button color="primary" on:click={toggle}>Do Something</Button>
      <Button color="secondary" on:click={toggle}>Cancel</Button>
    </ModalFooter>
  </Modal>
</div> -->
