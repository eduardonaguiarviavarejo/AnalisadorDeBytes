﻿using System.Threading.Tasks;

namespace AnalisadorDeBytes.Core.Componentes.Log
{
    public interface IGeradorDeLog
    {
        Task GerarLog(string mensagem);
    }
}
