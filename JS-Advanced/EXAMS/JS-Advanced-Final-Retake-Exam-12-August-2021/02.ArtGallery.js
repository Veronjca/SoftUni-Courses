class ArtGallery {
  constructor(creator) {
    this.possibleArticles = { picture: 200, photo: 50, item: 250 };
    this.listOfArticles = [];
    this.guests = [];
  }

  addArticle(articleModel, articleName, quantity) {
    let model = articleModel.toLowerCase();
    if (!this.possibleArticles.hasOwnProperty(model)) {
      throw new Error("This article model is not included in this gallery!");
    }

    let current = this.listOfArticles.find((x) => x.articleName === articleName && x.articleModel === model);
    if (current !== undefined) {
      current.quantity += Number(quantity);
    } else {
      current = {
        articleModel: model,
        articleName: articleName,
        quantity: quantity,
      };
      this.listOfArticles.push(current);
    }

    return `Successfully added article ${articleName} with a new quantity- ${quantity}.`;
  }

  inviteGuest(guestName, personality) {
    if (this.guests.some((x) => x.guestName === guestName)) {
      throw new Error(`${guestName} has already been invited.`);
    }

    let points = personality === "Vip" ? 500 : personality === "Middle" ? 250 : 50;

    let currentGuest = {
      guestName: guestName,
      points: points,
      purchaseArticle: 0,
    };

    this.guests.push(currentGuest);
    return `You have successfully invited ${guestName}!`;
  }

  buyArticle(articleModel, articleName, guestName) {
    let currentArticle = this.listOfArticles.find((x) => x.articleName === articleName);

    if (!currentArticle || currentArticle.articleModel !== articleModel) {
      throw new Error("This article is not found.");
    }

    if (currentArticle.quantity === 0) {
      return `The ${articleName} is not available.`;
    }

    if (!this.guests.some((x) => x.guestName === guestName)) {
      return "This guest is not invited.";
    }

    let neededPoints = this.possibleArticles[articleModel];
    let guest = this.guests.find((x) => x.guestName == guestName);

    if (neededPoints > guest.points) {
      return "You need to more points to purchase the article.";
    }else{
        guest.points -= neededPoints;
        guest.purchaseArticle++;
        currentArticle.quantity--;
    }

    return `${guestName} successfully purchased the article worth ${neededPoints} points.`;
  }

  showGalleryInfo (criteria){
      let result = '';
      if(criteria === 'article'){
          result += "Articles information:\n";
          this.listOfArticles.forEach(x => {
              result += `${x.articleModel} - ${x.articleName} - ${x.quantity}\n`;
          })

      }else if(criteria === 'guest'){
          result += "Guests information:\n";
          this.guests.forEach(x => {
              result += `${x.guestName} - ${x.purchaseArticle}\n`;
          })
      }
      return result.trimEnd();
  }
}
mj


