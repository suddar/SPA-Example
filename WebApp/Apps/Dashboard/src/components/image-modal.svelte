<script>
    export let imageObject = null;
    // Định nghĩa các thuộc tính của component
    export let largeImageUrl = "";
    export let smallImageData = "";
    export let smallImageUrl = `data:image/jpeg;base64,${smallImageData}`;

    let isModalOpen = false;
    let isEditPopupOpen = false;

    let newImageName = null;
    let newImageFile = null;

    // Hàm này sẽ được gọi khi người dùng bấm vào hình ảnh nhỏ
    function handleClick() {
        // Mở modal
        isModalOpen = true;
    }

    // Hàm này sẽ được gọi khi người dùng bấm vào nút đóng modal
    function handleClose() {
        // Đóng modal
        isModalOpen = false;
    }

    // Thêm phần tử input vào hàm xử lý sự kiện -->
    function handleEdit() {
        isModalOpen = false;
        isEditPopupOpen = true;
    }

    function handleDelete() {
        // Thực hiện các hành động cần thiết khi người dùng bấm vào nút xóa
        isModalOpen = false;
    }

    // Thêm hàm xử lý sự kiện
    function handleCancel() {
        isEditPopupOpen = false;
    }

    function handleSave() {
        
    }
</script>

<!-- Hiển thị hình ảnh nhỏ và gán sự kiện click cho nó -->
<img src={smallImageUrl} on:mouseup={handleClick} alt="" />

<!-- Thay đổi phần hiển thị của modal -->
{#if isModalOpen}
    <div>
        <div class="modal-overlay" on:mouseup={handleClose}/>
        <div class="modal-content">
            <div class="image-container">
                <img src={largeImageUrl} alt="" />
                <button class="close-button" on:click={handleClose}>X</button>
            </div>
            <div class="button-container">
                <button on:click={handleEdit}>Chỉnh sửa</button>
                <button on:click={handleDelete}>Xóa</button>
            </div>
        </div>
    </div>
{/if}

<!-- Thay đổi phần hiển thị -->
{#if isEditPopupOpen}
    <!-- Thay đổi phần hiển thị của pop-up -->
    <div class="edit-popup">
        <h2>Chỉnh sửa ảnh</h2>
        <p>Tên hiện tại: {imageObject.fileName}</p>
        <label for="image-name">Tên mới:</label>
        <input type="text" id="image-name" bind:value={newImageName} />
        <label for="image-file">File:</label>
        <input
            type="file"
            id="image-file"
            accept="image/*"
            bind:value={newImageFile}
        />
        <button on:click={handleSave}>Lưu</button>
        <button on:click={handleCancel}>Hủy</button>
    </div>
{/if}

<style>
    /* Định dạng modal */
    .modal-overlay {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        z-index: 1;
    }
    .modal-content {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        background-color: white;
        padding: 10px;
        z-index: 2;
    }
    /* Sửa lại định dạng modal */
    .image-container {
        position: relative;
    }
    .close-button {
        position: absolute;
        top: -10px;
        right: 2px;
        background-color: transparent;
        border: none;
        color: white;
        font-size: 24px;
        cursor: pointer;
    }
    /* Sửa lại định dạng modal */
    .button-container {
        display: flex;
        background-color: white;
        padding: 10px;
    }
</style>
