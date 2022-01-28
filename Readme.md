## Docker �zerinde uygulamaya eri�im linkleri
	- API => http://localhost:5001/swagger
	- REACT UI => http://localhost:3000

## Uygulamay� Ba�latma
	- docker-compose up

Komutunu ana dizin i�erisinde �al��t�rman�z halinde API, MSSQL ve REACTJS projesi docker uzerinde �al���r hale gelecektir.

## ��z�m�n�n bir par�as� olarak kulland���n teknik ve mimari se�imine nas�l karar verdin?

H�zl�ca uygulayabilece�im bir mimari olan clean architecture'nin basic structure halini kulland�m. 
Ayn� anda multi tasking olarak birden fazla study case ile ilgilendi�im i�in konu �zerinde yeterince d���nme f�rsat� bulamad�m.
Projeyi geli�tirirken ihtiya�lara g�re aksiyon alarak baz� design patternleri uygulad�m

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
			- RecurringJob (Belirli zaman aral�klar�yla �al��an g�revler)
		- NUnitTest
			- Memory Storage
				- Movie 
				- MovieComment
		- AutoMapper

	- Reactjs
		- Axios
		- React-Router-Dom v6
		- moment

## G�nderece�in kodda yapabilece�in herhangi bir iyile�tirme var m�?

Tabi ki genelde kodlar� i�levselli�in %100 uygulanmas� i�in de�il, projenin temel anlamda �al��abilmesi i�in temel hedefe ula�abilmek i�in yazd�m. 
Geli�tirilmesi gereken bir �ok nokta var (Service'ler, BackgroundJob, Identity)

	- Frontend:
		- Redux
		- Redux Persistance
		- Thunk
		- Auth Middleware (Improvement)
		- UI / UX
	- Backend
		- Redis
			- Interceptor seviyesinde cache
		- Detayl� Log �al��mas� (Log4Net, Graylog vb.)
		- Katmanlar�n Geni�letilmesi ve �zolasyonlar�n Korunmas�
		- Unit Testlerin artt�r�lmas�
		- Relation (IdentityUser <-> MovieComment)

## Sana yeterince zaman tan�nsayd� neyi farkl� yapard�n?

	- Clean Architecture Mimarisini tam olarak uygulayabilirdim
	- Redis kullanabilirdim
	- Mongo Driver yazabilirdim
	- Frontend i�in UI / UX �zerinde biraz daha �al��abilirdim
	- Identity ve Hangfire �zerinde biraz daha geli�tirme yapabilirdim

H�zl� ve sonu� odakl� geli�tirmek zorunda kald�m. Di�er bir �ok detay� bir �st maddede payla�t�m.