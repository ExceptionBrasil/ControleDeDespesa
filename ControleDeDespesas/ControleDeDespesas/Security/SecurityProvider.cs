using Persistencia.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace ControleDeDespesas.Security
{
    public class SecurityProvider: SimpleMembershipProvider
    {
        private UsuariosDAO usuarioDAO;

        public SecurityProvider(UsuariosDAO u)
        {
            this.usuarioDAO = u;
        }

        public  bool ChangePassword(int userId, string oldPassword, string newPassword)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(newPassword);
            byte[] pass = base.EncryptPassword(bytes);

            //troca a senha no cadastro
            usuarioDAO.ChangePassword(userId, newPassword);
            
            
            return true;
           // return base.ChangePassword(username, oldPassword, newPassword);
        }
    }
}