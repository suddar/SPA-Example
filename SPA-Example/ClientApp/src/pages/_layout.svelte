<!-- routify:options preload="proximity" -->
<script>
    import { url } from "@roxi/routify";
</script>

<nav>
    <a href={$url("./")}>Home</a>
    <a href={$url("./maps")}>Maps</a>
    <a href={$url("./resoures")}>Upload image</a>
</nav>

<slot />
