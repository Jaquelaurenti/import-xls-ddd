using System;
using System.Collections.Generic;
using System.Text;

namespace ImportSpreadsheet.Application.Dtos
{
    public class SpreadSheetDTO
    {
        // colocar as colunas da planilha

        public string Objeto { get; set; }
        public string Cargo { get; set; }
        public string PerguntaAtual { get; set; }
        public string PerguntaNova { get; set; }
        public string Error { get; set; }
    }
}
