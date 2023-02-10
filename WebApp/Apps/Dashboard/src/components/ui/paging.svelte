<script>
  export let pageTotal;
  export let onLoadPage;
  let currentPage = 1;

  function previous() {
    if (currentPage > 1) currentPage--;
    onLoadPage(currentPage);
  }

  function next() {
    if (currentPage < pageTotal) currentPage++;
    onLoadPage(currentPage);
  }
</script>

<nav>
  <ul class="pagination">
    <li class="page-item">
      <p class="page-link" on:mouseup={previous}>&laquo;</p>
    </li>
    {#each Array(pageTotal) as _, i}
      {#if i == currentPage - 1}
        <li class="page-item active"><p class="page-link">{i + 1}</p></li>
      {:else}
        <li class="page-item"><p class="page-link">{i + 1}</p></li>
      {/if}
    {/each}
    <li class="page-item" on:mouseup={next}>
      <p class="page-link">&raquo</p>
    </li>
  </ul>
</nav>
