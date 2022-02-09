class Person {
  constructor(firstName, lastName) {
      this.firstName = firstName;
      this.lastName = lastName;
      this.fullName = `${this.firstName} ${this.lastName}`;
  }

  get firstName() {
    return this._firstName;
  }

  set firstName(value) {
    this._firstName = value;
    this._fullName = `${this.firstName} ${this.lastName}`;
  }

  get lastName() {
    return this._lastName;
  }

  set lastName(value) {
    this._lastName = value;
    this._fullName = `${this.firstName} ${this.lastName}`;
  }

  get fullName(){
      return this._fullName;
  }

  set fullName(value){
      if(/[\w]+\s[\w]+/g.test(value)){
        let [first, last] = value.split(' ');
        this._fullName = `${this.firstName} ${this.lastName}`;
        this.firstName = first;
        this.lastName = last;
      } 
  }
}

let person = new Person("Albert", "Simpson");
console.log(person.fullName); //Albert Simpson
person.firstName = "Simon";
console.log(person.fullName); //Simon Simpson
person.fullName = "Peter";
console.log(person.firstName);  // Simon
console.log(person.lastName);  // Simpson
