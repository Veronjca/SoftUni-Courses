window.onload = cookbook;
async function cookbook() {
  let main = document.querySelector("main");
  main.innerHTML = "";

  const responseRecipes = await fetch("http://localhost:3030/jsonstore/cookbook/recipes");
  const recipes = await responseRecipes.json();

  const responseDetails = await fetch("http://localhost:3030/jsonstore/cookbook/details");
  const recipesDetails = await responseDetails.json();

  for (const [key, value] of Object.entries(recipes)) {
    let articleElement = document.createElement("article");
    articleElement.classList.add("preview");

    let titleDivElement = document.createElement("div");
    titleDivElement.classList.add("title");

    let h2Element = document.createElement("h2");
    h2Element.textContent = value.name;

    titleDivElement.appendChild(h2Element);

    let imgDivElement = document.createElement("div");
    imgDivElement.classList.add("small");

    let imgElement = document.createElement("img");
    imgElement.src = value.img;

    imgDivElement.appendChild(imgElement);

    articleElement.appendChild(titleDivElement);
    articleElement.appendChild(imgDivElement);

    articleElement.addEventListener("click", () => {
      main.innerHTML = "";

      let article = document.createElement("article");

      let h2 = document.createElement("h2");
      h2.textContent = h2Element.textContent;

      article.appendChild(h2);

      let mainDivElement = document.createElement("div");
      mainDivElement.classList.add("band");

      let secondDivElement = document.createElement("div");
      secondDivElement.classList.add("thumb");

      let img = document.createElement("img");
      img.src = imgElement.src;

      secondDivElement.appendChild(img);
      mainDivElement.appendChild(secondDivElement);

      let ingredientDivElement = document.createElement("div");
      ingredientDivElement.classList.add("ingredients");

      let h3Element = document.createElement("h3");
      h3Element.textContent = "Ingredients:";

      ingredientDivElement.appendChild(h3Element);

      let ul = document.createElement("ul");
      let ingredients = recipesDetails[value._id].ingredients;

      ingredients.forEach((ingredient) => {
        let curretnLi = document.createElement("li");
        curretnLi.textContent = ingredient;
        ul.appendChild(curretnLi);
      });

      ingredientDivElement.appendChild(ul);
      mainDivElement.appendChild(ingredientDivElement);

      let descriptionDivElement = document.createElement("div");
      descriptionDivElement.classList.add("description");

      let anotherH3Element = document.createElement("h3");
      anotherH3Element.textContent = "Preparation:";

      descriptionDivElement.appendChild(anotherH3Element);

      let steps = recipesDetails[value._id].steps;

      steps.forEach((step) => {
        let paragraph = document.createElement("p");
        paragraph.textContent = step;
        descriptionDivElement.appendChild(paragraph);
      });

      article.appendChild(mainDivElement);
      article.appendChild(descriptionDivElement);
      main.appendChild(article);
    });

    main.appendChild(articleElement);
  }
}
