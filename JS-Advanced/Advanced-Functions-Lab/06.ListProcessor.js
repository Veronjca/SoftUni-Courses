function solve(input) {
    let innerArr = [];
   let obj = {
      add(string) {
        innerArr.push(string);
      },
      remove(string) {
        innerArr = innerArr.filter((x) => x !== string);
      },
      print() {
        console.log(innerArr.join(","));
      },
    };

    for (const item of input) {
        let [operation, value] = item.split(" ");
        obj[operation](value);
     }
}

solve(["add hello", "add again", "remove hello", "add again", "print"]);
