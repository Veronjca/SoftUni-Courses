class Textbox {
  constructor(selector, regex) {
    this._elements = document.querySelectorAll(`${selector}`);
    this._invalidSymbols = regex;
    this._value = '';
  }

  get elements() {
    return this._elements;
  }


  get value() {
    return this._value;
  }

  set value(param) {
    this._value = param;
    let arr = Array.from(this.elements);
    arr.forEach((element) => {
      element.value = this._value;
    });
  }

  isValid() {
      if (this._invalidSymbols.test(this._value)) {
        return false;
      }
    return true;
  }
}

let textbox = new Textbox(".textbox", /[^a-zA-Z0-9]/);
let inputs = Array.from(document.getElementsByClassName("textbox"));
textbox.value = 'asd_';


