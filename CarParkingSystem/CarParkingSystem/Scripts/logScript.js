// Variables
let ldate = new Date();
let ltime = ldate.toLocaleTimeString();
let store = ltime.replace(" ", ":")
let timeArr = store.split(":")
let greet = document.querySelector("#greet");
let hour = parseInt(timeArr[0])
let minuit = parseInt(timeArr[1])
let AP = timeArr[3];
let grab = document.querySelector(".grabLogin")
let loginBtn = document.querySelector(".loginBtn");
let form = document.querySelector("form");
let grabProfile = document.querySelector(".profileGrab");


setTimeout(() => {
    grabProfile.classList.add("progileFade")
}, 1100)


loginBtn.addEventListener("click", (e) => {
    e.preventDefault();
    grab.classList.add("loginShow");
    setTimeout(() => {
        form.submit();
    }, 2500)
})


// Conditional Rendaring
if (hour > 6 && AP === "AM") {
    console.log("Good Morning Sir")
    greet.innerHTML = "Good Morning Sir"
}
if (hour === 12 && minuit === 0 && AP === "PM") {
    console.log("Good Afternoon Sir")
    greet.innerHTML = "Good Afternoon Sir"
}
if (hour <= 12 && AP === "PM") {
    console.log("Good Evening Sir")
    greet.innerHTML = "Good Evening Sir"
}
if (hour < 12 && hour < 5 && AP === "AM") {
    console.log("Good Night Sir" + hour)
    greet.innerHTML = "Good Night Sir"
}
