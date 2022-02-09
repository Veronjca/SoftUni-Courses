function solve() {
  class Figure {
    constructor(value) {
      this.units = value === undefined ? "cm" : value;
    }
    get area() {}
    get units() {
      return this._units;
    }
    set units(value) {
      this._units = value;
    }

    changeUnits(value) {
      this.units = value;
    }

    toString() {
      return `Figures units: ${this.units}`;
    }
  }

  class Circle extends Figure {
    constructor(radius) {
      super();
      this.radius = Number(radius);
    }

    get area() {
        if(this._units === 'mm'){
            return Math.PI * ((this.radius * 10) ** 2);
        }else if(this._units === 'm'){
            return Math.PI * ((this.radius / 100) ** 2);
        }
      return Math.PI * this.radius ** 2;
    }

    toString() {
        if(this.units === 'mm'){
            return super.toString() + ` Area: ${this.area} - radius: ${this.radius * 10}`;
        }else if(this.units === 'm'){
            return super.toString() + ` Area: ${this.area} - radius: ${this.radius  / 100}`;
        }   
        return super.toString() + ` Area: ${this.area} - radius: ${this.radius}`;
    }
  }

  class Rectangle extends Figure {
    constructor(width, height, units) {
      super(units);
      this.width = Number(width);
      this.height = Number(height);
    }
    get area() {
      if (this._units === "mm") {
        return this.width * 10 * (this.height * 10);
      } else if (this._units === "m") {
        return (this.width / 100) * (this.height / 100);
      }
      return this.width * this.height;
    }

    toString() {
      if (this._units === "mm") {
        return super.toString() + ` Area: ${this.area} - width: ${this.width * 10}, height: ${this.height * 10}`;
      } else if (this._units === "m") {
        return (
          super.toString() + ` Area: ${this.area} - width: ${this.width / 100}, height: ${this.height / 100}`
        );
      }
      return super.toString() + ` Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
    }
  }

//   let c = new Circle(5);
//   console.log(c.area); // 78.53981633974483
//   console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5
//   let r = new Rectangle(3, 4, "mm");
//   console.log(r.area); // 1200
//   console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40
//   r.changeUnits("cm");
//   console.log(r.area); // 12
//   console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4
//   c.changeUnits("mm");
//   console.log(c.area); // 7853.981633974483
//   console.log(c.toString()); // Figures units: mm Area: 7853.981633974483 - radius: 50
  return {
    Figure,
    Circle,
    Rectangle,
  };
}

solve();
