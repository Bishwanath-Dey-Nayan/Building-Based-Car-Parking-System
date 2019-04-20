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


loginBtn.addEventListener("click", (e) => {
    e.preventDefault();
    grab.classList.add("loginShow");
    setTimeout(() => {
        form.submit();
    }, 2500)
})


// Conditional Rendaring
if (hour > 6 && AP === "AM") {
    console.log("Good Morning Admin")
    greet.innerHTML = "Good Morning Admin"
}
if (hour === 12 && minuit === 0 && AP === "PM") {
    console.log("Good Afternoon Admin")
    greet.innerHTML = "Good Afternoon Admin"
}
if (hour <= 12 && AP === "PM") {
    console.log("Good Evening Admin")
    greet.innerHTML = "Good Evening Admin"
}
if (hour < 12 && hour < 5 && AP === "AM") {
    console.log("Good Night Admin" + hour)
    greet.innerHTML = "Good Night Admin"
}
