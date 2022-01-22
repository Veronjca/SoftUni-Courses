function extractText() {
    let elements = document.getElementById('items').children;
    let result = '';
    for (let i = 0; i < elements.length; i++) {
        result += `${elements[i].textContent}\n`;       
    }
    document.getElementById('result').textContent = result;
}