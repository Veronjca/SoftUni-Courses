function getPreviousDay(year, month, day){
    let current = new Date(year, month+1, day);
    current.setDate(current.getDate()-1);
    console.log(`${current.getFullYear()}-${current.getMonth()-1}-${current.getDate()}`);
}

getPreviousDay(2016, 9, 30);
getPreviousDay(2016, 10, 1);