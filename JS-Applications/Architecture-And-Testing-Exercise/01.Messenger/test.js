import { expect } from "chai";
import { chromium } from "playwright";

const pageURL = "http://127.0.0.1:5500/01.Messenger/index.html";

describe("Tests", async function () {
  this.timeout(6000);

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

  it("should load messages", async () => {
    //navigate to page
    await page.goto(pageURL);

    //find and click refresh button
    await page.click("text=refresh");
    const text = await page.inputValue("textarea");

    expect(text).to.contains("Spami");
    expect(text).to.contains("George");
  });

  it("should create new message", async () => {
    //navigate to page
    await page.goto(pageURL);

    //find and populate input elements
    await page.fill("#author", "Peter");
    await page.fill("#content", "some content");

    // wait for response
    const [response] = await Promise.all([
      page.waitForResponse((resp) => resp.url().includes("/jsonstore/messenger")),
      page.click("text=send"),
    ]);

    //check if the response is successfull
    expect(response.ok()).to.be.true;
    expect(response.url()).includes("/jsonstore/messenger");

    expect(await response.json()).to.own.include({ author: "Peter" });
    expect(await response.json()).to.own.include({ content: "some content" });
  });
});
