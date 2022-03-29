using System;

namespace DIO.SERIES.Classes
{
    public class Serie : EntidadeBase
    {
        private Generos Genero { get; set; }
        public string Titulo { get; protected set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        public bool Excluido { get; private set; }

        public Serie(int id, Generos genero, string titulo, string descricao, int ano) 
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public void Excluir() {
            this.Excluido = true;
        }

        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += $"Gênero: {this.Genero}{Environment.NewLine}";
            retorno += $"Titulo: {this.Titulo}{Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao}{Environment.NewLine}";
            retorno += $"Ano de Início: {this.Ano}{Environment.NewLine}";
            return retorno;
        }
    }
}