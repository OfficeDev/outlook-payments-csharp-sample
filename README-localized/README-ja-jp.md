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
description: "これは、Payments in Outlook サービス用の支払い要求 webhook と支払い完了 webhook の実装例です。"
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Outlook webhook での ASP.NET Web API 支払いのサンプル

これは、[Payments in Outlook](https://docs.microsoft.com/outlook/payments/) サービス用の支払い要求 webhook と支払い完了 webhook の実装例です。

## 前提条件

このサンプルを実行する前に、[Payments in Outlook ダッシュボードで登録](https://docs.microsoft.com/outlook/payments/partner-dashboard)する必要があり、[Stripe](https://stripe.com/connect) Connect プラットフォームのアカウントが必要です。

また、Visual Studio 2017 がインストールされている必要があります。

## サンプルの構成

1. **OutlookPayments** ディレクトリにある [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config) ファイルのコピーを作成します。このファイルのコピーの名前を `MerchantInfo` に変更します。
1. Visual Studio で **OutlookPayments.sln** を開きます。
1. **MerchantInfo.config** ファイルを開き、`MerchantId` キーの値を Outlook ダッシュボードの支払いからの業者 ID で更新します。

## サンプルの実行

**F5** を押すか、Visual Studio の [**デバッグ**] メニューから [**デバッグの開始**] を選択します。

## ngrok を使用してローカルで実行する

サンプルをローカルで実行する場合、サンプルは `http://localhost:52663` からアクセスできます。Payment サービスは、webhook にインターネットから接続できる必要があるため、localhost 上では実行できません。ただし、[ngrok](https://ngrok.com/) を使用することにより、localhost に一時的に接続することができる、一般にアクセス可能なアドレスを作成できます。

コマンド プロンプトまたはシェルを開き、次のコマンドを実行します。

```Shell
ngrok http 52663 -host-header=localhost:52663
```

出力は、次のようになります。

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

2 つ目の `Forwarding` エントリの HTTPS URL をコピーします。上記の出力からコピーする URL は、`https://68cd84ed.ngrok.io` です。この URL をベースとして使用して、2 つの URL を作成してみましょう。1 つは、支払い要求 webhook (ngrok URL + `/api/invoices`) へのもので、もう 1 つは支払い完了 webhook (ngrok URL + `/api/payments`) へのものです。たとえば、上記の出力例から次の URL を使用します。

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [重要]
これらの URL がアクティブな状態に保たれるよう、ngrok を実行中のままにします。

これらのテスト用 URL を使用して、パートナー ダッシュボードの webhook URL を更新します。

![Payments in Outlook ダッシュボードにある webhook URL のスクリーンショット](readme-images/dashboard-webhooks.PNG)

## テスト用支払い要求メッセージの生成

自分宛にテスト メッセージを送信する手順については、「[Get started with Payments in Outlook](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request)」 (Payments in Outlook の使用を開始する) を参照してください。

## 投稿

このプロジェクトは投稿や提案を歓迎します。
たいていの投稿には、投稿者のライセンス契約 (CLA) に同意することにより、投稿内容を使用する権利を Microsoft に付与する権利が自分にあり、実際に付与する旨を宣言していただく必要があります。
詳細については、[https://cla.microsoft.com](https://cla.microsoft.com) をご覧ください。

プル要求を送信すると、
CLA を提供して PR を適切に修飾する (ラベル、コメントなど) 必要があるかどうかを CLA ボットが自動的に判断します。
ボットの指示に従ってください。すべてのリポジトリに対して 1 度のみ、CLA を使用してこれを行う必要があります。

このプロジェクトでは、[Microsoft Open Source Code of Conduct (Microsoft オープン ソース倫理規定)](https://opensource.microsoft.com/codeofconduct/)
が採用されています。詳細については、「[Code of Conduct の FAQ (倫理規定の FAQ)](https://opensource.microsoft.com/codeofconduct/faq/)」を参照してください。
また、その他の質問やコメントがあれば、[opencode@microsoft.com](mailto:opencode@microsoft.com) までお問い合わせください。
