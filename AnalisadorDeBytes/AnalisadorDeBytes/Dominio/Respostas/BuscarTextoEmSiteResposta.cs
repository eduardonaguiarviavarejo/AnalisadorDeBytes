using AnalisadorDeBytes.IoC;

namespace AnalisadorDeBytes.Dominio.Respostas
{
    public class BuscarTextoEmSiteResposta : IResposta
    {
        public string TextoRecuperadoDaWeb { get; private set; }

        public BuscarTextoEmSiteResposta(string textoRecuperadoDaWeb)
        {
            TextoRecuperadoDaWeb = textoRecuperadoDaWeb;
        }
    }
}
