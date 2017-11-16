using Factorys.Ninject;
using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys.Aprovacao
{
    public static class AprovadorFactory
    {

        private static CentroDeCustoDAO custoDAO = Injections.CentroDeCustoInject();
        private static UsuariosDAO userDAO = Injections.UsuarioInject();


        //Gera um aprovador com base em um modelo de Visão 
        public static AprovadorPorCC GeraAprovador(AprovadorPorCCModelView aprovador)
        {
            AprovadorPorCC aprovadorModel= new AprovadorPorCC()
            {
                CC = custoDAO.GetById(aprovador.CC),
                Id = aprovador.Id,
                Usuario = userDAO.GetById(aprovador.Usuario)
            };

            return aprovadorModel;

        }

        //Gera uma lista de Aprovador com base em uma lista de  modelo de Visão
        public static IList<AprovadorPorCC> GeraListaAprovador(IList<AprovadorPorCCModelView> listaAprovador)
        {
            IList<AprovadorPorCC> lista = new List<AprovadorPorCC>();
            foreach (var x in listaAprovador)
            {
                lista.Add(AprovadorFactory.GeraAprovador(x));
            }

            return lista;
            
        }

        public static AprovadorPorCCModelView GeraModelView(AprovadorPorCC aprovador)
        {
            AprovadorPorCCModelView model = new AprovadorPorCCModelView()
            {
                CC = aprovador.CC.Id,
                Id = aprovador.Id,                
                Usuario = aprovador.Usuario.Id
            };

            return model;
        }
    }
}
