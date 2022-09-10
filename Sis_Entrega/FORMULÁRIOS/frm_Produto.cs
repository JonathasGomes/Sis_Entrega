using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Entrega
{
    public partial class frm_Produto : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        Produto obj_Produto_Atual = new Produto();




        public frm_Produto()
        {
            InitializeComponent();
            //desabilitar a tela
            obj_FuncGeral.HabilitaTela(this, false);
            //Arrumar os botões da tela Status 0
            obj_FuncGeral.StatusBtn(this, 0);
            PopulaLista();

        }

        /********************************************************************************************************************
        * NOME: PopulaTela 
        * CLASSE: Responsável por popular os componentes editáveis do formulário 
        * PARAMETRO: Classe Produto
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private void PopulaTela(Produto pobj_Produto)
        {
            if (pobj_Produto.Cod_Produto != -1)
            {
                tbox_Cod_Produto.Text = pobj_Produto.Cod_Produto.ToString();
            }
            tbox_Nm_Produto.Text = pobj_Produto.Nm_Produto;
            tbox_Vlr_Produto.Text = pobj_Produto.Vlr_Produto.ToString();
            tbox_Desc_Produto.Text = pobj_Produto.Desc_Produto;

        }

        /********************************************************************************************************************
        * NOME: PopulaObjeto
        * CLASSE: Responsável por popular os componentes editáveis do formulário 
        * PARAMETRO: Objeto Produto
        * RETORNO: Objeto Produto
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private Produto PopulaObjeto()
        {
            Produto obj_Produto = new Produto();

            if (tbox_Cod_Produto.Text != "")
            {
                obj_Produto.Cod_Produto = Convert.ToInt16(tbox_Cod_Produto.Text);
            }
            obj_Produto.Nm_Produto = tbox_Nm_Produto.Text;
            obj_Produto.Vlr_Produto = Convert.ToDouble(tbox_Vlr_Produto.Text);
            obj_Produto.Desc_Produto = tbox_Desc_Produto.Text;

            return obj_Produto;
        }


        /********************************************************************************************************************
        * NOME: PopulaLista
        * CLASSE: Responsável por popular a Lista do formulário 
        * RETORNO: Lista de Objetos Produto
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private void PopulaLista()
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            List<Produto> Lista = new List<Produto>();

            lbox_Produtos.Items.Clear();

            Lista = obj_ProdutoBD.FindAllProduto();

            if (Lista.Count != 0)
            {
                for (int i = 0; i <= Lista.Count - 1; i++)
                {
                    lbox_Produtos.Items.Add(Lista[i].Cod_Produto.ToString() + "-" + Lista[i].Nm_Produto);
                }
            }

        }



        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.LimpaTela(this);
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 2);
            tbox_Nm_Produto.Focus();

        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 2);
            tbox_Nm_Produto.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (obj_Produto_Atual.Cod_Produto != -1)
            {
                PopulaTela(obj_Produto_Atual);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
            }
            else
            {
                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 0);

            }
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            DialogResult dr_Resp = MessageBox.Show("Confirma a Exclusão do Produto " + obj_Produto_Atual.Nm_Produto + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr_Resp == DialogResult.Yes)
            {
                ProdutoBD obj_ProdutoBD = new ProdutoBD();

                if (obj_ProdutoBD.Excluir(obj_Produto_Atual)) ;
                {
                    MessageBox.Show("O Produto " + obj_Produto_Atual.Nm_Produto + " foi excluido com Sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 0);
                PopulaLista();

            }
            obj_Produto_Atual = new Produto();
        }

        private void lbox_Produtos_Click(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();

            if (lbox_Produtos.SelectedIndex != -1)
            {
                string s_Linha = lbox_Produtos.Items[lbox_Produtos.SelectedIndex].ToString();

                //1-Antônio
                //123-Marcia
                int i_Pos = 0;

                for (int i = 0; i <= s_Linha.Length - 1; i++)
                {
                    if (s_Linha.Substring(i, 1) == "-")
                    {
                        i_Pos = i;
                        break;
                    }
                }

                obj_Produto_Atual.Cod_Produto = Convert.ToInt16(s_Linha.Substring(0, i_Pos));
                obj_Produto_Atual = obj_ProdutoBD.FindByProduto(obj_Produto_Atual);

                PopulaTela(obj_Produto_Atual);

                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);

            }
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            ProdutoBD obj_ProdutoBD = new ProdutoBD();
            obj_Produto_Atual = PopulaObjeto();

            if (obj_Produto_Atual.Cod_Produto != -1)
            {
                //Alterar
                if (obj_ProdutoBD.Alterar(obj_Produto_Atual))
                {
                    MessageBox.Show("Alteração Realizada com Sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                //Incluir
                obj_Produto_Atual.Cod_Produto = obj_ProdutoBD.Incluir(obj_Produto_Atual);
                MessageBox.Show("Inclusão Realizada com Sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_Cod_Produto.Text = obj_Produto_Atual.Cod_Produto.ToString();
            }

            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaLista();

        }

        private void frm_Produto_Load(object sender, EventArgs e)
        {

        }

    }
}
