using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersAspNet.Interfaces;

namespace E_PlayersAspNet.Models
{
    public class Equipes : EPlayersBase , IEquipes 
    {
        //será utilizado o Id (identificador) no nome das entidades, pois para altera-las será mais fácil
        public int IdEquipes { get; set; }
        public string Nome   { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "DateBase/Equipes.csv";

        //O metodo chama um caminho, ai será usado o PATH
        public Equipes(){
            CreateFolderAndFile(PATH);//o caminho é DataBase/Equipe.csv
        }

        public void Alterar(Equipes e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == e.IdEquipes.ToString());
            linhas.Add( PrepararLinha(e) );
            RewriteCSV(PATH, linhas);
        }

        public void Criar(Equipes e)
        {
            string[] linha = { PrepararLinha(e) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Equipes e){
            return $"{IdEquipes};{e.Nome};{e.Imagem}";
        }

        public void Excluir(int idEquipes)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == idEquipes.ToString());
        }

        public List<Equipes> Ler()
        {
             List<Equipes> equipes = new List<Equipes>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipes equipe = new Equipes();
                equipe.IdEquipes = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }
    }
}