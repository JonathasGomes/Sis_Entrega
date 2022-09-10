/********************************************************************************************************************
 * NOME: ClienteBD 
 * CLASSE: Esta classe representa a Entidade de controle dos Clientes na TB_Cliente
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
    class ClienteBD
    {
        //Metodo de destruição da Classe
        ~ClienteBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um Cliente na TB_Cliente
        * PARAMETRO: Cliente (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_CLIENTE)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (Cliente pobj_Cliente)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_CLIENTE " +
                           " ( " +
                           " S_NM_CLIENTE, " +
                           " S_DOC_CLIENTE, " +
                           " S_END_CLIENTE, " +
                           " S_BAI_CLIENTE, " +
                           " S_CID_CLIENTE, " +
                           " S_UF_CLIENTE, " +
                           " S_CEP_CLIENTE, " +
                           " S_EMAIL_CLIENTE, " +
                           " S_CEL_CLIENTE " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_CLIENTE, " +
                           " @S_DOC_CLIENTE, " +
                           " @S_END_CLIENTE, " +
                           " @S_BAI_CLIENTE, " +
                           " @S_CID_CLIENTE, " +
                           " @S_UF_CLIENTE, " +
                           " @S_CEP_CLIENTE, " +
                           " @S_EMAIL_CLIENTE, " +
                           " @S_CEL_CLIENTE " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_CLIENTE') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            obj_CMD.Parameters.AddWithValue("S_DOC_CLIENTE", pobj_Cliente.Doc_Cliente);
            obj_CMD.Parameters.AddWithValue("S_END_CLIENTE", pobj_Cliente.End_Cliente);
            obj_CMD.Parameters.AddWithValue("S_BAI_CLIENTE", pobj_Cliente.Bai_Cliente);
            obj_CMD.Parameters.AddWithValue("S_CID_CLIENTE", pobj_Cliente.Cid_Cliente);
            obj_CMD.Parameters.AddWithValue("S_UF_CLIENTE", pobj_Cliente.UF_Cliente);
            obj_CMD.Parameters.AddWithValue("S_CEP_CLIENTE", pobj_Cliente.CEP_Cliente);
            obj_CMD.Parameters.AddWithValue("S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            obj_CMD.Parameters.AddWithValue("S_CEL_CLIENTE", pobj_Cliente.Cel_Cliente);


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
        * CLASSE: Responsável por alterar um Cliente na TB_Cliente
        * PARAMETRO: Cliente (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Alterar(Cliente pobj_Cliente)
        {
            bool b_Alterado = false;

            //Possível testagem do código para verificar se é -1

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " UPDATE TB_CLIENTE SET " +
                           " S_NM_CLIENTE = @S_NM_CLIENTE,  " +
                           " S_DOC_CLIENTE = @S_DOC_CLIENTE, " +
                           " S_END_CLIENTE = @S_END_CLIENTE, " +
                           " S_BAI_CLIENTE = @S_BAI_CLIENTE, " +
                           " S_CID_CLIENTE = @S_CID_CLIENTE, " +
                           " S_UF_CLIENTE = @S_UF_CLIENTE, " +
                           " S_CEP_CLIENTE = @S_CEP_CLIENTE, " +
                           " S_EMAIL_CLIENTE = @S_EMAIL_CLIENTE , " +
                           " S_CEL_CLIENTE = @S_CEL_CLIENTE " +
                           " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_NM_CLIENTE", pobj_Cliente.Nm_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_DOC_CLIENTE", pobj_Cliente.Doc_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_END_CLIENTE", pobj_Cliente.End_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_BAI_CLIENTE", pobj_Cliente.Bai_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_CID_CLIENTE", pobj_Cliente.Cid_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_UF_CLIENTE", pobj_Cliente.UF_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_CEP_CLIENTE", pobj_Cliente.CEP_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_EMAIL_CLIENTE", pobj_Cliente.Email_Cliente);
            obj_CMD.Parameters.AddWithValue("@S_CEL_CLIENTE", pobj_Cliente.Cel_Cliente);

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
        * CLASSE: Responsável por excluir um Cliente na TB_Cliente
        * PARAMETRO: Cliente (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(Cliente pobj_Cliente)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_CLIENTE " +
                           " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

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
        * NOME: FindAllCliente 
        * CLASSE: Responsável por trazer todos os Clientes cadastrados na TB_Cliente
        * RETORNO: Lista (Lista de Cliente)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<Cliente> FindAllCliente()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<Cliente> Lista_Cliente = new List<Cliente>();

            string s_SQL = " SELECT * FROM TB_CLIENTE ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        Cliente obj_Cliente = new Cliente();

                        obj_Cliente.Cod_Cliente= Convert.ToInt16(obj_DTR["I_COD_CLIENTE"]);
                        obj_Cliente.Nm_Cliente= obj_DTR["S_NM_CLIENTE"].ToString();
                        obj_Cliente.Doc_Cliente= obj_DTR["S_DOC_CLIENTE"].ToString();
                        obj_Cliente.End_Cliente= obj_DTR["S_END_CLIENTE"].ToString();
                        obj_Cliente.Bai_Cliente= obj_DTR["S_BAI_CLIENTE"].ToString();
                        obj_Cliente.Cid_Cliente= obj_DTR["S_CID_CLIENTE"].ToString();
                        obj_Cliente.UF_Cliente= obj_DTR["S_UF_CLIENTE"].ToString();
                        obj_Cliente.CEP_Cliente= obj_DTR["S_CEP_CLIENTE"].ToString();
                        obj_Cliente.Email_Cliente= obj_DTR["S_EMAIL_CLIENTE"].ToString();
                        obj_Cliente.Cel_Cliente= obj_DTR["S_CEL_CLIENTE"].ToString();

                        Lista_Cliente.Add(obj_Cliente);
                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_Cliente;

        }

        /********************************************************************************************************************
        * NOME: FindByCliente 
        * CLASSE: Responsável por trazer um Cliente cadastrado na TB_Cliente
        * PARAMETRO: Cliente
        * RETORNO: Cliente  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public Cliente FindByCliente(Cliente pobj_Cliente)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_CLIENTE "+
                           " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    obj_DTR.Read();

                    pobj_Cliente.Cod_Cliente = Convert.ToInt16(obj_DTR["I_COD_CLIENTE"]);
                    pobj_Cliente.Nm_Cliente = obj_DTR["S_NM_CLIENTE"].ToString();
                    pobj_Cliente.Doc_Cliente = obj_DTR["S_DOC_CLIENTE"].ToString();
                    pobj_Cliente.End_Cliente = obj_DTR["S_END_CLIENTE"].ToString();
                    pobj_Cliente.Bai_Cliente = obj_DTR["S_BAI_CLIENTE"].ToString();
                    pobj_Cliente.Cid_Cliente = obj_DTR["S_CID_CLIENTE"].ToString();
                    pobj_Cliente.UF_Cliente = obj_DTR["S_UF_CLIENTE"].ToString();
                    pobj_Cliente.CEP_Cliente = obj_DTR["S_CEP_CLIENTE"].ToString();
                    pobj_Cliente.Email_Cliente = obj_DTR["S_EMAIL_CLIENTE"].ToString();
                    pobj_Cliente.Cel_Cliente = obj_DTR["S_CEL_CLIENTE"].ToString();
                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_Cliente;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
