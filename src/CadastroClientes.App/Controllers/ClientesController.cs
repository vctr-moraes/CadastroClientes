using Microsoft.AspNetCore.Mvc;
using CadastroClientes.Business.Models;
using CadastroClientes.App.Models;
using CadastroClientes.Business.Interfaces;

namespace CadastroClientes.App.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteRepository.ObterTodos();
            return View(clientes.Select(cliente => new ClienteViewModel(cliente)).ToList());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            var clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                NomeFantasia = cliente.NomeFantasia,
                RazaoSocial = cliente.RazaoSocial,
                Cnpj = cliente.Cnpj,
                DataCadastro = cliente.DataCadastro,
                Contatos = cliente.Contatos.Select(contato => new ContatoViewModel(contato)).ToList(),
                Endereco = new EnderecoViewModel
                {
                    Logradouro = cliente.Endereco.Logradouro,
                    Numero = cliente.Endereco.Numero,
                    Bairro = cliente.Endereco.Bairro,
                    Cidade = cliente.Endereco.Cidade,
                    Estado = cliente.Endereco.Estado,
                    Pais = cliente.Endereco.Pais,
                    Cep = cliente.Endereco.Cep
                }
            };

            return View(clienteViewModel);
        }

        public IActionResult Create()
        {
            var clienteViewModel = new ClienteViewModel();

            return View(clienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = new Cliente(
                clienteViewModel.NomeFantasia,
                clienteViewModel.RazaoSocial,
                clienteViewModel.Cnpj);

            var endereco = new Endereco(
                clienteViewModel.Endereco.Logradouro,
                clienteViewModel.Endereco.Numero,
                clienteViewModel.Endereco.Bairro,
                clienteViewModel.Endereco.Cidade,
                clienteViewModel.Endereco.Estado,
                clienteViewModel.Endereco.Pais,
                clienteViewModel.Endereco.Cep,
                cliente);

            var contato = new Contato(
                clienteViewModel.Contato.DescricaoContato,
                clienteViewModel.Contato.NomeRepresentante,
                clienteViewModel.Contato.EmailRepresentante,
                clienteViewModel.Contato.TelefoneRepresentante,
                clienteViewModel.Contato.EmailComercial,
                clienteViewModel.Contato.TelefoneComercial,
                clienteViewModel.Contato.Cargo,
                cliente);

            cliente.AdicionarContato(contato);
            cliente.AdicionarEndereco(endereco);

            try
            {
                _clienteRepository.Adicionar(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao cadastrar o cliente. Tente novamente.");
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            return View(new ClienteViewModel(cliente));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(clienteViewModel);

            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            cliente.AtualizarCliente(
                clienteViewModel.NomeFantasia,
                clienteViewModel.RazaoSocial,
                clienteViewModel.Cnpj);

            cliente.Endereco?.AtualizarEndereco(
                clienteViewModel.Endereco.Logradouro,
                clienteViewModel.Endereco.Numero,
                clienteViewModel.Endereco.Bairro,
                clienteViewModel.Endereco.Cidade,
                clienteViewModel.Endereco.Estado,
                clienteViewModel.Endereco.Pais,
                clienteViewModel.Endereco.Cep);

            cliente.AtualizarContato(
                cliente.Contatos.FirstOrDefault(),
                clienteViewModel.Contato.DescricaoContato,
                clienteViewModel.Contato.NomeRepresentante,
                clienteViewModel.Contato.EmailRepresentante,
                clienteViewModel.Contato.TelefoneRepresentante,
                clienteViewModel.Contato.EmailComercial,
                clienteViewModel.Contato.TelefoneComercial,
                clienteViewModel.Contato.Cargo);

            try
            {
                _clienteRepository.Atualizar(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao atualizar o cliente. Tente novamente.");
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            return View(new ClienteViewModel(cliente));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cliente = await _clienteRepository.ObterPorId(id) ?? null;

            if (cliente == null) return NotFound();

            try
            {
                _clienteRepository.Remover(id);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao excluir o cliente. Tente novamente.");
            }
        }
    }
}