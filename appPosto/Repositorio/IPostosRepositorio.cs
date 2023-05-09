using appPosto.Models;

namespace appPosto.Repositorio
{
    public interface IPostosRepositorio
    {
        PostosModel ListarPorId(int id);
        List<PostosModel> BuscarTodos();
        PostosModel Adicionar(PostosModel postos);

        PostosModel Atualizar (PostosModel postos);

        bool Apagar (int id);
    }
}
