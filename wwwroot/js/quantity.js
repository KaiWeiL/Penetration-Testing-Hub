let quantityArray = [];


//quantity button enable and disable
function isQuantityAdjustable(leftDiv, inputField, rightDiv, trueOrFalse) {

    let goodQuantityLeftDiv = leftDiv;
    let goodQuantityInput = inputField;
    let goodQuantityRightDiv = rightDiv;
    let itemId = leftDiv.parentElement.parentElement.id;

    if (trueOrFalse) {
        //enable quantity adjustment
        //left
        if (localStorage.getItem(itemId) == null || JSON.parse(localStorage.getItem(itemId)).quantity > 0) {
            goodQuantityLeftDiv.style.cursor = 'pointer';
            goodQuantityLeftDiv.onclick = e => {
                //minus input value
                e.target.nextElementSibling.value--;
                if (parseInt(e.target.nextElementSibling.value) == 0) {
                    e.target.onclick = e => { };
                    e.target.onmouseover = e => { };
                    e.target.onmouseleave = e => { };
                    e.target.style.backgroundColor = '';
                    e.target.style.cursor = 'default';
                }
            }
            goodQuantityLeftDiv.onmouseover = e => {
                e.target.style.backgroundColor = 'grey';
            }
            goodQuantityLeftDiv.onmouseleave = e => {
                e.target.style.backgroundColor = '';
            }
        }
        //right
        goodQuantityRightDiv.style.cursor = 'pointer';
        goodQuantityRightDiv.onmouseover = e => {
            e.target.style.backgroundColor = 'grey';
        }
        goodQuantityRightDiv.onmouseleave = e => {
            e.target.style.backgroundColor = '';
        }
        goodQuantityRightDiv.onclick = e => {
            //increase input value
            e.target.previousElementSibling.value++;

            //Add Left Div listener
            if (localStorage.getItem(itemId) == null || JSON.parse(localStorage.getItem(itemId)).quantity > 0) {
                goodQuantityLeftDiv.style.cursor = 'pointer';
                goodQuantityLeftDiv.onclick = e => {
                    //minus input value
                    e.target.nextElementSibling.value--;
                    if (parseInt(e.target.nextElementSibling.value) == 0) {
                        e.target.onclick = e => { };
                        e.target.onmouseover = e => { };
                        e.target.onmouseleave = e => { };
                        e.target.style.backgroundColor = '';
                        e.target.style.cursor = 'default';
                    }
                }
                goodQuantityLeftDiv.onmouseover = e => {
                    e.target.style.backgroundColor = 'grey';
                }
                goodQuantityLeftDiv.onmouseleave = e => {
                    e.target.style.backgroundColor = '';
                }
            }
        }
            //input
        goodQuantityInput.disabled = true;

    } else if (!trueOrFalse) {
        //disable quantity adjustment
        goodQuantityLeftDiv.style.cursor = 'default';
        goodQuantityLeftDiv.onclick = e => { };
        goodQuantityLeftDiv.onmouseover = e => { };
        goodQuantityLeftDiv.onmouseleave = e => { };
        goodQuantityLeftDiv.style.backgroundColor = '';
        goodQuantityRightDiv.style.cursor = 'default';
        goodQuantityRightDiv.onclick = e => { };
        goodQuantityRightDiv.onmouseover = e => { };
        goodQuantityRightDiv.onmouseleave = e => { };
        goodQuantityRightDiv.style.backgroundColor = '';
        goodQuantityInput.disabled = true;
    }

}


function addAdjustQuantityElement() {

    //left button
    let divLeft = document.createElement('div');
    let divleftClass = document.createAttribute('class');
    divleftClass.value = 'div-left';
    divLeft.setAttributeNode(divleftClass);
    divLeft.innerText = '<';


    //input quantity
    let input = document.createElement('input');
    let inputType = document.createAttribute('type');
    let inputSize = document.createAttribute('size');
    inputSize.value = '3';
    inputType.value = 'text';
    input.setAttributeNode(inputType);
    input.setAttributeNode(inputSize);
    input.value = '0';

    //right button
    let divRight = document.createElement('div');
    let divRightClass = document.createAttribute('class');
    divRightClass.value = 'div-right';
    divRight.setAttributeNode(divRightClass);
    divRight.innerText = '>';


    let quantityBrothers = [divLeft, input, divRight];

    return quantityBrothers;
}

function initialize() {

    if (localStorage.getItem('cart-item-quantity') != null) {
        document.querySelector('#cart-item-quantity').innerHTML = localStorage.getItem('cart-item-quantity');
    }

    //initialize quantity adjustments and append them
    document.querySelectorAll('.good-quantity').forEach(element => {

        let quantityBrothers = addAdjustQuantityElement();
        let itemId = element.parentElement.id;

        element.appendChild(quantityBrothers[0]);
        element.appendChild(quantityBrothers[1]);
        element.appendChild(quantityBrothers[2]);

        if (localStorage.getItem(itemId + '-state') == 'true') {
            isQuantityAdjustable(quantityBrothers[0], quantityBrothers[1], quantityBrothers[2], false);
        } else {
            isQuantityAdjustable(quantityBrothers[0], quantityBrothers[1], quantityBrothers[2], true);
        }

        if (localStorage.getItem(element.parentElement.id) == null) {
            element.firstElementChild.nextElementSibling.value = '0';
        } else {
            element.firstElementChild.nextElementSibling.value = JSON.parse(localStorage.getItem(element.parentElement.id)).quantity;
        }
    });

    //initialize ADD TO CART button state
    document.querySelectorAll('.good-container').forEach(element => addAddToCartButtonListenerWithState(element));
}

function addAddToCartButtonListenerWithState(item) {
    let itemId = item.id;
    let addToCartButton = document.querySelector('#' + itemId + ' .add-to-cart-button');
    if (localStorage.getItem(itemId + '-state') == "true") {
        addToCartButton.disabled = true;
        addToCartButton.onclick = e => { };
        item.appendChild(createEditQuantityButton());
    } else if (localStorage.getItem(itemId + '-state') == "false" || localStorage.getItem(itemId + '-state') == null) {
        addToCartButton.disabled = false;
        document.querySelector('#' + itemId + ' .add-to-cart-button').onclick = e => {

            let itemId = e.target.parentElement.parentElement.id;

            //disable ADD TO CART button
            localStorage.setItem(itemId + '-state', "true");
            e.target.disabled = true;

            //disable quantity adjustment
            let goodQuantityLeftDiv = document.querySelector('#' + itemId + ' .good-quantity .div-left');
            let goodQuantityInput = document.querySelector('#' + itemId + ' .good-quantity input');
            let goodQuantityRightDiv = document.querySelector('#' + itemId + ' .good-quantity .div-right');
            isQuantityAdjustable(goodQuantityLeftDiv, goodQuantityInput, goodQuantityRightDiv, false);

            //put into shopping cart for the anonymous user
            let itemInfo = {
                id: itemId, //string
                title: document.querySelector('#' + itemId).firstElementChild.innerText,
                price: parseInt(document.querySelector('#' + itemId + ' .good-price').textContent.slice(0, -4)), //int
                quantity: document.querySelector('#' + itemId + ' .good-quantity input').value,  //string
                imgSrc: document.querySelector('#' + itemId + ' img').src,
                imgSize: [document.querySelector('#' + itemId + ' img').width, document.querySelector('#' + itemId + ' img').height]
            };
            localStorage.setItem(itemId, JSON.stringify(itemInfo));

            //increase cart item quantity (one item at most can stand for 1)
            if (localStorage.getItem('cart-item-quantity') != null) {
                let cartQuantity = parseInt(localStorage.getItem('cart-item-quantity'));
                cartQuantity++;
                localStorage.setItem('cart-item-quantity', cartQuantity.toString());
                document.querySelector('#cart-item-quantity').innerHTML = cartQuantity.toString();
            } else {
                localStorage.setItem('cart-item-quantity', '1');
                document.querySelector('#cart-item-quantity').innerHTML = '1';
            }

            //Edit Quantity Button shows up
            e.target.parentElement.parentElement.appendChild(createEditQuantityButton());
        }
    }
}


//create edit quantity button
function createEditQuantityButton() {

    let editQuantityDiv = document.createElement('div');
    let editQuantityButton = document.createElement('button');
    let editQuantityButtonClass = document.createAttribute('class');
    editQuantityButtonClass.value = 'btn btn-primary edit-quantity-button';
    editQuantityDiv.appendChild(editQuantityButton);
    editQuantityButton.setAttributeNode(editQuantityButtonClass);
    editQuantityButton.innerText = 'Edit Quantity';

    editQuantityButton.onclick = e => {
        let itemId = e.target.parentElement.parentElement.id;

        //store state
        localStorage.setItem(itemId + '-state', 'false');

        //turn back the ADD TO CART button
        let addToCartButton = document.querySelector('#' + itemId + ' .add-to-cart-button');
        addToCartButton.disabled = false;
        addAddToCartButtonListenerWithState(document.querySelector('#' + itemId));

        //decrease cart item quantity (one item at most can stand for 1)
        let cartQuantity = parseInt(localStorage.getItem('cart-item-quantity'));
        cartQuantity--;
        localStorage.setItem('cart-item-quantity', cartQuantity.toString());
        document.querySelector('#cart-item-quantity').innerHTML = cartQuantity.toString();

        //enable quantity adjustment
        let goodQuantityLeftDiv = document.querySelector('#' + itemId + ' .good-quantity .div-left');
        let goodQuantityInput = document.querySelector('#' + itemId + ' .good-quantity input');
        let goodQuantityRightDiv = document.querySelector('#' + itemId + ' .good-quantity .div-right');
        isQuantityAdjustable(goodQuantityLeftDiv, goodQuantityInput, goodQuantityRightDiv, true);

        //delete item from cart
        localStorage.removeItem(itemId);

        //delete itself
        e.target.remove();
    };
    return editQuantityDiv;
}

initialize();
