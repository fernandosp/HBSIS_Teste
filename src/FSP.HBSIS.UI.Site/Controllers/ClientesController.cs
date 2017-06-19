using System;
using System.Net;
using System.Web.Mvc;
using FSP.HBSIS.Application;
using FSP.HBSIS.Application.Interfaces;
using FSP.HBSIS.Application.ViewModels;
using FSP.HBSIS.Infra.CrossCutting.MvcFilters;

namespace FSP.HBSIS.UI.Site.Controllers
{
    // PermissoesCliente - CL,CI,CE,CD,CX

    [Authorize]
    [RoutePrefix("hbsis/cadastros")]
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [ClaimsAuthorize("PermissoesCliente","CL")]
        [Route("listar-clientes")]
        public ActionResult Index()
        {
            return View(_clienteAppService.ObterTodos());
        }

        [ClaimsAuthorize("PermissoesCliente", "CD")]
        [Route("{id:guid}/detalhe-cliente")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-cliente")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("PermissoesCliente", "CI")]
        [Route("novo-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteViewModel = _clienteAppService.Adicionar(clienteViewModel);

                if (!clienteViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty,erro.Message);
                    }

                    return View(clienteViewModel);
                }

                return RedirectToAction("Index");
            }

            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-cliente")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);

            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CE")]
        [Route("{id:guid}/editar-cliente")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteViewModel.Ativo = true;
                _clienteAppService.Atualizar(clienteViewModel);
                return RedirectToAction("Index");
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-cliente")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return HttpNotFound();
            }
            return View(clienteViewModel);
        }

        [ClaimsAuthorize("PermissoesCliente", "CX")]
        [Route("{id:guid}/excluir-cliente")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _clienteAppService.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
