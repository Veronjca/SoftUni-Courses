function operations(first, second, operator){
    if(operator == '+'){
        console.log(first + second);
    }else if(operator == '-'){
        console.log(first - second);
    } else if(operator == '*'){
        console.log(first * second);
    }else if(operator == '/'){
        console.log(first / second);
    }else if(operator == '%'){
        console.log(first % second);
    }else if(operator == '**'){
        console.log(first ** second);
    }      
};

operations(5, 6, '+');