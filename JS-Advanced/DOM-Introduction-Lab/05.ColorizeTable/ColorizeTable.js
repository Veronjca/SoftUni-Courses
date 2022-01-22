function colorize() {
    let elements = Array.from(document.querySelectorAll('tr:nth-of-type(2n)'));
    elements.forEach(x => {
       x.style.backgroundColor = 'teal';
    })
}