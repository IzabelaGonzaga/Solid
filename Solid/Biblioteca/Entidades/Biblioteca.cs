namespace Solid.Biblioteca.Entidades
{
    public class Biblioteca
    {
        private List<Livro> livros;
        private Dictionary<string, RegistroEmprestimo> registrosEmprestimo;

        public Biblioteca()
        {
            livros = new List<Livro>();
            registrosEmprestimo = new Dictionary<string, RegistroEmprestimo>();
        }

        // Métodos relacionados ao gerenciamento de livros
        public void AdicionarLivro(Livro livro)
        {
            livros.Add(livro);
        }

        public void RemoverLivro(Livro livro)
        {
            livros.Remove(livro);
        }

        public List<Livro> ObterLivros()
        {
            return livros;
        }

        // Métodos relacionados ao empréstimo de livros
        public void EmprestarLivro(string usuarioId, Livro livro)
        {
            if (livros.Contains(livro))
            {
                registrosEmprestimo[usuarioId] = new RegistroEmprestimo(usuarioId, livro, DateTime.Now);
                livros.Remove(livro);
            }
        }

        public void DevolverLivro(string usuarioId, Livro livro)
        {
            if (registrosEmprestimo.TryGetValue(usuarioId, out var registro) && registro.Livro.Equals(livro))
            {
                livros.Add(livro);
                registrosEmprestimo.Remove(usuarioId);
            }
        }

        // Métodos relacionados ao cálculo de multas
        public double CalcularMulta(string usuarioId)
        {
            if (registrosEmprestimo.TryGetValue(usuarioId, out var registro))
            {
                var diasEmprestados = (DateTime.Now - registro.DataEmprestimo).TotalDays;
                if (diasEmprestados > 14)
                {
                    return (diasEmprestados - 14) * 0.5;
                }
            }
            return 0.0;
        }
    }
}
