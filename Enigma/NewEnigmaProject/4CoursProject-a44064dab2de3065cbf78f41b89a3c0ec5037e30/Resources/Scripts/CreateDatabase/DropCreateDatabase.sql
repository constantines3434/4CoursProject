USE master;
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'EnigmaBase')
    DROP DATABASE EnigmaBase;
GO
CREATE DATABASE EnigmaBase
ON   
( NAME = 'EnigmaBase_data',  
    FILENAME = 'C:\\VS Projects\\4CoursProject\\Resources\\Scripts\\CreateDatabase\\EnigmaBase.mdf',  
    SIZE = 8,  
    MAXSIZE = 100,  
    FILEGROWTH = 10 )  
LOG ON  
( NAME = 'EnigmaBase_log',  
    FILENAME = 'C:\\VS Projects\\4CoursProject\\Resources\\Scripts\\CreateDatabase\\EnigmaBase.ldf',  
    SIZE = 8,  
    MAXSIZE = 25MB,  
    FILEGROWTH = 5MB );  
GO  

USE EnigmaBase;
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Users')
    DROP TABLE Users
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Lessons')
    DROP TABLE Lessons
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'UserProgress')
    DROP TABLE UserProgress
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Questions')
    DROP TABLE Questions
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Quizes')
    DROP TABLE Quizes
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'QuizQuestions')
    DROP TABLE QuizQuestions
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Rotors')
    DROP TABLE Rotors
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'SetOfRotors')
    DROP TABLE SetOfRotors
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'Reflectors')
    DROP TABLE Reflectors
IF EXISTS (SELECT * FROM SYSOBJECTS WHERE NAME = 'EnigmaMachines')
    DROP TABLE EnigmaMachines

    
CREATE TABLE Users
(
    IdUser INT IDENTITY PRIMARY KEY, 
	LoginOfUser NVARCHAR(100),
	RoleOfUser NVARCHAR(13),
	PasswordOfUser NVARCHAR(100) 
);

INSERT INTO Users (LoginOfUser, RoleOfUser, PasswordOfUser)
VALUES 
('логин1', 'Пользователь', 'пароль1'),
('логин2', 'Администратор', 'пароль2');

CREATE TABLE Lessons
(
    IdLesson INT IDENTITY PRIMARY KEY, 
	LessonTitle NVARCHAR(100),
	Content NVARCHAR(100),
	Concepts NVARCHAR(100) 
);

INSERT INTO Lessons (LessonTitle, Content, Concepts)
VALUES 
('заголовок1', 'контент1', 'концепция1'),
('заголовок2', 'контент2', 'концепция2'),
('заголовок3', 'контент3', 'концепция3'),
('заголовок4', 'контент4', 'концепция4');

CREATE TABLE UserProgress
(
	IdProgress INT IDENTITY PRIMARY KEY,
    IdUser INT,
	IdLesson INT,
	Completed BIT,
	FOREIGN KEY (IdUser) REFERENCES Users(IdUser) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdLesson) REFERENCES Lessons(IdLesson) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO UserProgress (IdUser, IdLesson, Completed)
VALUES
(1, 1, 0),
(1, 2, 0),
(1, 3, 0),
(1, 4, 0);

CREATE TABLE Questions
(
    IdQuestion INT IDENTITY PRIMARY KEY, 
	Content NVARCHAR(100)
);

INSERT INTO Questions (Content)
VALUES 
('вопрос1'),
('вопрос2'),
('вопрос3'),
('вопрос4');

CREATE TABLE Quizes
(
    IdQuiz INT IDENTITY PRIMARY KEY,
    IdProgress INT,
    FOREIGN KEY (IdProgress) REFERENCES UserProgress(IdProgress) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO Quizes (IdProgress)
VALUES 
(2),
(4);

CREATE TABLE QuizQuestions
(
    IdQuiz INT,
    IdQuestion INT,
    PRIMARY KEY (IdQuiz, IdQuestion),
    FOREIGN KEY (IdQuiz) REFERENCES Quizes(IdQuiz) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (IdQuestion) REFERENCES Questions(IdQuestion) ON DELETE CASCADE ON UPDATE CASCADE
);
INSERT INTO QuizQuestions (IdQuiz, IdQuestion)
VALUES 
(1, 1),
(1, 2),
(1, 3),
(1, 4);

CREATE TABLE SetOfRotors
(
    IdSetOfRotors INT IDENTITY PRIMARY KEY,
	NameOfSetOfRotors NVARCHAR(100) 
);

INSERT INTO SetOfRotors(NameOfSetOfRotors)
VALUES 
('Первый набор ротеров'),
('Второй набор ротеров');

CREATE TABLE Rotors
(
    IdRotor INT IDENTITY PRIMARY KEY, 
    IdSetOfRotors INT,
    Dictionary NVARCHAR(26),
    FOREIGN KEY (IdSetOfRotors) REFERENCES SetOfRotors(IdSetOfRotors) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Rotors(IdSetOfRotors, Dictionary)
VALUES 
(1, 'EKMFLGDQVZNTOWYHXUSPAIBRCJ'),
(1, 'AJDKSIRUXBLHWTMCQGZNPYFVOE'),
(1, 'BDFHJLCPRTXVZNYEIWGAKMUSQO'),
(2, 'EKMFLGDQVZNTOWYHXUSPAIBRCJ'),
(2, 'BDFHJLCPRTXVZNYEIWGAKMUSQO'),
(2, 'ESOVPZJAYQUIRHXLNFTGKDCMWB');

CREATE TABLE Reflectors
(
    IdReflector INT IDENTITY PRIMARY KEY,
	NameOfReflector NVARCHAR(5),
	Dictionary NVARCHAR(26)
);

INSERT INTO Reflectors(NameOfReflector, Dictionary)
VALUES 
('UKW-A', 'EJMZALYXVBWFCRQUONTSPIKHGD'),
('UKW-B', 'YRUHQSLDPXNGOKMIEBFZCWVJAT'),
('UKW-C', 'FVPJIAOYEDRZXWGCTKUQSBNMHL');

CREATE TABLE EnigmaMachine
(
    IdEnigmaMachine INT IDENTITY PRIMARY KEY,
	IdSetOfRotors INT,
	IdReflector INT,
	FOREIGN KEY (IdSetOfRotors) REFERENCES SetOfRotors(IdSetOfRotors) ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (IdReflector) REFERENCES Reflectors(IdReflector) ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO EnigmaMachine(IdSetOfRotors, IdReflector)
VALUES 
((SELECT IdSetOfRotors FROM SetOfRotors WHERE IdSetOfRotors = 1), (SELECT IdReflector FROM Reflectors WHERE NameOfReflector = 'UKW-A')),
((SELECT IdSetOfRotors FROM SetOfRotors WHERE IdSetOfRotors = 2), (SELECT IdReflector FROM Reflectors WHERE NameOfReflector = 'UKW-B'));
