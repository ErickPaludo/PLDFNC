import {useState} from 'react';
import {FiSearch} from 'react-icons/fi';
import './style.css';
function App() {

  const[input,setInput] = useState('Teste 123')

  function handleSearch(){
    alert("Valor do input" + input)
  }

  return (
    <div className="container">
      <h1 className="title">Buscar Cep</h1>
      <div className="containerInput">
        <input type="text" placeholder="Digite seu cep" value={input} onChange={(e) => setInput(e.target.value)}></input>
        <button className="buttonSearch" onClick={handleSearch}>
          <FiSearch size={25} color='#FFF'/>         
        </button>
      </div>
      <main className='main'>
        <h2>CEP:95110195</h2>
        <span>Complemento:React my eggs</span>
        <span>Rua:Rua Sanvitho</span>
        <span>Iguatemi</span>
        <span>Caxias do Sul - RS</span>
      </main>
    </div>
  );
}

export default App;
