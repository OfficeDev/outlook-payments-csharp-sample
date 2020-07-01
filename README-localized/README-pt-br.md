---
page_type: sample
products:
- aspnet
- dotnet
- office
- office-365
- office-outlook
languages:
- javascript
- csharp
description: "Este é um exemplo de implementação da solicitação de pagamento e de um pagamento concluído da webhook para um serviço de Pagamento do Outlook."
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Exemplo de pagamentos da API Web do ASP.NET no Outlook webhook

Este é um exemplo de implementação da solicitação de pagamento e webhooks completos de pagamento para um serviço [Pagamentos no Outlook](https://docs.microsoft.com/outlook/payments/).

## Pré-requisitos

Antes de executar este exemplo, você deve [se registrar no painel Pagamentos no Outlook](https://docs.microsoft.com/outlook/payments/partner-dashboard) e ter uma conta da plataforma de conexão [Stripe](https://stripe.com/connect).

Você também deve ter o Visual Studio 2017 instalado.

## Configurar o exemplo

1. Faça uma cópia do arquivo [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config)no**diretório**OutlookPayments. Renomeie a cópia do arquivo para `MerchantInfo. config`.
1. Abra o **OutlookPayments. sln** no Visual Studio.
1. Abra o arquivo **MerchantInfo. config** e atualize o valor da `Comercianteid` com a ID de comerciante no painel de pagamentos no painel do Outlook.

## Execução do exemplo

Pressione **F5** ou selecione **iniciar depuração** no menu **Debug** no Visual Studio.

## Usar ngrok para executar localmente

Ao executar o exemplo localmente, ele é acessível por meio de `http://localhost:52663`. O serviço de pagamento deverá entrar em contato com seu webhook pela Internet, assim, a execução no host local não funcionará. Entretanto, ao usar [ngrok](https://ngrok.com/), pode-se criar um endereço publicamente acessível que é temporariamente capaz de entrar em contato com o host local.

Abrir um prompt de comando ou shell e executar o seguinte comando:

```Shell
ngrok http 52663 -host-header=localhost:52663
```

O arquivo deve ser semelhante ao seguinte:

```Shell
ngrok by @inconshreveable                                     (Ctrl+C to quit)

Session Status                online
Account                       Jason Johnston (Plan: Free)
Version                       2.2.8
Region                        United States (us)
Web Interface                 http://127.0.0.1:4040
Forwarding                    http://68cd84ed.ngrok.io -> localhost:52663
Forwarding                    https://68cd84ed.ngrok.io -> localhost:52663
```

Copiar a URL HTTPS da segunda `Entrada de encaminhamento`. Na saída acima, a URL a ser copiada é `https://68cd84ed.ngrok.io`. Ao usar essa URL como base, serão construídas duas URLs: um para a webhook de solicitação de pagamento (ngrok URL + `/api/invoices`), e outra para a webhook de pagamento completo (ngrok URL + `/api/payments`). Por exemplo, ao usar a URL do exemplo de saída acima:

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [! IMPORTANTE]
deixe ngrok em execução para que as URLs permaneçam ativas.

Atualize as URLs do webhook no painel parceiro com essas URLs para teste.

![Uma captura de tela das URLs da webhook no painel Pagamentos no Outlook](readme-images/dashboard-webhooks.PNG)

## Gerando uma mensagem de solicitação de pagamento de teste

Confira [introdução aos pagamentos no Outlook](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request) para obter as etapas para enviar uma mensagem de teste para si mesmo.

## Colaboração

Este projeto recebe e agradece as contribuições e sugestões.
A maioria das contribuições exige que você concorde com um CLA (Contrato de Licença de Contribuinte) declarando que você tem o direito e realmente nos concede os direitos de usar sua contribuição.
Para saber mais, [https://cla.microsoft.com](https://cla.microsoft.com).

Quando você envia uma solicitação de pull, um bot de CLA determina automaticamente se você precisa fornecer um CLA e decora o PR adequadamente (por exemplo, rótulo, comentário).
Basta seguir as instruções fornecidas pelo bot.
Você só precisa fazer isso uma vez em todos os repositórios que usam nosso CLA.

Este projeto adotou o [Código de Conduta de Código Aberto da Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para saber mais, confira as [Perguntas frequentes sobre o Código de Conduta](https://opensource.microsoft.com/codeofconduct/faq/)
ou entre em contato pelo [opencode@microsoft.com](mailto:opencode@microsoft.com) se tiver outras dúvidas ou comentários.
