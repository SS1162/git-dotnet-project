
function BuildObjectFromUserInput() {
    const userName = document.querySelector("#name")
    const userPassward = document.querySelector("#passward")
    const userFirstName = document.querySelector("#first_name")
    const userLastName = document.querySelector("#last_name")

    const userDetailsInObject = {
        UserName: userName.value,
        UserPassward: userPassward.value,
        UserFirstName: userFirstName.value,
        UserLastName: userLastName.value
    }
    return userDetailsInObject
}



async function Update() {

    const userDetailsInObject = BuildObjectFromUserInput()

 
    const currentUserFromSession = sessionStorage.getItem("users")
    const currentUserInObject = JSON.parse(currentUserFromSession)
    
 
    //fetch request
    try {
        const UpdateRespones = await fetch(`https://localhost:44399/api/users/${currentUserInObject["userID"]}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userDetailsInObject)
        })

        if (UpdateRespones.ok) {
            alert(` עדכון פרטים בוצע בהצלחה`)

        }
        else {
            throw new Error(`HTTP error status ${UpdateRespones.status}`)
        }
    }

    catch (error) {
        alert(error)
    }
    const updateObjectForSession = {
        UserName: userDetailsInObject["UserName"],
        UserID: currentUserInObject["userID"],
        UserPassward: userDetailsInObject["UserPassward"],
        UserFirstName: userDetailsInObject["UserFirstName"],
        UserLastName: userDetailsInObject["UserLastName"]
    }
    sessionStorage.setItem("users", JSON.stringify(updateObjectForSession))

}