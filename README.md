# DevAndreaCarrattaIT.MailGun

## local.setting.json
```json
{
	"IsEncrypted": false,
	"Values": {
		"AzureWebJobsStorage": "UseDevelopmentStorage=true",
		"FUNCTIONS_WORKER_RUNTIME": "dotnet",
		"DEVAndreaCarratta.MailGun.BaseUri": "https://api.eu.mailgun.net/v3/",
		"DEVAndreaCarratta.MailGun.Api": "<Add your MailGun.Api>",
		"DEVAndreaCarratta.MailGun.Domain": "<Add your MailGun.Api - ex mg.blablabla.fake>",
		"DEVAndreaCarratta.MailGun.Expression": "<Add your MailGun.Expression>",
		"DEVAndreaCarratta.MailGun.AddHeaderNativeSend": "<Add your MailGun.AddHeaderNativeSend>",
		"DEVAndreaCarratta.MailGun.FromMail": "<Add your MailGun Mail From address>",
		"DEVAndreaCarratta.MailGun.FromName": "<Add your MailGun Mail From Name>"
	}
}
```

## postman request

```json
{
	"info": {
		"_postman_id": "2c8bdb56-36e6-4e23-802a-f9ba5bd9710b",
		"name": "DevAndreaCarrattaIT.MailGun",
		"schema": "https://schema.getpostman.com/json/collection/v2.1.0/collection.json"
	},
	"item": [
		{
			"name": "DevAndreaCarrattaIT.MailGun.Send",
			"protocolProfileBehavior": {
				"disableBodyPruning": true
			},
			"request": {
				"method": "POST",
				"header": [
					{
						"key": "Content-Type",
						"name": "Content-Type",
						"value": "application/json",
						"type": "text"
					}
				],
				"body": {
					"mode": "raw",
					"raw": "{\n\"Subject\":\"Test Mail Subject\",\n\"Text\":\"body plain text\",\n\"BodyHtml\":\"body <b>html</b> text\",\n\"To\":\"mail1@blablabla.fake;mail2@blablabla.fake\",\n\"Cc\":\"mail3@blablabla.fake;mail4@blablabla.fake\",\n\"Ccn\":\"mail5@blablabla.fake;mail6@blablabla.fake\",\n}"
				},
				"url": {
					"raw": "http://localhost:7071/api/Send",
					"protocol": "http",
					"host": [
						"localhost"
					],
					"port": "7071",
					"path": [
						"api",
						"Send"
					]
				}
			},
			"response": []
		}
	]
}
```
