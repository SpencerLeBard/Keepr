-- DROP TABLE keeps
-- SET FOREIGN_KEY_CHECKS=0;

-- FIXME FILL THIS OUT, DROP TABLE, CREATE NEW TABLE WITH ADDITIONS

-- CREATE TABLE keeps
-- (
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   creatorId VARCHAR(255) NOT NULL,
--   shares INT
--   views INT
--   keeps INT
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255)NOT NULL,
--   PRIMARY KEY (id)
-- );


/*NOTE HARDCODE A KEEP */

-- INSERT INTO keeps ( name , description, img , creatorId) VALUES ("spencers", "extra testy" , "http://www.img2.com" , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d");

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
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),
--   FOREIGN KEY (vaultId) 
--     REFERENCES vaults (id) 
--     ON DELETE CASCADE,
--   FOREIGN KEY (keepId) 
--     REFERENCES keeps (id)
--     ON DELETE CASCADE
-- );

-- INSERT INTO vaultkeeps ( vaultId , keepId, creatorId) VALUES ("1", "1" , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d");