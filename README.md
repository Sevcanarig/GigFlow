# GigFlow - Freelancer İş Platformu Backend API

GigFlow, freelancer’lar ile iş verenleri (client) bir araya getiren bir iş platformu backend projesidir. Proje, Clean Architecture ve CQRS prensiplerine uygun olarak geliştirilmiştir.

---

## 🚀 Teknolojiler

- .NET 10 Web API
- Entity Framework Core
- MediatR (CQRS Pattern)
- FluentValidation
- AutoMapper
- Swagger (Swashbuckle)
- PostgreSQL / MSSQL

---

## 🧱 Mimari (Clean Architecture)

Proje 5 katmandan oluşmaktadır:

- **Domain** → Entity’ler, enum’lar, business rules
- **Application** → CQRS (Commands & Queries), DTO’lar, validator’lar
- **Infrastructure** → Harici servisler (JWT, mail, vs.)
- **Persistence** → DbContext, EF Core, migration’lar, repository
- **Presentation (API)** → Controller’lar, Swagger, middleware

Bağımlılık yönü dıştan içe doğrudur.

---

## ⚙️ CQRS Yapısı

- **Commands** → Create / Update / Delete işlemleri
- **Queries** → Read işlemleri

Her feature (JobPostings, Proposals, Contracts vb.) için MediatR handler yapısı kullanılmıştır.

---

## 🗄️ Veritabanı

- Code First yaklaşımı kullanılmıştır
- EF Core ile migration oluşturulmuştur
- Migration dosyaları projeye dahildir

- ## 📸 Swagger Screenshots

### Swagger Ana Sayfa
![Swagger 1](./images/swagger1.png)

### API Endpoint Test
![Swagger 2](./images/swagger2.png)

