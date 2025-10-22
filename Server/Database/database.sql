SET DATEFORMAT ymd
-- File name: C:\Users\TobiasPoulsen\Desktop\Server-eksamen\Server\Database\database.sql\n-- Created by MSSQL Library http://www.dbconvert.com\n
DROP DATABASE [library] 
GO
 
CREATE DATABASE [library] 
GO
 
USE [library]  
GO
 


---- Table structure for table `Genres` 
----

CREATE TABLE [Genres] ([ID] INTEGER IDENTITY(1,1)  ,[Name] TEXT NOT NULL  ,[BgColor] TEXT NOT NULL  ); 

---- Table structure for table `Items` 
----

CREATE TABLE [Items] ([ID] INTEGER IDENTITY(1,1)  ,[Title] TEXT NOT NULL  ,[Description] TEXT NOT NULL  ,[GenreID] INTEGER NOT NULL  DEFAULT 0 ,[CategoryID] TEXT NOT NULL  DEFAULT '' , CONSTRAINT [Items_GenreID_Genres_ID] FOREIGN KEY ("GenreID") REFERENCES "Genres" ( "ID" ) ON UPDATE NO ACTION ON DELETE NO ACTION); 
ALTER TABLE [Items] NOCHECK CONSTRAINT [Items_GenreID_Genres_ID];

---- Table structure for table `Categories` 
----

CREATE TABLE [Categories] ([ID] INTEGER IDENTITY(1,1)  ,[Name] TEXT NOT NULL  ,[Icon] TEXT NOT NULL  ); 

---- Dumping data for table `Genres`
---- 


 SET IDENTITY_INSERT [Genres] ON 
 GO

INSERT INTO [Genres] ([ID],[Name],[BgColor])( select 1,N'Science Fiction',N'8DA0CB') union all ( select 2,N'Fantasy',N'F2E766') union all ( select 3,N'Thriller',N'FC8D62') union all ( select 4,N'Romance',N'E5C494') union all ( select 5,N'Non-fiction',N'66C2A5') union all ( select 6,N'Crime',N'B3B3B3')

 SET IDENTITY_INSERT [Genres] OFF 
 GO


---- Dumping data for table `Items`
---- 


 SET IDENTITY_INSERT [Items] ON 
 GO

INSERT INTO [Items] ([ID],[Title],[Description],[GenreID],[CategoryID])( select 1,N'Dune',N'A sci-fi epic set in a distant future.',1,N'1') union all ( select 2,N'The Hobbit',N'A fantasy adventure with dragons and treasure.',2,N'1') union all ( select 3,N'The Da Vinci Code',N'A mystery thriller about hidden codes and secrets.',3,N'1') union all ( select 4,N'Pride and Prejudice',N'A classic romance novel.',4,N'1') union all ( select 5,N'Sapiens',N'A book exploring the history of humankind.',5,N'1') union all ( select 6,N'Neuromancer',N'A cyberpunk novel that introduced the concept of the Matrix.',1,N'1') union all ( select 7,N'Foundation',N'A sci-fi series about the fall and rise of a galactic empire.',1,N'1') union all ( select 8,N'Snow Crash',N'A sci-fi novel blending cyberpunk and virtual reality.',1,N'1') union all ( select 9,N'The Lord of the Rings',N'An epic fantasy trilogy set in Middle-earth.',2,N'1') union all ( select 10,N'Harry Potter and the Sorcerer’s Stone',N'A young wizard''s journey begins.',2,N'1') union all ( select 11,N'A Game of Thrones',N'Political intrigue and war in a medieval fantasy world.',2,N'1') union all ( select 12,N'The Girl with the Dragon Tattoo',N'A thriller involving a hacker and journalist solving a mystery.',3,N'1') union all ( select 13,N'Gone Girl',N'A psychological thriller with twists and deception.',3,N'1') union all ( select 14,N'The Silence of the Lambs',N'A psychological thriller featuring Hannibal Lecter.',3,N'1') union all ( select 15,N'Me Before You',N'A romance novel about an unexpected love story.',4,N'1') union all ( select 16,N'The Notebook',N'A touching love story spanning decades.',4,N'1') union all ( select 17,N'Outlander',N'A mix of romance and time travel adventure.',4,N'1') union all ( select 18,N'Educated',N'A memoir about growing up in a survivalist family.',5,N'1') union all ( select 19,N'The Power of Habit',N'Exploring the science of habit formation.',5,N'1') union all ( select 20,N'Thinking, Fast and Slow',N'A book about cognitive biases and decision-making.',5,N'1') union all ( select 21,N'Brave New World',N'A dystopian novel about a futuristic society.',1,N'1') union all ( select 22,N'The Name of the Wind',N'A fantasy novel about a gifted young man’s rise to power.',2,N'1') union all ( select 23,N'Sharp Objects',N'A dark psychological thriller.',3,N'1') union all ( select 24,N'Eleanor Oliphant Is Completely Fine',N'A novel about loneliness and self-discovery.',4,N'1') union all ( select 25,N'Sapiens',N'A book exploring the history of humankind.',5,N'1')

 SET IDENTITY_INSERT [Items] OFF 
 GO


---- Dumping data for table `Categories`
---- 


 SET IDENTITY_INSERT [Categories] ON 
 GO

INSERT INTO [Categories] ([ID],[Name],[Icon])( select 1,N'Books',N'📚') union all ( select 2,N'Movies',N'🎬') union all ( select 3,N'Games',N'🎮')

 SET IDENTITY_INSERT [Categories] OFF 
 GO

