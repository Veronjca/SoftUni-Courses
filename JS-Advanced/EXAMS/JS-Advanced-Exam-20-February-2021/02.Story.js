class Story {
  constructor(title, creator) {
    this.title = title;
    this.creator = creator;
    this._comments = [];
    this._likes = [];
  }

  get likes() {
    if (this._likes.length === 0) {
      return `${this.title} has 0 likes`;
    } else if (this._likes.length === 1) {
      return `${this._likes[0]} likes this story!`;
    }

    return `${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
  }

  like(username) {
    if (this._likes.includes(username)) {
      throw new Error("You can't like the same story twice!");
    } else if (username === this.creator) {
      throw new Error("You can't like your own story!");
    }
    this._likes.push(username);
    return `${username} liked ${this.title}!`;
  }

  dislike(username) {
    if (!this._likes.includes(username)) {
      throw new Error("You can't dislike this story!");
    }

    let index = this._likes.indexOf(username);
    this._likes.splice(index, 1);

    return `${username} disliked ${this.title}`;
  }

  comment(username, content, id) {
    let lastComment = this._comments[this._comments.length - 1];
    let index = lastComment !== undefined ? lastComment.Id : 0;

    if (id === undefined || !this._comments.some((x) => x.Id === id)) {
      let newComment = {
        Id: ++index,
        Username: username,
        Content: content,
        Replies: [],
      };
      this._comments.push(newComment);
      return `${username} commented on ${this.title}`;
    }

    let currentComment = this._comments.find((x) => x.Id === id);
    let lastReplay = currentComment.Replies[currentComment.Replies.length - 1];
    let replyIndex = lastReplay ? lastReplay.Id.toString().split('') : 0;
    let element = replyIndex === 0 ? 0 : Number(replyIndex[replyIndex.length - 1]);

    let newReply = {
      Id: `${currentComment.Id}.${++element}`,
      Username: username,
      Content: content,
    };

    currentComment.Replies.push(newReply);
    return "You replied successfully";
  }

  toString(sortingType) {
    let result = `Title: ${this.title}\n`;
    result += `Creator: ${this.creator}\n`;
    result += `Likes: ${this._likes.length}\n`;
    result += `Comments:\n`;

    if (sortingType === "asc") {
      this._comments.sort((a, b) => a.Id - b.Id);
      this._comments.forEach((x) => {
        x.Replies.sort((a, b) => a.Id - b.Id);
      });
    } else if (sortingType === "desc") {
      this._comments.sort((a, b) => b.Id - a.Id);
      this._comments.forEach((x) => {
        x.Replies.sort((a, b) => b.Id - a.Id);
      });
    } else if (sortingType === "username") {
      this._comments.sort((a, b) => a.Username.localeCompare(b.Username));
      this._comments.forEach((x) => {
        x.Replies.sort((a, b) => a.Username.localeCompare(b.Username));
      });
    }

    this._comments.forEach((x) => {
      result += `-- ${x.Id}. ${x.Username}: ${x.Content}\n`;

        x.Replies.forEach((y) => {
          result += `--- ${y.Id}. ${y.Username}: ${y.Content}\n`;
        });
    });
    return result.trimEnd();
  }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('asc'));
