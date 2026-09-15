using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoControllers
    {
        static private List<Produto> produtos = new List<Produto>();
        
        [HttpPost]
        [Route("{id}")]
        public string Post([FromBody] Produto produto)
        {
            produtos.Add(produto);
            return $"O produto com id {produto.Id} e nome {produto.Nome} foi criado!";
        }

        [HttpGet]
        public List<Produto> Get()
        {
            return produtos;
        }

        [HttpGet]
        [Route("{id}")]
        public Produto GetPorId([FromRoute] int id)
        {
            return ObterProduto(id);
        } 

        [HttpDelete]
        [Route("{id}")]
        public string Delete([FromRoute] int id)
        {
            var produtoDeletar = ObterProduto(id);
            if(produtoDeletar == null)
            {
                return $"Produto com id {id} não encontrado!";
            } else
            {
                produtos.Remove(produtoDeletar);
                return $"Produto com id {id} deletado!";
            }
        }


        [HttpPut]
        [Route("{id}")]
        public string Put([FromRoute] int id, [FromBody] Produto produtoParaAtualizar)
        {
            Produto produtoAtualizar = ObterProduto(id);
            if(produtoAtualizar.Id == null)
            {
                return $"Produto com id {id} não encontrado!";
            }
            produtoAtualizar.Id = produtoAtualizar.Id;
            produtoAtualizar.Nome = produtoAtualizar.Nome;
            return $"O produto foi atualizado com sucesso!";
        }

        private Produto ObterProduto(int id)
        {
            Produto produtoSelecionado = null;

            foreach(var produto in produtos)
            {
                if(produto.Id == id)
                {
                    produtoSelecionado = produto;
                    break;
                } 
            }
            return produtoSelecionado;
        }
    }
}