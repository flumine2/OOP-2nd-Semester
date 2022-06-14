using Lab6.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Services.Providers
{
    static class RepositoryProvider
    {
        private static RepositoryControler _repositoryControler;

        public static RepositoryControler GetRepositoryReference()
        {
            if (_repositoryControler is null)
            {
                _repositoryControler = new RepositoryControler();
            }

            return _repositoryControler;
        }
    }
}
