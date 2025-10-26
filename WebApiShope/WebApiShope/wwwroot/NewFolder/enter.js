
const messege = document.querySelector(".messege")
const object = sessionStorage.getItem("users")
const name = JSON.parse(object)
console.log(name)
console.log(name["userName"])
messege.textContent = `התחברתה בהצלחה ${name["userName"]} שלום`