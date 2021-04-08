let itemIdArray = [];

for (let i = 0; i < localStorage.length; i++) {
    if (localStorage.key(i).substring(localStorage.key(i).length - 6) == "itemId") {
        itemIdArray.push(JSON.parse(localStorage.getItem(localStorage.key(i))));
    };
}


for (let i = 0; i < itemIdArray.length; i++) {
    //container div
    let goodContainerDiv = document.createElement('div');
    let goodContainerClass = document.createAttribute('class');
    //let goodContainerId = document.createAttribute('id');
    goodContainerClass.value = 'good-container-checkout';
    goodContainerDiv.setAttributeNode(goodContainerClass);

    //title div
    let goodTitleDiv = document.createElement('div');
    goodTitleDiv.innerHTML = itemIdArray[i].title;

    //image div
    let goodImgDiv = document.createElement('div');
    let goodImg = document.createElement('img');
    let goodImgSrc = document.createAttribute('src');
    let goodImgWidth = document.createAttribute('width');
    let goodImgHeight = document.createAttribute('height');
    goodImgSrc.value = itemIdArray[i].imgSrc;
    goodImgWidth.value = itemIdArray[i].imgSize[0];
    goodImgHeight.value = itemIdArray[i].imgSize[1];
    goodImg.setAttributeNode(goodImgSrc);
    goodImg.setAttributeNode(goodImgWidth);
    goodImg.setAttributeNode(goodImgHeight);
    goodImgDiv.appendChild(goodImg);

    //price div
    let goodPriceDiv = document.createElement('div');
    goodPriceDiv.innerHTML = itemIdArray[i].price;

    //quantity div
    let goodQuantityDiv = document.createElement('div');
    goodQuantityDiv.innerHTML = itemIdArray[i].quantity;

    goodContainerDiv.appendChild(goodTitleDiv);
    goodContainerDiv.appendChild(goodImgDiv);
    goodContainerDiv.appendChild(goodPriceDiv);
    goodContainerDiv.appendChild(goodQuantityDiv);
    document.querySelector('.goods-container-checkout').appendChild(goodContainerDiv);
}

