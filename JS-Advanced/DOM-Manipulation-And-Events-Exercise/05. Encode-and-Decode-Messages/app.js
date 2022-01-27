function encodeAndDecodeMessages() {
  let buttons = document.getElementsByTagName("button");
  let encodeButton = buttons[0];
  let decodeButton = buttons[1];
  encodeButton.addEventListener("click", encodeText);
  decodeButton.addEventListener('click', decodeText);

  function encodeText(ev) {
    let textAreaElement = ev.currentTarget.previousElementSibling;
    let value = textAreaElement.value;
    let encodedText = '';
    for (let i = 0; i < value.length; i++) {
        encodedText += String.fromCharCode(value.charCodeAt(i) + 1);      
    }
    let receiverTextArea = ev.currentTarget.parentNode.nextElementSibling.querySelector('textarea');
    receiverTextArea.value = encodedText;
    textAreaElement.value = '';
  }

  function decodeText(ev){
    let textAreaElement = ev.currentTarget.previousElementSibling;
    let value = textAreaElement.value;
    let decodedText = '';
    for (let i = 0; i < value.length; i++) {
        decodedText += String.fromCharCode(value.charCodeAt(i) - 1);      
    }
    textAreaElement.value = decodedText;
  }
}
