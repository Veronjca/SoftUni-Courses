(function solve() {
  String.prototype.ensureStart = function (str) {
    if (this.valueOf(this).startsWith(str)) {return this.valueOf(this)};
    return str + this.valueOf(this);
  };
  String.prototype.ensureEnd = function (str) {
    if (this.valueOf(this).endsWith(str)) {return this.valueOf(this)};
    return this.valueOf(this) + str;
  };
  String.prototype.isEmpty = function () {
    return this.valueOf(this) === '';
  };
  String.prototype.truncate = function (number) {
    let n = Number(number);
    if (this.length <= n) {
      return this.valueOf(this);
    } else if (this.length > n) {
      let index = this.valueOf(this).substring(0, n -2).lastIndexOf(" ");
      if (index !== -1) {
        return this.slice(0, index) + '...';
      } else if (n >= 4) {
        return this.slice(0, n - 3) + '...';
      }
      return ".".repeat(n);
    }
  };
  String.format = function (string, ...params) {
      let elements = params;
    for (let i = 0; i < string.length; i++) {
      if ((Number(string[i]) || string[i] === '0') && elements.length > 0) {
        string = string.replace(`{${string[i]}}`, elements.shift());
      }
    }
    return string;
  };
})();


