using System;
using System.IO;
using System.Web.Mvc;
     

namespace Factorys.Tools
{
    public static class DiretorioFactory
    {
        public static void Cria(int id,string path)
        {
            //no primeiro acesso cria o diretorio de imagens do usuário
            if (!Directory.Exists(path+ Convert.ToString(id)))
            {
                Directory.CreateDirectory(path+ Convert.ToString(id));
            }
        }
}
}
