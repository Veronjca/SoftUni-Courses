function editElement(element, match, replacer) {
    let current = element.textContent;
    let regex = new RegExp(match, 'g');
    current = current.replace(regex, replacer);
    element.textContent = current;
    console.log(current);
}