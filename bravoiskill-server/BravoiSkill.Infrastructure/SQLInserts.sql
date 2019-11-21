
INSERT INTO BravoiSkill.dbo.Badges (Description) VALUES 
('n00bie'),
('Incepator'),
('Expert')
;

INSERT INTO BravoiSkill.dbo.Departments (Description) VALUES 
('.NET'),
('Java'),
('Testare'),
('Unasigned')
;

INSERT INTO BravoiSkill.dbo.Profiles (Description) VALUES 
('Administrator'),
('User')
;

INSERT INTO BravoiSkill.dbo.SkillCategories (Description, ParentId) VALUES 
('Personal',NULL),
('Job-related/Professional',NULL),
('Human Relations',1),('Character',1),
('Web - Front-End',2),('Web - Back-End',2),('Desktop/Mobile',2),('Databases',2),('Q&A',2),('UI/UX',2),('Business Analysis',2),('Sales',2),('Management',2),('Digital',2)
;

INSERT INTO BravoiSkill.dbo.Skills (Description, CategoryId) VALUES 
('Communication',3),('Group work',3),('Coworker relations',3),('Dependability',3),('Receives well criticism',3),('Patience',3),('Helper',3),('Receiver of help',3),('Integration with new people',3),
('Works to full potential',4),('Quality of work',4),('Independent work',4),('Initiative',4),('Productivity',4),('Creativity',4),('Humor',4),('Honesty',4),('Punctuality',4),('Open-minded',4),('Motivation',4),('Self-discipline',4),('Self-improvement',4),('Confidence',4),('Positivity',4),
('HTML',5),('CSS',5),('JavaScript',5),('Angular',5),('React.JS',5),('Vue.JS',5),('jQuery',5),('jQuery DT',5),('Bootstrap',5),('PrimeNG',5),
('Java EE',6),('Spring',6),('ASP.NET Core',6),('PHP',6),('GraphQL',6),
('Java SE',7),('.NET Desktop',7),('VB.NET',7),('.NET Framework',7),('Android',7),('iOS',7),
('DB Admin',8),('SQL Development',8),('T-SQL',8),('PL/SQL',8),('My SQL',8),
('Automation Testing',9),('Manual Testing',9),('Selenium',9),('Telerik',9),('HP ALM',9),
('Photoshop',10),('InDesign',10),('Webpage Design',10),('Logo Design',10),('UX Analyst',10),
('Writing Documentation',11),('Reverse Engineering',11),
('Persuasion',12),('Product Knowledge',12),('TimeManagement',12),('Buyer-Seller Agreement',12),('Strategic Prospecting',12),('Extraversion',12),
('Planning',13),('Decision making',13),('Delegation',13),('Resources Management',13),('Motivational',13),('Problem Solving',13),
('Adapting to change',14),('Microsoft Office',14),('Mail Management',14),('Usage of tools',14),('Conference maister',14),('Photography',14),('Videography',14),('Social media pro-activity',14)
;

INSERT INTO BravoiSkill.dbo.Users (FirstName,LastName,DateOfBirth,Email,Password,Skype,Photo,DepartmentId,ProfileId,BadgeId) VALUES 
('Andrei','Leahu','1996-11-29 00:00:00.000','andrei_lh@yahoo.com','123456','live:andrei_lh',NULL,1,1,3),
('Lidia-Gabriela','Burca','1999-07-14 00:00:00.000','lidia_burca@yahoo.com','123456','live:4013d68d7a36af76',NULL,1,1,2),
('Olimpia','Ticlos','1997-06-10 00:00:00.000','olimpia_ticlos@yahoo.com','123456','live:olimpiaticlos',NULL,1,1,3),
('Laiu','Stefanel','1990-06-10 00:00:00.000','stefanel_laiu@yahoo.com','123456','wolfang27',NULL,1,1,3),
('Lungu','Claudiu-Demian','1994-06-10 00:00:00.000','naimad_lungu@yahoo.com','123456','klahoodyoo',NULL,1,1,3),
('User','USER','1997-06-10 00:00:00.000','user@yahoo.com','123456','skype@notfakeskye.tru',NULL,3,2,1),
('User','USER','1997-06-10 00:00:00.000','user@yahoo.com','123456','skype@notfakeskye.tru',NULL,2,2,1)
;

INSERT INTO BravoiSkill.dbo.Reviews (ReviewDate, Comment, ReviewedUserId, ReviewerUserId) VALUES
('2018-11-12 00:00:00.000', 'A acceptat ca a gresit', 1, 3),
('2018-12-25 00:00:00.000', 'M-a ajutat la HTML toata ziua', 2, 1),
('2019-11-02 00:00:00.000', 'Problema la iOS', 4, 1),
('2019-10-17 00:00:00.000', 'A pus link la un buton', 5, 4),
('2019-04-02 00:00:00.000', 'Am invatat sa modific saturatia culorilor', 3, 2),
('2019-05-12 00:00:00.000', 'S-a miscat foarte repede la task', 1, 5),
('2019-06-14 00:00:00.000', 'Foarte increzator', 1, 4),
('2019-11-02 00:00:00.000', 'Ma ajuta mereu', 2, 1),
('2018-03-02 00:00:00.000', 'Mi-a dat clasele pentru buton', 5, 2),
('2019-08-23 00:00:00.000', 'Mereu la timp la meeting', 3, 5),
('2019-01-09 00:00:00.000', 'Ma destinde cand sunt incordat', 1, 4),
('2019-10-02 00:00:00.000', 'Bun organizator de task-uri', 4, 2),
('2019-06-14 00:00:00.000', 'Mi-a dat modele de interogari in SQL si exemple', 3, 2),
('2019-10-13 00:00:00.000', 'Mi-a facut o prezentare in power point', 4, 5)

INSERT INTO BravoiSkill.dbo.SkillReviews (SkillId, ReviewId, ReviewPoints) VALUES
(5, 1, 4),
(25, 2, 7),
(45, 3, 3),
(25, 4, 3),
(57, 5, 5),
(14, 6, 4),
(24, 7, 5),
(7, 8, 7),
(33, 9, 2),
(18, 10, 10),
(16, 11, 5),
(69, 12, 6),
(50, 13, 8),
(76, 14, 2)

INSERT INTO BravoiSkill.dbo.UserBadges (UserId, BadgeId) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(3, 1),
(4, 1),
(4, 2),
(4, 3),
(5, 1),
(5, 2),
(5, 3),
(6, 1),
(7, 1)



	--//modelBuilder.Entity<Badge>().HasData(new Badge[] {
	--//    new Badge{Description="Cel mai nou"},
	--//    new Badge{Description="Cel mai avansat"},
	--//});
	--//modelBuilder.Entity<Profile>().HasData(new Profile[] {
	--//    new Profile{Description="Administrator"},
	--//    new Profile{Description="User"}
	--//});
	--//modelBuilder.Entity<User>().HasData(new User[] {
	--//    new User{FirstName = "Andrei", LastName="Leahu", DateOfBirth = new System.DateTime(1996, 11, 29), Email="andrei_lh@yahoo.com", ProfileId=1},
	--//    new User{FirstName = "Lidia-Gabriela", LastName="Burca", DateOfBirth = new System.DateTime(1996, 11, 29), Email="lidia_bu@yahoo.com", ProfileId=2},
	--//    new User{FirstName = "Olimpia", LastName="Ticlos", DateOfBirth = new System.DateTime(1996, 11, 29), Email="olimpia_ti@yahoo.com", ProfileId=3}
	--//});