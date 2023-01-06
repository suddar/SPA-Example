<script>
    import { onMount } from "svelte";
    import ImageModal from "../../components/image-modal.svelte";

    import { inject } from 'svelte';

    const myValue = inject('myValue');

    var hostName = "https://localhost:6060";
    let images = [];

    onMount(async () => {
        // Gọi API và lấy dữ liệu tại đây
        const response = await fetch(
            "https://localhost:6060/api/Resources/GetResources"
        );

        images = await response.json();
        //console.log(images[0].filePath);
        console.log(myValue);
    });

    function openImage(imageSrc) {
        // Tạo một element img mới
        const imgElement = new Image();

        // Sử dụng phương thức `src` để tải hình ảnh vào element
        imgElement.src = imageSrc;

        // Mở hình ảnh dưới dạng pop-up khi hình ảnh đã được tải xong
        imgElement.onload = () => {
            window.open(imgElement.src);
        };
    }
</script>

{#each images as image}
    <!-- <div on:mouseup={() => openImage(hostName + image.filePath)}>
        <img
            src={"data:image/png;base64," + image.thumbnai}
            alt={image.description}
        />
    </div> -->
    <!-- Sử dụng smallImageData thay vì smallImageUrl -->
    <ImageModal
        imageObject="image"
        smallImageData={image.thumbnai}
        largeImageUrl={hostName + image.filePath}
    />
    <!-- <img src={hostName + image.filePath} alt="" /> -->
{/each}

<style>
    /* Một số CSS cho việc hiển thị các hình ảnh */
</style>
