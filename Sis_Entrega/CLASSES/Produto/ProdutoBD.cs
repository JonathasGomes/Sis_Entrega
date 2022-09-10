/********************************************************************************************************************
 * NOME: ProdutoBD 
 * CLASSE: Esta classe representa a Entidade de controle dos Produtos na TB_Produto
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
    class ProdutoBD
    {
        //Metodo de destruição da Classe
        ~ProdutoBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um Produto na TB_Produto
        * PARAMETRO: Produto (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_PRODUTO)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (Produto pobj_Produto)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_PRODUTO " +
                           " ( " +
                           " S_NM_PRODUTO, " +
                           " D_VLR_PRODUTO, " +
                           " S_DESC_PRODUTO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_PRODUTO, " +
                           " @D_VLR_PRODUTO, " +
                           " @S_DESC_PRODUTO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_PRODUTO') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_NM_PRODUTO", pobj_Produto.Nm_Produto);
            obj_CMD.Parameters.AddWithValue("@D_VLR_PRODUTO", pobj_Produto.Vlr_Produto);
            obj_CMD.Parameters.AddWithValue("@S_DESC_PRODUTO", pobj_Produto.Desc_Produto);

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
        * CLASSE: Responsável por alterar um Produto na TB_Produto
        * PARAMETRO: Produto (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Alterar(Produto pobj_Produto)
        {
            bool b_Alterado = false;

            //Possível testagem do código para verificar se é -1

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " UPDATE TB_PRODUTO SET " +
                           " S_NM_PRODUTO   = @S_NM_PRODUTO,  " +
                           " D_VLR_PRODUTO  = @D_VLR_PRODUTO, " +
                           " S_DESC_PRODUTO = @S_DESC_PRODUTO " +
                           " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);
            obj_CMD.Parameters.AddWithValue("@S_NM_PRODUTO", pobj_Produto.Nm_Produto);
            obj_CMD.Parameters.AddWithValue("@D_VLR_PRODUTO", pobj_Produto.Vlr_Produto);
            obj_CMD.Parameters.AddWithValue("@S_DESC_PRODUTO", pobj_Produto.Desc_Produto);

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
        * CLASSE: Responsável por excluir um Produto na TB_Produto
        * PARAMETRO: Produto (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(Produto pobj_Produto)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_PRODUTO " +
                           " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);

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
        * NOME: FindAllProduto 
        * CLASSE: Responsável por trazer todos os Produtos cadastrados na TB_Produto
        * RETORNO: Lista (Lista de Produto)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<Produto> FindAllProduto()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<Produto> Lista_Produto = new List<Produto>();

            string s_SQL = " SELECT * FROM TB_PRODUTO ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        Produto obj_Produto = new Produto();

                        obj_Produto.Cod_Produto = Convert.ToInt16(obj_DTR["I_COD_PRODUTO"]);
                        obj_Produto.Nm_Produto = obj_DTR["S_NM_PRODUTO"].ToString();
                        obj_Produto.Vlr_Produto = Convert.ToDouble(obj_DTR["D_VLR_PRODUTO"]);
                        obj_Produto.Desc_Produto = obj_DTR["S_DESC_PRODUTO"].ToString();

                        Lista_Produto.Add(obj_Produto);

                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_Produto;

        }

        /********************************************************************************************************************
        * NOME: FindByProduto 
        * CLASSE: Responsável por trazer um Produto cadastrado na TB_Produto
        * PARAMETRO: Produto
        * RETORNO: Produto  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public Produto FindByProduto(Produto pobj_Produto)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_PRODUTO "+
                           " WHERE I_COD_PRODUTO = @I_COD_PRODUTO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_Produto.Cod_Produto);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    obj_DTR.Read();
                    pobj_Produto.Cod_Produto = Convert.ToInt16(obj_DTR["I_COD_PRODUTO"]);
                    pobj_Produto.Nm_Produto = obj_DTR["S_NM_PRODUTO"].ToString();
                    pobj_Produto.Vlr_Produto = Convert.ToDouble(obj_DTR["D_VLR_PRODUTO"]);
                    pobj_Produto.Desc_Produto = obj_DTR["S_DESC_PRODUTO"].ToString();
                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_Produto;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
