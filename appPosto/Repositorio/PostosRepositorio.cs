using appPosto.Data;
using appPosto.Models;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Linq;

namespace appPosto.Repositorio
{
    public class PostosRepositorio : IPostosRepositorio
    {
        private readonly BancoContext _bancoContext;

        public PostosRepositorio(BancoContext bancoContext) 
        {
            this._bancoContext = bancoContext;
           
        }

        public PostosModel ListarPorId(int id)
        {
            return _bancoContext.Postos.FirstOrDefault(x => x.Id == id);
        }

        public List<PostosModel> BuscarTodos()
        {
            return _bancoContext.Postos.ToList();
        }
        public PostosModel Adicionar(PostosModel postos)
        {
            //gravar no banco de dados
            _bancoContext.Postos.Add(postos);
            _bancoContext.SaveChanges();
            return postos;
        }

        public PostosModel Atualizar(PostosModel postos)
        {
            PostosModel postosDB = ListarPorId(postos.Id);

            if (postosDB == null) throw new Exception("Houve um erro na atualização do contato!"); //se não der certo mudar o new Exception por new System.Exception

            else
            {
                postosDB.Nome = postos.Nome;
                postosDB.Endereco = postos.Endereco;
                postosDB.PrecoGasolinaComum = postos.PrecoGasolinaComum;
                postosDB.PrecoGasolinaAditivada = postos.PrecoGasolinaAditivada;
                postosDB.PrecoDiesel = postos.PrecoDiesel;

                _bancoContext.Postos.Update(postosDB);
                _bancoContext.SaveChanges();

                return postosDB;
            }
        }
        public bool Apagar(int id)
        {
            PostosModel postosDB = ListarPorId(id);

            if (postosDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _bancoContext.Postos.Remove(postosDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
