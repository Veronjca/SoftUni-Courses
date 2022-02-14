window.addEventListener("load", solve);

function solve() {
  let modelInputElement = document.querySelector("#model");
  let yearInputElement = document.querySelector("#year");
  let descriptionTextAreaElement = document.querySelector("#description");
  let priceInputElement = document.querySelector("#price");
  let furnitureListElement = document.querySelector('#furniture-list');
  let totalPriceElement = document.querySelector('.total-price');
  let addButton = document.querySelector("#add");
  addButton.addEventListener("click", (ev) => {
    ev.preventDefault();
    let model = modelInputElement.value;
    let year = Number(yearInputElement.value);
    let description = descriptionTextAreaElement.value;
    let price = Number(priceInputElement.value);
    let totalPrice = Number(totalPriceElement.textContent);

    modelInputElement.value = "";
    yearInputElement.value = "";
    descriptionTextAreaElement.value = "";
    priceInputElement.value = "";

    if (model && description && price > 0 && year > 0) {
        let trElement = document.createElement('tr');
        let hiddenTrElement = document.createElement('tr');
        let modelTdElement = document.createElement('td');
        let priceTdElement = document.createElement('td');
        let actionsTdElement = document.createElement('td');
        let yearTdElement = document.createElement('td');
        let descriptionTdElement = document.createElement('td');
        let moreInfoButton = document.createElement('button');
        let buyItButton = document.createElement('button');

        trElement.classList.add('info');
        modelTdElement.textContent = model;
        priceTdElement.textContent = price.toFixed(2);
        moreInfoButton.classList.add('moreBtn');
        moreInfoButton.textContent = 'More Info';
        buyItButton.classList.add('buyBtn');
        buyItButton.textContent = 'Buy it';

        hiddenTrElement.classList.add('hide');
        yearTdElement.textContent = `Year: ${year}`;
        descriptionTdElement.setAttribute('colspan', 3);
        descriptionTdElement.textContent = `Description: ${description}`;

        actionsTdElement.appendChild(moreInfoButton);
        actionsTdElement.appendChild(buyItButton);
        hiddenTrElement.appendChild(yearTdElement);
        hiddenTrElement.appendChild(descriptionTdElement);
        trElement.appendChild(modelTdElement);
        trElement.appendChild(priceTdElement);
        trElement.appendChild(actionsTdElement);

        moreInfoButton.addEventListener('click', () =>{
            if(moreInfoButton.textContent === 'More Info'){
                moreInfoButton.textContent = "Less Info";
                hiddenTrElement.style.display = 'contents';
            }else{
                moreInfoButton.textContent = "More Info";
                hiddenTrElement.style.display = 'none';
            }
        })

        buyItButton.addEventListener('click', () => {
            totalPriceElement.textContent = (totalPrice + price).toFixed(2);
            trElement.remove();
            hiddenTrElement.remove();
        })

        furnitureListElement.appendChild(trElement);
        furnitureListElement.appendChild(hiddenTrElement);
    }
  });
}
