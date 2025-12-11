CREATE TABLE IF NOT EXISTS Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserName TEXT NOT NULL,
    Email TEXT NOT NULL,
    Password TEXT NOT NULL,
    FirstName TEXT,
    LastName TEXT,
    Phone TEXT,
    ProfileImage BLOB,
    CreatedDate TEXT
);

CREATE TABLE IF NOT EXISTS Memberships (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Price REAL NOT NULL,
    Duration INTEGER NOT NULL,
    Description TEXT,
    Details TEXT
);

CREATE TABLE IF NOT EXISTS Coaches (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Surname TEXT NOT NULL,
    Age INTEGER,
    Speciality TEXT,
    ImageUrl TEXT
);

CREATE TABLE IF NOT EXISTS Orders (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    MembershipId INTEGER,
    OrderDate TEXT,
    TotalAmount REAL
);

CREATE TABLE IF NOT EXISTS Events (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    Description TEXT,
    EventDate TEXT,
    Location TEXT
);

CREATE TABLE IF NOT EXISTS DiscountCodes (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Code TEXT NOT NULL,
    Percentage REAL,
    ExpirationDate TEXT
);

CREATE TABLE IF NOT EXISTS Feedbacks (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    Message TEXT,
    Rating INTEGER,
    CreatedDate TEXT
);

CREATE TABLE IF NOT EXISTS UserMemberships (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    MembershipId INTEGER,
    StartDate TEXT,
    EndDate TEXT,
    QrCodeImage BLOB,
    PurchaseDate TEXT
);
