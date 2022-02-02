function printDeckOfCards(input) {
  let cards = input;
  function createCard(face, suit) {
    let faces = ["2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"];
    let suits = {
      S: "\u2660",
      H: "\u2665",
      D: "\u2666",
      C: "\u2663",
    };
    face = face.toUpperCase();

    if (!faces.includes(face)) {
      throw new Error(`Invalid card: ${face}${suit}`);
    }
    if(!suits.hasOwnProperty(suit)){
        throw new Error(`Invalid card: ${face}${suit}`);
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
  let newArray;
  try {
    newArray = cards.map((x) => {
      let face = x.slice(0, x.length - 1);
      let suit = x[x.length - 1];
      return createCard.call(x, face, suit);
    });
  } catch (error) {
    console.log(error.message);
    return;
  }

  console.log(newArray.join(" "));
}

printDeckOfCards(["AS", "10D", "KH", "2C"]);
printDeckOfCards(["5S", "3D", "QG", "1C"]);
