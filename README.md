# MyFood

MyFood é uma Web API de um sistema de entrega de fast food. 

<a href="https://myfoodapi.azurewebsites.net/Home" target="_blank">Acesse o My Food</a>

MyFood foi desenvolvido com a intenção de colocar os conhecimentos em .Net do seu criador em prática. É uma aplicação muito simples e que atualmente não possui muitas funcionalidades pois o principal objetivo é colocar conhecimentos de diversas tecnologias em prática (Dependency Injection, AutoMapper, Refelction, etc.).

Obviamente para uma aplicação desse porte não seria necessário uma estrutura tão grande e complexa mas como o intuito é colocar conhecimentos em prática, o MyFood possui uma abordagem mais complexa e organizada em relação à sua arquitetura.

## API
Para ter êxito na utilização é importante seguir as implementações abaixo. Utilize alguma ferramenta para realizar requisições Http na API do MyFood. Postman é uma boa opção.

O endpoint utilizado no exemplo é onde a aplicação está hospedada para demonstração. Você pode realizar os testes como quiser fazendo o deploy em um servidor de sua preferência e trocando a url do endpoint.

#### Usuários
Atualmente não há nenhum tipo de autenticação de usuários na aplicação. Por enquanto todas as rotas estão abertas para a realização de testes.
Para realizar pedidos e comprar na plataforma é necessário o CPF de um usuário cadastrado, para que o sistema possa reconhecê-lo e gerar a operação.
##### Lista os usuários
Você pode utilizar um dos usuários que já estão cadastrados para realizar os testes

``` 
[Get]
https://myfoodapi.azurewebsites.net/api/v1/Usuario
```
##### Empresas
Para visualizar as empresas cadastradas no MyFood
``` 
[Get]
https://myfoodapi.azurewebsites.net/api/v1/Empresa
```
##### Produtos
Para escolher um produto acesse a lista
``` 
[Get]
https://myfoodapi.azurewebsites.net/api/v1/Produto
```
##### Pedidos
Agora vamos realizar um pedido
```
[Post]
https://myfoodapi.azurewebsites.net/api/v1/Pedido

[Body]
{
    "Pagamento": {
        "NumeroCartao": "5579252221601880",
        "MesVencimento": "08",
        "AnoVencimento": "2022",
        "CodigoSeguranca": "265"
    },
    "Pedido": {
        "UsuarioCpf": "312.407.190-51",
        "FormaPagamento": "CC",
        "Produtos": [
            { "ProdutoId": 1, "Quantidade": 1 }
        ]
    }
}
```
Para que o pedido seja gerado corretamente é importante que as seguintes convernções sejam seguidas:
 * O objeto enviado deve conter duas ramificações principais ("Pagamento" e "Pedido");
 * No "Pagamento" todas as informações do cartão devem ser preenchidas. Neste caso não há a necessidade de preenchimento com pontos e traços;
 * No "Pedido" devemos nos atentar a algumas regras:
    *  O CPF do usuário deve ser digitado com pontos e traços. É imprescindível que seja enviado, pois o sistema vincula o pedido ao cliente pelo CPF;
    *  O sistema possui duas forma de pagamento: "CC" (Cartão de Crédito) e DC (Cartão de Débito);
    *  Em "Produtos" devem ser preenchidos todos os produtos e as quantidades desejadas dentro da coleção passano o "ProdutoId" como identificador do produto (Na rota de produtos estão todas as informações necessárias).

IMPORTANTE: NÃO UTILIZE DADOS REAIS DE CARTÃO DE CRÉDITO!

Para consultar seu pedido
```
[Get]
https://myfoodapi.azurewebsites.net/api/v1/Pedido/{cpf}
```
Consulta:
 * O CPF deve ser enviado com pontos e traços.

## Conclusão
O MyFood é uma aplicação ainda muito simples mas expansiva. A arquitetura utilizada na construção permite uma grande expansão e facilidade para futuras manutenções e criação de novas funcionalidades.


