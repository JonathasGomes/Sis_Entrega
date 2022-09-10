/********************************************************************************************************************
 * NOME: FuncGeral 
 * CLASSE: Esta classe representa a Entidade de funçoes gerais utilizadas por formulários e classes
 * DT. CRIAÇÃO: 04/03/2021
 * DT. ALTERAÇÃO: --
 *                --
 * CRIADA POR: mFacine (Monstro)               
 * OBSERVAÇÃO: 
 * ******************************************************************************************************************/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sis_Entrega
{
    public class FuncGeral
    {
        /********************************************************************************************************************
        * NOME: HabilitaTela 
        * CLASSE: Responsável por habilitar os componentes editáveis do formulário 
        * PARAMETRO: Nome do Formulário, Variavel Booleana 
        * DT. CRIAÇÃO: 04/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public void HabilitaTela(Form pobj_Form, bool b_Hab)
        {
            //percorre todos os componentes do form
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhes")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox && Convert.ToInt16(ctrl.Tag) != 1)
                        {
                            ctrl.Enabled = b_Hab;
                        }
                    }
                }
            }
        }

        /********************************************************************************************************************
        * NOME: LimpaTela 
        * CLASSE: Responsável por Limpar os componentes editáveis (ou não) do formulário 
        * PARAMETRO: Nome do Formulário 
        * DT. CRIAÇÃO: 04/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * OBSERVAÇÃO: Utiliza a classe de conexão (Connection) para acesso ao Banco de Dados
        * ******************************************************************************************************************/
        public void LimpaTela(Form pobj_Form)
        {
            //percorre todos os componentes do form
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhes")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        if (ctrl is TextBox)
                        {
                            ctrl.Text = "";
                        }
                    }
                }
            }
        }

        /********************************************************************************************************************
        * NOME: StatusBtn 
        * CLASSE: Responsável por definir o status dos botões do formulário 
        *           0 - apenas o btn_novo habilitado
        *           1 - btn_Novo, btn_Alterar e btn_Excluir habilitados
        *           2 - btn_Confirmar e btn_Cancelar habilitados
        * PARAMETRO: Nome do Formulário, inteiro do status 
        * DT. CRIAÇÃO: 04/03/2021
        * DT. ALTERAÇÃO: --
        *                --
        * CRIADA POR: mFacine (Monstro)               
        * ******************************************************************************************************************/
        public void StatusBtn(Form pobj_Form, int i_Status)
        {
            //percorre todos os componentes do form
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Botoes")
                {
                    foreach (Control ctrl in pnl.Controls)
                    {
                        switch (i_Status)
                        {
                            case 0:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    break;
                                }

                            case 1:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = false;
                                    }

                                    break;
                                }

                            case 2:
                                {
                                    if (ctrl.Name == "btn_Novo")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Alterar")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Excluir")
                                    {
                                        ctrl.Enabled = false;
                                    }
                                    if (ctrl.Name == "btn_Confirmar")
                                    {
                                        ctrl.Enabled = true;
                                    }
                                    if (ctrl.Name == "btn_Cancelar")
                                    {
                                        ctrl.Enabled = true;
                                    }

                                    break;
                                }
                        }
                        
                    }
                }
            }
        }



    }
}
