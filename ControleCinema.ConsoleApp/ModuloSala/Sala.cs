using ControleCinema.ConsoleApp.Compartilhado;
using System;
using System.Collections;

namespace ControleCinema.ConsoleApp.ModuloSala

{
    public class Sala : EntidadeBase
    { 
        public int NumeroDeCadeiras { get; set; }

        public Sala(int numeroDeCadeiras)
        {
            NumeroDeCadeiras = numeroDeCadeiras;
        }

        public override string ToString()
        {
            return "numero da Sala: " + id + Environment.NewLine +
                "numeros de caideiras da sala: " + NumeroDeCadeiras + Environment.NewLine;
        }
    }
}
