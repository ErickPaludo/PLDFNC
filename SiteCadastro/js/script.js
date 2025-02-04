var errormsg = document.getElementById("errormsg");
function Cadastrar() {
    var usuario = {
        firstName: document.getElementById("nome").value.trim(),
        lastName: document.getElementById("sobrenome").value.trim(),
        userName: document.getElementById("usuario").value.trim(),
        userPass: document.getElementById("senha").value.trim(),
        email: document.getElementById("email").value.trim()
    };

    if (usuario.firstName === "" || usuario.lastName === "" || usuario.userName === "" || usuario.userPass === "" || usuario.email === "") {
        errormsg.innerText = "Todos os campos devem ser preenchidos!"
        errormsg.style.display="block"
        return;
    }
    else{
        fetch("https://localhost:44394/api/Usuarios/cadastrauser", {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(usuario) 
        })
        .then(response => response.json())  
        .then(data => {
             errormsg.style.display="none"
            window.location.href = `/pages/cadastrado.html?nome=${encodeURIComponent(usuario.firstName)}`;
        })
        .catch(error => {
           errormsg.innerText = "Erro ao enviar os dados:"
        errormsg.style.display="block"
        });
        
    }
}
