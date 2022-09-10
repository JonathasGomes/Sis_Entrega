/********************************************************************************************************************
 * NOME: ItemPedido 
 * CLASSE: Esta classe representa a Entidade ItemPedido
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
    class ItemPedido
    {
        // Metodo de destruição da classe
        ~ItemPedido()
        {
        }

        #region Atributos
        private int v_Cod_ItemPedido = -1;
        private int v_Cod_Pedido = -1;
        private int v_Cod_Produto = -1;
        private int v_Qtde_ItemPedido = 0;
        #endregion


        #region Métodos
        public int Cod_ItemPedido 
        { 
            get => v_Cod_ItemPedido; 
            set => v_Cod_ItemPedido = value; 
        }

        public int Cod_Pedido 
        { 
            get => v_Cod_Pedido; 
            set => v_Cod_Pedido = value; 
        }

        public int Cod_Produto 
        { 
            get => v_Cod_Produto; 
            set => v_Cod_Produto = value; 
        }

        public int Qtde_ItemPedido 
        { 
            get => v_Qtde_ItemPedido; 
            set => v_Qtde_ItemPedido = value; 
        }
        #endregion

    }
}

