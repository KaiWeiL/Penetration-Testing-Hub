//for (let i = 0; i < 10; i++) {
//    let containerDiv = document.querySelector('.container-post');
//    let cellDiv = document.createElement('div');
//    let cellClass = document.createAttribute('class');
//    cellClass.value = 'post-cell';
//    cellDiv.setAttributeNode(cellClass);
//    cellDiv.innerHTML = 'Test!!';
//    if (i == 1) {
//        cellClass.value = 'post-cell title-cell';
//    }else if (i == 2) {
//        cellClass.value = 'post-cell dp-cell';
//    }else if (i == 3) {
//        cellClass.value = 'post-cell content-cell';
//    }else if (i == 4) {
//        cellClass.value = 'post-cell author-cell';
//        cellDiv.innerHTML = 'Author';
//    }else if (i == 5) {
//        cellClass.value = 'post-cell role-cell';
//        cellDiv.innerHTML = 'Role!!';
//    }else if (i == 7) {
//        cellClass.value = 'post-cell reply-cell';
//    }else if (i == 9) {
//        cellClass.value = 'post-cell timestamp-cell';
//    }else {
//        cellClass.value = 'post-cell';
//    }
//    containerDiv.appendChild(cellDiv);
//}


console.log('Hiiii');
alert('hiii');

let postTitle = document.querySelector('#post-title');
postTitle.addEventListener('resize', titleLengthResize);

function titleLengthResize() {
    let newLength = window.innerWidth / 10;
    document.querySelector('#post-title').setAttribute('size', newLength);
}
