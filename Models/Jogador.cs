namespace E_PlayersAspNet.Models
{
    public class Jogador
    {
        //os Id podem amarrar as coisas, como se fosse uma espécie de herança.
        public int IdJogador { get; set; }
        public string Nome   { get; set; }
        public int IdEquipe  { get; set; }

    }
}