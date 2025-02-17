/****** Script for seeding Pitches  ******/

declare @date datetime2 = GETUTCDATE();

BEGIN TRAN
	INSERT INTO [Pitchball].[dbo].[Pitches](
		[Name],
		[Street],
		[City],
		[IsActive],
		[Surface],
		[Lighting],
		[CreatedAt],
		[UpdatedAt]
	)
	VALUES
		(
			'Stadion Ludowy',
			'Kresowa 1',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Płatne',
			@date,
			@date
		),
		(
			'KKS Czarni Sosnowiec',
			'Niepodległości 31',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Zespół Szkół Ogólnokształcących nr 12',
			'Jasieńskiego 2A',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Liceum Ogólnokształcące nr 6 im. J. Korczaka',
			'Ludwika Zamenhofa 15',
			'Sosnowiec',
			1,
			'Tartan',
			'Brak',
			@date,
			@date
		),
		(
			'Zespół Szkół Ogólnokształcących nr 5',
			'Bohaterów Monte Cassino 46',
			'Sosnowiec',
			1,
			'Tartan',
			'Brak',
			@date,
			@date
		),
		(
			'IX Liceum Ogólnokształcące',
			'Jana Dormana 9A',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 4',
			'Kościelna 9',
			'Sosnowiec',
			1,
			'Beton / asfalt',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 13 im. Adama Piwowara',
			'Józefa Piłsudskiego 24',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
			),
		(
			'Szkoła Podstawowa nr 46 im. J. Kiepury',
			'Gwiezdna 2',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Miejski Ośrodek Sportu i Rekreacji',
			'3 Maja 51',
			'Sosnowiec',
			1,
			'Naturalna trawa',
			'Brak',
			@date,
			@date
		),
		(
			'Zespół Szkół Ogólnokształcących nr 10',
			'Czołgistów 12',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Zespół Szkół Ogólnokształcących nr 8',
			'Hutnicza 6b',
			'Sosnowiec',
			1,
			'Beton / asfalt',
			'Brak',
			@date,
			@date
		),
		(
			'Zespół Szkół Ogólnokształcących nr 14',
			'Stefana Kisielewskiego 4B',
			'Sosnowiec',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 29',
			'Zagłębiowska 25',
			'Sosnowiec',
			1,
			'Tartan',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 19 im. Marii Skłodowskiej-Curie',
			'Składowa 5',
			'Sosnowiec',
			1,
			'Tartan',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 20',
			'Adamieckiego 12',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Zespół Szkół nr 3',
			'Morcinka 4',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Zespół Szkół Elektronicznych i Informatycznych',
			'Jagiellońska 13',
			'Sosnowiec',
			1,
			'Tartan',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 3 im. J. Korczaka',
			'Stanisława Staszica 47',
			'Czeladź',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Gimnazjum nr 4',
			'Stanisława Wyspiańskiego 1',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Płatne',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 12 im. Stanisława Staszica',
			'Tysiąclecia 25',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Gimnazjum im. Marszałka J. Piłsudskiego',
			'Szkolna 32',
			'Psary',
			1,
			'Sztuczna trawa',
			'Płatne',
			@date,
			@date
		),
		(
			'Miejski Zespół Szkół nr 2 im. H. Wagnera',
			'Rewolucjonistów 18',
			'Będzin',
			1,
			'Sztuczna trawa',
			'Płatne',
			@date,
			@date
		),
		(
			'Obiekty Sportowo - Rekreacyjne OSIR',
			'Sportowa 4',
			'Będzin',
			1,
			'Sztuczna trawa',
			'Płatne',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 22',
			'Zwycięstwa 44',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		),
		(
			'Szkoła Podstawowa nr 30 im. E. Zawidzkiej',
			'Jaworowa 6',
			'Dąbrowa Górnicza',
			1,
			'Sztuczna trawa',
			'Darmowe',
			@date,
			@date
		);
COMMIT TRAN