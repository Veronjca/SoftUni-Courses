const expect = require("chai").expect;
const chromium = require("playwright-chromium").chromium;

const pageURL = "http://127.0.0.1:5500/02.Book-Library/index.html";
describe("Tests", async function () {
  this.timeout(10000);
  let count;

  let browser, page;
  before(async () => {
    browser = await chromium.launch();
  });

  after(async () => {
    await browser.close();
  });

  beforeEach(async () => {
    page = await browser.newPage();
  });

  afterEach(async () => {
    page.close();
  });

  it("should load all books", async () => {
    await page.goto(pageURL);

    await page.click("text=Load all books");
    await page.waitForSelector("text=Svetlin Nakov");

    let data = await page.$$eval("tbody tr", (rows) => rows.map((r) => r.textContent));

    expect(data).to.not.be.empty;
  });

  it("should not sent request when one of the input fields are not filled corectly", async () => {
    await page.goto(pageURL);

    await page.waitForSelector("text=form");
    await page.fill('[name="author"]', "");
    await page.fill('[name="title"]', "some title");
    await page.click("text=Submit");
    await page.click("text=Load all books");
    await page.waitForSelector("text=Svetlin Nakov");

    page.on("dialog", (dialog) => {
      expect(dialog.message()).to.equal("All fields are required!");
      dialog.accept();
    });

    await page.fill('[name="author"]', "some author");
    await page.fill('[name="title"]', "");
    await page.click("text=Submit");
    await page.click("text=Load all books");
    await page.waitForSelector("text=Svetlin Nakov");

    page.on("dialog", (dialog) => {
      expect(dialog.message()).to.equal("All fields are required!");
      dialog.accept();
    });
  });

  it("should send the right request when trying to add new book", async () => {
    await page.goto(pageURL);

    await page.waitForSelector("text=form");

    await page.fill('input[name="author"]', "some author");
    await page.fill('input[name="title"]', "some title");
    let request;

    page.on("request", (r) => (request = r));
    await page.click("text=Submit");

    expect(request.method()).to.equal("POST");
    expect(request.postDataJSON()).to.own.include({ title: "some title" });
    expect(request.postDataJSON()).to.own.include({ author: "some author" });
    expect(await request.allHeaders()).to.have.property("content-type");
    expect(await request.headerValue("content-type")).to.equal("application/json");
  });

  it("edit should work correctly", async () => {
    await page.goto(pageURL);

    await page.click("text=Load all books");
    await page.click("text=Edit");

    await page.fill('#editForm input[name="title"]', "new title");
    await page.click("text=Save");
    await page.waitForSelector("text=form");
    await page.click("text=Load all books");

    let data = await page.$$eval("tbody tr", (e) => e.map((x) => x.textContent));
    expect(data[0]).to.includes("J.K.Rowling");
    expect(data[0]).to.includes("new title");
  });

  it("should display correct form and correct info when edit button is pressed", async () => {
    await page.goto(pageURL);

    await page.click("text=Load all books");
    await page.click(".editBtn");

    await page.waitForSelector("text=edit form");
    let data = await page.$$eval("#editForm input", (e) => e.map((x) => x.value));
    expect(data[1]).to.includes("new title");
    expect(data[2]).to.includes("J.K.Rowling");
  });

  it("should send the right request when save button is clicked", async () => {
    await page.goto(pageURL);

    await page.click("text=Load all books");
    await page.click(".editBtn");

    await page.waitForSelector("text=edit form");
    await page.fill('#editForm  input[name="author"]', "J.K.Rowling");
    await page.fill('#editForm  input[name="title"]', "new title");
    let request;

    page.on("request", (r) => (request = r));
    await page.click("#editForm button");

    expect(request.method()).to.equal("PUT");
    expect(request.postDataJSON()).to.own.include({ title: "new title" });
    expect(request.postDataJSON()).to.own.include({ author: "J.K.Rowling" });
    expect(await request.allHeaders()).to.have.property("content-type");
    expect(await request.headerValue("content-type")).to.equal("application/json");
  });

  it("should display right dialog when delete button is clicked", async () => {
    await page.goto(pageURL);

    await page.click("text=Load all books");
    await page.click(".deleteBtn");

    page.on("dialog", (dialog) => {
      expect(dialog.message()).to.equal("Are you sure you want to delete this book?");
      dialog.accept();
    });
  });

  it("confirmation to delete a book should send the right request", async () => {
    await page.goto(pageURL);
    await page.click("text=Load all books");
  
    page.on("dialog", (dialog) => {
      dialog.accept();
    });

    const [request] = await Promise.all([
      page.waitForRequest((request) => request.method() === "DELETE"),
      page.locator("button >> nth=6").click(),
    ]);

    expect(request.method()).to.equal("DELETE");
  });
});
