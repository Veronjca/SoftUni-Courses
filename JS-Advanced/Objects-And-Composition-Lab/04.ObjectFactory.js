function factory(library, orders){
let arr = [];

for (let i = 0; i < orders.length; i++) {
    let current = {};
    Object.assign(current, orders[i].template);
    for (const part of orders[i].parts) {
        current[part] = library[part];
    } 
    // other solution 
    // for (let j = 0; j < orders[i].parts.length; j++) {
    //    Object.assign(current, {[orders[i].parts[j]]: library[orders[i].parts[j]]});
        
    // }
    arr.push(current);
}
return arr;
}
const library = {
    print: function () {
      console.log(`${this.name} is printing a page`);
    },
    scan: function () {
      console.log(`${this.name} is scanning a document`);
    },
    play: function (artist, track) {
      console.log(`${this.name} is playing '${track}' by ${artist}`);
    },
  };
  const orders = [
    {
      template: { name: 'ACME Printer'},
      parts: ['print']
    },
    {
      template: { name: 'Initech Scanner'},
      parts: ['scan']
    },
    {
      template: { name: 'ComTron Copier'},
      parts: ['scan', 'print']
    },
    {
      template: { name: 'BoomBox Stereo'},
      parts: ['play']
    }
  ];
  const products = factory(library, orders);
  console.log(products);
  