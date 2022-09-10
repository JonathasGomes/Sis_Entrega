/********************************************************************************************************************
 * NOME: Status 
 * CLASSE: Esta classe representa a Entidade Status
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
    class Status
    {
        // Metodo de destruição da classe
        ~Status()
        {
        }

        #region Atributos
        private int v_Cod_Status = -1;
        private string v_Fase_Status = "";
        #endregion

        #region Metodos
        public int Cod_Status 
        { 
            get => v_Cod_Status; 
            set => v_Cod_Status = value; 
        }

        public string Fase_Status 
        { 
            get => v_Fase_Status; 
            set => v_Fase_Status = value; 
        }
        #endregion
    }
}
