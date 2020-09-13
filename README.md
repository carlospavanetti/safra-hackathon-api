# Sofia - Chatbot para o desafio Hackathon Safra 2020

Este é o protótipo apresentado no Hackathon Safra 2020 pelo time 3, composto pelos seguintes integrantes:

- Camila Vieira
- Carlos Pavanetti
- Caroline Alcântara
- Débora Bonfá
- Hector Lima

## Estrutura do projeto

O projeto utiliza o framework Next.js, feito em cima da biblioteca React.js,
e se integra com o backend, feito em ASP.NET Core, pela fetch API.

## Estrutura do back-end do projeto

O back-end do projeto está estruturado de acordo com o padrão MVC (Model-View-Controller). O diretório `Controllers` contém a mediação entre entrada e saída da API, o diretório `Services` é responsável por se comunicar com a camada de dados, enquanto no diretório `Agents` se encontram as classes responsáveis pela comunicação com as `APIs` disponibilizadas para o desafio Hackathon Safra.

Essa API utiliza as requisições `GET` e `POST` para se comunicarem e HTTP [response codes](https://en.wikipedia.org/wiki/List_of_HTTP_status_codes) para indicar status e erros. Todas as respostas são dadas em JSON.

## Dados da conta

**Você envia:** ID da conta.
**Você obtém:** Um JSON com os dados básicos da conta.

**Requisição:**

```json
GET / api / account / 00711234533
```

**Resposta válida:**

```json
{
  "Data": {
    "Account": [
      {
        "AccountId": "00711234533",
        "Currency": "BRL",
        "Nickname": "Mark",
        "Account": {
          "SchemeName": "SortCodeAccountNumber",
          "Identification": "12345678901233",
          "Name": "Mark Zuckerberg da Silva",
          "SecondaryIdentification": "12332133"
        }
      }
    ]
  },
  "Links": {
    "Self": "/accounts/00711234533"
  }
}
```

## Saldo da conta

**Você envia:** ID da conta.
**Você obtém:** Um JSON com o saldo da conta.

**Requisição:**

```json
GET / api / account / 00711234533 / balances
```

**Resposta válida:**

```json
{
  "Data": {
    "Balance": [
      {
        "AccountId": "00711234533",
        "Amount": {
          "Amount": "2768.48",
          "Currency": "BRL"
        },
        "CreditDebitIndicator": "Debit",
        "Type": "InterimAvailable",
        "DateTime": "2020-06-23T10:43:07-03:00",
        "CreditLine": [
          {
            "Included": false,
            "Amount": {
              "Amount": "97231.52",
              "Currency": "BRL"
            },
            "Type": "Pre-Agreed"
          },
          {
            "Included": false,
            "Amount": {
              "Amount": "20000.00",
              "Currency": "BRL"
            },
            "Type": "Emergency"
          }
        ]
      }
    ]
  },
  "Links": {
    "Self": "/accounts/00711234533/balances/"
  }
}
```

## Transações da conta

**Você envia:** ID da conta.
**Você obtém:** Um JSON com as últimas transações da conta.

**Requisição:**

```json
GET / api / account / 00711234533 / transactions
```

**Resposta válida:**

```json
{
  "data": {
    "transaction": [
      {
        "accountId": "00711234533",
        "transactionId": "999921",
        "amount": {
          "amount": "8000.00",
          "currency": "BRL"
        },
        "creditDebitIndicator": "Credit",
        "status": "Booked",
        "bookingDateTime": "2020-05-09T11:43:07-03:00",
        "valueDateTime": "2020-05-09T11:45:22-03:00",
        "transactionInformation": "Entrada Compra Carro",
        "bankTransactionCode": {
          "code": "ReceivedCreditTransfer",
          "subCode": "DomesticCreditTransfer"
        },
        "proprietaryBankTransactionCode": {
          "code": "Transfer",
          "issuer": "BancoSafra"
        },
        "balance": {
          "amount": {
            "amount": "5481,52",
            "currency": "BRL"
          },
          "creditDebitIndicator": "Debit",
          "type": "InterimBooked"
        }
      },
      {
        "accountId": "00711234533",
        "transactionId": "999911",
        "amount": {
          "amount": "250.00",
          "currency": "BRL"
        },
        "creditDebitIndicator": "Debit",
        "status": "Booked",
        "bookingDateTime": "2020-04-05T10:43:07-03:00",
        "valueDateTime": "2020-04-05T10:45:22-03:00",
        "transactionInformation": "Mensalidade Academia",
        "bankTransactionCode": {
          "code": "ReceivedCreditTransfer",
          "subCode": "DomesticCreditTransfer"
        },
        "proprietaryBankTransactionCode": {
          "code": "Transfer",
          "issuer": "BancoSafra"
        },
        "balance": {
          "amount": {
            "amount": "2768.48",
            "currency": "BRL"
          },
          "creditDebitIndicator": "Credit",
          "type": "InterimBooked"
        }
      }
    ]
  },
  "links": {
    "self": "/accounts/00711234533/transactions"
  }
}
```

## Gráficos da conta

**Você envia:** ID da conta.
**Você obtém:** Um JSON com o gráficos referentes as últimas transações da conta.

**Requisição:**

```json
GET / api / account / 00711234533 / graphics
```

**Resposta válida:**

```json
{
  "AccountId": "00711234533",
  "Url": "https://public.tableau.com/views/GraficosSafra/Painel3?:showVizHome=no&:embed=true"
}
```

## Aprovação de renegociação de dívida

**Você envia:** ID da conta.
**Você obtém:** Um JSON com a resposta (SIM/NÃO) se a conta especificada possui autorização para renegociar a dívida.

**Requisição:**

```json
GET api/account/00711234533/debtapprove
```

**Resposta válida:**

```json
{
  "AccountId": "00711234533",
  "Approved": true
}
```

## Congelamento de renegociação da dívida

**Você envia:** ID da conta.
**Você obtém:** Um JSON com a resposta (SIM/NÃO) se a ação de congelar a dívida foi autorizada

**Requisição:**

```json
POST api/account/00711234533/debtfreezing
```

**Resposta válida:**

```json
{
  "AccountId": "00711234533",
  "Approved": true
}
```

## Morning Calls

**Você envia:** -
**Você obtém:** Um JSON com as últimas Morning Calls do banco Safra.

**Requisição:**

```json
GET api/morningcalls
```

**Resposta válida:**

```json
{
  "data": [
    {
      "id": "_V8f_Su9_RA",
      "channel": "safra",
      "playlist": "morningCalls",
      "data": "2020-07-14",
      "title": "Morning Call Safra - 14/07/2020",
      "description": "Veja no Morning Call desta terça-feira, 14 de julho, como o Ibovespa perdeu ontem os 100 mil pontos, após passar a maior parte do pregão acima desse nível.",
      "links": [
        {
          "href": "https://www.youtube.com/watch?v=_V8f_Su9_RA",
          "rel": "youtube",
          "title": "Link Youtube do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/KkvwgXxVpb3LtpopVhGJ7VgeKbp23imgFbBrImW4W_Q/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2014_07_2020.m4a",
          "rel": "audioFile",
          "title": "Arquivo .m4a do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/A4foEVfocaZE-enp7tmLdButDRwCxamcryNOCte3P1Q/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2014_07_2020.mp4",
          "rel": "videoFile",
          "title": "Arquivo .mp4 do Morning Call"
        }
      ]
    },
    {
      "id": "bsFdyOim2iM",
      "channel": "safra",
      "playlist": "morningCalls",
      "data": "2020-07-10",
      "title": "Morning Call Safra - 10/07/2020",
      "description": "No Morning Call desta sexta-feira, 10 de julho, comentamos sobre como o Ibovespa chegou a superar a marca dos 100 mil pontos ontem, embora não tenha conseguido sustentar os ganhos.",
      "links": [
        {
          "href": "https://www.youtube.com/watch?v=bsFdyOim2iM",
          "rel": "youtube",
          "title": "Link Youtube do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/avSFUKU9GTdRswxPKZmz3ARgVDDVBc_7fy2JRJH0Z4A/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2010_07_2020.m4a",
          "rel": "audioFile",
          "title": "Arquivo .m4a do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/KiQYxZtZT0MBPce8dpnu1dTJcbBgGUSrsFsEFCMDPPM/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2010_07_2020.mp4",
          "rel": "videoFile",
          "title": "Arquivo .mp4 do Morning Call"
        }
      ]
    },
    {
      "id": "TvGi1rTewVE",
      "channel": "safra",
      "playlist": "morningCalls",
      "data": "2020-07-09",
      "title": "Morning Call Safra - 09/07/2020",
      "description": "No Morning Call desta quinta-feira, 9 de julho, comentamos sobre o forte desempenho no dia de ontem, quando o Ibovespa se aproximou dos 100 mil pontos.",
      "links": [
        {
          "href": "https://www.youtube.com/watch?v=TvGi1rTewVE",
          "rel": "youtube",
          "title": "Link Youtube do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/OYtv12R9oMRDz9PntENXFmSceGX0V4oFtKRYCFmTiyc/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2009_07_2020.m4a",
          "rel": "audioFile",
          "title": "Arquivo .m4a do Morning Call"
        },
        {
          "href": "https://objectstorage.sa-saopaulo-1.oraclecloud.com/p/Bq-j8Jzq-VJa473YxbCQ6HYP_JhdYcXKptgt9CSo1Mo/n/gr618lalrmiy/b/morningcalls/o/Morning%20Call%20Safra%20-%2009_07_2020.mp4",
          "rel": "videoFile",
          "title": "Arquivo .mp4 do Morning Call"
        }
      ]
    }
  ]
}
```
