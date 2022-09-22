const url = "https://api.ipify.org?format=json";
const ipBeto = "170.231.57.206";
const ipAmorzinho = "189.45.91.87";

const canvas = document.getElementById('desenho');
let ctx = canvas.getContext('2d');

// canvas.width = 1487;
// canvas.height = 3438;

canvas.width = 1487;
canvas.height = 3438;


let background = new Image();
background.src = "./images/background.png";


background.onload = function(){
    ctx.drawImage(background,0,0);   
    ctx.font = "55px Acme";
    ctx.fillStyle = "white";

    getIp();
}


async function getIp() {
    const response = await fetch(url);    
    const data = await response.json();

    if (data.ip == ipBeto){
        ctx.fillText("Beto", 370, 3295);
    }
}