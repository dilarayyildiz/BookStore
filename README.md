<<<<<<< HEAD
# BookStore
=======
# 📚 BookStore API

## 🚀 Tech Stack

- ASP.NET Core 8.0
- C#
- Entity Framework Core (Code-First)
- AutoMapper
- Swagger 
- RESTful API principles

---

## 🧩 Features

- 📖 **Get All Books**  
  `GET /api/book`  
  Returns a list of all available books in the system.

- 🔍 **Get Book By ID**  
  `GET /api/book/{id}`  
  Returns the details of a single book by its ID.

- ➕ **Create New Book**  
  `POST /api/book`  
  Adds a new book to the system. Requires title, genreId, pageCount, and publishDate.

- 📝 **Update Existing Book**  
  `PUT /api/book/{id}`  
  Updates the fields of an existing book. Partial updates supported.

- ❌ **Delete Book**  
  `DELETE /api/book/{id}`  
  Removes a book from the system by its ID.

Each endpoint follows RESTful conventions and returns proper status codes and error messages when necessary.

>>>>>>> 1e0ea01 (Update README.md)
