function extract(content) {
let txt = document.getElementById(content).textContent;
let myRegEx = RegExp(/\((.+?)\)/, 'g');
let matches = myRegEx.exec(txt);
let result = '';
while(matches != null){
    result += `${matches[1]}; `;
    matches = myRegEx.exec(txt);
}
return result;
}