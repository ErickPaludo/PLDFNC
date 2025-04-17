using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototipoFNCForms
{
    public class UpClass
    { 
            public int OperationType { get; set; } // Tipo da operação (2 para PATCH)
            public string Path { get; set; }       // Caminho do atributo a ser modificado
            public string Op { get; set; }         // Tipo de operação (replace)
            public string From { get; set; }       // Origem (geralmente null em replace)
            public string Value { get; set; }      // Novo valor (nesse caso, "P")
    }
}
