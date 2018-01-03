using Modelos;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DAO.Upload
{
    public class UploadDAO
    {
        ISession session;
        

        public UploadDAO (ISession sessao)
        {
            this.session = sessao;
        }


        /// <summary>
        /// Retorna o arquivo pelo ID
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public UploadedFile  GetById(int id)
        {
            var file = session.QueryOver<UploadedFile>()
                              .Where(x => x.Id == id)
                              .SingleOrDefault();
            return file;
        }

        /// <summary>
        /// Retorna o arquivo pelo seu nome 
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public UploadedFile GetByFileName(string filename)
        {
            var file = session.QueryOver<UploadedFile>()
                              .Where(x => x.FileName == filename)
                              .SingleOrDefault();
            return file;
        }

        /// <summary>
        /// Verifica pelo nome râdomico se o arquivo já existe no servidor
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public bool ExistsRandomName(string name)
        {
            var file = session.QueryOver<UploadedFile>()
                              .Where(x => x.RandomName == name)
                              .SingleOrDefault();
                              


            return (file==null);
        }

        /// <summary>
        /// Persiste os dados na base de dados 
        /// </summary>
        /// <param name="file">The file.</param>
        public void Incluir (UploadedFile file)
        {
            ITransaction Tran = session.BeginTransaction();
            session.Save(file);
            Tran.Commit();
        }

    }
}
