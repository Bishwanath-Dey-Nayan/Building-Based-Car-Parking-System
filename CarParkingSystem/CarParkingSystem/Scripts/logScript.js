// Variables
let ldate = new Date();
let ltime = ldate.toLocaleTimeString();
let store = ltime.replace(" ", ":")
let timeArr = store.split(":")
let greet = document.querySelector("#greet");
let hour = parseInt(timeArr[0])
let minuit = parseInt(timeArr[1])
let AP = timeArr[3]


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
if (hour < 12 && AP === "AM") {
    console.log("Good Night Admin")
    greet.innerHTML = "Good Night Admin"
}
