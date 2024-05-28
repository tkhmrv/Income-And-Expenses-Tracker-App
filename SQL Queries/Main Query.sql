create database Tracker_DB;

use Tracker_DB;

-- Установите кодировку базы данных
ALTER DATABASE Tracker_DB COLLATE Cyrillic_General_Ci_AI;

-- Для каждой колонки, которую нужно изменить, выполните следующую команду
ALTER TABLE YourTableName ALTER COLUMN YourColumnName NVARCHAR(MAX) COLLATE Cyrillic_General_Ci_AI;

CREATE TABLE users (
    id_user INT PRIMARY KEY IDENTITY(1,1),
    username VARCHAR(30) NOT NULL,
    [password] VARCHAR(50) NOT NULL,
    register_date DATETIME DEFAULT CURRENT_TIMESTAMP
);

SELECT * FROM users;

CREATE TABLE categories (
    id_category INT PRIMARY KEY IDENTITY(1,1),
    category VARCHAR(50) NOT NULL,
    [type] VARCHAR(7) NOT NULL CHECK ([type] IN ('Доходы', 'Расходы')),
    [status] VARCHAR(10) NOT NULL CHECK ([status] IN ('Активный', 'Неактивный')),
    creation_date DATETIME DEFAULT CURRENT_TIMESTAMP
);

SELECT * FROM categories;

CREATE TABLE income (
	id_income INT PRIMARY KEY IDENTITY(1,1),
	category VARCHAR(50) NOT NULL,
	item VARCHAR(50) NOT NULL,
	amount FLOAT NOT NULL,
	[description] TEXT NOT NULL,
	income_date DATE NOT NULL,
	creation_date DATETIME DEFAULT CURRENT_TIMESTAMP
);

SELECT * FROM income_3nf;

delete from income_3nf where category_id = 3;

CREATE TABLE income_3nf (
	id_income INT PRIMARY KEY IDENTITY(1,1),
	category_id INT NOT NULL,
	item VARCHAR(50) NOT NULL,
	amount FLOAT NOT NULL,
	[description] TEXT NOT NULL,
	income_date DATE NOT NULL,
	creation_date DATETIME DEFAULT CURRENT_TIMESTAMP
	FOREIGN KEY (category_id) REFERENCES categories(id_category)
);
