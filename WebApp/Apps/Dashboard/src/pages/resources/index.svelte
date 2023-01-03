<script>
    import { onMount } from "svelte";

    let images = [];

    onMount(async () => {
        // Gọi API và lấy dữ liệu tại đây
        const response = await fetch("https://localhost:6060/api/Resources/GetResources");
        images = await response.json();
    });
</script>

{#each images as image}
    <img src={image.url} alt={image.description} />
{/each}

<style>
    /* Một số CSS cho việc hiển thị các hình ảnh */
</style>
