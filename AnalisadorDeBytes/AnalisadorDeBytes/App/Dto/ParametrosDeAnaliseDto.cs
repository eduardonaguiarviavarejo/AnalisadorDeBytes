using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System.ComponentModel.DataAnnotations;

namespace AnalisadorDeBytes.App
{
    public class ParametrosDeAnaliseDto : IDto
    {
        public TiposDeRelatorio TiposDeRelatorio { get; set; } = TiposDeRelatorio.Tabela;
        
        [Required(ErrorMessage = "Parâmetro requerido.")]
        public string CaminhoDoArquivo { get; set; }

        
        [Required(ErrorMessage = "Parâmetro requerido.")]        
        public int TamanhoDoBufferEmBytes { get; set; }
    }
}