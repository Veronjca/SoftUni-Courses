function solve(input, command){
    let numbers = input;

    let manipulator = {
        asc(){
            numbers.sort((a,b) => a - b);
        },
        desc(){
            numbers.sort((a,b) => b - a);
        }
    }

    manipulator[command]();
    return numbers;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));