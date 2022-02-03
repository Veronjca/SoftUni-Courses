function validate() {
    let inputField = document.querySelector('#email');
    inputField.addEventListener('change', validateEmail);

    function validateEmail(){
        let email = inputField.value;
        let regEx = /[a-z]+\@[a-z]+\.[a-z]+/g;
        if(regEx.test(email)){
            inputField.classList.remove('error');
        }else{
            inputField.classList.add('error');
        }
    }
}