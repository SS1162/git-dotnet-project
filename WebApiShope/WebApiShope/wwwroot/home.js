          // sesion storege
//sessionStorage.setItem([])


          //get request
async function getReaspone(){
   
    try {
        const resulte = await fetch("https://localhost:44399/api/users")
    if (resulte.ok) {
            
            const array = await resulte.json()
            console.log(resulte)
            console.log(array)
            alert(array)
        }
        else {
            throw new Error(`HTTP error status ${resulte.status}`)
        }
    }
    catch (e) {
        alert(e)
    }
}



async function PostReaspone() {

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



              //sesion storege
    //const temp = JSON.parse((sessionStorage.getItem())
    //temp.pop(PostData)
    //sessionStorage.setItem(JSON.stringify(temp))
            

               //fetch request
    try {
        const PostRespones = await fetch("https://localhost:44399/api/users/login", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(PostData)
        })

        if (PostRespones.ok) {
            const PostRespones2 = await PostRespones.json()
            alert(`נרשמתה בהצלחה ${name.value}`)
            
        }
        else {
            throw new Error(`HTTP error status ${resulte.status}`)
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



async function PostGetReaspone() {
   
    //get information fron users
    const name = document.querySelector("#name2")
    const passward = document.querySelector("#passward2")
    

    const PostGetData = {
        UserName: name.value,
        UserPassward: passward.value
    }
    //fetch request
    try {
        const PostRespones = await fetch("https://localhost:44399/api/users", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(PostGetData)
        })
        if (!PostRespones.ok) {
            throw new Error(`HTTP error status ${resulte.status}`)
        }

        if (PostRespones.status===204) {
            
            alert(`שם משתמש לא קיים במערכת`)

        }
        else {
            //sesion storege
            
            window.location.href = await  "NewFolder/enter.html"
            const session = await PostRespones.json()
            console.log(session)
            sessionStorage.setItem("users", JSON.stringify(session))
        }
    }

    catch (error) {
        alert(error)
    }
    }



    //if (PostRespones.status !== 201) {
    //    alert(PostRespones.status)
    //}
    //else {
    //move to the new page
    //window.location.href = "https://example.com";
    //}



    


    //sesion storege
    //sessionStorage.setItem(JSON.stringify(temp))


    //to use the information of the sesion storege
    //const temp = JSON.parse((sessionStorage.getItem())
    //temp.pop(PostData)



   


