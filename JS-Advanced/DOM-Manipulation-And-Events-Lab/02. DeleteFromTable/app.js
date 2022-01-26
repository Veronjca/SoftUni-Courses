function deleteByEmail() {
    let lines = document.querySelectorAll('tbody tr');
    let inputEmail = document.getElementsByName('email');
    let email = inputEmail[0].value;
    inputEmail[0].value = '';
    let resultElement = document.getElementById('result');

    for (const line of lines) {
        if(line.textContent.includes(email)){
            line.remove();
            resultElement.textContent = 'Deleted.';
            break;
        }else{
            resultElement.textContent = 'Not found.'
        }
    }
}