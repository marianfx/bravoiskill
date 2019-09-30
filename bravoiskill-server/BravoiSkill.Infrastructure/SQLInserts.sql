INSERT INTO BravoiSkill.dbo.Profiles (Description) VALUES 
('Administrator'),
('User'),
('Guest')
;

INSERT INTO BravoiSkill.dbo.Badges (Description) VALUES 
('Incepator'),
('Expert')
;

INSERT INTO BravoiSkill.dbo.Department (Description) VALUES 
('.NET'),
('Java'),
('Testare')
;

INSERT INTO BravoiSkill.dbo.Users (FirstName,LastName,DateOfBirth,Email,Password,Skype,Photo,DepartmentId,ProfileId,BadgeId) VALUES 
('Andrei','Leahu','1996-11-29 00:00:00.000','andrei_lh@yahoo.com','123456',NULL,NULL,1,1,2),
('Lidia-Gabriela','Burca','1999-07-14 00:00:00.000','lidia_burca@yahoo.com','123456',NULL,NULL,1,1,2),
('Olimpia','Ticlos','1997-06-10 00:00:00.000','olimpia_ticlos@yahoo.com','123456',NULL,NULL,1,1,2),
('Guest','GUEST','1997-06-10 00:00:00.000','guest@yahoo.com','123456',NULL,NULL,2,3,1),
('User','USER','1997-06-10 00:00:00.000','user@yahoo.com','123456',NULL,NULL,3,2,1),
('User','USER','1997-06-10 00:00:00.000','user@yahoo.com','123456',NULL,NULL,2,2,2)
;



            --//modelBuilder.Entity<Badge>().HasData(new Badge[] {
            --//    new Badge{Description="Cel mai nou"},
            --//    new Badge{Description="Cel mai avansat"},
            --//});
            --//modelBuilder.Entity<Profile>().HasData(new Profile[] {
            --//    new Profile{Description = "Administrator"},
            --//    new Profile{Description="User"},
            --//    new Profile{Description="Guest"}
            --//});
            --//modelBuilder.Entity<User>().HasData(new User[] {
            --//    new User{FirstName = "Andrei", LastName="Leahu", DateOfBirth = new System.DateTime(1996, 11, 29), Email="andrei_lh@yahoo.com", ProfileId=1},
            --//    new User{FirstName = "Lidia-Gabriela", LastName="Burca", DateOfBirth = new System.DateTime(1996, 11, 29), Email="lidia_bu@yahoo.com", ProfileId=2},
            --//    new User{FirstName = "Olimpia", LastName="Ticlos", DateOfBirth = new System.DateTime(1996, 11, 29), Email="olimpia_ti@yahoo.com", ProfileId=3}
            --//});