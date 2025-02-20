import {useState} from 'react';
import api from './services/api';
import Swal from 'sweetalert2'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import 'bootstrap/dist/css/bootstrap.min.css';
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';

function App() {
  const[cadSucess, setCadSucess] = useState(0);

  const[firstName,setFirstName] = useState("")
  const[lastName,setLastName] = useState("")
  const[email,setLastEmail] = useState("")
  const[user,setUser] = useState("")
  const[password,setPass] = useState("")
  const[confPassword,setConfPass] = useState("")

  const[userLogin,setUserLogin] = useState("")
  const[passLogin,setPassLogin] = useState("")
  const[showPassword,setShowPass] = useState(false)

  const[cadTitulo,setCadTitulo] = useState("")
  const[cadValor,setCadValor] = useState("")
  const[cadDescricao,setCadDescricao] = useState("")
  const[cadData,setCadData] = useState(new Date().toLocaleString())
  const[cadCategoria,setCadCategoria] = useState("")
  const[cadParcela,setCadParcela] = useState(1);

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


      setCadSucess(1)

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

  async function CadastraGasto(){
    if(cadTitulo === '' || cadValor === '' || cadDescricao === '' || cadData === '' || cadCategoria === '' || cadParcela === ''  ){
      Swal.fire({
        title: "Campos vazios",
        text: "Existem campos vazios",
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


      setCadSucess(1)

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
        <Navbar.Brand>Financ</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link  onClick={() => setCadSucess(0)}>Cadastro</Nav.Link>
            <Nav.Link   onClick={() => setCadSucess(1)}>Entrar</Nav.Link>
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
     }

      {cadSucess === 0 && (
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

    {cadSucess === 1 && (
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
      <button className="buttonEnv" onClick={() => setCadSucess(2)} >
        Entrar
      </button>
      </div>
      
      </div> 
         )}  

      {cadSucess === 2 && (
      <div>
      <div className="containerInput">
      <p>Título: </p>
      <input type="text" placeholder="titulo" onChange={(e) => setCadTitulo(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Valor: </p>
      <input type="number" placeholder="R$ 00,00" onChange={(e) => setCadValor(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Data: </p>
        <input type="date"></input>
      </div>
      <div className="containerInput">
      <p>Descrição: </p>
      <input type="text" onChange={(e) => setCadDescricao(e.target.value)} ></input>
      </div>
      <div className="containerInput">
      <p>Gasto: </p>
      <select id="categoria" name="categoria" value={cadCategoria} onChange={(e) => setCadCategoria(Number(e.target.value))} required>
      <option value="" disabled>Selecione uma categoria</option>
      <option value={0}>Débito</option>  
      <option value={1}>Crédito</option>         
</select>

      </div>
       {cadCategoria === 1 && (
      <div className="containerInput">
      <p>Parcelas: </p>
      <input type="number" value={cadParcela} onChange={(e) => setCadParcela(e.target.value)} ></input>
      </div>
      )}

      <div className="containerInput">  
      <button className="buttonEnv" onClick={CadastraGasto} >
        Entrar
      </button>
      </div>
      
      </div> 
         )}  
    </div>
  );
}

export default App;
