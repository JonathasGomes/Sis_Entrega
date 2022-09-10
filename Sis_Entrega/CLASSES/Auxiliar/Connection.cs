/********************************************************************************************************************
 * NOME: Connection 
 * CLASSE: Esta classe representa a Entidade de conexão com o Banco de Dados
 * DT. CRIAÇÃO: 26/02/2021
 * DT. ALTERAÇÃO: --
 *                --
 * CRIADA POR: mFacine (Monstro)               
 * OBSERVAÇÃO: Conecta os objetos BDs ao Banco de Dados
 * ******************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sis_Entrega
{
    class Connection
    {
        ~Connection()
        {
        }

        //Metodo para retornar o caminho do Banco de Dados para a Conexão
        public static string Connection_Path()
        {
            return @"Data Source = (LocalDB)\MSSQLLOCALDB; AttachDBFilename = D:\1 - SENAC\3 - CURSOS\TÉCNICOS\PROJETOS ATUAIS\SIS_ENTREGA\Sis_Entrega\Sis_Entrega\BD_SIS_ENTREGA.mdf; Integrated Security = true; Connection Timeout = 20";
        }

    }
}
