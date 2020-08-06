using System;

namespace MyFood.ViewModel
{
    public class PagamentoCartaoView
    {
         public String NumeroCartao { get; set; }
         public DateTimeOffset DataVencimento { get; set; }
         public String CodigoSeguranca { get; set; }
    }
}
