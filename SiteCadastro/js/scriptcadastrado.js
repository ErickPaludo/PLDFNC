
let urlParams = new URLSearchParams(window.location.search);
let nomeUsuario = urlParams.get('nome');
document.getElementById("nome").innerText = nomeUsuario;

