using System.Collections.Generic;
using E_PlayersAspNet.Models;

namespace E_PlayersAspNet.Interfaces
{
    public interface IEquipes
    {
         //Criar 
         void Criar(Equipes e);
         //Ler
         List<Equipes> Ler();
         //Alterar
         void Alterar(Equipes e);
         //Excluir 
         void Excluir(int idEquipes);

    }
}