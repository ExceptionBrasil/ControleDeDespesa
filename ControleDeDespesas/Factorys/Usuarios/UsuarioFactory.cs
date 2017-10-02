using Modelos;
using Modelos.ViewModels;
using Persistencia.DAO;
using Persistencia.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Factorys
{
    public static class UsuarioFactory
    {
        public static CadastroDeUsuario GeraUsuario(UsuarioModelView model, CentroDeCustoDAO ccDAO)
        {
           
            CadastroDeUsuario usuario = new CadastroDeUsuario() {
                CentroDeCusto = ccDAO.GetById(model.CentroDeCusto),
                Cpf = model.Cpf,
                Email = model.Email,
                Id = model.Id,
                IsAdmin= model.IsAdmin,
                IsAprovador = model.IsAprovador,
                Login = model.Login,
                Nome = model.Nome,
                Senha = model.Senha
            };

            return usuario;
        }

        public static IList<CadastroDeUsuario> GeraListaUsuario(IList<UsuarioModelView> listModel, CentroDeCustoDAO ccDAO)
        {
            IList<CadastroDeUsuario> listaUsuario = new List<CadastroDeUsuario>();

            foreach (var x in listModel)
            {
                listaUsuario.Add(UsuarioFactory.GeraUsuario(x,ccDAO));
            }

            return listaUsuario;

        }
    }
}
