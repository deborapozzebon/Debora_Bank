# Debora_Bank

Essa API disponibiliza opções básicas (GET, INSERT, UPDATE and DELETE) para uma conta de banco e suas transações.

A API está publicada neste [link](https://deborabank20200317085200.azurewebsites.net/accounts).

## Getting Started

Para testar a API localmente, clone este repositório.

Dentro do projeto "Debora_Bank", encontre o arquivo launchSettings.json e altere a porta que a API irá utilizar em seu computador. 

Por default, deixamos setado com "4545", mas caso essa porta já esteja em uso por outra aplicação, troque por qualquer outra disponível.

Ex: "applicationUrl": "http://localhost:5050"

### End points
#### ACCOUNT:
* POST: 
https://deborabank20200317085200.azurewebsites.net/accounts

No body da requisição, serialize o objeto Account. Podendo setar, as propriedades: Nome, CPF e Saldo atual. 

```
{
	"currentBalance": 500,
	"name": "Wagner",
	"cpf": "03273853085"
}
```


* GET ALL

https://deborabank20200317085200.azurewebsites.net/accounts

Este end point retorna todas as contas registradas.


* GET BY ID

https://deborabank20200317085200.azurewebsites.net/accounts/ {INSIRA O NÚMERO DO ID AQUI}

Exemplo, get na conta com o ID 1: https://deborabank20200317085200.azurewebsites.net/accounts/1

* PUT: 

No body da requisição serialize os dados para atualizar na conta. Na url, passe o ID da conta que deseja atualizar.

https://deborabank20200317085200.azurewebsites.net/accounts/ {INSIRA O NÚMERO DO ID AQUI}

```
{
	"currentBalance": 350,
	"name": "Wagner Scholl",
	"cpf": "03273853085"
}
```

* DELETE: 

Passe na url o ID da conta que deseja deletar.
 
 https://deborabank20200317085200.azurewebsites.net/accounts/ {INSIRA O NÚMERO DO ID AQUI}
 
 Exemplo, delete da conta com o ID 1: https://deborabank20200317085200.azurewebsites.net/accounts/1
 
 #### TRANSACTIONS:
 
 * POST: 
https://deborabank20200317085200.azurewebsites.net/transactions

No body da requisição, serialize o objeto transactions. Podendo setar, as propriedades: Tipo de transação, data, valor e o ID da conta que essa transação pertence.

Estão disponíveis as seguintes transações:
* 0 = Depósito
* 1 = Saque
* 2 = Transferência (Em desenvolvimento ainda...)
* 3 = Pagamento


```
{
	"transactionType": 0,
	"date": "2020-03-16",
	"value": 500,
	"accountId": 1
}
```


* GET ALL

https://deborabank20200317085200.azurewebsites.net/transactions

Este end point retorna todas as transações registradas.


* GET BY ID

https://deborabank20200317085200.azurewebsites.net/transactions/ {INSIRA O NÚMERO DO ID AQUI}

Exemplo, get da transação com o ID 1: https://deborabank20200317085200.azurewebsites.net/transactions/1

* PUT: 

No body da requisição serialize os dados para atualizar a transação. Na url, passe o ID da transação que deseja atualizar.

https://deborabank20200317085200.azurewebsites.net/transactions/ {INSIRA O NÚMERO DO ID AQUI}

```
{
	"transactionType": 1,
	"date": "2020-03-16",
	"value": 50,
	"accountId": 1
}
```

* DELETE: 

Passe na url o ID da transação que deseja deletar.
 
 https://deborabank20200317085200.azurewebsites.net/transactions/ {INSIRA O NÚMERO DO ID AQUI}
 
 Exemplo, delete da transação com o ID 1: https://deborabank20200317085200.azurewebsites.net/transactions/1
 

## In Progress
Para as próximas versões, estarão disponíveis:
* Front em React
* Transação do tipo transferência entre contas, tendo disponível TED e DOC com suas respectivas regras. 
* Rentabilização do dinheiro na conta

 
## Author 
Débora Pozzebon
