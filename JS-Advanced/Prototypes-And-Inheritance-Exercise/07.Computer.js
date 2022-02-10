function solve() {
  class Keyboard {
    constructor(manufacturer, responseTime) {
      this.manufacturer = manufacturer;
      this.responseTime = Number(responseTime);
    }
  }

  class Monitor {
    constructor(manufacturer, width, height) {
      this.manufacturer = manufacturer;
      this.width = Number(width);
      this.height = Number(height);
    }
  }

  class Battery {
    constructor(manufacturer, expectedLife) {
      this.manufacturer = manufacturer;
      this.expectedLife = expectedLife;
    }
  }

  class Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
      if (this.constructor == Computer) {
        throw new Error("Invalid instance!");
      }
      this.manufacturer = manufacturer;
      this.processorSpeed = Number(processorSpeed);
      this.ram = Number(ram);
      this.hardDiskSpace = Number(hardDiskSpace);
    }
  }

  class Laptop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, weight, color, battery) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);
      this.weight = Number(weight);
      this.color = color;
      this.battery = battery;
    }
    get battery() {
      return this._battery;
    }

    set battery(value) {
      if (value instanceof Battery) {
        this._battery = value;
      } else {
        throw new TypeError("Invalid argument!");
      }
    }
  }

  class Desktop extends Computer {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace, keyboard, monitor) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);
      this.keyboard = keyboard;
      this.monitor = monitor;
    }

    get keyboard() {
      return this._keyboard;
    }
    set keyboard(value) {
      if (value instanceof Keyboard) {
        this._keyboard = value;
      } else {
        throw new TypeError("Invalid argument!");
      }
    }

    get monitor() {
      return this._monitor;
    }

    set monitor(value) {
      if (value instanceof Monitor) {
        this._monitor = value;
      } else {
        throw new TypeError("Invalid argument!");
      }
    }
  }

  return {
    Battery,
    Keyboard,
    Monitor,
    Computer,
    Laptop,
    Desktop,
  };
}

let classes = solve();
let test = new classes.Computer();
