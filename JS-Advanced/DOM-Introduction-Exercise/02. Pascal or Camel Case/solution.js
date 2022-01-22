function solve() {
  let result = "";
  let text = document.getElementById('text').value.toLowerCase();
  let converter = document.getElementById('naming-convention').value;
  let words = text.split(" ");
  if (converter === "Pascal Case") {
    for (const word of words) {
      result += word[0].toUpperCase() + word.slice(1);
    }
  } else if (converter === "Camel Case") {
    result += words[0];
    for (let i = 1; i < words.length; i++) {
      result += words[i][0].toUpperCase() + words[i].slice(1);
    }
  } else {
    result = "Error!";
  }
  document.getElementById('result').textContent = result;
}
