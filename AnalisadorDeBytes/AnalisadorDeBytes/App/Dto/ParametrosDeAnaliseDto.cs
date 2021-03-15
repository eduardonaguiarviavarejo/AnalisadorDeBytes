using AnalisadorDeBytes.Dominio.Modelo;
using AnalisadorDeBytes.IoC;
using System.ComponentModel.DataAnnotations;

namespace AnalisadorDeBytes.App
{
    public class ParametrosDeAnaliseDto : IDto
    {
        public ParametrosDeAnaliseDto(            
            string caminhoDoArquivo, 
            int tamanhoDoBufferEmBytes,
            TiposDeRelatorio tiposDeRelatorio = TiposDeRelatorio.Tabela)
        {
            TiposDeRelatorio = tiposDeRelatorio;
            CaminhoDoArquivo = caminhoDoArquivo;
            TamanhoDoBufferEmBytes = tamanhoDoBufferEmBytes;
        }

        public TiposDeRelatorio TiposDeRelatorio { get; private set; }
        
        [Required(ErrorMessage = "Parâmetro requerido.")]
        public string CaminhoDoArquivo { get; private set; }

        
        [Required(ErrorMessage = "Parâmetro requerido.")]        
        public int TamanhoDoBufferEmBytes { get; private set; }
    }
}