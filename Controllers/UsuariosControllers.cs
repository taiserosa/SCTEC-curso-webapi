using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraAPI.Models;

namespace MinhaPrimeiraAPI.Controllers
{
    [ApiController]
    [Route("usuarios")]
    public class UsuariosControllers
    {
        static private List<Usuario> usuarios = new List<Usuario>();

        [HttpGet]
        public List<Usuario> GetUsuario()
        {
            return usuarios;
        }

        [HttpGet]
        [Route("{id}")]
        public Usuario GetUsuarioPorId([FromRoute] string id)
        {
            Usuario resultado = null;
            foreach(var usuario in usuarios)
            {
                if (usuario.Id == id)
                {
                    resultado = usuario;
                }
            }
            return resultado;
        }

        [HttpGet]
        [Route ("{id}/pedidos")]
        public string GetPedidosUsuario([FromRoute] string id)
        {
            return "Você chamou o método Obter Pedidos do Usuário com o id " + id;
        }

        [HttpPut]
        [Route("{id}")]
        public string AtualizaUsuario([FromRoute] string id, [FromBody] Usuario usuarioAtualizar)
        {
            Usuario usuarioSelecionado = null;
            
            foreach(var usuario in usuarios)
            {
                if(usuario.Id == id)
                {
                    usuarioSelecionado = usuario;
                    break;
                }
            }

            if(usuarioSelecionado == null)
            {
                return $"Usuário com o id {id} não encontrado!";
            }

            usuarioSelecionado.Id = usuarioAtualizar.Id;
            usuarioSelecionado.Nome = usuarioAtualizar.Nome;
            usuarioSelecionado.Idade = usuarioAtualizar.Idade;

            // abaixo, opção não muito boa para "atualizar" (remover e depois adicionar)
            // usuarios.Remove(usuarioSelecionado);
            // usuarios.Add(usuarioAtualizar);
            return $"Usuário com o id {id} atualizado!";
        }

        [HttpDelete]
        [Route("{id}")]
        public string DeletaUsuario([FromRoute] string id)
        {
            Usuario usuarioDeletar = null;
            foreach(var usuario in usuarios)
            {
                if(usuario.Id == id)
                {
                    usuarioDeletar = usuario;
                    break;
                }
            }
            if(usuarioDeletar == null)
            {
                return $"Não foi encontrado um usuário com o id {id}!";
            } else
            {
                usuarios.Remove(usuarioDeletar);
                return $"Usuário com o id {id} deletado!";
            }
        }

        [HttpPost]
        public string CriaUsuario([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            return $"Você chamou o Método Criar Usuário com o nome {usuario.Nome} e idade de {usuario.Idade} anos!";
        } 
    }
}