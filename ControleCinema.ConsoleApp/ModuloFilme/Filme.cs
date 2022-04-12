using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloGenero;
using System;
using System.Collections;

namespace ControleCinema.ConsoleApp.ModuloFilme

{
    public class Filme : EntidadeBase
    { 
        public string Nome { get; set; }
        public Genero Genero { get; set; }

        public Filme(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return "numero do Filme: " + id + Environment.NewLine +
                "nome do filme: " + Nome + Environment.NewLine;
        }
    }
}
