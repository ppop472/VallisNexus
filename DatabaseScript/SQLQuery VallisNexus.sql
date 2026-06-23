CREATE TABLE Genre (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Naam NVARCHAR(100) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime
);

CREATE TABLE Artiest (
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Naam NVARCHAR(100) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime
);

CREATE TABLE ArtiestGenre(
	ArtiestId INT FOREIGN KEY REFERENCES Artiest(Id) NOT NULL,  
	GenreId INT FOREIGN KEY REFERENCES Genre(Id) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime
);


CREATE TABLE Podium(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,  
	Naam NVARCHAR(100) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime
);

CREATE TABLE Optreden(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ArtiestId INT REFERENCES Artiest(Id) NOT NULL,
	PodiumId INT REFERENCES Podium(Id) NOT NULL,
	StartTijd DateTime NOT NULL,
	EindTijd DateTime NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime	
);

CREATE TABLE Gebruiker(
	Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FavorieteId INT,
	Naam NVARCHAR(100) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime	
);

CREATE TABLE Favoriet(
	GebruikerId INT FOREIGN KEY REFERENCES Gebruiker(Id) NOT NULL,  
	OptredenId INT FOREIGN KEY REFERENCES Optreden(Id) NOT NULL,
	CreatedAt DateTime NOT NULL,
	UpdatedAt DateTime,
	DeletedAt DateTime	
);

-- Genre Dummy Data
INSERT INTO Genre(Naam, CreatedAt) VALUES ('Pop', GETDATE())
INSERT INTO Genre(Naam, CreatedAt) VALUES ('Rock', GETDATE())

-- Artiest Dummy Data
INSERT INTO Artiest (Naam,CreatedAt)
SELECT 'Christian', GETDATE()
WHERE NOT EXISTS (
    SELECT 1
    FROM Artiest
    WHERE Naam = 'Christian'
);

-- ArtiestGenre Dummy Data
INSERT INTO ArtiestGenre (
    ArtiestId,
    GenreId,
    CreatedAt
)
SELECT
    1,
    2,
    GETDATE()
WHERE NOT EXISTS (
    SELECT 1
    FROM ArtiestGenre
    WHERE ArtiestId = 1
      AND GenreId = 2
);

-- Podium Dummy Data
INSERT INTO Podium (Naam,CreatedAt)
SELECT 'Main Stage', GETDATE()
WHERE NOT EXISTS (
    SELECT 1
    FROM Artiest
    WHERE Naam = 'Main Stage'
);

-- Optreden Dummy Data
INSERT INTO Optreden (
    ArtiestId,
    PodiumId,
    StartTijd,
    EindTijd,
    CreatedAt
)
SELECT
    1,
    1,
    '2026-07-01 20:00:00',
    '2026-07-01 21:30:00',
    GETDATE()
WHERE EXISTS (
    SELECT 1
    FROM Artiest
    WHERE Id = 1
)
AND NOT EXISTS (
    SELECT 1
    FROM Optreden o
    WHERE o.PodiumId = 1
      AND '2026-07-01 20:00:00' < o.EindTijd
      AND '2026-07-01 21:30:00' > o.StartTijd
);