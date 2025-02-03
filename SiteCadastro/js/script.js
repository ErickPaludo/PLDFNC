function Cadastrar() {
    var usuario = {
        firstName: document.getElementById("nome").value.trim(),
        lastName: document.getElementById("sobrenome").value.trim(),
        userName: document.getElementById("usuario").value.trim(),
        userPass: document.getElementById("senha").value.trim(),
        email: document.getElementById("email").value.trim()
    };

    if (usuario.firstName === "" || usuario.lastName === "" || usuario.userName === "" || usuario.userPass === "" || usuario.email === "") {
        console.log("Objeto Usuario:", usuario);
        alert("Todos os campos devem ser preenchidos!");
        return;
    }
    else{
        fetch("http://25.49.76.159:8060/api/Cadastros/eleicao", {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(objeto)  // Envia o objeto convertido para JSON
        })
        .then(response => response.json())  // Trata a resposta da API
        .then(data => {
            alert("Resposta do servidor: " + JSON.stringify(data));  // Exibe a resposta no alert
        })
        .catch(error => {
          alert("Erro ao enviar os dados:" + error);  // Exibe erros, caso haja
        });
    }
}
