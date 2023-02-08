<script>
  import {
    Modal,
    ModalBody,
    ModalFooter,
    ModalHeader,
  } from "sveltestrap";

  import { hostName } from "../../../scripts/store";

  export let isOpen = false;
  export let resourceName;
  let imageFile;

  async function handleSave() {
    //const response = await fetch(`${hostName}/api/Resources/${resourceId}`);

    const formData = new FormData();
    formData.append("file", imageFile);

    // axios
    //   .post(`${hostName}/api/Resources/edit/${resourceId}`, formData, {
    //     headers: {
    //       "Content-Type": "multipart/form-data",
    //     },
    //   })
    //   .then((response) => {
    //     console.log(response);
    //   })
    //   .catch((error) => {
    //     console.log(error);
    //   });

    const imageFormData = new FormData();
    imageFormData.append("file", imageFile);

    fetch(`${hostName+'resource'}`, {
      method: "PUT",
      body: imageFormData,
    })
      .then((response) => response.json())
      .then((data) => console.log(data))
      .catch((error) => console.error(error));
  }
</script>

<div>
  <Modal bind:isOpen={isOpen}>
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
          bind:value={imageFile}
        />
      </div>
    </ModalBody>
    <ModalFooter>
      <button on:click={handleSave}>Lưu</button>
      <button on:click={() => (isOpen = false)}>Hủy</button>
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
