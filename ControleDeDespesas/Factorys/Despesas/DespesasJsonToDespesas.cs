using Modelos;
using Modelos.ViewModels;
using Factorys.Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Persistencia.DAO;
using Factorys.Ninject;

namespace Factorys
{
    public static class DespesasJsonToDespesas
    {
        private static TiposDeDespesasDAO tipoDAO = Injections.GetTiposDeDespesasInject();

        /// <summary>
        /// Gera uma despesa simples
        /// </summary>
        /// <param name="depJ">The dep j.</param>
        /// <returns></returns>
        public static Despesas Gera(DespesasJson depJ)
        {
            Despesas despesa = new Despesas();

            despesa.Tipo = tipoDAO.GetById(depJ.IdDespesa);
            despesa.Quantidade = depJ.Quantidade;
            despesa.Valor = depJ.Valor;
            despesa.Descritivo = depJ.Observacao;
            despesa.DataInclusao = DateTime.Now;            

            return despesa;
            
        }

        /// <summary>
        /// Gera uma despesa com a data de inclusao e cadastro de uuário determinado
        /// </summary>
        /// <param name="depJ">The dep j.</param>
        /// <param name="dataInclusao">The data inclusao.</param>
        /// <param name="usuario">The usuario.</param>
        /// <returns></returns>
        public static Despesas Gera(DespesasJson depJ,DateTime dataInclusao,CadastroDeUsuario usuario)
        {
            Despesas despesa = new Despesas();

            despesa.Tipo = tipoDAO.GetById(depJ.IdDespesa);
            despesa.Quantidade = depJ.Quantidade;
            despesa.Valor = depJ.Valor;
            despesa.Descritivo = depJ.Observacao;
            despesa.DataInclusao = dataInclusao;
            despesa.UsuarioInclusao = usuario;
            despesa.CentroDeCusto = usuario.CentroDeCusto;            

            return despesa;

        }

        /// <summary>
        /// Gera a lista de Despesa com base em uma estrutura de  Json
        /// </summary>
        /// <param name="lista">The lista.</param>
        /// <returns></returns>
        public static List<Despesas> GeraLista(IList<DespesasJson> lista)
        {
            List<Despesas> despesas = new List<Despesas>();
            for (int i = 0; i < lista.Count; i++)
            {
                despesas.Add(Gera(lista[i]));
            }
            return despesas;
        }

        /// <summary>
        /// Gera a lista de Despesa com base em uma estrutura de  Json,  com a data de inclusao e cadastro de uuário determinado
        /// </summary>
        /// <param name="lista">The lista.</param>
        /// <param name="usuario">The usuario.</param>
        /// <param name="dataInclusao">The data inclusao.</param>
        /// <returns></returns>
        public static List<Despesas> GeraLista(IList<DespesasJson> lista,CadastroDeUsuario usuario,DateTime dataInclusao)
        {
            List<Despesas> despesas = new List<Despesas>();
            for (int i = 0; i < lista.Count; i++)
            {
                despesas.Add(Gera(lista[i],dataInclusao,usuario));                
            }
            return despesas;
        }
    }
}