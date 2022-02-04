class Point {
  constructor(x, y) {
    this.x = x;
    this.y = y;
  }

  static distance(firstPoint, secondPoint) {
    let a = firstPoint.x - secondPoint.x;
    let b = firstPoint.y - secondPoint.y;
    return Math.hypot(a, b);
  }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));