CREATE TABLE Users (
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 921600),
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users (Username, Password) VALUES
('user1', '12345p1'),
('user2', '12345p2'),
('user3', '12345p3'),
('user4', '12345p4'),
('user5', '12345p5')