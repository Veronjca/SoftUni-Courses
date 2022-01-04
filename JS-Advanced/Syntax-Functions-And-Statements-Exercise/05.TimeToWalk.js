function getTime(steps, length, speed){
    let distance = steps * length;
    distance /= 1000;
    let timeInHours = distance / speed;
    let timeInMinutes = timeInHours * 60;
    let restTime = Math.floor((distance * 1000) / 500);
    timeInMinutes += restTime;

    let hours;
    let minutes;
    let seconds;

    if(timeInMinutes >= 60){
        hours = Math.floor(timeInMinutes / 60);
        minutes = timeInMinutes % 60;
    }else{
        hours = 0;
        minutes = Math.floor(timeInMinutes);
    }
    seconds = Math.round((timeInMinutes - Math.floor(timeInMinutes)) * 60);

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`);
}

getTime(2564, 0.70, 5.5);