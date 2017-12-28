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

        public static List<Despesas> GeraLista(IList<DespesasJson> lista)
        {
            List<Despesas> despesas = new List<Despesas>();
            for (int i = 0; i < lista.Count; i++)
            {
                despesas.Add(Gera(lista[i]));
            }
            return despesas;
        }
        public static List<Despesas> GeraLista(IList<DespesasJson> lista,CadastroDeUsuario usuario,DateTime dataInclusao)
        {
            List<Despesas> despesas = new List<Despesas>();
            for (int i = 0; i < lista.Count; i++)
            {
                despesas.Add(Gera(lista[i]));
                despesas[despesas.Count].UsuarioInclusao = usuario;
                despesas[despesas.Count].DataInclusao = dataInclusao;
            }
            return despesas;
        }
    }
}