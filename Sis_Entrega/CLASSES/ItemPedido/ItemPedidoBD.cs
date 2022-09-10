/********************************************************************************************************************
 * NOME: ItemPedidoBD 
 * CLASSE: Esta classe representa a Entidade de controle dos ItemPedidos na TB_ItemPedido
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
    class ItemPedidoBD
    {
        //Metodo de destruição da Classe
        ~ItemPedidoBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um ItemPedido na TB_ItemPedido
        * PARAMETRO: ItemPedido (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_ITEMPEDIDO)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (ItemPedido pobj_ItemPedido)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_ITEMPEDIDO " +
                           " ( " +
                           " I_COD_PEDIDO, " +
                           " I_COD_PRODUTO, " +
                           " I_QTDE_ITEMPEDIDO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_PEDIDO, " +
                           " @I_COD_PRODUTO, " +
                           " @I_QTDE_ITEMPEDIDO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_ITEMPEDIDO') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_ItemPedido.Cod_Pedido);
            obj_CMD.Parameters.AddWithValue("@I_COD_PRODUTO", pobj_ItemPedido.Cod_Produto);
            obj_CMD.Parameters.AddWithValue("@I_QTDE_ITEMPEDIDO", pobj_ItemPedido.Qtde_ItemPedido);


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
        * NOME: Excluir 
        * CLASSE: Responsável por excluir um ItemPedido na TB_ItemPedido
        * PARAMETRO: ItemPedido (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(ItemPedido pobj_ItemPedido)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_ITEMPEDIDO " +
                           " WHERE I_COD_ITEMPEDIDO = @I_COD_ITEMPEDIDO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_ITEMPEDIDO", pobj_ItemPedido.Cod_ItemPedido);

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
        * NOME: FindAllItemPedido 
        * CLASSE: Responsável por trazer todos os ItemPedidos cadastrados na TB_ItemPedido
        * RETORNO: Lista (Lista de ItemPedido)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<ItemPedido> FindAllItemPedido()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<ItemPedido> Lista_ItemPedido = new List<ItemPedido>();

            string s_SQL = " SELECT * FROM TB_ITEMPEDIDO ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        ItemPedido obj_ItemPedido = new ItemPedido();

                        obj_ItemPedido.Cod_ItemPedido = Convert.ToInt16(obj_DTR["I_COD_ITEMPEDIDO"]);
                        obj_ItemPedido.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                        obj_ItemPedido.Cod_Produto  = Convert.ToInt16(obj_DTR["I_COD_PRODUTO"]);
                        obj_ItemPedido.Qtde_ItemPedido = Convert.ToInt16(obj_DTR["I_QTDE_ITEMPEDIDO"]);


                        Lista_ItemPedido.Add(obj_ItemPedido);

                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_ItemPedido;

        }

        /********************************************************************************************************************
        * NOME: FindByItemPedido 
        * CLASSE: Responsável por trazer um ItemPedido cadastrado na TB_ItemPedido
        * PARAMETRO: ItemPedido
        * RETORNO: ItemPedido  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public ItemPedido FindByItemPedido(ItemPedido pobj_ItemPedido)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_ITEMPEDIDO "+
                           " WHERE I_COD_ITEMPEDIDO = @I_COD_ITEMPEDIDO ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_ITEMPEDIDO", pobj_ItemPedido.Cod_ItemPedido);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    pobj_ItemPedido.Cod_ItemPedido = Convert.ToInt16(obj_DTR["I_COD_ITEMPEDIDO"]);
                    pobj_ItemPedido.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                    pobj_ItemPedido.Cod_Produto = Convert.ToInt16(obj_DTR["I_COD_PRODUTO"]);
                    pobj_ItemPedido.Qtde_ItemPedido = Convert.ToInt16(obj_DTR["I_QTDE_ITEMPEDIDO"]);

                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_ItemPedido;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
