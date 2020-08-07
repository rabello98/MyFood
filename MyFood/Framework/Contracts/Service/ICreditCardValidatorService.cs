using MyFood.ViewModel;
using System;

namespace MyFood.Framework.Contracts.Service
{
    public interface ICreditCardValidatorService
    {
        bool Validate(PagamentoCartaoView pagamentoCartao, String formaPagamento);
    }
}
