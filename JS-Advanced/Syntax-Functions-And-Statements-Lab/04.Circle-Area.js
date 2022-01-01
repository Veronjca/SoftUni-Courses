function area(a){
    let area;
    if(typeof(a) === 'number'){    
        area = Math.PI * Math.pow(a, 2);
    } else{
        return `We can not calculate the circle area, because we receive a ${typeof(a)}.`;
    }
       return area.toFixed(2);
};

console.log(area('name'));