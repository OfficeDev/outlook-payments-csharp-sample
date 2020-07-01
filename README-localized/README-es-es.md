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
description: "Este es un ejemplo de implementación de los webhooks de solicitud de pago y pago completado para servicio de Pagos en Outlook."
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Ejemplo de webhook para pagos de la API Web de ASP.NET en Outlook

Este es un ejemplo de implementación de los webhooks de solicitud de pago y pago completado para un servicio de [Pagos en Outlook](https://docs.microsoft.com/outlook/payments/).

## Requisitos previos

Antes de ejecutar este ejemplo, debe [registrarse en el panel Pagos en Outlook](https://docs.microsoft.com/outlook/payments/partner-dashboard) y debe tener una cuenta de conexión de plataforma [Stripe](https://stripe.com/connect).

Debe tener instalado también Visual Studio 2017.

## Configuración del ejemplo

1. Haga una copia del archivo [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config) en el directorio **OutlookPayments**. Cambie el nombre de la copia del archivo a `MerchantInfo.config`.
1. Abra **OutlookPayments.sln** en Visual Studio.
1. Abra el archivo **MerchantInfo.config** y actualice el valor de la clave `MerchantId` con el ID. de comerciante en el panel Pagos de Outlook.

## Ejecución del ejemplo

Presione **F5** o seleccione **Iniciar la depuración** desde el menú **Depurar** en Visual Studio.

## Usar ngrok para ejecutar de forma local

Cuando ejecuta el ejemplo de forma local, puede obtener acceso a él a través de `http://localhost:52663`. El servicio de pago debe poder ponerse en contacto con el webhook desde Internet, por lo que no funcionará al usar localhost. Sin embargo, al usar [ngrok](https://ngrok.com/), podemos crear una dirección de acceso público que pueda ponerse en contacto con localhost de forma temporal.

Abra un shell o símbolo del sistema y ejecute el siguiente comando:

```Shell
ngrok http 52663 -host-header=localhost:52663
```

El resultado debería tener un aspecto similar al siguiente:

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

Copie la dirección URL HTTPS de la segunda entrada de `Reenvío`. En el resultado anterior, la dirección URL para copiar es `https://68cd84ed.ngrok.io`. Con esa dirección URL como base, construimos dos URL: una al remitente de la solicitud de pago (ngrok URL + `/api/invoices`) y otra al webhook de pago completado (ngrok URL + `/api/payments`). Por ejemplo, si usa la dirección URL del resultado de ejemplo anterior:

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [IMPORTANTE]
Deje ngrok en ejecución para que esas URL permanezcan activas.

Actualice sus URL de webhook en el panel del asociado con estas URL para las pruebas.

![Una captura de pantalla de las direcciones URL de webhook en el panel Pagos de Outlook](readme-images/dashboard-webhooks.PNG)

## Generar un mensaje de solicitud de pago de prueba

Consulte [Introducción a los Pagos en Outlook](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request) para ver los pasos para enviarse un mensaje de prueba a sí mismo.

## Colaboradores

Este proyecto recibe las contribuciones y las sugerencias.
La mayoría de las contribuciones necesitan un contrato de licencia de colaboración (CLA) que declare que tiene el derecho, y realmente lo tiene, de otorgarnos los derechos para usar su contribución.
Para obtener más información, visite [https://cla.microsoft.com](https://cla.microsoft.com).

Cuando envíe una solicitud de incorporación de cambios, un bot de CLA determinará automáticamente si necesita proporcionar un CLA y decorar PR correctamente (por ejemplo, etiqueta, comentario).
Siga las instrucciones proporcionadas por el bot.
Solo debe hacerlo una vez en todos los repos que usen nuestro CLA.

Este proyecto ha adoptado el [Código de conducta de código abierto de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Para obtener más información, vea [Preguntas frecuentes sobre el código de conducta](https://opensource.microsoft.com/codeofconduct/faq/)
o póngase en contacto con [opencode@microsoft.com](mailto:opencode@microsoft.com) si tiene otras preguntas o comentarios.
