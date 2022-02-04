function getPersons(){
    let persons = [];
    class Person {
        constructor(firstName, lastName, age, email) {
          this.firstName = firstName;
          this.lastName = lastName;
          this.age = age;
          this.email = email;
        }
      
        toString() {
          return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
      }

      persons.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
      persons.push(new Person('SoftUni'));
      persons.push(new Person('Stephan', 'Johnson', 25));
      persons.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));
      return persons;
}

console.log(getPersons());

