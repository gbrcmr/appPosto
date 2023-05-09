using appPosto.Models;
using appPosto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace appPosto.Controllers
{
    public class PostosController : Controller
    {
        private readonly IPostosRepositorio _postosRepositorio;

        public PostosController(IPostosRepositorio postosRepositorio)
        {
            _postosRepositorio = postosRepositorio;   
        }
        public IActionResult Index()
        {
            List<PostosModel> postos = _postosRepositorio.BuscarTodos();
            
            return View(postos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            PostosModel posto = _postosRepositorio.ListarPorId(id);
            return View(posto);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            PostosModel posto = _postosRepositorio.ListarPorId(id);
            return View(posto);
        }

        public IActionResult Apagar (int id)
        {
            try
            {
                bool apagado = _postosRepositorio.Apagar(id);

                if (apagado)
                {
                   TempData["MensagemSucesso"] = "Posto apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamente.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception erro) {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(PostosModel postos)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    _postosRepositorio.Adicionar(postos);
                    TempData["MensagemSucesso"] = "Posto cadastrado com sucesso!" ;
                    return RedirectToAction("Index");

                }

                return View(postos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente. Detalhe do erro: {erro.Message}" ;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(PostosModel postos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _postosRepositorio.Atualizar(postos);
                    TempData["MensagemSucesso"] = "Posto alterado com sucesso!" ;
                    return RedirectToAction("Index");
                }

                return View("Editar", postos);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamente. Detalhe do erro: {erro.Message}" ;
                return View("Editar", postos);
            }
        }

    }
}
