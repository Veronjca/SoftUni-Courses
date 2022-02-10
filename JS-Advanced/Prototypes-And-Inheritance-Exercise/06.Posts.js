function solve() {
  class Post {
    constructor(title, content) {
      this.title = title;
      this.content = content;
    }
    toString() {
      return `Post: ${this.title}\nContent: ${this.content}`;
    }
  }

  class SocialMediaPost extends Post {
    constructor(title, content, likes, dislikes) {
      super(title, content);
      this.likes = Number(likes);
      this.dislikes = Number(dislikes);
      this.comments = [];
    }

    addComment(comment) {
      this.comments.push(comment);
    }
    toString() {
      let result = `${super.toString()}\n`;
      result += `Rating: ${this.likes - this.dislikes}\n`;
      if (this.comments.length > 0) {
        result += "Comments:\n";
        for (let i = 0; i < this.comments.length; i++) {
          result += ` * ${this.comments[i]}\n`;
        }
      }
      return result.trim();
    }
  }

  class BlogPost extends Post{
      constructor(title, content, views){
          super(title, content);
          this.views = Number(views);
      }
      view(){
          this.views++;
          return this;
      }
      toString(){
          return super.toString() + `\nViews: ${this.views}`;
      }
  }

  return {
      Post,
      SocialMediaPost,
      BlogPost,
  }
}
