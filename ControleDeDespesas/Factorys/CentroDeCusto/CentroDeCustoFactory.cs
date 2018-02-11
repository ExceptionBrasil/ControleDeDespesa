using Factorys.Ninject;
using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorys
{
    public static class CentroDeCustoFactory
    {
        /// <summary>
        /// Gera um Centro de Custo com base na Model View
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static CentroDeCusto GetModel(CentroDeCustoModelView c)
        {
            UsuariosDAO cDAO = Injections.UsuarioInject();
            CentroDeCusto cc = new CentroDeCusto();      

            cc.Aprovador = cDAO.GetById(c.Aprovador);
            cc.Codigo = c.Codigo;
            cc.Descricao = c.Descricao;
            cc.DescricaoExtendida = c.Codigo + " - " + c.Descricao;
            cc.Id = c.Id;

            return cc;
        }

        /// <summary>
        /// Gera um Model com base em um Centro de Custo 
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static CentroDeCustoModelView GetModelView(CentroDeCusto c)
        {
            CentroDeCustoModelView model = new CentroDeCustoModelView();

            model.Id = c.Id;

            if (c.Aprovador != null)
            {
                model.Aprovador = c.Aprovador.Id;
            }
            model.Codigo = c.Codigo;
            model.Descricao = c.Descricao;

            return model;
        }
    }
}
