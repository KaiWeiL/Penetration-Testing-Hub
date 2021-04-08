
let total = 0;
for (let i = 0; i < localStorage.length; i++) {
    if (localStorage.key(i).substring(localStorage.key(i).length - 6) == "itemId") {
        total += JSON.parse(localStorage.getItem(localStorage.key(i))).price;
    };
}

document.querySelector('#money-total').value = total;