function getDays(month, year){
    let daysInAMonth = new Date(year, month, 0).getDate();
    return daysInAMonth;
};

console.log(getDays(1, 2012));
