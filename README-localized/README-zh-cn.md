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
description: "这是 Payments in Outlook 服务的付款请求和付款完成 Webhook 的示例实现。"
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Outlook Webhook 中的 ASP.NET Web API 付款示例

这是 [Payments in Outlook](https://docs.microsoft.com/outlook/payments/) 服务的付款请求和付款完成 Webhook 的示例实现。

## 先决条件

在运行本示例之前，必须[在 Payments in Outlook 中注册](https://docs.microsoft.com/outlook/payments/partner-dashboard)，并且必须具有 [Stripe](https://stripe.com/connect) Connect 平台帐户。

此外，还必须安装 Visual Studio 2017。

## 配置本示例

1. 复制 **OutlookPayments** 目录中的 [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config) 文件。将此文件副本重命名为 `MerchantInfo.config`。
1. 在 Visual Studio 中打开 **OutlookPayments.sln**。
1. 打开 **MerchantInfo.config** 文件，然后使用 Payments in Outlook 中的付款 ID 更新 `MerchantId` 键的值。

## 运行本示例

在 Visual Studio 中按 **F5** 或从“**调试**”菜单中选择“**开始调试**”。

## 使用 ngrok 在本地运行

在本地运行本示例时，可通过 `http://localhost:52663` 访问它。付款服务必须能够从 Internet 联系你的 Webhook，因此在 localhost 上运行将不起作用。但是，通过使用 [ngrok](https://ngrok.com/)，我们可以创建暂时可与 localhost 联系并且可公开访问的地址。

打开命令提示符窗口或 Shell，然后运行以下命令：

```Shell
ngrok http 52663 -host-header=localhost:52663
```

输出结果应如下所示：

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

从第二个 `Forwarding` 条目中复制 HTTPS URL。在上面的输出中，要复制的 URL 是 `https://68cd84ed.ngrok.io`。以该 URL 为基础，让我们构造两个 URL：一个用于付款请求 Webhook (ngrok URL + `/api/invoices`)，另一个用于付款完成 Webhook (ngrok URL + `/api/payments`)。例如，使用上面示例输出中的 URL：

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [!重要提示]
使 ngrok 保持运行状态，以便让这些 URL 保持活动状态。

使用这些 URL 来更新合作伙伴仪表板中的 Webhook URL 以便进行测试。

![Payments in Outlook 仪表板中的 Webhook URL 的屏幕截图](readme-images/dashboard-webhooks.PNG)

## 生成测试付款请求邮件

请参阅 [Payments in Outlook 入门](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request)以了解向自己发送测试邮件的步骤。

## 参与

本项目欢迎供稿和建议。
大多数的供稿都要求你同意“参与者许可协议 (CLA)”，声明你有权并确定授予我们使用你所供内容的权利。
有关详细信息，请访问 [https://cla.microsoft.com](https://cla.microsoft.com)。

在提交拉取请求时，CLA 机器人会自动确定你是否需要提供 CLA 并适当地修饰 PR（例如标记、批注）。
只需按照机器人提供的说明操作即可。
只需在所有存储库上使用我们的 CLA 执行此操作一次。

此项目已采用 [Microsoft 开放源代码行为准则](https://opensource.microsoft.com/codeofconduct/)。
有关详细信息，请参阅[行为准则常见问题解答](https://opensource.microsoft.com/codeofconduct/faq/)。
如有其他任何问题或意见，也可联系 [opencode@microsoft.com](mailto:opencode@microsoft.com)。
