function solution(){
    let text = '';
    return {
        append(string){
            text += string;
        },
        removeStart(n) {
            text = text.slice(n);
        },
        removeEnd(n){
            text = text.slice(0, -n);
        },
        print(){
            console.log(text);
        }
    }
}

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();