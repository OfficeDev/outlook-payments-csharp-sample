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
description: "Il s’agit d’un exemple d’implémentation de la demande de paiement et de webhooks de paiement complet pour Paiements dans le service Outlook."
urlFragment: outlook-payments
extensions:
  contentType: samples
  createdDate: "4/24/2018 7:42:25 AM"
---

# Exemple de paiements de l’API web ASP.NET dans Outlook webhook

Il s’agit d’un exemple d’implémentation de la demande de paiement et de webhooks de paiement complet pour [Paiements dans le service Outlook](https://docs.microsoft.com/outlook/payments/).

## Conditions préalables

Avant d’exécuter cet exemple, vous devez [inscrire dans le tableau de bord des Paiements dans Outlook](https://docs.microsoft.com/outlook/payments/partner-dashboard). vous devez disposer d’un compte de plateforme de connexion [Stripe](https://stripe.com/connect).

Visual Studio 2017 doit également être installé.

## Configuration de l’exemple

1. Effectuez une copie du fichier [OutlookPayments/MerchantInfo.EXAMPLE.config](OutlookPayments/MerchantInfo.EXAMPLE.config) dans le répertoire **OutlookPayments**. Renommez cette copie du fichier comme `MerchantInfo.config`.
1. Ouvrez **OutlookPayments.sln** dans Visual Studio.
1. Ouvrez le fichier **MerchantInfo.config** et mettez à jour la valeur de la clé `MerchantId` avec votre ID de commerçant à partir de Paiements dans le tableau de bord Outlook.

## Exécution de l’exemple

Appuyez sur **F5** ou sélectionnez **Démarrer le débogage** dans le menu de **Débogage** de Visual Studio.

## Utilisation de ngrok pour exécuter localement

Lorsque vous exécutez l’exemple localement, celui-ci est accessible via `http://localhost:52663`. Le service des Paiements doit être en mesure de contacter votre webhook à partir d’Internet, de sorte que l’exécution sur localhost ne fonctionnera pas. Toutefois, l’utilisation de [ngrok](https://ngrok.com/)vous permet de créer une adresse accessible publiquement qui peut contacter le localhost de manière temporaire.

Ouvrez une fenêtre d'invite de commandes ou un shell, puis exécutez la commande suivante :

```Shell
ngrok http 52663 -host-header=localhost:52663
```

Les résultats doivent être similaires à ceci :

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

Copiez l’URL HTTPS de la deuxième entrée de `Transfert`. Dans la sortie ci-dessus, l’URL à copier est `https://68cd84ed.ngrok.io`. À l’aide de cette URL comme base, créez deux URL : l’une pour le webhook de demande de paiement (ngrok URL + `/API/Invoices`), et l’autre pour le webhook de paiement complet (ngrok URL + `/API/Payments`). Par exemple, si vous utilisez l’URL de l’exemple de sortie ci-dessus :

```http
https://68cd84ed.ngrok.io/api/invoices
https://68cd84ed.ngrok.io/api/payments
```

> [!IMPORTANT]
conservez ngrok en cours d’exécution afin que ces URL restent actives.

Mettez à jour vos URL de webhook dans le tableau de bord du partenaire avec ces URL à des fins de test.

![Capture d’écran des URL webhook dans le tableau de bord Paiements dans Outlook](readme-images/dashboard-webhooks.PNG)

## Génération d’un test de message de demande de paiement

Voir [Prise en main des Paiements dans Outlook](https://docs.microsoft.com/outlook/payments/get-started#send-the-test-payment-request) pour connaître la procédure d’envoi d’un message de test à vous-même.

## Contribution

Ce projet autorise les contributions et les suggestions.
Pour la plupart des contributions, vous devez accepter le Contrat de licence de contributeur (CLA, Contributor License Agreement) stipulant que vous êtes en mesure, et que vous vous y engagez, de nous accorder les droits d’utiliser votre contribution.
Pour plus d’informations, visitez [https://cla.microsoft.com](https://cla.microsoft.com).

Lorsque vous soumettez une demande de tirage, un robot CLA détermine automatiquement si vous devez fournir un CLA et si vous devez remplir la demande de tirage appropriée (par exemple, étiquette, commentaire).
Suivez simplement les instructions données par le robot.
Vous ne devrez le faire qu’une seule fois au sein de tous les référentiels à l’aide du CLA.

Ce projet a adopté le [Code de conduite Open Source de Microsoft](https://opensource.microsoft.com/codeofconduct/).
Pour en savoir plus, reportez-vous à la [FAQ relative au Code de conduite](https://opensource.microsoft.com/codeofconduct/faq/)
ou contactez [opencode@microsoft.com](mailto:opencode@microsoft.com) pour toute question ou tout commentaire.
