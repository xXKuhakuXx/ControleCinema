using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloSala;
using ControleCinema.ConsoleApp.ModuloFilme;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ControleCinema.ConsoleApp.ModuloSessao

{
    public class Sessao : EntidadeBase
    {
        public string NomeDaSessao { get; set; }
        public DateTime HorarioDaSessao;
        public Sala Sala;
        public Filme Filme;
        public List<Ingresso> Ingressos;


        public Sessao(string nomeDaSessao, DateTime horarioDaSessao, Sala sala, Filme filme)
        {
            NomeDaSessao = nomeDaSessao;
            HorarioDaSessao = horarioDaSessao;
            Sala = sala;
            Filme = filme;

        }

        public override string ToString()
        {
            return "Id: " + id + Environment.NewLine +
                "Nome da Sessao: " + NomeDaSessao + Environment.NewLine +
                "Data da Sessao: " + HorarioDaSessao + Environment.NewLine +
                "Filme da Sessao: " + Sala.id + Environment.NewLine +
                "Sala da Sessao : " + Filme.Nome;
                
        }
    }
}
