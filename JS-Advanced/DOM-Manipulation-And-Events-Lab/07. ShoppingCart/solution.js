function solve() {
  let addButtons = Array.from(document
    .querySelectorAll(".add-product"))
    .forEach((x) => x.addEventListener("click", addProduct));
    let checkoutButton = document.querySelector('.checkout');
    checkoutButton.addEventListener('click', checkout);

  let resultElement = document.querySelector("textarea");

  let products = [];
  let totalPrice = 0;
  function addProduct(ev) {
    let productName = ev
    .currentTarget
    .parentNode
    .previousElementSibling
    .querySelector(".product-title")
    .textContent;
    let productPrice = Number(ev.currentTarget.parentNode.nextElementSibling.textContent);
    totalPrice+= productPrice;
   if(!products.some(x => x === productName)){
      products.push(productName);
   }
    resultElement.textContent += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
  }

  function checkout(ev){
     resultElement.textContent += `You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`;
     let addButtonElements = Array.from(document.querySelectorAll('.add-product'))
     .forEach(x => x.disabled = true);
     ev.currentTarget.disabled = true;
  }
}
