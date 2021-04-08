//when cart img show up
if (document.querySelector('.cart-img') != null) {
    document.querySelector('.cred-nav').style.marginRight = '5em';
}

if (localStorage.getItem('cart-item-quantity') === null) {
    localStorage.setItem('cart-item-quantity', '0');
} else if (parseInt(localStorage.getItem('cart-item-quantity')) > 0 && document.querySelector('#cart-item-quantity').innerHTML != null){
    document.querySelector('#cart-item-quantity').innerHTML = localStorage.getItem('cart-item-quantity');
}

