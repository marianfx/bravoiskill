INSERT INTO BravoiSkill.dbo.Profiles (Description) VALUES 
('Administrator')
,('User')
,('Guest')
;

INSERT INTO BravoiSkill.dbo.Badges (Description) VALUES 
('Incepator')
,('Expert')
;

INSERT INTO BravoiSkill.dbo.Users (FirstName,LastName,DateOfBirth,ProfileId,BadgeId,Email,Password,Photo,Skype) VALUES 
('Andrei','Leahu','1996-11-29 00:00:00.000',1,1,'andrei_lh@yahoo.com','123456',NULL,NULL)
,('Lidia-Gabriela','Burca','1998-06-10 00:00:00.000',1,1,'lidia_burca@yahoo.com','123456',NULL,NULL)
,('Olimpia','Ticlos','1997-06-10 00:00:00.000',1,2,'olimpia_ticlos@yahoo.com','123456',NULL,NULL)
,('Guest','GUEST','1997-06-10 00:00:00.000',3,2,'guest@yahoo.com','123456',NULL,NULL)
,('User','USER','1997-06-10 00:00:00.000',2,2,'user@yahoo.com','123456',NULL,NULL)
,('User','USER','1997-06-10 00:00:00.000',2,1,'user@yahoo.com','123456',NULL,NULL)
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