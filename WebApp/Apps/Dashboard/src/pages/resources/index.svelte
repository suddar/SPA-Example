<script>
    import { onMount } from "svelte";
    import { readable } from "svelte/store";

    var hostName = "https://localhost:6060";
    let images = [];

    onMount(async () => {
        // Gọi API và lấy dữ liệu tại đây
        const response = await fetch(
            "https://localhost:6060/api/Resources/GetResources"
        );

        images = await response.json();
        console.log(images[0].filePath);
    });
</script>

{#each images as image}
    <p>image</p>
    <img
        src={"data:image/png;base64," + image.thumbnai}
        alt={image.description}
    />
    <img src={hostName + image.filePath} alt="" />
{/each}

<style>
    /* Một số CSS cho việc hiển thị các hình ảnh */
</style>
