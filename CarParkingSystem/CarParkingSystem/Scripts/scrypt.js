//Variables
let welcome = document.querySelector(".welcome");
let floor = document.querySelector(".shFloor");
let time = document.querySelector(".time");

// Time & Date
const Localtime = () => {
    let today = new Date();
    let todayTime = today.toLocaleTimeString();
    let todayDate = today.toLocaleDateString();
    time.innerHTML = todayTime + " || " + todayDate
}
setInterval(Localtime , 1000)

