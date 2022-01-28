## Docker üzerinde uygulamaya eriþim linkleri
	- API => http://localhost:5001/swagger
	- REACT UI => http://localhost:3000

## Uygulamayý Baþlatma
	- docker-compose up

Komutunu ana dizin içerisinde çalýþtýrmanýz halinde API, MSSQL ve REACTJS projesi docker uzerinde çalýþýr hale gelecektir.

## Çözümünün bir parçasý olarak kullandýðýn teknik ve mimari seçimine nasýl karar verdin?

Hýzlýca uygulayabileceðim bir mimari olan clean architecture'nin basic structure halini kullandým. 
Ayný anda multi tasking olarak birden fazla study case ile ilgilendiðim için konu üzerinde yeterince düþünme fýrsatý bulamadým.
Projeyi geliþtirirken ihtiyaçlara göre aksiyon alarak bazý design patternleri uyguladým

	- .NET 5.0
		- UnitOfWork
		- Repository Pattern (EF)
		- Entitiy Framework Core
		- NTier Architecture (Clean)
			- Application
			- Domain
			- Infrastructure
			- Infrastructure.IOC
			- Api
			- WebUI (Reactjs)
		- Dependency Injection
		- Identity
			- Authorization: Bearer (JWT Token)
		- HangFire
			- RecurringJob (Belirli zaman aralýklarýyla çalýþan görevler)
		- NUnitTest
			- Memory Storage
				- Movie 
				- MovieComment
		- AutoMapper

	- Reactjs
		- Axios
		- React-Router-Dom v6
		- moment

## Göndereceðin kodda yapabileceðin herhangi bir iyileþtirme var mý?

Tabi ki genelde kodlarý iþlevselliðin %100 uygulanmasý için deðil, projenin temel anlamda çalýþabilmesi için temel hedefe ulaþabilmek için yazdým. 
Geliþtirilmesi gereken bir çok nokta var (Service'ler, BackgroundJob, Identity)

	- Frontend:
		- Redux
		- Redux Persistance
		- Thunk
		- Auth Middleware (Improvement)
		- UI / UX
	- Backend
		- Redis
			- Interceptor seviyesinde cache
		- Detaylý Log Çalýþmasý (Log4Net, Graylog vb.)
		- Katmanlarýn Geniþletilmesi ve Ýzolasyonlarýn Korunmasý
		- Unit Testlerin arttýrýlmasý
		- Relation (IdentityUser <-> MovieComment)

## Sana yeterince zaman tanýnsaydý neyi farklý yapardýn?

	- Clean Architecture Mimarisini tam olarak uygulayabilirdim
	- Redis kullanabilirdim
	- Mongo Driver yazabilirdim
	- Frontend için UI / UX üzerinde biraz daha çalýþabilirdim
	- Identity ve Hangfire üzerinde biraz daha geliþtirme yapabilirdim

Hýzlý ve sonuç odaklý geliþtirmek zorunda kaldým. Diðer bir çok detayý bir üst maddede paylaþtým.