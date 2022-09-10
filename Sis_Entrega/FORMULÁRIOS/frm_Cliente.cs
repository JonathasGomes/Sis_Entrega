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
    public partial class frm_Cliente : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        Cliente obj_Cliente_Atual = new Cliente();




        public frm_Cliente()
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
        * PARAMETRO: Classe Cliente
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private void PopulaTela(Cliente pobj_Cliente)
        {
            if (pobj_Cliente.Cod_Cliente != -1)
            {
                tbox_Cod_Cliente.Text = pobj_Cliente.Cod_Cliente.ToString();
            }
            tbox_Nm_Cliente.Text = pobj_Cliente.Nm_Cliente;
            tbox_Doc_Cliente.Text = pobj_Cliente.Doc_Cliente;
            tbox_End_Cliente.Text = pobj_Cliente.End_Cliente;
            tbox_Bai_Cliente.Text = pobj_Cliente.Bai_Cliente;
            tbox_Cid_Cliente.Text = pobj_Cliente.Cid_Cliente;
            tbox_UF_Cliente.Text = pobj_Cliente.UF_Cliente;
            tbox_CEP_Cliente.Text = pobj_Cliente.CEP_Cliente;
            tbox_Email_Cliente.Text = pobj_Cliente.Email_Cliente;
            tbox_Cel_Cliente.Text = pobj_Cliente.Cel_Cliente;
        }

        /********************************************************************************************************************
        * NOME: PopulaObjeto
        * CLASSE: Responsável por popular os componentes editáveis do formulário 
        * PARAMETRO: Objeto Cliente
        * RETORNO: Objeto Cliente
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private Cliente PopulaObjeto()
        {
            Cliente obj_Cliente = new Cliente();

            if (tbox_Cod_Cliente.Text != "")
            {
                obj_Cliente.Cod_Cliente = Convert.ToInt16(tbox_Cod_Cliente.Text);
            }
            obj_Cliente.Nm_Cliente = tbox_Nm_Cliente.Text ;
            obj_Cliente.Doc_Cliente = tbox_Doc_Cliente.Text ;
            obj_Cliente.End_Cliente = tbox_End_Cliente.Text ;
            obj_Cliente.Bai_Cliente = tbox_Bai_Cliente.Text ;
            obj_Cliente.Cid_Cliente = tbox_Cid_Cliente.Text ;
            obj_Cliente.UF_Cliente = tbox_UF_Cliente.Text ;
            obj_Cliente.CEP_Cliente = tbox_CEP_Cliente.Text ;
            obj_Cliente.Email_Cliente = tbox_Email_Cliente.Text ;
            obj_Cliente.Cel_Cliente = tbox_Cel_Cliente.Text ;

            return obj_Cliente;
        }

        
        /********************************************************************************************************************
        * NOME: PopulaLista
        * CLASSE: Responsável por popular a Lista do formulário 
        * RETORNO: Lista de Objetos Cliente
        * DT. CRIAÇÃO: 05/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        private void PopulaLista()
        {
            ClienteBD obj_ClienteBD = new ClienteBD();
            List<Cliente> Lista = new List<Cliente>();

            lbox_Clientes.Items.Clear();

            Lista = obj_ClienteBD.FindAllCliente();

            if ( Lista.Count != 0)
            {
                for (int i = 0; i <= Lista.Count -1; i++)
                {
                    lbox_Clientes.Items.Add(Lista[i].Cod_Cliente.ToString() + "-" + Lista[i].Nm_Cliente);
                }
            }

        }



        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.LimpaTela(this);
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 2);
            tbox_Nm_Cliente.Focus();

        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaTela(this, true);
            obj_FuncGeral.StatusBtn(this, 2);
            tbox_Nm_Cliente.Focus();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                PopulaTela(obj_Cliente_Atual);
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
            DialogResult dr_Resp = MessageBox.Show("Confirma a Exclusão do Cliente " + obj_Cliente_Atual.Nm_Cliente + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);        

            if (dr_Resp == DialogResult.Yes)
            {
                ClienteBD obj_ClienteBD = new ClienteBD();

                if (obj_ClienteBD.Excluir(obj_Cliente_Atual));
                {
                    MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Cliente + " foi excluido com Sucesso.", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaTela(this);
                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 0);
                PopulaLista();

            }
            obj_Cliente_Atual = new Cliente();
        }

        private void lbox_Clientes_Click(object sender, EventArgs e)
        {
            ClienteBD obj_ClienteBD = new ClienteBD();

            if (lbox_Clientes.SelectedIndex != -1)
            {
                string s_Linha = lbox_Clientes.Items[lbox_Clientes.SelectedIndex].ToString();
           
                //1-Antônio
                //123-Marcia
                int i_Pos = 0;

                for (int i = 0; i <= s_Linha.Length -1; i++)
                {
                    if (s_Linha.Substring(i,1) == "-")
                    {
                        i_Pos = i;
                        break;
                    }
                }

                obj_Cliente_Atual.Cod_Cliente = Convert.ToInt16(s_Linha.Substring(0, i_Pos));
                obj_Cliente_Atual = obj_ClienteBD.FindByCliente(obj_Cliente_Atual);

                PopulaTela(obj_Cliente_Atual);

                obj_FuncGeral.HabilitaTela(this, false);
                obj_FuncGeral.StatusBtn(this, 1);

            }
        }

        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            ClienteBD obj_ClienteBD = new ClienteBD();
            obj_Cliente_Atual = PopulaObjeto();

            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                //Alterar
                if (obj_ClienteBD.Alterar(obj_Cliente_Atual))
                {
                    MessageBox.Show("Alteração Realizada com Sucesso.", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                //Incluir
                obj_Cliente_Atual.Cod_Cliente = obj_ClienteBD.Incluir(obj_Cliente_Atual);
                MessageBox.Show("Inclusão Realizada com Sucesso.", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbox_Cod_Cliente.Text = obj_Cliente_Atual.Cod_Cliente.ToString();
            }

            obj_FuncGeral.HabilitaTela(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaLista();

        }

        private void frm_Cliente_Load(object sender, EventArgs e)
        {

        }
    }
}
