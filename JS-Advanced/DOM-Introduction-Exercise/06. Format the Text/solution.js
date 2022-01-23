function solve() {
  let text = document
    .getElementById("input")
    .value.split(".")
    .filter((x) => x);

  while (text.length > 0) {
   let append = "<p>";
    if (text.length <= 3) {
      while(text.length > 0){
        append += text.shift() + '.';
      }
    } else {
      append = `${text.shift()}.${text.shift()}.${text.shift()}.`;
    }
    append += "</p>";
    document.getElementById('output').innerHTML += append;
  } 
}
