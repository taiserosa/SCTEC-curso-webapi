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
        public string AtualizaUsuario()
        {
            return "Você chamou o método Atualizar Usuário!";
        }

        [HttpDelete]
        public string DeletaUsuario()
        {
            return "Você chamou o método Deletar Usuário!";
        }

        [HttpPost]
        public string CriaUsuario([FromBody] Usuario usuario)
        {
            usuarios.Add(usuario);
            return $"Você chamou o Método Criar Usuário com o nome {usuario.Nome} e idade de {usuario.Idade} anos!";
        } 
    }
}