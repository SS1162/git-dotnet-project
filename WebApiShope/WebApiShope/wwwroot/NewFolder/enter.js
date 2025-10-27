
const messegeToUser = document.querySelector(".messege")
const userDetails = sessionStorage.getItem("users")
const curentUser = JSON.parse(userDetails)
messegeToUser.textContent = `התחברתה בהצלחה ${curentUser["userName"]} שלום`