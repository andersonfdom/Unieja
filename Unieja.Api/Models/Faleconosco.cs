using System;
using System.Collections.Generic;

namespace Unieja.Api.Models
{
    public partial class Faleconosco
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? Assunto { get; set; }
        public string? Mensagem { get; set; }
    }
}
