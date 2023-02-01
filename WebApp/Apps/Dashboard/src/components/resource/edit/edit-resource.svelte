<script>
  import {
    Button,
    Modal,
    ModalBody,
    ModalFooter,
    ModalHeader,
  } from "sveltestrap";

  import axios from "axios";

  export let resourceId = 1;
  export let isShow = false;
  export let resourceName;
  let newImageFile;

  var hostName = "https://localhost:6060";

  async function handleSave() {
    //const response = await fetch(`${hostName}/api/Resources/${resourceId}`);

    var data = {
      fileName: "test",
      data: newImageFile,
    };

    const formData = new FormData();
    formData.append("file", newImageFile);

    axios
      .post(`${hostName}/api/Resources/edit/${resourceId}`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((response) => {
        console.log(response);
      })
      .catch((error) => {
        console.log(error);
      });

    // axios
    //   .put(`${hostName}/api/Resources/${resourceId}`, data)
    //   .then((response) => {
    //     console.log(response);
    //   });

    // axios({
    //   method: "post",
    //   url: "myurl",
    //   data: bodyFormData,
    //   headers: { "Content-Type": "multipart/form-data" },
    // })
    //   .then(function (response) {
    //     //handle success
    //     console.log(response);
    //   })
    //   .catch(function (response) {
    //     //handle error
    //     console.log(response);
    //   });
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
