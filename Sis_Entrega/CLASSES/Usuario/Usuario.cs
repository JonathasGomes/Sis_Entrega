/********************************************************************************************************************
 * NOME: Usuario 
 * CLASSE: Esta classe representa a Entidade Usuario
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
    class Usuario
    {
        // Metodo de destruição da classe
        ~Usuario()
        {
        }

        #region Atributos
        private int v_Cod_Usuario = -1;
        private string v_UNm_Usuario = "";
        private string v_PW_Usuario = "";
        #endregion

        #region Métodos
        public int Cod_Usuario 
        { 
            get => v_Cod_Usuario; 
            set => v_Cod_Usuario = value; 
        }
        
        public string UNm_Usuario 
        { 
            get => v_UNm_Usuario; 
            set => v_UNm_Usuario = value; 
        }

        public string PW_Usuario 
        { 
            get => v_PW_Usuario; 
            set => v_PW_Usuario = value; 
        }
        #endregion

    }
}
