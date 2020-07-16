using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersAspNet.Interfaces;

namespace E_PlayersAspNet.Models
{
    public class Noticia : EPlayersBase , INoticia 
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto  { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "DataBase/noticia.csv";

        //O metodo pede um caminho e será usado o do PATH
        public Noticia(){
            CreateFolderAndFile(PATH);
        }


        public void Alterar(Noticia n)
        {
           List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n) );
            RewriteCSV(PATH, linhas);
        }

        public void Criar(Noticia n)
        {
            string[] linha = { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Noticia n){
            return $"{IdNoticia};{n.Titulo};{n.Imagem};{n.Texto}";
        }

        public void Excluir(int idNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == idNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Noticia> Ler()
        {
             List<Noticia> noticias = new List<Noticia>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticia noticia = new Noticia();
                noticia.IdNoticia = Int32.Parse(linha[0]);
                noticia.Titulo = linha[1];
                noticia.Imagem = linha[2];
                noticia.Texto  = linha[3];

                noticias.Add(noticia);
            }
            return noticias;
        }
    }
}