function solve() {
  document.querySelector("#btnSend").addEventListener("click", onClick);

  function onClick() {
    let input = JSON.parse(document.getElementById("inputs").querySelector('textarea').value);
    let restaurants = [];

    for (const restaurant of input) {
      let currentRestaurant = {};
      let arguments = restaurant.split(" - ");
      let restaurantName = arguments[0];
      let workers = arguments[1].split(", ");
      currentRestaurant["Name"] = restaurantName;
      currentRestaurant["Workers"] = [];
      currentRestaurant['AverageSalary'] = function(){
         if(this.Workers.length > 0){
            return this.Workers.reduce((a, b) => a + b.Salary, 0) / this.Workers.length;
         }
         return 0;       
      }
      currentRestaurant['BestSalary'] = function(){
         if(this.Workers.length === 0){
            return 0;
         }
        let bestSalary = this.Workers[0].Salary;
        for (const worker of this.Workers) {
           if(worker.Salary > bestSalary){
              bestSalary = worker.Salary;
           }
        }
        return bestSalary;
      }
    
      for (const worker of workers) {
         let arguments = worker.split(' ');
         let name = arguments[0];
         let salary = Number(arguments[1]);
         let currentWorker = {
            Name: name,
            Salary: salary,
            toString() {
               return `Name: ${this.Name} With Salary: ${this.Salary}`;
            }
         };
          currentRestaurant.Workers.push(currentWorker);
      }
      if(restaurants.some(x => x.Name === restaurantName)){
         let rest = restaurants.find(x => x.Name === restaurantName);
         rest.Workers = rest.Workers.concat(currentRestaurant.Workers);
      }else{
         restaurants.push(currentRestaurant);
      }
   }
   restaurants.sort((a,b) => b.AverageSalary() - a.AverageSalary());
   restaurants[0].Workers.sort((a,b) => b.Salary - a.Salary);
   document.getElementById('bestRestaurant').querySelector('p').textContent = `Name: ${restaurants[0].Name} Average Salary: ${restaurants[0].AverageSalary().toFixed(2)} Best Salary: ${restaurants[0].BestSalary().toFixed(2)}`;
   document.getElementById('workers').querySelector('p').textContent = restaurants[0].Workers.map(x => x.toString()).join(' ');
}
}
