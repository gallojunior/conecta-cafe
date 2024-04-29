let elements = document.querySelectorAll('input[type="text"], select, textarea');
elements.forEach((elem, index, array) => {
  let placeholder = elem.placeholder;
  if (placeholder != "") {
    elem.placeholder = "";
    elem.onfocus = () => {
      elem.placeholder = placeholder;
    };
    elem.onblur = () => {
      elem.placeholder = "";
    };
  }

  if (elem.value != "") {
    elem.parentElement.classList.add("is-filled");
  }
});