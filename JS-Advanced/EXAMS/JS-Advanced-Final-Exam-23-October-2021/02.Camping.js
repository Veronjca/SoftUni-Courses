class SummerCamp {
  constructor(organizer, location) {
    this.organizer = organizer;
    this.location = location;
    this.priceForTheCamp = { child: 150, student: 300, collegian: 500 };
    this.listOfParticipants = [];
  }
  registerParticipant(name, condition, money) {
    if (!this.priceForTheCamp.hasOwnProperty(condition)) {
      throw new Error("Unsuccessful registration at the camp.");
    }
    if (this.listOfParticipants.some((x) => x.name === name)) {
      return `The ${name} is already registered at the camp.`;
    }

    let price = this.priceForTheCamp[condition];
    if (Number(money) < price) {
      return `The money is not enough to pay the stay at the camp.`;
    }

    let participant = {
      name: name,
      condition: condition,
      power: 100,
      wins: 0,
    };

    this.listOfParticipants.push(participant);
    return `The ${name} was successfully registered.`;
  }

  unregisterParticipant(name) {
    if (!this.listOfParticipants.some((x) => x.name === name)) {
      throw new Error(`The ${name} is not registered in the camp.`);
    }
    let index = this.listOfParticipants.indexOf((x) => x.name === name);
    this.listOfParticipants.splice(index, 1);
    return `The ${name} removed successfully.`;
  }

  timeToPlay(typeOfGame, ...participants) {
    let first = this.listOfParticipants.find((x) => x.name === participants[0]);
    let second = this.listOfParticipants.find((x) => x.name === participants[1]);

    if (typeOfGame === "WaterBalloonFights") {
      if (
        !this.listOfParticipants.some((x) => x.name === participants[0]) ||
        !this.listOfParticipants.some((x) => x.name === participants[1])
      ) {
        throw new Error(`Invalid entered name/s.`);
      }

      if (first.condition !== second.condition) {
        throw new Error(`Choose players with equal condition.`);
      }

      if (first.power > second.power) {
        first.wins++;
        return `The ${first.name} is winner in the game ${typeOfGame}.`;
      } else if (second.power > first.power) {
        second.wins++;
        return `The ${second.name} is winner in the game ${typeOfGame}.`;
      }

      return `There is no winner.`;
    }

    if (typeOfGame === "Battleship") {
      if (!this.listOfParticipants.some((x) => x.name === participants[0])) {
        throw new Error(`Invalid entered name/s.`);
      }
      first.power += 20;
      return `The ${first.name} successfully completed the game ${typeOfGame}.`;
    }
  }

  toString(){
      let result = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}\n`;
      this.listOfParticipants.sort((a, b) => b.wins - a.wins);

      this.listOfParticipants.forEach(x => {
          result += `${x.name} - ${x.condition} - ${x.power} - ${x.wins}\n`;
      })
      return result.trimEnd();
  }
}

