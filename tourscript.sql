USE [Tour]
GO
SET IDENTITY_INSERT [dbo].[UserTip] ON 

INSERT [dbo].[UserTip] ([userTipID], [userTipAd], [isDeleted]) VALUES (1, N'Superadmin', 0)
INSERT [dbo].[UserTip] ([userTipID], [userTipAd], [isDeleted]) VALUES (2, N'Firma', 0)
INSERT [dbo].[UserTip] ([userTipID], [userTipAd], [isDeleted]) VALUES (4, N'Altfirma', 0)
SET IDENTITY_INSERT [dbo].[UserTip] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([userID], [username], [password], [active], [createDate], [lastLogin], [email], [isim], [telefon], [adres], [userPhoto], [userTipID], [isDeleted]) VALUES (1, N'user1', N'123456', 1, CAST(N'2019-12-05T13:12:17.453' AS DateTime), CAST(N'2019-12-05T13:12:17.453' AS DateTime), N'user1@gmail.com', N'user1name', N'05348305050', N'Pınar, Katar Cd No:73, 34460 Sarıyer/İstanbul', N'/Uploads/UyeFoto/b47cdcb2-8866-41a7-b026-d16eea38cbbd.jpeg', 1, 0)
INSERT [dbo].[User] ([userID], [username], [password], [active], [createDate], [lastLogin], [email], [isim], [telefon], [adres], [userPhoto], [userTipID], [isDeleted]) VALUES (2, N'rehber2', N'123456', 1, CAST(N'2019-12-05T13:15:47.290' AS DateTime), CAST(N'2019-12-05T13:15:47.290' AS DateTime), N'rehber2@gmail.com', N'rehber2name', N'05342308787', N'Acıbadem, Çeçen Sokağı No:25, 34660 Üsküdar/İstanbul', NULL, 2, 0)
INSERT [dbo].[User] ([userID], [username], [password], [active], [createDate], [lastLogin], [email], [isim], [telefon], [adres], [userPhoto], [userTipID], [isDeleted]) VALUES (3, N'firma1', N'123456', 1, CAST(N'2019-12-09T15:15:53.760' AS DateTime), CAST(N'2019-12-09T15:15:53.760' AS DateTime), N'firma1@gmail.com', N'firma1name', N'08505445050', N'Ovacık D 100 Karayolu No:34 ·', NULL, 2, 0)
INSERT [dbo].[User] ([userID], [username], [password], [active], [createDate], [lastLogin], [email], [isim], [telefon], [adres], [userPhoto], [userTipID], [isDeleted]) VALUES (4, N'firma2', N'123456ab', 1, NULL, NULL, N'firma2@gmail.com', N'firma2firma', N'08504476334', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', NULL, 2, 0)
INSERT [dbo].[User] ([userID], [username], [password], [active], [createDate], [lastLogin], [email], [isim], [telefon], [adres], [userPhoto], [userTipID], [isDeleted]) VALUES (5, N'bahad41@gmail.com', N'123', 1, NULL, NULL, N'bahad41@gmail.com', N'bazad', N'05348304087', N'Akkavaklar Cd. Yakamoz Sk. G/21/A', N'/Uploads/UyeFoto/b47cdcb2-8866-41a7-b026-d16eea38cbbd.jpeg', 2, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[AltFirma] ON 

INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (1, N'Logo1@gmail.com', N'123456', N'Logo1', N'8502956600', NULL, N'Pınar, Katar Cd No:73, 34460 Sarıyer/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (2, N'Invenoa@gmail.com', N'123456ab', N'Invenoa', N'0216 630 62 99', NULL, N'Sanayi Mh. Teknopark Bulvarı Kurtköy Mahallesi Teknopark 1/1C 1/1C No 1101, 34906 Pendik', 2, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (3, N'neon@gmail.com', N'123456', N'Neon', N'0216 595 06 16', NULL, N'Yenişehir, Starport Residence, Sümbül Sk D:Kat-8, 34912 Pendik/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (4, N'begum@gmai.com', N'123456', N'Begüm', N'0216 411 14 54', NULL, N'Caddebostan Mah, Caddebostan Plaj Yolu Sk. No:21A D:2, 34728 Kadıköy/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (5, N'yena@gmail.com', N'123456', N'Yena', N'0216 577 67 77', NULL, N'İçerenköy, Çayır Cad. Partaş Center No:1/4 Kat:17, 34752 Ataşehir/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (6, N'Intertech@gmail.com', N'123456', N'Intertech', N'0216 664 20 00', NULL, N'Sanayi Mahallesi, Teknopark Bulvarı 1/3C, Kurtköy, 34906 Pendik/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (7, N'Apollo@gmail.com', N'123456', N'Apollo', N'0216 688 88 69', NULL, N'Teknopark İstanbul, Sanayi Mahallesi Teknopark Bulvarı 1/4A 101, Teknopark / Pendik / İstanbul, 34906 Pendik/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (8, N'ctech@gmail.com', N'123456', N'CTECH', N'0850 480 7744', NULL, N'Teknopark Sanayi Mah. Teknopark Bulvarı A Blok, Kat:2, Kurtköy, 34912 Pendik/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (9, N'Digitexa@gmail.com', N'123456', N'Digitexa', N'0850 532 6658', NULL, N'Koşuyolu Mah, Ali Nazime Sk. No:32, 34784 Kadıköy/İstanbul', 1, 0)
INSERT [dbo].[AltFirma] ([altFirmaID], [altFirmaEmail], [altFirmaSifre], [altFirmaAd], [altFirmaTel], [altFirmaLogo], [altFirmaAdres], [userID], [isDeleted]) VALUES (10, N'Ts@gmail.com', N'123456', N'TS', N'0850 532 57 21', NULL, N'Sahrayı Cedit, Atatürk Cd., 34734 Kadıköy/İstanbul', 1, 0)
SET IDENTITY_INSERT [dbo].[AltFirma] OFF
SET IDENTITY_INSERT [dbo].[Kotasyon] ON 

INSERT [dbo].[Kotasyon] ([kotasyonID], [kotasyonAd], [kotasyonGunSayisi], [kotasyonBas], [kotasyonBit], [kotasyonGelenUlke], [kotasyonGelenSehir], [kotasyonKisiSayisi], [kotasyonToplamTutar], [altFirmaID], [onaylanmis]) VALUES (31, N'Isparta Gezisi', 10, CAST(N'2020-01-21' AS Date), CAST(N'2020-01-22' AS Date), N'Türkiye', N'Isparta', 15, NULL, 1, 1)
INSERT [dbo].[Kotasyon] ([kotasyonID], [kotasyonAd], [kotasyonGunSayisi], [kotasyonBas], [kotasyonBit], [kotasyonGelenUlke], [kotasyonGelenSehir], [kotasyonKisiSayisi], [kotasyonToplamTutar], [altFirmaID], [onaylanmis]) VALUES (32, N'HALO', 10, CAST(N'2020-02-01' AS Date), CAST(N'2020-02-10' AS Date), N'Türkiye', N'İzmir', 15, 11000, 1, 1)
INSERT [dbo].[Kotasyon] ([kotasyonID], [kotasyonAd], [kotasyonGunSayisi], [kotasyonBas], [kotasyonBit], [kotasyonGelenUlke], [kotasyonGelenSehir], [kotasyonKisiSayisi], [kotasyonToplamTutar], [altFirmaID], [onaylanmis]) VALUES (34, N'Kotasyon5', 10, CAST(N'2020-02-01' AS Date), CAST(N'2020-02-10' AS Date), N'Türkiye', N'Bartın', 10, NULL, 1, 1)
INSERT [dbo].[Kotasyon] ([kotasyonID], [kotasyonAd], [kotasyonGunSayisi], [kotasyonBas], [kotasyonBit], [kotasyonGelenUlke], [kotasyonGelenSehir], [kotasyonKisiSayisi], [kotasyonToplamTutar], [altFirmaID], [onaylanmis]) VALUES (35, N'HALO', 10, CAST(N'2020-02-01' AS Date), CAST(N'2020-02-10' AS Date), N'Macaristan', N'', 10, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Kotasyon] OFF
SET IDENTITY_INSERT [dbo].[Otel] ON 

INSERT [dbo].[Otel] ([otelID], [otelAd], [otelTip], [otelTelefon], [otelAdres], [otelResim], [otelGecelikFiyat], [otelFiyatBirimi], [otelSingleRoomFiyat], [otelDoubleRoomFiyat], [otelKingSuitFiyat], [otelFamilyRoomFiyat], [otelLat], [otelLong], [otelIl], [otelIlce], [userID], [isDeleted]) VALUES (1, N'Nice Royal', N'3', N'02165726393', N'Küçükbakkalköy, Işıklar Cd. No:12, 34750 Ataşehir/İstanbul', N'/Uploads/OtelPhoto/85bbdb1b-b108-459f-8743-96145832cd9d.jpg', NULL, N'Tl (₺)', 100, 200, 300, 400, NULL, NULL, N'İstanbul', N'Ataşehir', 1, 0)
INSERT [dbo].[Otel] ([otelID], [otelAd], [otelTip], [otelTelefon], [otelAdres], [otelResim], [otelGecelikFiyat], [otelFiyatBirimi], [otelSingleRoomFiyat], [otelDoubleRoomFiyat], [otelKingSuitFiyat], [otelFamilyRoomFiyat], [otelLat], [otelLong], [otelIl], [otelIlce], [userID], [isDeleted]) VALUES (2, N'Ataşehir Palace', N'4', N'02165720707', NULL, N'/Uploads/OtelPhoto/9b859730-62ee-480f-9af5-1ba1467de1d9.jpg', NULL, N'Tl (₺)', 121, 220, 320, 420, NULL, NULL, N'İstanbul', N'Ataşehir', 1, 0)
INSERT [dbo].[Otel] ([otelID], [otelAd], [otelTip], [otelTelefon], [otelAdres], [otelResim], [otelGecelikFiyat], [otelFiyatBirimi], [otelSingleRoomFiyat], [otelDoubleRoomFiyat], [otelKingSuitFiyat], [otelFamilyRoomFiyat], [otelLat], [otelLong], [otelIl], [otelIlce], [userID], [isDeleted]) VALUES (6, N'Ibis Otel', N'4', N'02124143900', NULL, N'/Uploads/OtelPhoto/958a3468-ec0e-425f-8b13-e75571d5fb7b.jpg', NULL, N'Tl (₺)', 150, 250, 350, 450, NULL, NULL, N'İstanbul', N'Zeytinburnu', 1, 0)
INSERT [dbo].[Otel] ([otelID], [otelAd], [otelTip], [otelTelefon], [otelAdres], [otelResim], [otelGecelikFiyat], [otelFiyatBirimi], [otelSingleRoomFiyat], [otelDoubleRoomFiyat], [otelKingSuitFiyat], [otelFamilyRoomFiyat], [otelLat], [otelLong], [otelIl], [otelIlce], [userID], [isDeleted]) VALUES (12, N'Hotel Terrace Istanbul', N'3', N'02125226705', N'Yavuz Sinan, Tahsildar Sk. No:10, 34134 Fatih/İstanbul', N'/Uploads/OtelPhoto/1d146e07-0ce0-46be-9026-818c8c0438b0.jpg', NULL, N'Tl (₺)', 108, 108, 162, 250, NULL, NULL, N'İstanbul', N'Fatih', 1, 0)
INSERT [dbo].[Otel] ([otelID], [otelAd], [otelTip], [otelTelefon], [otelAdres], [otelResim], [otelGecelikFiyat], [otelFiyatBirimi], [otelSingleRoomFiyat], [otelDoubleRoomFiyat], [otelKingSuitFiyat], [otelFamilyRoomFiyat], [otelLat], [otelLong], [otelIl], [otelIlce], [userID], [isDeleted]) VALUES (14, N'Ramada by Wyndham', N'4', N'(0282) 229 29 29', N'Altınova Mah. Adnan Menderes Bulvarı Cad. No: 79, 59100 Süleymanpaşa', NULL, NULL, N'Tl (₺)', 140, 200, 260, 310, NULL, NULL, N'Tekirdağ', N'Süleymanpaşa', 1, 0)
SET IDENTITY_INSERT [dbo].[Otel] OFF
SET IDENTITY_INSERT [dbo].[OtelKot] ON 

INSERT [dbo].[OtelKot] ([otelKotID], [otelkotTarih], [singleKisi], [doubleKisi], [familyKisi], [kingSuitKisi], [otelToplamFiyat], [otelID], [kotasyonID]) VALUES (10, N'01-21-2020 12:00:00 - 01-30-2020 11:00:59', 12, 12, 12, 12, 13000, 12, 31)
INSERT [dbo].[OtelKot] ([otelKotID], [otelkotTarih], [singleKisi], [doubleKisi], [familyKisi], [kingSuitKisi], [otelToplamFiyat], [otelID], [kotasyonID]) VALUES (11, N'01-23-2020 12:00:00 - 01-29-2020 11:00:59', 10, 10, 10, 10, 12000, 6, 32)
INSERT [dbo].[OtelKot] ([otelKotID], [otelkotTarih], [singleKisi], [doubleKisi], [familyKisi], [kingSuitKisi], [otelToplamFiyat], [otelID], [kotasyonID]) VALUES (13, N'01-24-2020 12:00:00 - 01-24-2020 11:59:59', 5, 2, 2, 1, 2500, 6, 35)
INSERT [dbo].[OtelKot] ([otelKotID], [otelkotTarih], [singleKisi], [doubleKisi], [familyKisi], [kingSuitKisi], [otelToplamFiyat], [otelID], [kotasyonID]) VALUES (14, N'02-01-2020 10:00:00 - 02-06-2020 9:00:59', 10, 10, 10, 10, 54050, 2, 35)
SET IDENTITY_INSERT [dbo].[OtelKot] OFF
SET IDENTITY_INSERT [dbo].[Restorant] ON 

INSERT [dbo].[Restorant] ([restorantID], [restorantAd], [restorantAdres], [restorantIl], [restorantIlce], [restorantFoto], [restorantTelefon], [restorantKahvaltiFiyat], [restorantOglenFiyat], [restorantAksamFiyat], [restorantOrtalamFiyat], [restorantFiyatBirimi], [userID], [isDeleted]) VALUES (1, N'Sultanahmet Fish House', N'Alemdar Mah, Prof. K. Ismail Gurkan Cad No:14, 34122 Sultanahmet/Fatih/İstanbul', N'İstanbul', N'Fatih', NULL, N'(0212) 527 44 41 ', 30, 40, 35, 35, N'Tl (₺)', 1, 0)
INSERT [dbo].[Restorant] ([restorantID], [restorantAd], [restorantAdres], [restorantIl], [restorantIlce], [restorantFoto], [restorantTelefon], [restorantKahvaltiFiyat], [restorantOglenFiyat], [restorantAksamFiyat], [restorantOrtalamFiyat], [restorantFiyatBirimi], [userID], [isDeleted]) VALUES (2, N'Lezzet Pide & Lahmacun', N'Kurtköy, Selçuklu Cd. No:65, 34912 Pendik/İstanbul', N'İstanbul', N'Pendik', NULL, N'(0216) 378 60 70 ', 30, 40, 35, 35, N'Tl (₺)', 1, 0)
INSERT [dbo].[Restorant] ([restorantID], [restorantAd], [restorantAdres], [restorantIl], [restorantIlce], [restorantFoto], [restorantTelefon], [restorantKahvaltiFiyat], [restorantOglenFiyat], [restorantAksamFiyat], [restorantOrtalamFiyat], [restorantFiyatBirimi], [userID], [isDeleted]) VALUES (3, N'Balkanika Restoran', N'Yenimahalle Yenipazar Cad. No:34/A, 34893 Pendik/İstanbul', N'İstanbul', N'Pendik', N'/Uploads/RestorantPhoto/2a14f347-9da0-4598-8f0c-83913ecae7e3.jpg', N'02164919052      ', 20, 30, 20, 30, N'Tl (₺)', 1, 0)
INSERT [dbo].[Restorant] ([restorantID], [restorantAd], [restorantAdres], [restorantIl], [restorantIlce], [restorantFoto], [restorantTelefon], [restorantKahvaltiFiyat], [restorantOglenFiyat], [restorantAksamFiyat], [restorantOrtalamFiyat], [restorantFiyatBirimi], [userID], [isDeleted]) VALUES (4, N'Mivan Restaurant Cafe', N'Emin Sinan, Piyer Loti Cd. no 34, 34126 Fatih/İstanbul', N'İstanbul', N'Fatih', N'/Uploads/RestorantPhoto/21dcc461-6b65-4c23-98b4-f3474a25767b.jpg', N'02125179929      ', 20, 28, 28, 22, N'Tl (₺)', 1, 0)
SET IDENTITY_INSERT [dbo].[Restorant] OFF
SET IDENTITY_INSERT [dbo].[ResKot] ON 

INSERT [dbo].[ResKot] ([resKotID], [reskotTarih], [resToplamFiyat], [restorantID], [kotasyonID]) VALUES (8, N'01-23-2020 12:00:00 - 01-25-2020 11:00:59', 500, 2, 31)
INSERT [dbo].[ResKot] ([resKotID], [reskotTarih], [resToplamFiyat], [restorantID], [kotasyonID]) VALUES (9, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 525, 2, 32)
INSERT [dbo].[ResKot] ([resKotID], [reskotTarih], [resToplamFiyat], [restorantID], [kotasyonID]) VALUES (11, N'01-24-2020 12:00:00 - 01-24-2020 11:59:59', 350, 2, 34)
INSERT [dbo].[ResKot] ([resKotID], [reskotTarih], [resToplamFiyat], [restorantID], [kotasyonID]) VALUES (12, N'01-30-2020 12:00:00 - 01-30-2020 11:59:59', 350, 2, 35)
SET IDENTITY_INSERT [dbo].[ResKot] OFF
SET IDENTITY_INSERT [dbo].[Muze] ON 

INSERT [dbo].[Muze] ([muzeID], [muzeAd], [muzeIl], [muzeIlce], [muzeFoto], [muzeAdres], [muzeGirisFiyat], [muzeFiyatBirim], [userID], [isDeleted]) VALUES (1, N'Ayasofya Müzesi', N'İstanbul', N'Fatih', N'/Uploads/MuzePhoto/0874b9ff-0d51-4b02-8a19-5c60575b654c.jpg', N'Sultan Ahmet, Ayasofya Meydanı, 34122 Fatih/İstanbul', 73, N'Tl (₺)', 1, 0)
INSERT [dbo].[Muze] ([muzeID], [muzeAd], [muzeIl], [muzeIlce], [muzeFoto], [muzeAdres], [muzeGirisFiyat], [muzeFiyatBirim], [userID], [isDeleted]) VALUES (2, N'Topkapı Sarayı', N'İstanbul', N'Fatih', N'/Uploads/MuzePhoto/835adf67-4d50-4ce1-b81f-5553912f722f.jpg', N'Cankurtaran, 34122 Fatih/İstanbul', 72, N'Tl (₺)', 1, 0)
INSERT [dbo].[Muze] ([muzeID], [muzeAd], [muzeIl], [muzeIlce], [muzeFoto], [muzeAdres], [muzeGirisFiyat], [muzeFiyatBirim], [userID], [isDeleted]) VALUES (3, N'Madame Tussauds', N'İstanbul', N'Beyoğlu', N'/Uploads/MuzePhoto/6b3ae677-6f6b-4b10-8f95-109195406614.jpg', N'Grand Pera AVM, İstanbul 34440', 152, N'Tl (₺)', 1, 0)
INSERT [dbo].[Muze] ([muzeID], [muzeAd], [muzeIl], [muzeIlce], [muzeFoto], [muzeAdres], [muzeGirisFiyat], [muzeFiyatBirim], [userID], [isDeleted]) VALUES (4, N'İstanbul Arkeoloji Müzeleri', N'İstanbul', N'Fatih', N'/Uploads/MuzePhoto/a7965baa-ff3e-45f9-a0be-9d7b14d4feaa.jpg', N'Cankurtaran, 34122 Fatih/İstanbul', 30, N'Tl (₺)', 1, 0)
INSERT [dbo].[Muze] ([muzeID], [muzeAd], [muzeIl], [muzeIlce], [muzeFoto], [muzeAdres], [muzeGirisFiyat], [muzeFiyatBirim], [userID], [isDeleted]) VALUES (5, N'Kariye Müzesi', N'İstanbul', N'Fatih', N'/Uploads/MuzePhoto/91758341-7ee2-436d-9ef7-4362acd31a86.jpg', N'Dervişali, Kariye Cami Sk. No:18, 34087 Fatih/İstanbul', 31, N'Tl (₺)', 1, 0)
SET IDENTITY_INSERT [dbo].[Muze] OFF
SET IDENTITY_INSERT [dbo].[MuzeKot] ON 

INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (20, N'01-22-2020 12:00:00 - 01-23-2020 11:00:59', 1000, 2, 31)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (21, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 1080, 2, 32)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (22, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 2280, 3, 32)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (23, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 450, 4, 32)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (26, N'01-24-2020 12:00:00 - 01-24-2020 11:59:59', 720, 2, 34)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (27, N'01-30-2020 12:00:00 - 01-30-2020 11:59:59', 720, 2, 35)
INSERT [dbo].[MuzeKot] ([muzeKotID], [muzeTarih], [muzeToplamFiyat], [muzeID], [kotasyonID]) VALUES (28, N'01-30-2020 12:00:00 - 01-30-2020 11:59:59', 1520, 3, 35)
SET IDENTITY_INSERT [dbo].[MuzeKot] OFF
SET IDENTITY_INSERT [dbo].[Ekstra] ON 

INSERT [dbo].[Ekstra] ([ekstraID], [ekstraAd], [ekstraFiyat], [ekstraFoto], [ekstraFiyatBirimi], [ekstraIl], [ekstraIlce], [ekstraTelefon], [ekstraAdres], [userID]) VALUES (3, N'Florya lunapark', 10, NULL, N'Tl (₺)', N'İstanbul', N'Küçükçekmece', N'0532 315 78 39', N'Yeşilova, Florya Cd., 34295 Küçükçekmece/İstanbul', 1)
INSERT [dbo].[Ekstra] ([ekstraID], [ekstraAd], [ekstraFiyat], [ekstraFoto], [ekstraFiyatBirimi], [ekstraIl], [ekstraIlce], [ekstraTelefon], [ekstraAdres], [userID]) VALUES (5, N'İstinyePark Avm Gezisi', NULL, N'/Uploads/EkstraPhoto/3c94d310-eb5c-4ad8-9846-54d13dc3baf5.jpg', N'Tl (₺)', N'İstanbul', N'Sarıyer', N'02123455555', N'Pınar, Katar Cd No:73, 34460 Sarıyer/İstanbul', 1)
SET IDENTITY_INSERT [dbo].[Ekstra] OFF
SET IDENTITY_INSERT [dbo].[EkstraKot] ON 

INSERT [dbo].[EkstraKot] ([ekstraKotID], [ekstraTarih], [ekstraToplamFiyat], [ekstraID], [kotasyonID]) VALUES (1, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 150, 3, 32)
INSERT [dbo].[EkstraKot] ([ekstraKotID], [ekstraTarih], [ekstraToplamFiyat], [ekstraID], [kotasyonID]) VALUES (3, N'01-23-2020 12:00:00 - 01-23-2020 11:59:59', 100, 3, 34)
INSERT [dbo].[EkstraKot] ([ekstraKotID], [ekstraTarih], [ekstraToplamFiyat], [ekstraID], [kotasyonID]) VALUES (4, N'01-30-2020 12:00:00 - 01-30-2020 11:59:59', 0, 5, 35)
INSERT [dbo].[EkstraKot] ([ekstraKotID], [ekstraTarih], [ekstraToplamFiyat], [ekstraID], [kotasyonID]) VALUES (5, N'01-30-2020 12:00:00 - 01-30-2020 11:59:59', 100, 3, 35)
SET IDENTITY_INSERT [dbo].[EkstraKot] OFF
SET IDENTITY_INSERT [dbo].[Arac] ON 

INSERT [dbo].[Arac] ([aracID], [aracPlaka], [aracMarka], [aracKapasite], [aracDurum], [aracFiyat], [aracFiyatBirim], [userID], [isDeleted]) VALUES (1, N'34BA815', N'Mercedes Travego', 40, 0, 2000, N'Tl (₺)', 1, 0)
INSERT [dbo].[Arac] ([aracID], [aracPlaka], [aracMarka], [aracKapasite], [aracDurum], [aracFiyat], [aracFiyatBirim], [userID], [isDeleted]) VALUES (2, N'34BA816', N'Mercedes Tourismo', 55, 0, 1000, N'Tl (₺)', 1, 0)
INSERT [dbo].[Arac] ([aracID], [aracPlaka], [aracMarka], [aracKapasite], [aracDurum], [aracFiyat], [aracFiyatBirim], [userID], [isDeleted]) VALUES (3, N'34BA817', N'Wolkswagen Crafter', 40, 1, 1000, N'Tl (₺)', 1, 0)
SET IDENTITY_INSERT [dbo].[Arac] OFF
SET IDENTITY_INSERT [dbo].[AracKot] ON 

INSERT [dbo].[AracKot] ([aracKotID], [aracToplamFiyat], [aracID], [kotasyonID]) VALUES (1, 10000, 2, 32)
INSERT [dbo].[AracKot] ([aracKotID], [aracToplamFiyat], [aracID], [kotasyonID]) VALUES (3, 0, 1, 34)
INSERT [dbo].[AracKot] ([aracKotID], [aracToplamFiyat], [aracID], [kotasyonID]) VALUES (4, 10000, 2, 34)
INSERT [dbo].[AracKot] ([aracKotID], [aracToplamFiyat], [aracID], [kotasyonID]) VALUES (5, 10000, 2, 35)
SET IDENTITY_INSERT [dbo].[AracKot] OFF
SET IDENTITY_INSERT [dbo].[Dil] ON 

INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (1, N'Ingilizce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (2, N'Almanca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (3, N'Fransizca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (4, N'Italyanca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (5, N'Rusca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (6, N'Cince')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (7, N'Fince')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (8, N'Flemenkce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (9, N'Ukraynaca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (10, N'Japonca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (16, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (17, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (18, N'İngilizce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (19, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (20, N'İngilizce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (21, N'İspanyolca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (22, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (23, N'İngilizce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (24, N'İspanyolca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (25, N'İngilizce')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (26, N'İspanyolca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (27, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (28, N'Türkçe')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (30, N'Almanca')
INSERT [dbo].[Dil] ([dilID], [dilAd]) VALUES (31, N'İngilizce')
SET IDENTITY_INSERT [dbo].[Dil] OFF
SET IDENTITY_INSERT [dbo].[Rehber] ON 

INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (1, N'OsmanTank', N'123456', N'Osman Tan Erkir', N'5348475656', N'osmantan41@gmail.com', N'/Uploads/RehberPhoto/4c43252a-c580-47f0-887c-51a0a64554d9.jpg', N'Yahyakaptan, Akasyalar Cd. No:24, 41000 İzmit/Kocaeli', N'Bay', 4.8, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (7, N'BahadırTanErkir', N'123456', N'BahadırTanErkir', N'5323338774', N'bahad41@gmail.com', NULL, N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bayan', 4.3, 5, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (13, N'Husbani', N'123456', N'Husbani Kelam', N'5349758466', N'husbani@gmail.com', NULL, N'Acıbadem, 34660 Üsküdar/İstanbul', N'Bayan', 3.9, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (16, N'Bahadir', N'123456', N'Bahadir', N'5348304087', N'bahad41@gmail.com', N'/Uploads/RehberPhoto/44b0eead-8673-4288-aabb-7a08f2a710c5.jpeg', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bay', NULL, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (17, N'Selena', N'123456', N'Selena', N'5347653232', N'Selena@gmail.com', N'/Uploads/RehberPhoto/814907ee-2d68-47c3-ad23-eb8e39818825.jpg', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bayan', NULL, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (18, N'Adriana', N'123456', N'Adriana', N'5323338774', N'adriana@gmail.com', N'/Uploads/RehberPhoto/96d7c74f-f6f5-461b-8f5d-f376580b42fa.jpg', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bayan', NULL, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (19, N'KattyTyga', N'123456', N'Kate Tyga', N'5346572323', N'kate@gmail.com', N'/Uploads/RehberPhoto/8128e43f-09e3-45f7-88ac-350999ee67c8.jpg', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bayan', NULL, 1, 0)
INSERT [dbo].[Rehber] ([rehberID], [rehberUsername], [rehberPassword], [rehberAd], [rehberTelefon], [rehberEmail], [rehberPhoto], [rehberAdres], [rehberCinsiyet], [rehberRating], [userID], [isDeleted]) VALUES (21, N'Umut', N'123456', N'Umut', N'5347653232', N'umutgmail@gmail.com', N'/Uploads/RehberPhoto/41ecb952-00b2-4575-88a2-768e44a04d6e.jpg', N'19 Mayıs, Büyükdere Cd. No:22, 34360 Şişli/İstanbul', N'Bay', NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Rehber] OFF
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (1, 1)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (1, 2)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (13, 1)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (13, 2)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (16, 17)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (16, 18)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (17, 19)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (17, 20)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (17, 21)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (18, 22)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (18, 23)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (18, 24)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (19, 25)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (19, 26)
INSERT [dbo].[RehberDil] ([rehberID], [dilID]) VALUES (21, 28)
SET IDENTITY_INSERT [dbo].[Tur] ON 

INSERT [dbo].[Tur] ([turID], [turKod], [turAd], [turAciklama], [turGunSayisi], [turBaslangic], [turBitis], [turKisiSayisi], [turRenk], [isFullDay], [ertelenmis], [turToplamFiyat], [rehberID], [userID]) VALUES (1, N'IIS-615', N'Istanbul Gezisi', N'2 gun surecek guzel bir seyahat', 10, CAST(N'2020-01-15' AS Date), CAST(N'2020-02-15' AS Date), 15, N'#E6DADA   ', 1, 0, NULL, 1, 1)
INSERT [dbo].[Tur] ([turID], [turKod], [turAd], [turAciklama], [turGunSayisi], [turBaslangic], [turBitis], [turKisiSayisi], [turRenk], [isFullDay], [ertelenmis], [turToplamFiyat], [rehberID], [userID]) VALUES (2, N'DDF-515', N'Kapadokya Gezisi', N'Erciyes, Hasandağı ve Güllüdağ’dan püsküren lav ve küller ile oluşan, yumuşacık zeminin zamanla yağmur ve rüzgar ile aşınması ile meşhur peri bacaları', 8, CAST(N'2020-01-15' AS Date), CAST(N'2020-03-03' AS Date), 5, N'#C9FFBF   ', 1, 0, NULL, 13, 1)
INSERT [dbo].[Tur] ([turID], [turKod], [turAd], [turAciklama], [turGunSayisi], [turBaslangic], [turBitis], [turKisiSayisi], [turRenk], [isFullDay], [ertelenmis], [turToplamFiyat], [rehberID], [userID]) VALUES (3, N'KM-41', N'Kocaeli Gezisi', N'Güzel ve yeşil doğasıyla sizlere güzel bir tecrübe kazandıracak bir seyahat.', 13, CAST(N'2020-01-15' AS Date), CAST(N'2020-02-01' AS Date), 5, N'#FFAFBD   ', 1, 0, NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[Tur] OFF
SET IDENTITY_INSERT [dbo].[Kafile] ON 

INSERT [dbo].[Kafile] ([kafileID], [kafileAd], [kafileKisiSayisi], [kafileUlke], [turID], [isDeleted]) VALUES (1, N'İstanbul Kafilesi', 10, N'Türkiye', 1, 0)
SET IDENTITY_INSERT [dbo].[Kafile] OFF
SET IDENTITY_INSERT [dbo].[Turist] ON 

INSERT [dbo].[Turist] ([turistID], [turistAd], [turistTel], [turistFoto], [turistYas], [turistCinsiyet], [turistTC], [turistPasaportNo], [turistVizeNo], [kafileID]) VALUES (3, N'Anastasia', N'7933056587', N'/Uploads/TuristPhoto/4fa9a2c8-fb3c-4aae-afbb-47c09142236e.jpg', 21, NULL, N'28754376766', N'D23106202', NULL, 1)
INSERT [dbo].[Turist] ([turistID], [turistAd], [turistTel], [turistFoto], [turistYas], [turistCinsiyet], [turistTC], [turistPasaportNo], [turistVizeNo], [kafileID]) VALUES (4, N'Valeria', N'7972926192', N'/Uploads/TuristPhoto/db6180f7-1650-43cc-9615-127fae54d7b7.jpg', 21, NULL, N'29038588531', N'P0644822', NULL, 1)
INSERT [dbo].[Turist] ([turistID], [turistAd], [turistTel], [turistFoto], [turistYas], [turistCinsiyet], [turistTC], [turistPasaportNo], [turistVizeNo], [kafileID]) VALUES (5, N'Aki1', N'5348304087', N'/Uploads/TuristPhoto/33c4769d-442b-4726-8ff4-215f0a19cc66.jpg', 20, NULL, N'29171592372', N'Z2311715', NULL, 1)
INSERT [dbo].[Turist] ([turistID], [turistAd], [turistTel], [turistFoto], [turistYas], [turistCinsiyet], [turistTC], [turistPasaportNo], [turistVizeNo], [kafileID]) VALUES (6, N'Polina', N'3076894586', N'/Uploads/TuristPhoto/93a8d9b3-a0b0-4ffc-8f13-2a5091f1cbb6.jpg', 20, NULL, N'12529172922', N'020196390', NULL, 1)
SET IDENTITY_INSERT [dbo].[Turist] OFF
