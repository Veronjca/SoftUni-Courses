function createSortedList() {
    let elements = [];
  return {
    add(element) {
      elements.push(element);
      elements.sort((a,b) => a-b);
    },
    remove(index) {
        if(index >= 0 && index < elements.length){
            elements.splice(index, 1);
        }  
    },
    get(index) {
        if(index >= 0 && index < elements.length){
            return elements[index];
        }    
    },
    get size() {
      return elements.length;
    },
  };
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));