async function Update() {

    //get information fron users
    const name = document.querySelector("#name")
    const passward = document.querySelector("#passward")
    const first_name = document.querySelector("#first_name")
    const last_name = document.querySelector("#last_name")

    const PostData = {
        UserName: name.value,
        UserPassward: passward.value,
        UserFirstName: first_name.value,
        UserLastName: last_name.value
    }

 
    const object = sessionStorage.getItem("users")
    const name2 = JSON.parse(object)
    console.log(name2)
    console.log(name2["userID"])
 
    //fetch request
    try {
        const PostRespones = await fetch(`https://localhost:44399/api/users/${name2["userID"]}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(PostData)
        })

        if (PostRespones.ok) {
            alert(` עדכון פרטים בוצע בהצלחה`)

        }
        else {
            throw new Error(`HTTP error status ${resulte.status}`)
        }
    }

    catch (error) {
        alert(error)
    }
    const PostData = {
        UserName: name.value,
        UserID: name2["userID"],
        UserPassward: passward.value,
        UserFirstName: first_name.value,
        UserLastName: last_name.value
    }
    sessionStorage.setItem("users", JSON.stringify(PostData))

}