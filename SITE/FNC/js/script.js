var errormsg = document.getElementById("errormsg");

function Cadastrar() {
    var pass = document.getElementById("senha").value.trim();
    var pasconfirm = document.getElementById("confirmarSenha").value.trim(); // Corrigido para pegar o valor do campo correto

    var usuario = {
        firstName: document.getElementById("nome").value.trim(),
        lastName: document.getElementById("sobrenome").value.trim(),
        userName: document.getElementById("usuario").value.trim(),
        userPass: pass,  // Usando a variável `pass` corretamente
        email: document.getElementById("email").value.trim()
    };

    // Validação de comprimento da senha
    if (pass.length < 8 || pasconfirm.length < 8) {
        errormsg.innerText = "Senha deve possuir no mínimo 8 caracteres";
        errormsg.style.display = "block";
        return;
    }

    // Validação se as senhas são iguais
    if (pass !== pasconfirm) {
        errormsg.innerText = "As senhas não são idênticas!";
        errormsg.style.display = "block";
        return;
    }

    // Verifica se todos os campos foram preenchidos
    if (usuario.firstName === "" || usuario.lastName === "" || usuario.userName === "" || usuario.userPass === "" || usuario.email === "") {
        errormsg.innerText = "Todos os campos devem ser preenchidos!";
        errormsg.style.display = "block";
        return;
    } else {
        fetch("https://localhost:44394/cadastrauser", {
            method: "POST",
            headers: {
                "Content-type": "application/json"
            },
            body: JSON.stringify(usuario)
        })
        .then(async response => {
            const contentType = response.headers.get("Content-Type");

            if (contentType && contentType.includes("application/json")) {
                const data = await response.json();
                if (response.status === 409) {
                    errormsg.innerText = data.message || "Usuário já existe.";
                    errormsg.style.display = "block";
                } else if (response.status === 201) {
                    errormsg.style.display = "none";
                    window.location.href = `/pages/cadastrado.html?nome=${encodeURIComponent(usuario.firstName)}`;
                } else {
                    errormsg.innerText = "Ocorreu um erro, tente novamente!";
                    errormsg.style.display = "block";
                }
            } else {
                const text = await response.text();
                errormsg.innerText = text || "Ocorreu um erro inesperado.";
                errormsg.style.display = "block";
            }
        })
        .catch(error => {
            errormsg.innerText = error.message;
            errormsg.style.display = "block";
        });
    }
}
