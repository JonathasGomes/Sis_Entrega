/********************************************************************************************************************
 * NOME: HistoricoStatus 
 * CLASSE: Esta classe representa a Entidade HistoricoStatus
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
    class HistoricoStatus
    {
        // Metodo de destruição da classe
        ~HistoricoStatus()
        {
        }

        #region Atributos
        private int v_Cod_HistoricoStatus = -1;
        private int v_Cod_Pedido = -1;
        private int v_Fase_HistoricoStatus = 0;
        private DateTime v_Lanc_HistoricoStatus = DateTime.MinValue;
        #endregion

        #region Metodos
        public int Cod_HistoricoStatus 
        { 
            get => v_Cod_HistoricoStatus; 
            set => v_Cod_HistoricoStatus = value; 
        }

        public int Cod_Pedido 
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }

        public int Fase_HistoricoStatus 
        { 
            get => v_Fase_HistoricoStatus; 
            set => v_Fase_HistoricoStatus = value; 
        }

        public DateTime Lanc_HistoricoStatus 
        { 
            get => v_Lanc_HistoricoStatus; 
            set => v_Lanc_HistoricoStatus = value; 
        }

        #endregion
    }
}
