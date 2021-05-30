
if (localStorage.getItem('cart-item-quantity') != null) {
    document.querySelector('#cart-item-quantity').innerHTML = localStorage.getItem('cart-item-quantity');
}


//money total

let total = 0;
if (document.querySelector('.money-total') != null) {
    for (let i = 0; i < localStorage.length; i++) {
        if (localStorage.key(i).substring(localStorage.key(i).length - 6) == "itemId") {
            let itemObjLiteral = JSON.parse(localStorage.getItem(localStorage.key(i)));
            total += (itemObjLiteral.price * itemObjLiteral.quantity);
        };
    }

    document.querySelector('.money-total').innerHTML = 'Total ' + total + ' CAD';
}

if (document.querySelector('#create-total') != null) {
    document.querySelector('#create-total').value = total;
}

