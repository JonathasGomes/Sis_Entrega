/********************************************************************************************************************
 * NOME: UsuarioBD 
 * CLASSE: Esta classe representa a Entidade de controle dos Usuarios na TB_Usuario
 * DT. CRIAÇÃO: 26/02/2021
 * DT. ALTERAÇÃO: --
 *                --
 * CRIADA POR: mFacine (Monstro)               
 * OBSERVAÇÃO: 
 * ******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sis_Entrega
{
    class UsuarioBD
    {
        //Metodo de destruição da Classe
        ~UsuarioBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um Usuario na TB_Usuario
        * PARAMETRO: Usuario (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_USUARIO)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (Usuario pobj_Usuario)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_USUARIO " +
                           " ( " +
                           " S_UNM_USUARIO, " +
                           " S_PW_USUARIO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_UNM_USUARIO, " +
                           " @S_PW_USUARIO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_USUARIO') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_UNM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_CMD.Parameters.AddWithValue("@S_PW_USUARIO", pobj_Usuario.PW_Usuario);

            try
            {
                obj_CONN.Open();
                
                i_ID = Convert.ToInt16(obj_CMD.ExecuteScalar());

                obj_CONN.Close();
            }
            catch(Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS",MessageBoxButtons.OK,MessageBoxIcon.Error);   
            }

            return i_ID;
        }

        /********************************************************************************************************************
        * NOME: Alterar 
        * CLASSE: Responsável por alterar um Usuario na TB_Usuario
        * PARAMETRO: Usuario (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Alterar(Usuario pobj_Usuario)
        {
            bool b_Alterado = false;

            //Possível testagem do código para verificar se é -1

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " UPDATE TB_USUARIO SET " +
                           " S_UNM_USUARIO   = @S_UNM_USUARIO,  " +
                           " S_PW_USUARIO = @S_PW_USUARIO " +
                           " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_USUARIO", pobj_Usuario.Cod_Usuario);
            obj_CMD.Parameters.AddWithValue("@S_NM_USUARIO", pobj_Usuario.UNm_Usuario);
            obj_CMD.Parameters.AddWithValue("@S_DESC_USUARIO", pobj_Usuario.PW_Usuario);

            try
            {
                obj_CONN.Open();

                obj_CMD.ExecuteNonQuery();

                obj_CONN.Close();

                b_Alterado = true;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return b_Alterado;
        }

        /********************************************************************************************************************
        * NOME: Excluir 
        * CLASSE: Responsável por excluir um Usuario na TB_Usuario
        * PARAMETRO: Usuario (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(Usuario pobj_Usuario)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_USUARIO " +
                           " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                obj_CONN.Open();

                obj_CMD.ExecuteNonQuery();

                obj_CONN.Close();

                b_Excluido = true;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return b_Excluido;
        }

        /********************************************************************************************************************
        * NOME: FindAllUsuario 
        * CLASSE: Responsável por trazer todos os Usuarios cadastrados na TB_Usuario
        * RETORNO: Lista (Lista de Usuario)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<Usuario> FindAllUsuario()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<Usuario> Lista_Usuario = new List<Usuario>();

            string s_SQL = " SELECT * FROM TB_USUARIO ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        Usuario obj_Usuario = new Usuario();

                        obj_Usuario.Cod_Usuario = Convert.ToInt16(obj_DTR["I_COD_USUARIO"]);
                        obj_Usuario.UNm_Usuario = obj_DTR["S_UNM_USUARIO"].ToString();
                        obj_Usuario.PW_Usuario = obj_DTR["S_PW_USUARIO"].ToString();

                        Lista_Usuario.Add(obj_Usuario);

                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_Usuario;

        }

        /********************************************************************************************************************
        * NOME: FindByUsuario 
        * CLASSE: Responsável por trazer um Usuario cadastrado na TB_Usuario
        * PARAMETRO: Usuario
        * RETORNO: Usuario  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public Usuario FindByUsuario(Usuario pobj_Usuario)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_USUARIO "+
                           " WHERE I_COD_USUARIO = @I_COD_USUARIO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_USUARIO", pobj_Usuario.Cod_Usuario);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    pobj_Usuario.Cod_Usuario = Convert.ToInt16(obj_DTR["I_COD_USUARIO"]);
                    pobj_Usuario.UNm_Usuario = obj_DTR["S_UNM_USUARIO"].ToString();
                    pobj_Usuario.PW_Usuario = obj_DTR["S_PW_USUARIO"].ToString();
                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_Usuario;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
