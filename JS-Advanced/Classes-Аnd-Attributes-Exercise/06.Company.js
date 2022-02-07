class Company {
  constructor() {
    this.departments = {};
  }

  addEmployee(name, salary, position, department) {
    if ((!name || !salary || !position || !department)) {
      throw new Error("Invalid input!");
    } else if (salary < 0) {
      throw new Error("Invalid input!");
    }

    if (!this.departments.hasOwnProperty(department)) {
      this.departments[department] = [];
    }
    this.departments[department].push(Object.assign({}, { name, salary, position }));
    return `New employee is hired. Name: ${name}. Position: ${position}`;
  }

  bestDepartment() {
    let best = "";
    let avgSalary = 0;
    for (const [department, employees] of Object.entries(this.departments)) {
      let current = employees.reduce((a, b) => a + b.salary, 0) / employees.length;
      if (current > avgSalary) {
        avgSalary = current;
        best = department;
      }
    }
    this.departments[best].sort(function (a, b) {

      if (a.salary > b.salary) return -1;
      if (a.salary < b.salary) return 1;
      return a.name.localeCompare(b.name);
    });
    let result = `Best Department is: ${best}\n`;
    result += `Average salary: ${avgSalary.toFixed(2)}\n`;
    this.departments[best].forEach(x => {
            result += `${x['name']} ${x['salary']} ${x['position']}\n`;
    })
    return result.trim();
  }
}

let c = new Company();
c.addEmployee(undefined, 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());