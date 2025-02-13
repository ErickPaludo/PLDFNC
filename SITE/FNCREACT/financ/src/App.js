import {useState} from 'react';
import {FiSearch} from 'react-icons/fi';
import './style.css';
import api from './services/api';

function App() {

  const[input,setInput] = useState('Teste 123')
  const [cep, setCep] = useState({});
  async function handleSearch(){
    if(input === ''){
      alert("Preencha algum CEP");
      return;
    }
    try{
      const response = await api.get(`${input}/json`);
      console.log(response.data);
      setCep(response.data);
      setInput("");
    }catch{
      alert("Ops! Erro ao buscar CEP!")
      setInput("");   
    }
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

      {Object.keys(cep).length > 0 && (
      <main className='main'>
        <h2>CEP: {cep.cep}</h2>
        {Object.keys(cep.complemento).length > 0 && (
        <span>Complemento:{cep.complemento}</span>
        )}
        <span>Rua:{cep.logradouro}</span>
        <span>Bairro:{cep.bairro}</span>
        <span>{cep.localidade} - {cep.uf}</span>
      </main>
      )}

    </div>
  );
}

export default App;
