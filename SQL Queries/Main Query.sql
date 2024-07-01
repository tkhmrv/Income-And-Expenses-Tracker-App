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

	CREATE TABLE wallets (
		id_wallet INT PRIMARY KEY IDENTITY(1,1),
		user_id INT NOT NULL,
		wallet_name VARCHAR(50) NOT NULL,
		[type] VARCHAR(50) NOT NULL,
		[status] VARCHAR(10) NOT NULL CHECK ([status] IN ('Активный', 'Неактивный')),
		[description] TEXT NOT NULL,
		creation_date DATETIME DEFAULT CURRENT_TIMESTAMP,
		FOREIGN KEY (user_id) REFERENCES users(id_user)
	);

	select * from wallets;

	SELECT * FROM categories;

	SELECT * FROM income_3nf;

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

	SELECT * FROM expenses;

	CREATE TABLE expenses (
		id_expenses INT PRIMARY KEY IDENTITY(1,1),
		category_id INT NOT NULL,
		item VARCHAR(50) NOT NULL,
		amount FLOAT NOT NULL,
		[description] TEXT NOT NULL,
		expenses_date DATE NOT NULL,
		creation_date DATETIME DEFAULT CURRENT_TIMESTAMP
		FOREIGN KEY (category_id) REFERENCES categories(id_category)
	);	

	BEGIN TRANSACTION;

	-- Добавление столбца user_id в существующие таблицы
	ALTER TABLE categories ADD user_id INT NOT NULL DEFAULT 1;
	ALTER TABLE income_3nf ADD user_id INT NOT NULL DEFAULT 1;
	ALTER TABLE expenses ADD user_id INT NOT NULL DEFAULT 1;

	-- Добавление столбца wallet_id в существующие таблицы
	ALTER TABLE categories ADD wallet_id INT NOT NULL DEFAULT 1;
	ALTER TABLE income_3nf ADD wallet_id INT NOT NULL DEFAULT 1;
	ALTER TABLE expenses ADD wallet_id INT NOT NULL DEFAULT 1;

	-- Создание внешних ключей
	ALTER TABLE categories
	ADD CONSTRAINT FK_Categories_Wallets FOREIGN KEY (wallet_id) REFERENCES wallets(id_wallet);

	ALTER TABLE income_3nf
	ADD CONSTRAINT FK_Income_Wallets FOREIGN KEY (wallet_id) REFERENCES wallets(id_wallet);

	ALTER TABLE expenses
	ADD CONSTRAINT FK_Expenses_Wallets FOREIGN KEY (wallet_id) REFERENCES wallets(id_wallet);

	-- Создание внешних ключей
	ALTER TABLE categories
	ADD CONSTRAINT FK_Categories_Users FOREIGN KEY (user_id) REFERENCES users(id_user);

	ALTER TABLE income_3nf
	ADD CONSTRAINT FK_Income_Users FOREIGN KEY (user_id) REFERENCES users(id_user);

	ALTER TABLE expenses
	ADD CONSTRAINT FK_Expenses_Users FOREIGN KEY (user_id) REFERENCES users(id_user);

	UPDATE categories SET user_id = 2 WHERE user_id = 1;
	UPDATE income_3nf SET user_id = 2 WHERE user_id = 1;
	UPDATE expenses SET user_id = 2 WHERE user_id = 1;

	COMMIT TRANSACTION;

