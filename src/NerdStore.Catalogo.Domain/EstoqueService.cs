using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Event;
using NerdStore.Core.Bus;
using NerdStore.Core.DomainObject;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorID(produtoId);

            //Validacoes.ValidarSeNulo(produto, "O produto informado está nulo.");
            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            //Aqui deverá ser acionado um evento para alertar que é necessário a compra de mais quantidades deste produto.
            if (produto.quantidadeEstoque < 10)
            {
                //avisar, mandar email, mandar sms, integração com outro sistema e avisar que estoque está baixo
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.id, produto.quantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.unitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorID(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.unitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}