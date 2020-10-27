-- DROP TABLE vaultkeeps;
-- DROP TABLE keeps;



-- FIXME FILL THIS OUT, DROP TABLE, CREATE NEW TABLE WITH ADDITIONS

-- CREATE TABLE keeps
-- (
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   creatorId VARCHAR(255) NOT NULL,
--   shares INT,
--   views INT,
--   keeps INT,
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

/*NOTE Create KEEP */ 
-- INSERT INTO keeps ( name , description, img , creatorId , shares , views , keeps) VALUES ("spencers1", "description test" , "http://www.img2.com" , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d" , 0 , 0 , 0 );
-- INSERT INTO keeps ( name , description, img , creatorId , shares , views , keeps) VALUES ("spencers2", "extra testy" , "http://www.img2.com" , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d" , 0 , 0 , 0 );
-- INSERT INTO keeps ( name , description, img , creatorId , shares , views , keeps) VALUES ("kellys", "testy cal" , "http://www.img2.com" , "d33aace6-b5e0-47c8-a2d9-4c93207627e8" , 0 , 0 , 0);
/*FIXME do I include views, shares, ect as 0? or model? */ 


-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255)NOT NULL,
--   PRIMARY KEY (id)
-- );



-- CREATE TABLE vaults
-- (
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   isPrivate TINYINT,
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )
-- INSERT INTO vaults ( name , description, isPrivate , creatorId) VALUES ("Vaultusertest", "testtest" , 0 , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d");

-- CREATE TABLE vaultkeeps
-- (
--   id int AUTO_INCREMENT,
--   vaultId INT,
--   keepId INT,
--   creatorId VARCHAR(255),
--   PRIMARY KEY (id),
--     FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE,
--     FOREIGN KEY (vaultId)
--     REFERENCES vaults(id) 
--     ON DELETE CASCADE,
--     FOREIGN KEY (keepId) 
--     REFERENCES keeps(id)
--     ON DELETE CASCADE
-- );

-- DROP TABLE vaultkeeps;

-- INSERT INTO vaultkeeps ( vaultId , keepId, creatorId) VALUES (1 , 1 , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d");