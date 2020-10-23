-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   name VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   picture VARCHAR(255)NOT NULL,
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE keeps
-- (
--   id int AUTO_INCREMENT,
--   name VARCHAR(255) NOT NULL,
--   description VARCHAR(255) NOT NULL,
--   img VARCHAR(255),
--   creatorId VARCHAR(255) NOT NULL,
--   PRIMARY KEY (id),
--   FOREIGN KEY (creatorId)
--     REFERENCES profiles(id)
--     ON DELETE CASCADE
-- )

/*NOTE HARDCODE A KEEP */
-- INSERT INTO keeps ( name , description, img , creatorId) VALUES ("Test", "testy" , "http://www.img.com" , "d1346e0c-3732-45fc-ad6b-237fa1a0b73d");