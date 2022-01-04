function policeman(speed, areaType){
    let maxSpeed;
    if(areaType == 'motorway'){
        maxSpeed = 130;
    }else if(areaType == 'interstate'){
        maxSpeed = 90;
    }else if(areaType == 'city'){
        maxSpeed = 50;
    }else if(areaType == 'residential'){
        maxSpeed = 20;
    }

    if(speed <= maxSpeed){
        console.log(`Driving ${speed} km/h in a ${maxSpeed} zone`);
    }else{
        let overload = speed - maxSpeed;
        let status;
        switch(true){
            case overload <= 20:
                status = 'speeding';
                break;
            case overload <= 40:
                status = 'excessive speeding';
                break;
            default:
                status = 'reckless driving';
                break;        
        }
        console.log(`The speed is ${overload} km/h faster than the allowed speed of ${maxSpeed} - ${status}`);
    }
}

policeman(21, 'residential');