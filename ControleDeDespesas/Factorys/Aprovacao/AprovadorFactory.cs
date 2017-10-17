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

        public static AprovadorPorCC ViewModelToModel(AprovadorPorCCModelView aprovador, CentroDeCustoDAO custoDAO, UsuariosDAO userDAO)
        {
            AprovadorPorCC aprovadorModel= new AprovadorPorCC()
            {
                CC = custoDAO.GetById(aprovador.CC),
                Id = aprovador.Id,
                Limite = aprovador.Limite,
                Superiror = userDAO.GetById(aprovador.Superiror),
                Usuario = userDAO.GetById(aprovador.Usuario)
            };

            return aprovadorModel;

        }
    }
}
