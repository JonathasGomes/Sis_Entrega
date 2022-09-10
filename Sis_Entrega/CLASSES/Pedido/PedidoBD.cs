/********************************************************************************************************************
 * NOME: PedidoBD 
 * CLASSE: Esta classe representa a Entidade de controle dos Pedidos na TB_Pedido
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
    class PedidoBD
    {
        //Metodo de destruição da Classe
        ~PedidoBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um Pedido na TB_Pedido
        * PARAMETRO: Pedido (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_PEDIDO)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (Pedido pobj_Pedido)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_PEDIDO " +
                           " ( " +
                           " I_COD_CLIENTE, " +
                           " I_STATUS_PEDIDO, " +
                           " DT_LANC_PEDIDO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_CLIENTE, " +
                           " @I_STATUS_PEDIDO, " +
                           " @DT_LANC_PEDIDO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_PEDIDO') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_CMD.Parameters.AddWithValue("@I_STATUS_PEDIDO", pobj_Pedido.Status_Pedido);
            obj_CMD.Parameters.AddWithValue("@DT_LANC_PEDIDO", pobj_Pedido.Lanc_Pedido);


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
        * CLASSE: Responsável por alterar um Pedido na TB_Pedido
        * PARAMETRO: Pedido (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Alterar(Pedido pobj_Pedido)
        {
            bool b_Alterado = false;

            //Possível testagem do código para verificar se é -1

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " UPDATE TB_PEDIDO SET " +
                           " I_COD_CLIENTE   = @I_COD_CLIENTE,  " +
                           " I_STATUS_PEDIDO   = @I_STATUS_PEDIDO,  " +
                           " DT_LANC_PEDIDO = @DT_LANC_PEDIDO " +
                           " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_PEDIDO", pobj_Pedido.Cod_Pedido);
            obj_CMD.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Pedido.Cod_Cliente);
            obj_CMD.Parameters.AddWithValue("@I_STATUS_PEDIDO", pobj_Pedido.Status_Pedido);
            obj_CMD.Parameters.AddWithValue("@DT_LANC_PEDIDO", pobj_Pedido.Lanc_Pedido);

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
        * CLASSE: Responsável por excluir um Pedido na TB_Pedido
        * PARAMETRO: Pedido (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(Pedido pobj_Pedido)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_PEDIDO " +
                           " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

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
        * NOME: FindAllPedido 
        * CLASSE: Responsável por trazer todos os Pedidos cadastrados na TB_Pedido
        * RETORNO: Lista (Lista de Pedido)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<Pedido> FindAllPedido()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<Pedido> Lista_Pedido = new List<Pedido>();

            string s_SQL = " SELECT * FROM TB_PEDIDO ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        Pedido obj_Pedido = new Pedido();

                        obj_Pedido.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                        obj_Pedido.Cod_Cliente = Convert.ToInt16(obj_DTR["S_UNM_PEDIDO"]);
                        obj_Pedido.Status_Pedido  = Convert.ToInt16(obj_DTR["S_PW_PEDIDO"]);
                        obj_Pedido.Lanc_Pedido = Convert.ToDateTime(obj_DTR["S_PW_PEDIDO"]);


                        Lista_Pedido.Add(obj_Pedido);

                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_Pedido;

        }

        /********************************************************************************************************************
        * NOME: FindByPedido 
        * CLASSE: Responsável por trazer um Pedido cadastrado na TB_Pedido
        * PARAMETRO: Pedido
        * RETORNO: Pedido  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public Pedido FindByPedido(Pedido pobj_Pedido)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_PEDIDO "+
                           " WHERE I_COD_PEDIDO = @I_COD_PEDIDO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_PEDIDO", pobj_Pedido.Cod_Pedido);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    pobj_Pedido.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                    pobj_Pedido.Cod_Cliente = Convert.ToInt16(obj_DTR["S_UNM_PEDIDO"]);
                    pobj_Pedido.Status_Pedido = Convert.ToInt16(obj_DTR["S_PW_PEDIDO"]);
                    pobj_Pedido.Lanc_Pedido = Convert.ToDateTime(obj_DTR["S_PW_PEDIDO"]);
                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_Pedido;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
