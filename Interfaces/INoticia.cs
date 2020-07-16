using System.Collections.Generic;
using E_PlayersAspNet.Models;

namespace E_PlayersAspNet.Interfaces
{
    public interface INoticia
    {
         //Criar
         void Criar(Noticia n);
         //Ler
         List<Noticia> Ler();
         //Alterar
         void Alterar(Noticia n);
         //Excluir
         void Excluir(int idNoticia);
    }
}