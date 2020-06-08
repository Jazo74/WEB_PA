console.log("I can access the JS file");

const miniMapEl = document.querySelector("#minimap");
miniMapEl.addEventListener("load", Draw);

function Draw() {
    var canvas = document.getElementById("myCanvas");
    canvas.style.position = "absolute";
    canvas.style.left = miniMapEl.offsetLeft + "px";
    canvas.style.top = miniMapEl.offsetTop + "px";

    for (i = 0; i < points.length; i++)
    {
        const coordX = points[i].coordX;
        const coordY = points[i].coordY;
        const ctx = canvas.getContext("2d");
        ctx.beginPath();
        ctx.arc(coordX, coordY, 200, 0, 2 * Math.PI, false);
        ctx.lineWidth = 1;
        ctx.strokeStyle = '#00ff00';
        ctx.stroke();
    }
}

