using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL
{
    public class Jogo
    {
        public int Id { get; set; }
        public double? ValorPago { get; set; }
        public string Img { get; set; }
        public DateTime? DataCompra { get; set; }
        public string Titulo { get; set; }
        public int IdGenero { get; set; }
        public Genero Genero { get; set; }
        public int IdEditor { get; set; }
        public Editor Editor { get; set; }
    }
}
