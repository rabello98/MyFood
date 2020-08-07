using MyFood.Framework.Contracts.Service;
using MyFood.ViewModel;
using System;
namespace MyFood.Service
{
    public class CreditCardValidatorService : ICreditCardValidatorService
    {
        public bool Validate(PagamentoCartaoView pagamentoCartao, string formaPagamento)
        {
            if (String.IsNullOrEmpty(pagamentoCartao.NumeroCartao) 
                || String.IsNullOrEmpty(pagamentoCartao.CodigoSeguranca)
                || pagamentoCartao.DataVencimento == null)
            {
                throw new ArgumentException("Invalid information of credit card");
            }

            switch (formaPagamento)
            {
                // Not Implemented (fake)
                case "CC":
                    return true;
                case "CD":
                    return true;
            }

            return false;
        }
    }
}
