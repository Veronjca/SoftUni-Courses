function focused() {
  let inputFields = Array.from(document.getElementsByTagName("input")).forEach(
    (x) => x.addEventListener("focus", onFocused)
  );

  let second = Array.from(document.getElementsByTagName("input")).forEach(
    (x) => x.addEventListener("blur", onBlurred)
  );
  function onFocused(ev) {
    ev.currentTarget.parentNode.classList.add("focused");
  }

  function onBlurred(ev) {
    ev.currentTarget.parentNode.classList.remove("focused");
    s;
  }
}
