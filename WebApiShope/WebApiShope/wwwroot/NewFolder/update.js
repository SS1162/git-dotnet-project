
function BuildObjectFromUserInput() {

    const currentUserFromSession = sessionStorage.getItem("users")
    const currentUserInObject = JSON.parse(currentUserFromSession)

    const userName = document.querySelector("#name")
    const userPassward = document.querySelector("#passward")
    const userFirstName = document.querySelector("#first_name")
    const userLastName = document.querySelector("#last_name")

    const userDetailsInObject = {
        UserId: currentUserInObject["userId"],
        UserName: userName.value,
        Password: userPassward.value,
        FirstName: userFirstName.value,
        LastName: userLastName.value
    }
    return userDetailsInObject
}



async function Update() {

    const userDetailsInObject = BuildObjectFromUserInput()

 
    const currentUserFromSession = sessionStorage.getItem("users")
    const currentUserInObject = JSON.parse(currentUserFromSession)
    
 
    //fetch request
    try {
        const UpdateRespones = await fetch(`https://localhost:44399/api/users/${currentUserInObject["userId"]}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userDetailsInObject)
        })

        if (UpdateRespones.ok) {
            const updateObjectForSession = {
                UserName: userDetailsInObject["UserName"],
                userId: userDetailsInObject["UserId"],
                UserPassward: userDetailsInObject["Password"],
                UserFirstName: userDetailsInObject["FirstName"],
                UserLastName: userDetailsInObject["LastName"]
            }
            sessionStorage.setItem("users", JSON.stringify(updateObjectForSession))
            alert(` עדכון פרטים בוצע בהצלחה`)

        }
        else {
            throw new Error(`HTTP error status ${UpdateRespones.status}`)
        }
    }

    catch (error) {
        alert(error)
    }

 

}