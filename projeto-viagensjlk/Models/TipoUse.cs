using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace projeto_viagensjlk.Models
{
    public class TipoUse
    {   
        public int id_tipoUse {get; set;}
        public string nomeUse {get; set;}
        public string data_nasc {get; set;}
        public string senhaUse {get; set;}
        public string contaUse {get; set;}
        public string loginUse {get; set;}
    }
}