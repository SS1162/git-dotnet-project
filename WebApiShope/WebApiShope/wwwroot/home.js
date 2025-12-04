 
//get request
async function getReaspone(){
   
    try {
        const postResulte = await fetch("https://localhost:44399/api/users")
        if (postResulte.ok) {
            
            const array = await postResulte.json()
            alert(array)
        }
        else {
            throw new Error(`HTTP error status ${postResulte.status}`)
        }
    }
    catch (e) {
        alert(e)
    }
}
function BuildObjectFromUserInput() {
    const userName = document.querySelector("#name")
    const userPassward = document.querySelector("#passward")
    const userFirstName = document.querySelector("#first_name")
    const userLastName = document.querySelector("#last_name")

    const userDetailsInObject = {
        UserName: userName.value,
        Password: userPassward.value,
        FirstName: userFirstName.value,
        LastName: userLastName.value
    }
    return userDetailsInObject
}



async function Register() {
   
    const userDetailsInObject = BuildObjectFromUserInput()
               //fetch request
    try {
        const PostRespones = await fetch("https://localhost:44399/api/users", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userDetailsInObject)
        })

        if (PostRespones.ok) {
            const PostResponesData = await PostRespones.json()
            alert(`נרשמתה בהצלחה ${userDetailsInObject["UserName"]}`)
            
        }
        else {
            throw new Error(`HTTP error status ${PostRespones.status}`)
        }
    }

    catch (error) {
        alert(error)
    }
}


                   // form style
const button = document.querySelector(".button")
button.addEventListener("click",(e)=>{
    const new_user = document.querySelector(".new_user")
    new_user.style.display="block"

})

function BuildLoginObjectFromUserInput() {
    const userName = document.querySelector("#name2")
    const userPassward = document.querySelector("#passward2")

    const LoginObject = {
        UserName: userName.value,
        UserPassward: userPassward.value
    }
    return LoginObject
}

async function Login() {
   
    const LoginObject =BuildLoginObjectFromUserInput()
   
    //fetch request
    try {
        const PostRespones = await fetch("https://localhost:44399/api/users/loginFunction", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(LoginObject)
        })


        if (!PostRespones.ok) {
            throw new Error(`HTTP error status ${PostRespones.status}`)
        }

        if (PostRespones.status===204) {
            
            alert(`שם משתמש לא קיים במערכת`)

        }
        else {
            //sesion storege
            
            window.location.href = await  "NewFolder/enter.html"
            const forSession = await PostRespones.json()
            sessionStorage.setItem("users", JSON.stringify(forSession))
        }
    }

    catch (error) {
        alert(error)
    }
}

function BuildCheckPasswordObjectFromUserInput() {
    
    const userPassward = document.querySelector("#passward")

    const checkPasswordObject = {
        UserPassward: userPassward.value
    }
    return checkPasswordObject
}



//check password strength
async function CheckPasswordStrength() {
    const checkPasswordObject = BuildCheckPasswordObjectFromUserInput()

    //fetch request
    try {
        const PostRespones = await fetch("https://localhost:44399/api/password", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(checkPasswordObject)
        })


        if (!PostRespones.ok) {
            throw new Error(`HTTP error status ${PostRespones.status}`)
        }

      
        else {
            const PasswordStrength = await PostRespones.json()
            const bur = document.querySelector(".bur")
            bur.value = PasswordStrength
            alert(PostRespones.status + ' ' + PasswordStrength)
            
        }
    }

    catch (error) {
        alert(error)
    }
}




   


