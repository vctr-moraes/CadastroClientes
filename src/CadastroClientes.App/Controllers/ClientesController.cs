using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Business.Models;
using CadastroClientes.App.Models;
using CadastroClientes.Business.Interfaces;

namespace CadastroClientes.App.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IContatoRepository _contatoRepository;
        private readonly IContatoService _contatoService;
        private readonly IDocumentoRepository _documentoRepository;
        private readonly IDocumentoService _documentoService;

        public ClientesController(
            IClienteService clienteService,
            IDocumentoService documentoService,
            IContatoService contatoService,
            IClienteRepository clienteRepository,
            IDocumentoRepository documentoRepository,
            IContatoRepository contatoRepository)
        {
            _clienteService = clienteService;
            _documentoService = documentoService;
            _contatoService = contatoService;
            _clienteRepository = clienteRepository;
            _documentoRepository = documentoRepository;
            _contatoRepository = contatoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return View(clientes.Select(cliente => new ClienteDetailsViewModel(cliente)).ToList());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            var clienteViewModel = new ClienteDetailsViewModel
            {
                Id = cliente.Id,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                Cnpj = cliente.Cnpj,
                DataCadastro = cliente.DataCadastro,
                Contatos = cliente.Contatos.Select(contato => new ContatoViewModel(contato)).ToList(),
                Documento = new DocumentoViewModel { ClienteId = cliente.Id },
                Documentos = cliente.Documentos.Select(doc => new DocumentoViewModel(doc)).ToList(),
                Endereco = new EnderecoViewModel(cliente.Endereco)
            };

            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            var clienteViewModel = new ClienteCreateEditViewModel();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteCreateEditViewModel clienteCreateEditViewModel)
        {
            if (!ModelState.IsValid) return View(clienteCreateEditViewModel);

            var cliente = new Cliente(
                clienteCreateEditViewModel.NomeFantasia,
                clienteCreateEditViewModel.RazaoSocial,
                clienteCreateEditViewModel.Cnpj);

            var endereco = new Endereco(
                clienteCreateEditViewModel.Endereco.Logradouro,
                clienteCreateEditViewModel.Endereco.Numero,
                clienteCreateEditViewModel.Endereco.Bairro,
                clienteCreateEditViewModel.Endereco.Cidade,
                clienteCreateEditViewModel.Endereco.Estado,
                clienteCreateEditViewModel.Endereco.Pais,
                clienteCreateEditViewModel.Endereco.Cep,
                cliente);

            cliente.AdicionarEndereco(endereco);

            try
            {
                _clienteService.Adicionar(cliente);

                TempData["Sucesso"] = "Cliente cadastrado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            return View(new ClienteCreateEditViewModel(cliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteCreateEditViewModel clienteCreateEditViewModel)
        {
            if (id != clienteCreateEditViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteCreateEditViewModel);

            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            cliente.AtualizarCliente(
                clienteCreateEditViewModel.NomeFantasia,
                clienteCreateEditViewModel.RazaoSocial,
                clienteCreateEditViewModel.Cnpj);

            cliente.Endereco?.AtualizarEndereco(
                clienteCreateEditViewModel.Endereco.Logradouro,
                clienteCreateEditViewModel.Endereco.Numero,
                clienteCreateEditViewModel.Endereco.Bairro,
                clienteCreateEditViewModel.Endereco.Cidade,
                clienteCreateEditViewModel.Endereco.Estado,
                clienteCreateEditViewModel.Endereco.Pais,
                clienteCreateEditViewModel.Endereco.Cep);

            try
            {
                _clienteService.Atualizar(cliente);

                TempData["Sucesso"] = "Cliente atualizado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            var clienteViewModel = new ClienteDetailsViewModel
            {
                Id = cliente.Id,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                Cnpj = cliente.Cnpj,
                DataCadastro = cliente.DataCadastro,
                Contatos = cliente.Contatos.Select(contato => new ContatoViewModel(contato)).ToList(),
                Documento = new DocumentoViewModel { ClienteId = cliente.Id },
                Documentos = cliente.Documentos.Select(doc => new DocumentoViewModel(doc)).ToList(),
                Endereco = new EnderecoViewModel(cliente.Endereco)
            };

            return View(clienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            try
            {
                await _clienteService.Remover(id);

                TempData["Sucesso"] = "Cliente deletado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.Message);
                return View(new ClienteDetailsViewModel(cliente));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarDocumento(DocumentoViewModel documentoViewModel, Guid clienteId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details), new { id = clienteId });
            }

            var cliente = await _clienteRepository.ObterPorId(clienteId) ?? null;

            if (cliente == null) return NotFound();

            var documento = new Documento(
                documentoViewModel.Descricao,
                documentoViewModel.Arquivo.FileName,
                (TipoDocumento)documentoViewModel.TipoDocumento,
                cliente);

            try
            {
                _documentoService.Adicionar(documento);

                TempData["Sucesso"] = "Documento importado com sucesso.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }

            return RedirectToAction(nameof(Details), new { id = clienteId });
        }

        [HttpPost, ActionName("DeletarDocumento")]
        public async Task<IActionResult> DeletarDocumento(Guid id, Guid clienteId)
        {
            var documento = await _documentoRepository.ObterPorId(id) ?? null;

            if (documento == null) return NotFound();

            try
            {
                _documentoService.Remover(id);

                TempData["Sucesso"] = "Documento deletado com sucesso.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }

            return RedirectToAction(nameof(Details), new { id = clienteId });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarContato(ContatoViewModel contatoViewModel, Guid clienteId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Details), new { id = clienteId });
            }

            var cliente = await _clienteRepository.ObterPorId(clienteId) ?? null;

            if (cliente == null) return NotFound();

            var contato = new Contato(
                contatoViewModel.DescricaoContato,
                contatoViewModel.NomeRepresentante,
                contatoViewModel.EmailRepresentante,
                contatoViewModel.TelefoneRepresentante,
                contatoViewModel.EmailComercial,
                contatoViewModel.TelefoneComercial,
                contatoViewModel.Cargo,
                cliente);

            cliente.AdicionarContato(contato);

            try
            {
                _contatoService.Adicionar(contato);

                TempData["Sucesso"] = "Contato adicionado com sucesso.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }

            return RedirectToAction(nameof(Details), new { id = clienteId });
        }

        [HttpPost, ActionName("DeletarContato")]
        public async Task<IActionResult> DeletarContato(Guid id, Guid clienteId)
        {
            var contato = await _contatoRepository.ObterPorId(id) ?? null;

            if (contato == null) return NotFound();

            try
            {
                _contatoService.Remover(id);

                TempData["Sucesso"] = "Contato deletado com sucesso.";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex?.InnerException?.Message);
                throw new Exception(ex?.InnerException?.Message);
            }

            return RedirectToAction(nameof(Details), new { id = clienteId });
        }
    }
}