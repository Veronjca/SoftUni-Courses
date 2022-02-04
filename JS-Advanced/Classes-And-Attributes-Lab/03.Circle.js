class Circle {
    _diameter = 0;
  constructor(radius) {
    this.radius = Number(radius);
  }

  get diameter() {
      return this.radius * 2;
  }

  set diameter(value) {
    this.radius = Number(value) / 2;
    this._diameter = Number(value);
  }

  get area() {
      return this.radius ** 2 * Math.PI;
  }
}

let c = new Circle(2);
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
c.diameter = 1.6;
console.log(`Radius: ${c.radius}`);
console.log(`Diameter: ${c.diameter}`);
console.log(`Area: ${c.area}`);
