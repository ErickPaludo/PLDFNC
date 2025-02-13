import {useState} from 'react';
import {FiSearch} from 'react-icons/fi';
import api from './services/api';
import Swal from 'sweetalert2'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const [cadSucess, setCadSucess] = useState(false);
  const[input,setInput] = useState('Teste 123')
  const[firstName,setFirstName] = useState("")
  const[lastName,setLastName] = useState("")
  const[email,setLastEmail] = useState("")
  const[user,setUser] = useState("")
  const[password,setPass] = useState("")
  const[confPassword,setConfPass] = useState("")
  const[cep, setCep] = useState({});

  
  async function handleSearch(){
    if(firstName === '' || lastName === '' || email === '' || user === '' || password === '' || confPassword === ''  ){
      alert("Preencha algum CEP");
      return;
    }
    if(password !== confPassword){
      alert("As senhas não são iguais");
      return;
    }
    try{
      const usuario = {
        firstName: firstName ,
        lastName: lastName,
        userName: user,
        userPass: password,  
        email: email
      }
      /*const response = await api.post(usuario);
      console.log(response.data);
      setCep(response.data);
      setInput("");*/
      Swal.fire({
        title: "Bem Vindo ao Financ",
        text: "O Futuro começa!",
        icon: "success"
      });

      setCadSucess(true)

    }catch{
      alert("Ops! Erro ao buscar CEP!")
      setInput("");   
    }
  }
  function exibeCadastro(){
    setCadSucess(false)
  }
  function exibeCada(){
    setCadSucess(true)
  }
  return (
    
    <div className="container" style={{ width: "100%" }}>
     {
      <Navbar bg="light" expand="lg">
      <Container>
        <Navbar.Brand href="#home">Financ</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="#home" onClick={exibeCadastro}>Cadastro</Nav.Link>
            <Nav.Link href="#features"  onClick={exibeCada}>Features</Nav.Link>
            <Nav.Link href="#pricing">Pricing</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
     
     /* <div className="containerInput">
        <input type="text" placeholder="Digite seu cep" value={input} onChange={(e) => setInput(e.target.value)}></input>
        <button className="buttonSearch" onClick={handleSearch}>
          <FiSearch size={25} color='#FFF'/>         
        </button>
        </div>*/}
         {cadSucess === false && (
        <div>
          <div className="containerInput">
        <p>Nome: </p>
        <input type="text" placeholder="Nome" value={firstName} onChange={(e) => setFirstName(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Sobrenome: </p>
        <input type="text" placeholder="Sobrenome" value={lastName} onChange={(e) => setLastName(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Email: </p>
        <input type="email" placeholder="Email" value={email} onChange={(e) => setLastEmail(e.target.value)}></input>
      </div>
      <div className="containerInput">
      <p>Nome usuário: </p>
        <input type="text" placeholder="Nome de Usuário" value={user} onChange={(e) => setUser(e.target.value)}></input>
      </div>
      <p>Senha: </p>
      <div className="containerInput">
        <input type="password" placeholder="Senha" value={password} onChange={(e) => setPass(e.target.value)}></input>
      </div>    
      <p>Confirmar senha: </p>
      <div className="containerInput">
        <input type="password" placeholder="Confirmar senha" value={confPassword} onChange={(e) => setConfPass(e.target.value)}></input>
      </div>
      <div className="containerInput">     
      <button className="buttonEnv" onClick={handleSearch}>
        Enviar
      </button>
      </div>
      
      </div> 
         )}  
    </div>
  );
}

export default App;
