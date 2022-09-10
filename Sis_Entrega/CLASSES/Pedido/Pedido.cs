/********************************************************************************************************************
 * NOME: Pedido 
 * CLASSE: Esta classe representa a Entidade Pedido
 * DT. CRIAÇÃO: 26/02/2021
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
    class Pedido
    {
        // Metodo de destruição da classe
        ~Pedido()
        {
        }

        #region Atributos
        private int v_Cod_Pedido = -1;
        private int v_Cod_Cliente = -1;
        private int v_Status_Pedido = 0;
        private DateTime v_Lanc_Pedido = DateTime.MinValue;

        #endregion


        #region Métodos
        public int Cod_Pedido 
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }

        public int Cod_Cliente 
        { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value; 
        }

        public int Status_Pedido 
        { 
            get => v_Status_Pedido; 
            set => v_Status_Pedido = value; 
        }

        public DateTime Lanc_Pedido 
        { 
            get => v_Lanc_Pedido; 
            set => v_Lanc_Pedido = value; 
        }

        #endregion

    }
}

