/********************************************************************************************************************
 * NOME: Cliente 
 * CLASSE: Esta classe representa a Entidade Cliente
 * DT. CRIAÇÃO: 25/02/2021
 * DT. ALTERAÇÃO: --
 *                --
 * CRIADA POR: mFacine (Monstro)               
 * OBSERVAÇÃO: A Classe possui atributos privados e métodos públicos
 * ******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sis_Entrega
{
    class Cliente
    {
        // Metodo de destruição da classe
        ~Cliente()
        {
        }

        #region Atributos
        private int v_Cod_Cliente = -1;
        private string v_Nm_Cliente = "";
        private string v_Doc_Cliente = "";
        private string v_End_Cliente = "";
        private string v_Bai_Cliente = "";
        private string v_Cid_Cliente = "";
        private string v_UF_Cliente = "";
        private string v_CEP_Cliente = "";
        private string v_Email_Cliente = "";
        private string v_Cel_Cliente = "";
        #endregion

        #region Métodos
        public int Cod_Cliente 
        { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value; 
        }

        public string Nm_Cliente 
        { 
            get => v_Nm_Cliente; 
            set => v_Nm_Cliente = value; 
        }

        public string Doc_Cliente 
        { 
            get => v_Doc_Cliente; 
            set => v_Doc_Cliente = value; 
        }

        public string End_Cliente 
        { 
            get => v_End_Cliente; 
            set => v_End_Cliente = value; 
        }

        public string Bai_Cliente 
        { 
            get => v_Bai_Cliente; 
            set => v_Bai_Cliente = value; 
        }

        public string Cid_Cliente 
        { 
            get => v_Cid_Cliente; 
            set => v_Cid_Cliente = value; 
        }

        public string UF_Cliente 
        { 
            get => v_UF_Cliente; 
            set => v_UF_Cliente = value; 
        }

        public string CEP_Cliente 
        { 
            get => v_CEP_Cliente; 
            set => v_CEP_Cliente = value; 
        }

        public string Email_Cliente 
        { 
            get => v_Email_Cliente; 
            set => v_Email_Cliente = value; 
        }

        public string Cel_Cliente 
        { 
            get => v_Cel_Cliente; 
            set => v_Cel_Cliente = value; 
        }
        #endregion

    }
}
