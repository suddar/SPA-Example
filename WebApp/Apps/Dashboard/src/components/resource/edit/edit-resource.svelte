<script>
  import { Modal, ModalBody, ModalFooter, ModalHeader } from "sveltestrap";
  import { hostName } from "../../../scripts/store";
  import axios from "axios";

  export let isOpen = false;
  export let data;

  export let refesh;
  let file;

  async function handleUpdate() {
    // const formData = new FormData();
    // formData.append("file", file);
    // const response = await fetch(`${hostName}resource?id=${data.id}`, {
    //   headers: {
    //     "Content-Type": "multipart/form-data",
    //   },
    //   method: "POST",
    //   body: formData,
    // });
    // if (response.ok) {
    //   console.log(response);
    // } else {
    //   console.log("not ok");
    // }
    // isOpen = false;
    //refesh();
    // var xhr = new XMLHttpRequest();
    // xhr.open("PUT", `${hostName}resource?id=${data.id}`, true);
    // xhr.setRequestHeader("Content-Type", "multipart/form-data");
    // xhr.onreadystatechange = function () {
    //   if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
    //     console.log(xhr.responseText);
    //   }
    // };
    // xhr.send(formData);

    await postImage(file);
  }

  async function postImage(file) {
    console.log(file);
    const formData = new FormData();
    formData.append("file", file);

    axios.put(`${hostName}resource?id=${data.id}`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  }
</script>

<div>
  <Modal bind:isOpen>
    <ModalHeader>Modal title</ModalHeader>
    <ModalBody>
      <div>
        <label for="image-name">Nhập tên file</label>
        <input type="text" id="image-name" bind:value={data.fileName} />
      </div>
      <div>
        <label for="image-file">File:</label>
        <input type="file" id="image-file" accept="image/*" bind:value={file} />
      </div>
      <input accept="image/png, image/jpeg" bind:value={file} type="file" />
    </ModalBody>
    <ModalFooter>
      <button on:click={handleUpdate}>Update</button>
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
