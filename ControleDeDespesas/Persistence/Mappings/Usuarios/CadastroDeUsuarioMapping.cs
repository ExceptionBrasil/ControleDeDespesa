using Modelos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Persistencia.Mappings
{
    public class CadastroDeUsuarioMapping:ClassMap<CadastroDeUsuario>
    {
        public CadastroDeUsuarioMapping()
        {
            Id(u => u.Id).GeneratedBy.Identity();
            Map(u => u.Login);
            Map(u => u.IsAdmin);
            Map(u => u.Nome);
            Map(u => u.Senha);
            Map(u => u.Email);
            Map(u => u.Cpf);
            References(u => u.CentroDeCusto);
            Map(u => u.IsAprovador);
        }
    }
}