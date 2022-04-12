using ControleCinema.ConsoleApp.Compartilhado;
using ControleCinema.ConsoleApp.ModuloSala;
using ControleCinema.ConsoleApp.ModuloFilme;
using System;
using System.Collections.Generic;

namespace ControleCinema.ConsoleApp.ModuloSessao

{
    public class TelaCadastroSessao : TelaBase, ITelaCadastravel
    {
        private readonly IRepositorio<Sessao> _repositorioSessao;
        private readonly Notificador _notificador;
        private readonly TelaCadastroSala _telaCadastroSala;
        private readonly TelaCadastroFilme _telaCadastroFilme;

        public TelaCadastroSessao(IRepositorio<Sessao> repositorioSessao, 
                                  Notificador notificador, 
                                  TelaCadastroSala telaCadastroSala,
                                  TelaCadastroFilme telaCadastroFilme)
                                  : base("Cadastro de Sessao")
        {
            _repositorioSessao = repositorioSessao;
            _notificador = notificador;
            _telaCadastroSala = telaCadastroSala;
            _telaCadastroFilme = telaCadastroFilme;
        }

        public void Inserir()
        {
            MostrarTitulo("Cadastro de Sessao ");

            Sessao novaSessao = ObterSessao();

            _repositorioSessao.Inserir(novaSessao);

            _notificador.ApresentarMensagem("Sessao Cadastrada com sucesso!", TipoMensagem.Sucesso);
        }

        public Filme ObterFilme()
        {
            bool temFilmeDisponivel = _telaCadastroFilme.VisualizarRegistros("pesquisando");

            if (temFilmeDisponivel == false)
            {
                _notificador.ApresentarMensagem(
                    "Nenhum filme disponivel", TipoMensagem.Atencao);
                return null;
            }
            Console.Write("Digite o id do filme que sera apresentado: ");
            string nomeDoFilme = Console.ReadLine();
            Console.WriteLine();

            return new Filme(nomeDoFilme);
        }

        private Sala ObterSala()
        {
            bool temSalaDisponivel = _telaCadastroSala.VisualizarRegistros("pesquisando");

            if(temSalaDisponivel == false)
            {
                _notificador.ApresentarMensagem(
                    "Nenhuma sala disponivel", TipoMensagem.Atencao);
                return null;
            }
            Console.Write("Digite a id da sala na qual a sessao acontecerá: ");
            int idDaSala = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            return new Sala(idDaSala);
        }

        public void Editar()
        {
            MostrarTitulo("Editando Sessao");

            bool temRegistrosCadastrados = VisualizarRegistros("Pesquisando");

            if (temRegistrosCadastrados == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sessao para editar.", TipoMensagem.Atencao);
                return;
            }

            int numeroSessao = ObterNumeroRegistro();

            Sessao sessaoAtualizada = ObterSessao();

            bool conseguiuEditar = _repositorioSessao.Editar(numeroSessao , sessaoAtualizada);

            if (!conseguiuEditar)
                _notificador.ApresentarMensagem("Não foi possível editar.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sessao editada com sucesso!", TipoMensagem.Sucesso);
        }

        public void Excluir()
        {
            MostrarTitulo("Excluindo Sessao");

            bool temSessaoRegistrada = VisualizarRegistros("Pesquisando");

            if (temSessaoRegistrada == false)
            {
                _notificador.ApresentarMensagem("Nenhuma sessao cadastrada para excluir.", TipoMensagem.Atencao);
                return;
            }

            int numeroSessao = ObterNumeroRegistro();

            bool conseguiuExcluir = _repositorioSessao.Excluir(numeroSessao);

            if (!conseguiuExcluir)
                _notificador.ApresentarMensagem("Não foi possível excluir.", TipoMensagem.Erro);
            else
                _notificador.ApresentarMensagem("Sessão excluída com sucesso", TipoMensagem.Sucesso);
        }

        public bool VisualizarRegistros(string tipoVisualizacao)
        {
            if (tipoVisualizacao == "Tela")
                MostrarTitulo("Visualização de sessoes");

            List<Sessao> sessoes = _repositorioSessao.SelecionarTodos();

            if (sessoes.Count == 0)
            {
                _notificador.ApresentarMensagem("Nenhuma sessao disponível.", TipoMensagem.Atencao);
                return false;
            }

            foreach (Sessao sessao in sessoes)
                Console.WriteLine(sessao.ToString());


            Console.ReadLine();

            return true;
        }

        private Sessao ObterSessao()

        {
            Console.Write("Digite o nome da Sessao: ");
            string nomeDaSessao = Console.ReadLine();

            Console.Write("Digite a data e hora da sessao: ");
            DateTime dataDoFilme = Convert.ToDateTime(Console.ReadLine());

            
            Sala salaDaSessao = ObterSala();

            Filme filmeApresentado = ObterFilme();


            return new Sessao(nomeDaSessao, dataDoFilme, salaDaSessao, filmeApresentado);
        }

        public int ObterNumeroRegistro()
        {
            int numeroRegistro;
            bool numeroRegistroEncontrado;

            do
            {
                Console.Write("Digite o ID da sessao que deseja modificar: ");
                numeroRegistro = Convert.ToInt32(Console.ReadLine());

                numeroRegistroEncontrado = _repositorioSessao.ExisteRegistro(numeroRegistro);

                if (numeroRegistroEncontrado == false)
                    _notificador.ApresentarMensagem("ID da sessao nao foi encontrado, digite novamente", TipoMensagem.Atencao);

            } while (numeroRegistroEncontrado == false);

            return numeroRegistro;
        }
    }
}
