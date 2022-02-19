class LibraryCollection {
  constructor(capacity) {
    this.capacity = Number(capacity);
    this.books = [];
  }

  addBook(bookName, bookAuthor) {
    if (this.books.length === this.capacity) {
      throw new Error("Not enough space in the collection.");
    }

    let currentBook = {
      bookName,
      bookAuthor,
      payed: false,
    };

    this.books.push(currentBook);
    return `The ${bookName}, with an author ${bookAuthor}, collect.`;
  }

  payBook(bookName) {
    if (!this.books.some((x) => x.bookName === bookName)) {
      throw new Error(`${bookName} is not in the collection.`);
    }

    let book = this.books.find((x) => x.bookName === bookName);

    if (book.payed) {
      throw new Error(`${bookName} has already been paid.`);
    }

    book.payed = true;
    return `${bookName} has been successfully paid.`;
  }

  removeBook(bookName) {
    if (!this.books.some((x) => x.bookName === bookName)) {
      throw new Error("The book, you're looking for, is not found.");
    }

    let book = this.books.find((x) => x.bookName === bookName);

    if (book.payed === false) {
      throw new Error(`${bookName} need to be paid before removing from the collection.`);
    }

    let index = this.books.indexOf((x) => x.bookName === bookName);
    this.books.splice(index, 1);
    return `${bookName} remove from the collection.`;
  }

  getStatistics(bookAuthor) {
    let author = bookAuthor;
    let result = "";

    if (author === undefined) {
      result += `The book collection has ${this.capacity - this.books.length} empty spots left.\n`;
      this.books.sort((a, b) => a.bookName.localeCompare(b.bookName));

      this.books.forEach((x) => {
        result += `${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.\n`;
      });
     
    } else {
      let neededBooks = this.books.filter((x) => x.bookAuthor === author);

      if (neededBooks.length === 0) {
        throw new Error(`${author} is not in the collection.`);
      }

     neededBooks.forEach((x) => {
        result += `${x.bookName} == ${x.bookAuthor} - ${x.payed ? 'Has Paid' : 'Not Paid'}.\n`;
      });
    }
    return result.trimEnd();
  }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics('Blalala'));

