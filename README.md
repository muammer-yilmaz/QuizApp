
# QuizApp

This quiz application allows users to create and publish their own quizzes for others to solve. The app is designed to be user-friendly, allowing users to easily create and customize their quizzes, and to share them with others.

To get started, users can sign up for an account and create their own quizzes. Once a quiz has been created, users can publish it to make it available to other users. Other users can then search for and browse available quizzes, and select the ones they want to solve. The app keeps track of users' progress and scores, allowing them to see how they're doing and compare their results to others.

The app is built using modern web technologies, including Next for the frontend, Kotlin for mobile and .Net for the backend. It also makes use of authentication and authorization features to ensure that only authorized users can create and publish quizzes, and that users' data is kept secure.


## 👨‍💻 Author

- [@muammer-yilmaz](https://www.github.com/muammer-yilmaz)


## 🧵 Related

Here are some related projects

- [QuizApp Frontend](https://github.com/frknsprnl/quiz-app)
- [QuizApp Mobile](https://github.com/AhmetOcak/QuizApp)

## ⭐ Features

- User sign up & sign in
- JWT Authentication & Authorization  
- Quiz CRUD
- Question CRUD
- Refresh token mechanism


## 📦 Packages

- [Entity Framework](https://github.com/dotnet/efcore)
- [MediatR](https://github.com/jbogard/MediatR)
- [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- [NpgSql](https://www.npgsql.org/)
- [.Net Identity](https://github.com/dotnet/aspnetcore/tree/main/src/Identity)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Serilog](https://github.com/serilog/serilog)


## 🔷 Environment Variables

To run this project, you will need to add some environment variables to either .Net Secret Manager or appsettings.json

full list of variables will be in a sample config file.


## ✍ Lessons Learned

I wanted this project to be highly structured and modular, to achive this i used a clean architecture approach and used CQRS pattern to implement further abstraction.

- Structured Code & Modular Monolith design
- CQRS pattern with Clean Architecture
- Mediator pattern to implement CQRS
- Creating a database design for quiz systems 


## 🏁 Optimizations

- I avoided to use some heavy packages just for simple solutions. 
- I used linters to imply even further code structure and cleaning


## 🚩 Roadmap

- Additional question types (True/False, Multiple Answers, ...)

- Additional quiz types (Timed quiz, ...)

- Code Refactoring


## 🟢 Run Locally

Clone the project

```bash
  git clone https://github.com/muammer-yilmaz/QuizApp.git
```

Go to the project directory

```bash
  cd my-project
```

Install dependencies

```bash
  dotnet restore
```

Start the server

```bash
  dotnet run
```


## 💻 Tech Stack

**Client:** Next, TailwindCSS

**Mobile:** Android, Kotlin

**Server:** .Net, Entitiy Framework, PostgreSql, MongoDb


## 📜 License

[MIT](https://choosealicense.com/licenses/mit/)


## Feedback

If you have any feedback, please reach out to me muammercan68@gmail.com

