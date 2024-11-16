-- Tạo cơ sở dữ liệu
CREATE DATABASE EPLManagement;
GO

USE EPLManagement;
GO

-- Tạo bảng FootballTeam để lưu thông tin đội bóng
CREATE TABLE FootballTeam (
    FootballTeamID INT PRIMARY KEY IDENTITY(1,1),
    TeamName NVARCHAR(100) NOT NULL,
    FoundedYear INT,
    Stadium NVARCHAR(100),
    City NVARCHAR(50)
);

-- Tạo bảng Player để lưu thông tin cầu thủ
CREATE TABLE Player (
    PlayerID INT PRIMARY KEY IDENTITY(1,1),
    FootballTeamID INT FOREIGN KEY REFERENCES FootballTeam(FootballTeamID),
    FullName NVARCHAR(100) NOT NULL,
    Position NVARCHAR(50),
    JerseyNumber INT,
    DateOfBirth DATE,
    Nationality NVARCHAR(50)
);

-- Tạo bảng User để quản lý người dùng và phân quyền
CREATE TABLE [User] (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(256) NOT NULL,
    Role NVARCHAR(20) CHECK (Role IN ('Staff', 'Manager')), -- Vai trò: chỉ có Staff hoặc Manager
    FootballTeamID INT NULL, -- Để trống nếu là Staff
    CONSTRAINT FK_User_FootballTeam FOREIGN KEY (FootballTeamID) REFERENCES FootballTeam(FootballTeamID)
);

-- Thêm dữ liệu mẫu cho bảng FootballTeam (nếu cần)
INSERT INTO FootballTeam (TeamName, FoundedYear, Stadium, City)
VALUES 
('Manchester United', 1878, 'Old Trafford', 'Manchester'),
('Liverpool', 1892, 'Anfield', 'Liverpool'),
('Arsenal', 1886, 'Emirates Stadium', 'London');

-- Thêm dữ liệu mẫu cho bảng User (nếu cần)
INSERT INTO [User] (Username, PasswordHash, Role, FootballTeamID)
VALUES 
('staff01', 'hashed_password_staff01', 'Staff', NULL), -- Staff không có FootballTeamID
('manager01', 'hashed_password_manager01', 'Manager', 1); -- Manager chỉ xem được đội có ID là 1 (Manchester United)
