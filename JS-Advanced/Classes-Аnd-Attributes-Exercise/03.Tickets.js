function solve(info, criteria){
    let tickets = [];
    class Ticket{
        constructor(destination, price, status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (const ticketInfo of info) {
        let args = ticketInfo.split('|');
        let destination = args[0];
        let price = Number(args[1]);
        let status = args[2];
        tickets.push(new Ticket(destination,price,status));
    }

    tickets.sort(function(a,b){
       if(a[criteria] > b[criteria]) return 1; 
       if(a[criteria] < b[criteria]) return -1; 
       if(a[criteria] = b[criteria]) return 0; 
    });

    return tickets; 
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'));