//Variables
let welcome = document.querySelector(".welcome");
let floor = document.querySelector(".shFloor");
let time = document.querySelector(".time");
let welcomeAnimation = document.querySelector(".welcomeVanish");
let grabImg = document.querySelector(".grabImg");
let grabImg2 = document.querySelector(".grabImg2");


setTimeout(() => {
    welcomeAnimation.classList.add("welcomeAnimation")
}, 1700)

setTimeout(() => {
    grabImg.classList.add("imgAnimate")
}, 1700)

setTimeout(() => {
    grabImg2.classList.add("footerAnimate")
}, 1700)




// Time & Date
const Localtime = () => {
    let today = new Date();
    let todayTime = today.toLocaleTimeString();
    let todayDate = today.toLocaleDateString();
    time.innerHTML = todayTime + " || " + todayDate
}
setInterval(Localtime , 1000)

