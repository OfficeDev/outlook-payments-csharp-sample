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
description: "Это пример реализации веб-запросов на оплату и оплату услуг в Outlook"
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Примеры выплат ASP.NET веб-API в веб-перехватчике Outlook

В этом примере демонстрируется реализация запросов на платеж и завершенных веб-перехватчиков для [Выплаты в службе Outlook](https://docs.microsoft.com/outlook/payments/).

## Необходимые условия

Перед тем как приступить к работе с этим образцом, необходимо [зарегистрироваться на панели мониторинга Outlook](https://docs.microsoft.com/outlook/payments/partner-dashboard) и необходимо иметь учетную запись подключения [Stripe](https://stripe.com/connect).

Также необходимо установить Visual Studio 2017.

## Рис. 1. Настройка примераНастройка примера

1. Создайте копию файла [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config) в каталоге **OutlookPayments**. Переименуйте эту копию файла в `MerchantInfo.config`.
1. Откройте **OutlookPayments.sln** в Visual Studio.
1. Откройте файл **MerchantInfo.config** и обновите значение ключа `MerchantId`, используя свой идентификатор продавца, в разделе "Платежи в Outlook".

## Запуск приложения

Нажмите клавишу **F5** или выберите **Начать отладку** в меню **Отладка** в Visual Studio.

## Использование ngrok для локального запуска

При запуске примера локально можно получить доступ к нему с помощью `http://localhost:52663`. Служба платежей должна поддерживать связь с веб-перехватчиком с Интернет, поэтому запуск на localhost не будет работать. Однако с помощью [ngrok](https://ngrok.com/)можно создать общедоступный адрес, с которого временно можно связаться с localhost.

Откройте командную строку или интерпретатор команд и выполните следующую команду:

```Shell
ngrok http 52663 -host-header=localhost:52663
```

Результат должен выглядеть примерно так:

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

Скопируйте URL-адрес HTTPS из второй записи `Пересылки`. В приведенном выше результате URL-адрес для копирования `https://68cd84ed.ngrok.io`. Используя этот URL-адрес в качестве основы, давайте создадим два URL-адреса: один из них — веб-перехватчик запроса на платеж (ngrok URL + `/api/invoices`), а второй — веб перехватчик по завершению платежа (ngrok URL + `/api/payments`). Например, с помощью URL-адреса из приведенного выше примера выводится следующее:

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [! ВАЖНО]
Оставьте ngrok включенным, чтобы эти URL оставались активными.

Обновите URL-адреса веб-перехватчика на информационной панели партнера, используя эти URL-адреса для проверки.

![Снимок экрана: URL-адреса веб-перехватчика в области "платежи в Outlook"](readme-images/dashboard-webhooks.PNG)

## Генерация тестового сообщения о платеже

См. [Начало работы с платежами в Outlook](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request), чтобы узнать, как отправить тестовое сообщение себе.

## Помощь

Мы всегда рады предложениям и помощи в работе над проектом.
Обычно для добавления своих вариантов необходимо принять Лицензионное соглашение с участником (CLA), заявив, что вы имеете право предоставлять и предоставляете нам права на использование своего варианта.
Дополнительные сведения см. в [https://cla.microsoft.com](https://cla.microsoft.com).

Когда вы будете отправлять запрос на вытягивание, CLA-бот автоматически определит, нужно ли вам предоставить CLA и соответствующим образом изменит внешний вид запроса на вытягивание (например, добавит метку, комментарий).
Просто следуйте инструкциям бота.
Вам нужно будет сделать это только один раз во всех репозиториях, используя наш CLA.

Этот проект соответствует [Правилам поведения разработчиков открытого кода Майкрософт](https://opensource.microsoft.com/codeofconduct/).
Дополнительные сведения см. в разделе [часто задаваемых вопросов о правилах поведения](https://opensource.microsoft.com/codeofconduct/faq/).
Если у вас возникли вопросы или замечания, напишите нам по адресу [opencode@microsoft.com](mailto:opencode@microsoft.com).
