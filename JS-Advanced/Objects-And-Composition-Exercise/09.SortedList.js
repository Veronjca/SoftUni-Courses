function createSortedList() {
  return {
    elements: [],
    add(element) {
      this.elements.push(element);
    },
    remove(index) {
      this.elements.splice(index, 1);
    },
    get(index) {
      return this.elements[index];
    },
    size() {
      return this.elements.length();
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