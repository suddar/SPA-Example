<div class="modal-content">
  <slot></slot>
</div>

<style>
  .modal-content {
    position: absolute;
    width: 500px;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    padding: 10px;
    z-index: 100;
  }
</style>
