function toStringExtension() {
  class Person {
    constructor(name, email) {
      this.name = name;
      this.email = email;
    }
    toString() {
      return `${this.constructor.name} (name: ${this.name}, email: ${this.email})`;
    }
  }

  class Teacher extends Person {
    constructor(name, email, subject) {
      super(name, email);
      this.subject = subject;
    }
    toString() {
      let str = Array.from(super.toString());
      let result = str.splice(0, str.length - 1).join("");
      return result + `, subject: ${this.subject})`;
    }
  }

  class Student extends Person {
    constructor(name, email, course) {
      super(name, email);
      this.course = course;
    }
    toString() {
      let str = Array.from(super.toString());
      let result = str.splice(0, str.length - 1).join("");
      return result + `, course: ${this.course})`;
    }
  }

  return {
    Person,
    Teacher,
    Student,
  };
}

console.log(toStringExtension());
