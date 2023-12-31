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
('Constantine', 'Пользователь', '140088'),
('Tsar', 'Администратор', '140088');

CREATE TABLE Lessons
(
    IdLesson INT IDENTITY PRIMARY KEY, 
	LessonTitle NVARCHAR(100),
	Content NVARCHAR(2000),
	Concepts NVARCHAR(1000),
	IsCompleted BIT
);

INSERT INTO Lessons (LessonTitle, Content, Concepts, IsCompleted)
VALUES 
('Урок 1', 'Шифрование — обратимое преобразование информации в целях сокрытия от неавторизованных
лиц с предоставлением в это же время авторизованным пользователям доступа к ней.
Главным образом, шифрование служит для соблюдения конфиденциальности передаваемой информации. 
Пользователи являются авторизованными, если они обладают определённым аутентичным ключом.
Вся сложность и, собственно, задача шифрования состоит в том, как именно реализован этот процесс.
В целом, шифрование состоит из двух составляющих: зашифрование и расшифрование.
С помощью шифрования обеспечиваются конфиденциальность и целостность информации.',
'Шифрование — обратимое преобразование информации в целях сокрытия от неавторизованных
лиц с предоставлением в это же время авторизованным пользователям доступа к ней.', 0),
('Урок 2', 'Шифрование началось с использования простых методов замены символов или сдвига букв для сокрытия информации.
С развитием технологий появлялись более сложные методы шифрования, такие как шифр Цезаря и шифр Виженера.
Шифр Цезаря — это метод шифрования, в котором каждая буква в сообщении заменяется на букву,
находящуюся на определенном числе позиций в алфавите.
Это сдвиговый шифр, в котором каждая буква заменяется другой буквой,
находящейся на постоянное число позиций вперед или назад от исходной буквы в алфавите.
Именно с шифра Цезаря началось основное развитие шифрования.
Сейчас шифрование играет важную роль в защите данных в онлайн-мире.
Криптографические алгоритмы и протоколы обеспечивают конфиденциальность и целостность информации в сети.
С появлением квантовых вычислений стоят новые вызовы перед современным шифрованием.',
'Шифр Цезаря — это метод шифрования, в котором каждая буква в сообщении заменяется на букву,
находящуюся на определенном числе позиций в алфавите.
Это сдвиговый шифр, в котором каждая буква заменяется другой буквой,
находящейся на постоянное число позиций вперед или назад от исходной буквы в алфавите.', 0),
('Урок 3', 'Симметричное шифрование: Использует один ключ для шифрования и расшифровки данных.
Асимметричное шифрование: Использует пары ключей: открытый для шифрования и закрытый для расшифровки.
Хеш-функции: Преобразуют данные в фиксированный хеш-код для проверки целостности и создания цифровых подписей.
Криптография на основе кривых эллиптического типа: Использует математические кривые для создания безопасных ключей.
Квантовое шифрование: Использует принципы квантовой механики для передачи данных с высокой степенью защиты.',
'Симметричное шифрование: Использует один ключ для шифрования и расшифровки данных.
Асимметричное шифрование: Использует пары ключей: открытый для шифрования и закрытый для расшифровки.', 0),
('Урок 4', 'Энигма — это электромеханическая машина шифрования, использовавшаяся на протяжении Второй мировой войны для защиты военных сообщений. Вот краткий алгоритм работы Энигмы:
Вращающиеся диски: Энигма содержала ряд вращающихся дисков, на которых были отображены буквы алфавита. Каждый диск можно было устанавливать в различные положения.
Кабели и рефлектор: Сигнал от буквы проходил через кабели и отражался обратно с помощью рефлектора, что создавало сложные шифры.
Изменяемые настройки: Установка начальных позиций дисков и их взаимодействие создавали огромное количество возможных комбинаций.
Смена настроек во времени: Настройки менялись ежедневно, что делало шифр сложным для взлома.
Ключевое слово: Отправитель и получатель знали общее ключевое слово для настройки дисков, что позволяло расшифровывать сообщения.
Эта машина являлась одним из самых сложных шифровальных устройств своего времени и требовала продвинутых методов для взлома.
Ее криптография стала одной из ключевых целей дешифровки во время войны.',
'Энигма — это электромеханическая машина шифрования, использовавшаяся на протяжении Второй мировой войны для защиты военных сообщений.
Шифрование осуществлялось по средству прохождения символов сообщения через роторы и рефлектор', 0);

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
	Content NVARCHAR(2000)
);

INSERT INTO Questions (Content)
VALUES 
('Шифрование данных это -'),
('Шифр Цезаря это -'),
('Энигма это -'),
('Ротор это - ');

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
