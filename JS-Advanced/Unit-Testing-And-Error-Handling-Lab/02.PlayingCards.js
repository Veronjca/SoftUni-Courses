function solve(face, suit) {
  let faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
  let suits = {
    S: "\u2660 ",
    H: "\u2665",
    D: "\u2666",
    C: "\u2663",
  };
  face = face.toUpperCase();

  if (!faces.includes(face)) {
    throw new Error("Invalid face!");
  }
  let card = {
    face,
    suit: suits[suit],
    toString() {
      return this.face + this.suit;
    },
  };

  return card.toString();
}

console.log(solve('A', 'S'));
console.log(solve('10', 'H'));
console.log(solve('1', 'C'));