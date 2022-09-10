/********************************************************************************************************************
 * NOME: Produto 
 * CLASSE: Esta classe representa a Entidade Produto
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
    class Produto
    {
        // Metodo de destruição da classe
        ~Produto()
        {
        }

        #region Atributos
        private int v_Cod_Produto = -1;
        private string v_Nm_Produto = "";
        private double v_Vlr_Produto = 0;
        private string v_Desc_Produto = "";
        #endregion

        #region Métodos
        public int Cod_Produto 
        { 
            get => v_Cod_Produto; 
            set => v_Cod_Produto = value; 
        }
        
        public string Nm_Produto 
        { get => v_Nm_Produto; 
            set => v_Nm_Produto = value; 
        }

        public double Vlr_Produto 
        { get => v_Vlr_Produto; 
            set => v_Vlr_Produto = value; 
        }

        public string Desc_Produto 
        { get => v_Desc_Produto; 
            set => v_Desc_Produto = value; 
        }
        #endregion

    }
}
