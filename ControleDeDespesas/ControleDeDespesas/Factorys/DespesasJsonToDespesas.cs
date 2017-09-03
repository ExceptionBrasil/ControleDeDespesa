using ControleDeDespesas.DAO;
using ControleDeDespesas.Models;
using ControleDeDespesas.ViewModels;
using Helpers;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDeDespesas.Factorys
{
    public static class DespesasJsonToDespesas
    {
        public static Despesas Gera(DespesasJson depJ)
        {
            ISession session = NhibernateHelper.OpenSession();
            TiposDeDespesasDAO tipoDAO = new TiposDeDespesasDAO(session);


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
    }
}