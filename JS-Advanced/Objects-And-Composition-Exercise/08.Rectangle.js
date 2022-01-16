function rectangle(width, height, color){
    color = color.charAt(0).toUpperCase() + color.slice(1);
    return {
        width: Number(width),
        height: Number(height),
        calcArea(){
            return this.width * this.height;
        },
        color: color
    }
}
let rect = rectangle(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());