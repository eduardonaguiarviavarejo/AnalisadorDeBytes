using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System.ComponentModel.DataAnnotations;

namespace AnalisadorDeBytes.App
{
    public class ParametrosDeAnaliseDto : IDto
    {
        public ParametrosDeAnaliseDto(
            TiposDeRelatorio tiposDeRelatorio, 
            string caminhoDoArquivo, 
            int tamanhoDoBufferEmBytes)
        {
            TiposDeRelatorio = tiposDeRelatorio;
            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBufferEmBytes = tamanhoDoBufferEmBytes;
        }

        public TiposDeRelatorio TiposDeRelatorio { get; set; } = TiposDeRelatorio.Tabela;
        
        [Required(ErrorMessage = "Parâmetro requerido.")]
        public string CaminhoDoArquivo { get; set; }

        
        [Required(ErrorMessage = "Parâmetro requerido.")]        
        public int TamanhoDoBufferEmBytes { get; set; }
    }
}