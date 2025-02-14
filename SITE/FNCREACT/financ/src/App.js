import {useState} from 'react';
import api from './services/api';
import Swal from 'sweetalert2'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
  const[cadSucess, setCadSucess] = useState(false);
  const[firstName,setFirstName] = useState("")
  const[lastName,setLastName] = useState("")
  const[email,setLastEmail] = useState("")
  const[user,setUser] = useState("")
  const[password,setPass] = useState("")
  const[confPassword,setConfPass] = useState("")

  const[userLogin,setUserLogin] = useState("")
  const[passLogin,setPassLogin] = useState("")
  const[showPassword,setShowPass] = useState(false)

  async function handleSearch(){
    if(firstName === '' || lastName === '' || email === '' || user === '' || password === '' || confPassword === ''  ){
      Swal.fire({
        title: "Campos vazios",
        text: "Existem campos vazios",
        icon: "error"
      });
      return;
    }
    if(password !== confPassword){
      Swal.fire({
        title: "Reveja sua senha",
        text: "As senhas precisam ser idênticas",
        icon: "error"
      });
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

      const response = await api.post('/cadastrauser',usuario);
      console.log(response.data);

      console.log(response)
      if(response.code === 409){
        Swal.fire({
          title: "Ops... Temos um problema!",
          text: {response},
          icon: "error"
        });
        return
      }

      Swal.fire({
        title: "Bem Vindo ao Financ",
        text: "O Futuro começa!",
        icon: "success"
      });

      setFirstName("")
      setLastName("")
      setLastEmail("")
      setPass("")
      setConfPass("")


      setCadSucess(true)

    }catch(error){
      const errorMessages = Object.values(error.response?.data?.errors || {})
      .flat()
      .join("\n"); // Junta todas as mensagens em uma única string

      Swal.fire({
        title: "Ops... Ocorreu um erro no envio!",
        text: errorMessages,
        icon: "error"
      });
    }
    
  }

  return (
    
    <div className="ameba">
     {
      <Navbar bg="light" expand="lg">
      <Container fluid className="noPadding">
        <Navbar.Brand href="#home">Financ</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="#home" onClick={() => setCadSucess(false)}>Cadastro</Nav.Link>
            <Nav.Link href="#features"  onClick={() => setCadSucess(true)}>Entrar</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
     }

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

    {cadSucess === true && (
      <div>
      <div className="containerInput">
      <p>Usuário: </p>
      <input type="text" placeholder="Nome" value={userLogin} onChange={(e) => setUserLogin(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Senha: </p>
        <input type={showPassword ? "text" : "password"} placeholder="Password" value={passLogin} onChange={(e) => setPassLogin(e.target.value)} ></input>
      </div>

      <input type="checkbox" id="showPassword" onChange={() => setShowPass(!showPassword)}
      />
        <label htmlFor="showPassword"> Visualizar senha</label>

      <div className="containerInput">  
      <button className="buttonEnv" >
        Entrar
      </button>
      </div>
      
      </div> 
         )}  
    </div>
  );
}

export default App;
