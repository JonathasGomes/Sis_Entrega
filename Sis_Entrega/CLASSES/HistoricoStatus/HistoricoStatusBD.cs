/********************************************************************************************************************
 * NOME: HistoricoStatusBD 
 * CLASSE: Esta classe representa a Entidade de controle dos HistoricoStatuss na TB_HistoricoStatus
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
    class HistoricoStatusBD
    {
        //Metodo de destruição da Classe
        ~HistoricoStatusBD()
        {
        }

        /********************************************************************************************************************
        * NOME: Incluir 
        * CLASSE: Responsável por incluir um HistoricoStatus na TB_HistoricoStatus
        * PARAMETRO: HistoricoStatus (Objeto da Classe)  
        * RETORNO: int (Ultimo Identificados da TB_HISTORICOSTATUS)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public int Incluir (HistoricoStatus pobj_HistoricoStatus)
        {
            int i_ID = -1;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " INSERT INTO TB_HISTORICOSTATUS " +
                           " ( " +
                           " I_COD_PEDIDO, " +
                           " I_FASE_HISTORICOSTATUS, "+
                           " DT_LANC_HISTORICOSTATUS " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_PEDIDO, " +
                           " @I_FASE_HISTORICOSTATUS, " +
                           " @DT_LANC_HISTORICOSTATUS " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_HISTORICOSTATUS') AS 'ID' ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_HistoricoStatus.Cod_Pedido);
            obj_CMD.Parameters.AddWithValue("@I_FASE_HISTORICOSTATUS", pobj_HistoricoStatus.Fase_HistoricoStatus);
            obj_CMD.Parameters.AddWithValue("@DT_LANC_HISTORICOSTATUS", pobj_HistoricoStatus.Lanc_HistoricoStatus);

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
        * CLASSE: Responsável por alterar um HistoricoStatus na TB_HistoricoStatus
        * PARAMETRO: HistoricoStatus (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Alterar(HistoricoStatus pobj_HistoricoStatus)
        {
            bool b_Alterado = false;

            //Possível testagem do código para verificar se é -1

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " UPDATE TB_HISTORICOSTATUS SET " +
                           " I_COD_PEDIDO   = @I_COD_PEDIDO,  " +
                           " I_FASE_HISTORICOSTATUS  = @I_FASE_HISTORICOSTATUS, " +
                           " DT_LANC_HISTORICOSTATUS = @DT_LANC_HISTORICOSTATUS " +
                           " WHERE I_COD_HISTORICOSTATUS = @I_COD_HISTORICOSTATUS ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_HISTORICOSTATUS", pobj_HistoricoStatus.Cod_HistoricoStatus);
            obj_CMD.Parameters.AddWithValue("@I_COD_PEDIDO", pobj_HistoricoStatus.Cod_Pedido);
            obj_CMD.Parameters.AddWithValue("@S_FASE_HISTORICOSTATUS", pobj_HistoricoStatus.Fase_HistoricoStatus);
            obj_CMD.Parameters.AddWithValue("@DT_LANC_HISTORICOSTATUS", pobj_HistoricoStatus.Lanc_HistoricoStatus);

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
        * CLASSE: Responsável por excluir um HistoricoStatus na TB_HistoricoStatus
        * PARAMETRO: HistoricoStatus (Objeto da Classe)  
        * RETORNO: bool (Alterado (true/false)?)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public bool Excluir(HistoricoStatus pobj_HistoricoStatus)
        {
            bool b_Excluido = false;

            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " DELETE FROM TB_HISTORICOSTATUS " +
                           " WHERE I_COD_HISTORICOSTATUS = @I_COD_HISTORICOSTATUS ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_HISTORICOSTATUS", pobj_HistoricoStatus.Cod_HistoricoStatus);

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
        * NOME: FindAllHistoricoStatus 
        * CLASSE: Responsável por trazer todos os HistoricoStatuss cadastrados na TB_HistoricoStatus
        * RETORNO: Lista (Lista de HistoricoStatus)  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public List<HistoricoStatus> FindAllHistoricoStatus()
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            List<HistoricoStatus> Lista_HistoricoStatus = new List<HistoricoStatus>();

            string s_SQL = " SELECT * FROM TB_HISTORICOSTATUS ";
                           
            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    while (obj_DTR.Read())
                    {
                        HistoricoStatus obj_HistoricoStatus = new HistoricoStatus();

                        obj_HistoricoStatus.Cod_HistoricoStatus = Convert.ToInt16(obj_DTR["I_COD_HISTORICOSTATUS"]);
                        obj_HistoricoStatus.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                        obj_HistoricoStatus.Fase_HistoricoStatus = Convert.ToInt16(obj_DTR["I_FASE_HISTORICOSTATUS"]);
                        obj_HistoricoStatus.Lanc_HistoricoStatus = Convert.ToDateTime(obj_DTR["DT_LANC_HISTORICOSTATUS"]);

                        Lista_HistoricoStatus.Add(obj_HistoricoStatus);

                    }
                }

                obj_CONN.Close();
                obj_DTR.Close();

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Lista_HistoricoStatus;

        }

        /********************************************************************************************************************
        * NOME: FindByHistoricoStatus 
        * CLASSE: Responsável por trazer um HistoricoStatus cadastrado na TB_HistoricoStatus
        * PARAMETRO: HistoricoStatus
        * RETORNO: HistoricoStatus  
        * DT. CRIAÇÃO: 26/02/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public HistoricoStatus FindByHistoricoStatus(HistoricoStatus pobj_HistoricoStatus)
        {
            //Conexão com o Banco de Dados
            SqlConnection obj_CONN = new SqlConnection(Connection.Connection_Path());

            string s_SQL = " SELECT * FROM TB_HISTORICOSTATUS "+
                           " WHERE I_COD_HISTORICOSTATUS = @I_COD_HISTORICOSTATUS ";

            SqlCommand obj_CMD = new SqlCommand(s_SQL, obj_CONN);

            obj_CMD.Parameters.AddWithValue("@S_COD_HISTORICOSTATUS", pobj_HistoricoStatus.Cod_HistoricoStatus);

            try
            {
                obj_CONN.Open();

                SqlDataReader obj_DTR = obj_CMD.ExecuteReader();

                if (obj_DTR.HasRows)
                {
                    pobj_HistoricoStatus.Cod_HistoricoStatus = Convert.ToInt16(obj_DTR["I_COD_HISTORICOSTATUS"]);
                    pobj_HistoricoStatus.Cod_Pedido = Convert.ToInt16(obj_DTR["I_COD_PEDIDO"]);
                    pobj_HistoricoStatus.Fase_HistoricoStatus = Convert.ToInt16(obj_DTR["I_FASE_HISTORICOSTATUS"]);
                    pobj_HistoricoStatus.Lanc_HistoricoStatus = Convert.ToDateTime(obj_DTR["DT_LANC_HISTORICOSTATUS"]);
                }

                obj_CONN.Close();
                obj_DTR.Close();
                return pobj_HistoricoStatus;

            }
            catch (Exception Erro)
            {
                MessageBox.Show(Erro.Message, "ERRO NO BANCO DE DADOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            
        }
    }
}
