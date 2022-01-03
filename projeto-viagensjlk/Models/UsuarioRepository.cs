using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
//using System.Data.SqlClient.SqlException;
using Microsoft.AspNetCore.Http;
namespace projeto_viagensjlk.Models
{
    public class UsuarioRepository
    {   
        /*ENDEREÇO DE CONEXÃO*/
        private const  string enderecoConexao = "Data Source=DESKTOP-14LU66O;Initial Catalog=viagenjlk; Integrated Security=True";

    
    /**************************************USUÁRIOS**************************************************/
    
    /*CADASTRAR USUÁRIOS*/
    public void Insert(TipoUse user){
                  
    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlInsert = "INSERT INTO tipoUse (nomeUse, loginUse, data_nasc, senhaUse, contaUse) VALUES (@nomeUse, @loginUse, @data_nasc, @senhaUse, @contaUse)";

    SqlCommand comando = new SqlCommand(sqlInsert, conexao);

    comando.Parameters.AddWithValue("@nomeUse", user.nomeUse);
    comando.Parameters.AddWithValue("@loginUse", user.loginUse);
    comando.Parameters.AddWithValue("@data_nasc", user.data_nasc);
    comando.Parameters.AddWithValue("@senhaUse", user.senhaUse);
    comando.Parameters.AddWithValue("@contaUse", user.contaUse);

    comando.ExecuteNonQuery();

    conexao.Close();
    
    }

    /*LISTAR USUÁRIOS*/
    public List<TipoUse> Listar_Usuarios(){

        SqlConnection conexao = new SqlConnection(enderecoConexao);

        conexao.Open();

        string sqlList = "SELECT * FROM tipoUse ORDER BY nomeUse";

        SqlCommand comando = new SqlCommand(sqlList, conexao);

        SqlDataReader dados = comando.ExecuteReader();

        List<TipoUse> lista = new List<TipoUse>();
        
        while(dados.Read()){
        
        TipoUse tipoUse = new TipoUse();

        tipoUse.id_tipoUse = dados.GetInt32("id_tipoUse");

        if(!dados.IsDBNull(dados.GetOrdinal("nomeUse")))
        tipoUse.nomeUse = dados.GetString("nomeUse");

        if(!dados.IsDBNull(dados.GetOrdinal("data_nasc")))
        tipoUse.data_nasc = dados.GetString("data_nasc");

        if(!dados.IsDBNull(dados.GetOrdinal("senhaUse")))
        tipoUse.senhaUse = dados.GetString("senhaUse");

        if(!dados.IsDBNull(dados.GetOrdinal("loginUse")))
        tipoUse.loginUse = dados.GetString("loginUse");

        if(!dados.IsDBNull(dados.GetOrdinal("contaUse")))
        tipoUse.contaUse = dados.GetString("contaUse");

        lista.Add(tipoUse);

        }
        
        conexao.Close();
        return lista;
    }

    /*ALTERAR USUÁRIOS*/ 
    public void Alterar(TipoUse user){

    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlUpdate = "UPDATE tipoUse set nomeUse = @nomeUse, data_nasc = @data_nasc, loginUse = @loginUse, senhaUse = @senhaUse WHERE id_tipoUse = @id_tipoUse";        
    
    SqlCommand comando = new SqlCommand(sqlUpdate, conexao);

    comando.Parameters.AddWithValue("@id_tipoUse", user.id_tipoUse);
    comando.Parameters.AddWithValue("@nomeUse", user.nomeUse);
    comando.Parameters.AddWithValue("@data_nasc", user.data_nasc);
    comando.Parameters.AddWithValue("@loginUse", user.loginUse);
    comando.Parameters.AddWithValue("@senhaUse", user.senhaUse);
    
    comando.ExecuteNonQuery();
    
    conexao.Close();       
    }

    /*EXCLUIR USUÁRIOS*/
     public void Excluir(int id){
    
    SqlConnection conexao = new SqlConnection(enderecoConexao);
    
    conexao.Open();

    string sqlDelete = "DELETE FROM tipoUse WHERE id_tipoUse = @id";

    SqlCommand comando = new SqlCommand(sqlDelete, conexao);

    comando.Parameters.AddWithValue("@id", id);

    comando.ExecuteNonQuery();

    conexao.Close();  
    }

    /*RETORNO DE USUÁRIO*/
     public TipoUse RetornoTipoUse(int id){
    
    int id_user = id;
    
    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlConsulta = "SELECT * FROM tipoUse WHERE id_tipoUse = @id";

    SqlCommand comando = new SqlCommand(sqlConsulta, conexao);

    comando.Parameters.AddWithValue("@id", id_user);
    
    SqlDataReader dados = comando.ExecuteReader();

    dados.Read();

    TipoUse tipoUse  = new TipoUse();

    tipoUse.id_tipoUse = dados.GetInt32("id_tipoUse");
    
    if(!dados.IsDBNull(dados.GetOrdinal("nomeUse")))
    tipoUse.nomeUse = dados.GetString("nomeUse");

    if(!dados.IsDBNull(dados.GetOrdinal("data_nasc")))
    tipoUse.data_nasc = dados.GetString("data_nasc");

    if(!dados.IsDBNull(dados.GetOrdinal("loginUse")))
    tipoUse.loginUse = dados.GetString("loginUse");

    if(!dados.IsDBNull(dados.GetOrdinal("senhaUse")))
    tipoUse.senhaUse = dados.GetString("senhaUse");

    conexao.Close();
    return tipoUse;
    
    }


    /**************************************PACOTES***********************************************/
     
    /*CADASTRO DE PACOTES*/
    public void Insert_Pacotes(Pacotes pacote){
                  
    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlInsert = "INSERT INTO pacotes (nome, origem, destino, saida, retorno, preco) VALUES (@nome, @origem, @destino, @saida, @retorno, @preco)";

    SqlCommand comando = new SqlCommand(sqlInsert, conexao);

    comando.Parameters.AddWithValue("@nome", pacote.nome);
    comando.Parameters.AddWithValue("@origem", pacote.origem);
    comando.Parameters.AddWithValue("@destino", pacote.destino);
    comando.Parameters.AddWithValue("@saida", pacote.saida);
    comando.Parameters.AddWithValue("@retorno", pacote.retorno);
    comando.Parameters.AddWithValue("@preco", pacote.preco);
    

    comando.ExecuteNonQuery();

    conexao.Close();
    
    }

    /*LISTAGEM DE PACOTES*/
    public List<Pacotes> Listar_Pacotes(){

        SqlConnection conexao = new SqlConnection(enderecoConexao);

        conexao.Open();

        string sqlList = "SELECT * FROM pacotes ORDER BY nome";

        SqlCommand comando = new SqlCommand(sqlList, conexao);

        SqlDataReader dados = comando.ExecuteReader();

        List<Pacotes> lista = new List<Pacotes>();
        
        while(dados.Read()){
        
        Pacotes pacote = new Pacotes();

        pacote.id = dados.GetInt32("id_pacotes");

        if(!dados.IsDBNull(dados.GetOrdinal("nome")))
        pacote.nome = dados.GetString("nome");

        if(!dados.IsDBNull(dados.GetOrdinal("origem")))
        pacote.origem = dados.GetString("origem");

        if(!dados.IsDBNull(dados.GetOrdinal("destino")))
        pacote.destino = dados.GetString("destino");

        if(!dados.IsDBNull(dados.GetOrdinal("saida")))
        pacote.saida = dados.GetString("saida");

        if(!dados.IsDBNull(dados.GetOrdinal("retorno")))
        pacote.retorno = dados.GetString("retorno");

        if(!dados.IsDBNull(dados.GetOrdinal("preco")))
        pacote.preco = (double)dados.GetDecimal("preco");

      
        lista.Add(pacote);

        }
        
        conexao.Close();
        return lista;
    }

    /*ALTERAÇÃO DE PACOTES*/
     public void Alterar_P(Pacotes p){

    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlUpdate = "UPDATE pacotes set nome = @nome, origem = @origem, destino = @destino, saida = @saida, retorno = @retorno, preco = @preco WHERE id_pacotes = @id";        
    
    SqlCommand comando = new SqlCommand(sqlUpdate, conexao);

    comando.Parameters.AddWithValue("@id", p.id);
    comando.Parameters.AddWithValue("@nome", p.nome);
    comando.Parameters.AddWithValue("@origem", p.origem);
    comando.Parameters.AddWithValue("@destino", p.destino);
    comando.Parameters.AddWithValue("@saida", p.saida);
    comando.Parameters.AddWithValue("@retorno", p.retorno);
    comando.Parameters.AddWithValue("@preco", p.preco);
    
    comando.ExecuteNonQuery();
    
    conexao.Close();       
    }

    /*EXCLUSÃO DE PACOTES*/
     public void Excluir_P(int id){

        SqlConnection conexao = new SqlConnection(enderecoConexao);

        conexao.Open();

        string sqlDelete = "DELETE FROM pacotes WHERE id_pacotes = @id";

        SqlCommand comando = new SqlCommand(sqlDelete, conexao);

        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();

        conexao.Close();
    }
    
    /*RETORNO DE PACOTES*/
    public Pacotes RetornoPacote(int id){
    
    int id_pacote = id;
    
    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlConsulta = "SELECT * FROM pacotes WHERE id_pacotes = @id";

    SqlCommand comando = new SqlCommand(sqlConsulta, conexao);

    comando.Parameters.AddWithValue("@id", id_pacote);
    
    SqlDataReader dados = comando.ExecuteReader();

    dados.Read();

    Pacotes pacote = new Pacotes();

    pacote.id = dados.GetInt32("id_pacotes");
    
    if(!dados.IsDBNull(dados.GetOrdinal("nome")))
    pacote.nome = dados.GetString("nome");

    if(!dados.IsDBNull(dados.GetOrdinal("origem")))
    pacote.origem = dados.GetString("origem");

    if(!dados.IsDBNull(dados.GetOrdinal("destino")))
    pacote.destino = dados.GetString("destino");

    if(!dados.IsDBNull(dados.GetOrdinal("saida")))
    pacote.saida = dados.GetString("saida");

    if(!dados.IsDBNull(dados.GetOrdinal("retorno")))
    pacote.retorno = dados.GetString("retorno");
    
    if(!dados.IsDBNull(dados.GetOrdinal("preco")))
    pacote.preco = (double)dados.GetDecimal("preco");

    conexao.Close();
    return pacote; 
    }
           

        /**********************************************ATENDIMENTO*********************************************/

        /*REGISTRO DE ATENDIMENTO*/
        public void Insert_Atendimento(Atendimento a){
                  
    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlInsert = "INSERT INTO atendimento (nome, email, duvida) VALUES (@nome, @email, @duvida)";

    SqlCommand comando = new SqlCommand(sqlInsert, conexao);

    comando.Parameters.AddWithValue("@nome", a.nome);
    comando.Parameters.AddWithValue("@email", a.email);
    comando.Parameters.AddWithValue("@duvida", a.duvida);

    comando.ExecuteNonQuery();

    conexao.Close();
    
    }


    /********************************************loginUse************************************************************/

    public TipoUse loginUse(TipoUse user){

    SqlConnection conexao = new SqlConnection(enderecoConexao);

    conexao.Open();

    string sqlloginUse = "SELECT * FROM tipoUse WHERE loginUse = @loginUse AND senhaUse = @senhaUse";

    SqlCommand comando = new SqlCommand(sqlloginUse, conexao);

    comando.Parameters.AddWithValue("@loginUse", user.loginUse);
            comando.Parameters.AddWithValue("@senhaUse", user.senhaUse);

            SqlDataReader dados = comando.ExecuteReader();

            TipoUse us = null;

    if(dados.Read()){
        
        us = new TipoUse();
        us.id_tipoUse = dados.GetInt32("id_tipoUse");
        
        if(!dados.IsDBNull(dados.GetOrdinal("loginUse")))
        us.loginUse = dados.GetString("loginUse");

        if(!dados.IsDBNull(dados.GetOrdinal("senhaUse")))
        us.senhaUse = dados.GetString("senhaUse");

        if(!dados.IsDBNull(dados.GetOrdinal("contaUse")))
        us.contaUse = dados.GetString("contaUse");

         if(!dados.IsDBNull(dados.GetOrdinal("nomeUse")))
        us.nomeUse = dados.GetString("nomeUse");
    }

    conexao.Close();
    return us;

    }



    
 }
}