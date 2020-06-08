console.log("I can access the JS file");
const bigMapEl = document.querySelector("#bigmap");
const coordXEl = document.querySelector("#coord-x");
const coordYEl = document.querySelector("#coord-y");
bigMapEl.addEventListener("load", showNumbers);
bigMapEl.addEventListener("click", getCoords);
let zeroX;
let zeroY;
let endX;
let endY;

function showNumbers() {
    zeroX = bigMapEl.getBoundingClientRect().left - 10;
    zeroY = bigMapEl.getBoundingClientRect().top - 200;
    endX = bigMapEl.getBoundingClientRect().width + 10;
    endY = bigMapEl.getBoundingClientRect().height + 200;
}

function getCoords(e) {
    let offsetX;
    let offsetY;
    if (bigMapEl.getBoundingClientRect().top > 0) {
        offsetY = 200 - this.y;
    } else {
        offsetY = 200 + 200 + Math.abs(this.y);
    }
    if (bigMapEl.getBoundingClientRect().left > 0) {
        offsetX = 10 - this.x;
    } else {
        offsetX = 10 + 10 + Math.abs(this.x);
    }
    
    const mouseX = e.clientX + offsetX - 10;
    const mouseY = e.clientY + offsetY - 200;
    console.log(mouseY);
    console.log(endY);
    coordXEl.value = (mouseX / endX) * 100;;
    coordYEl.value = (mouseY / endY) * 100;
}