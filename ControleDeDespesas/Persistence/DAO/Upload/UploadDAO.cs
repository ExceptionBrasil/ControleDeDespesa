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

        public UploadedFile  GetById(int id)
        {
            var file = session.QueryOver<UploadedFile>()
                              .Where(x => x.Id == id)
                              .SingleOrDefault();
            return file;
        }

        public UploadedFile GetByFileName(string filename)
        {
            var file = session.QueryOver<UploadedFile>()
                              .Where(x => x.FileName == filename)
                              .SingleOrDefault();
            return file;
        }

    }
}
