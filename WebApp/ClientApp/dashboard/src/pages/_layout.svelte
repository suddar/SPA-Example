<script>
    import { url } from "@roxi/routify";
</script>

<nav>
    <a href={$url("./")}>Home</a>
    <a href={$url("./users")}>Users</a>
    <a href={$url("./resources")}>Resources</a>
</nav>

<!-- routify:options preload="proximity" -->
<slot />