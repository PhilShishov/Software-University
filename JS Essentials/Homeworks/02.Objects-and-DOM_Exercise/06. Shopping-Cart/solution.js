function solve() {
   const productAddButtons = Array.from(document.getElementsByClassName('add-product'));
   const checkoutButton = document.getElementsByClassName('checkout')[0];
   const resultArea = document.getElementsByTagName('textarea')[0];

   let shoppingCart = new Set();
   let totalPrice = 0;

   for (const addButton of productAddButtons) {
      addButton.addEventListener('click', onclick)
   }
   checkoutButton.addEventListener('click', checkout)


   function onclick(){
      let productName = this.parentElement.parentElement.getElementsByClassName('product-title')[0].textContent;
      let productPrice = this.parentElement.parentElement.getElementsByClassName('product-line-price')[0].textContent;

      shoppingCart.add(productName);
      totalPrice +=+productPrice;
      
      resultArea.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
   }

   function checkout(){
      resultArea.textContent +=`You bought ${Array.from(shoppingCart.values()).join(', ')} for ${totalPrice.toFixed(2)}.`;
      for (const addButton of productAddButtons) {
         addButton.disabled = true;
      }
      checkoutButton.disabled = true;
   }
}