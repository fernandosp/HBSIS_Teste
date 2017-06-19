using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using FSP.HBSIS.Application.Interfaces;
using FSP.HBSIS.Application.ViewModels;

namespace FSP.HBSIS.Services.REST.ClienteAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClientesController : ApiController
    {
        private readonly IClienteAppService _clienteAppService;

        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [ActionName("get"), HttpGet]
        public IEnumerable<ClienteViewModel> Clientes()
        {
            return _clienteAppService.ObterTodos();
        }

        [HttpGet]
        public ClienteViewModel Get(Guid id)
        {
            return _clienteAppService.ObterPorId(id);
        }

        // POST: api/Clientes
        [HttpPost]
        public HttpResponseMessage Post(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteViewModel = _clienteAppService.Adicionar(clienteViewModel);

                if (!clienteViewModel.ValidationResult.IsValid)
                {
                    foreach (var erro in clienteViewModel.ValidationResult.Erros)
                    {
                        ModelState.AddModelError(string.Empty, erro.Message);
                    }

                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, clienteViewModel);
                return response;
            }
            else {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }


        }

        // PUT: api/Clientes/5
        [HttpPut]
        public HttpResponseMessage Put(ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                clienteViewModel.Ativo = true;
                _clienteAppService.Atualizar(clienteViewModel);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, clienteViewModel);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            }

        // DELETE: api/Clientes/5
        public HttpResponseMessage Delete(Guid? id)
        {
            if (id == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var clienteViewModel = _clienteAppService.ObterPorId(id.Value);
            if (clienteViewModel == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else {
                _clienteAppService.Remover(id.Value);
                return Request.CreateResponse(HttpStatusCode.OK, clienteViewModel);
            }
        }
    }
}
