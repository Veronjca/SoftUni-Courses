class List{   
    size = 0;
    constructor(){
        this.numbers = [];  
    }
    
    validateIndex(index, array){
        return index >= 0 && index < array.length;
    }

    add(element){
        this.numbers.push(element);
        this.size++;
        this.numbers.sort((a,b) => a -b);
    }
    remove(index){
        if(this.validateIndex(index, this.numbers)){
            this.numbers.splice(index,1);
            this.size--;
            this.numbers.sort((a,b) => a -b);
        }else{
            throw new Error('Index is outside of the bounds of the array');
        } 
    }
    get(index){
        if(this.validateIndex(index, this.numbers)){
            return this.numbers[index];
        }else{
            throw new Error('Index is outside of the bounds of the array');
        }      
    }  
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(-1);
console.log(list.get(1));
console.log(list.size);