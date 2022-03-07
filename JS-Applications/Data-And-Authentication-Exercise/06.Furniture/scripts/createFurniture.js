export function createFurniture(item, tbodyElement){
    let furnitureTr = document.createElement("tr");

    let imgTd = document.createElement("td");
    let imgElement = document.createElement("img");
    imgElement.src = item.img;
    imgTd.appendChild(imgElement);

    let nameTd = document.createElement("td");
    let nameParagraph = document.createElement("p");
    nameParagraph.textContent = item.name;
    nameTd.appendChild(nameParagraph);

    let priceTd = document.createElement("td");
    let priceParagraph = document.createElement("p");
    priceParagraph.textContent = item.price;
    priceTd.appendChild(priceParagraph);

    let decFactorTd = document.createElement("td");
    let decFactorParagraph = document.createElement("p");
    decFactorParagraph.textContent = item.decFactor;
    decFactorTd.appendChild(decFactorParagraph);

    let checkboxTd = document.createElement("td");
    let inputElement = document.createElement("input");
    inputElement.setAttribute("type", "checkbox");
    checkboxTd.appendChild(inputElement);

    furnitureTr.appendChild(imgTd);
    furnitureTr.appendChild(nameTd);
    furnitureTr.appendChild(priceTd);
    furnitureTr.appendChild(decFactorTd);
    furnitureTr.appendChild(checkboxTd);

    tbodyElement.appendChild(furnitureTr);
}