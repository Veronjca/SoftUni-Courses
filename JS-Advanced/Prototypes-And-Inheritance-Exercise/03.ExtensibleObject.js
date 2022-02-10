function extensibleObject() {
  return {
    extend(template) {
      for (const [key, value] of Object.entries(template)) {
        if (typeof value === "function") {
          Object.getPrototypeOf(this)[key] = value;
        } else {
          this[key] = value;
        }
      }
    },
  };
}
const myObj = extensibleObject();

const template = {
  extensionMethod: function () {},
  extensionProperty: "someString",
};
myObj.extend(template);

console.log(typeof extensibleObject);
