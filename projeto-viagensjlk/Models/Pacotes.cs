using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
namespace projeto_viagensjlk.Models
{
    public class Pacotes
    {
      
      public int id {get; set;}
      public string nome {get; set;}
      public string origem {get; set;}
      public string destino {get; set;}
      public string saida {get; set;}
      public string retorno {get; set;}
      public double preco {get; set;}
     
        
    }
}