var errormsg = document.getElementById("errormsg");

document.addEventListener("DOMContentLoaded", function () {
    let dataInput = document.getElementById("data");

    if (dataInput) {
        let now = new Date();
        let year = now.getFullYear();
        let month = String(now.getMonth() + 1).padStart(2, '0'); // Adiciona zero se for necessário
        let day = String(now.getDate()).padStart(2, '0');
        let hours = String(now.getHours()).padStart(2, '0');
        let minutes = String(now.getMinutes()).padStart(2, '0');

        let formattedDateTime = `${year}-${month}-${day}T${hours}:${minutes}`;
        dataInput.value = formattedDateTime;
    }
});

function Cadastrar() {
    var categoria = document.getElementById("categoria").value;

    if (categoria === "debito") {
        var debito = {
            descricao: document.getElementById("descricao").value.trim(),
            valor: document.getElementById("valor").value.trim(),
            data: document.getElementById("data").value.trim(),
            userId: 1
        };

        // Verifica se algum campo está vazio
        if (!debito.descricao || !debito.valor || !debito.data) {
            errormsg.innerText = "Todos os campos devem ser preenchidos!";
            errormsg.style.display = "block";
            return;
        }

        fetch("https://localhost:44394/cadastradebito", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(debito)
        })
        .then(async response => {
            const contentType = response.headers.get("Content-Type");

            if (contentType && contentType.includes("application/json")) {
                const data = await response.json();
                if (response.status === 201) {
                    errormsg.style.display = "none";
                    alert("Cadastrado com sucesso!");
                    window.location.href = window.location.href;

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
    else{
        errormsg.innerText = "Selecione a categoria";
        errormsg.style.display = "block";
    }
}
