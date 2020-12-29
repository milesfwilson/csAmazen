-- CREATE TABLE profiles (
--     id VARCHAR(255) NOT NULL,
--     name VARCHAR(255) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     picture VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id)
-- )
-- CREATE TABLE items (
--     title VARCHAR(255) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     price DECIMAL NOT NULL,
--     salePrice DECIMAL,
--     picture VARCHAR(255) NOT NULL,
--     quantity INT NOT NULL,
--     id INT NOT NULL AUTO_INCREMENT,
--     rating INT NOT NULL,
--     isAvailable TINYINT NOT NULL,
--     creatorId VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--         FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )

-- ALTER TABLE items
-- ADD COLUMN salePrice decimal(10,2);



    -- CREATE TABLE lists (
    --     title VARCHAR(255) NOT NULL,
    --     creatorId VARCHAR(255) NOT NULL,
    --     id INT NOT NULL AUTO_INCREMENT,
    --     isPublic TINYINT NOT NULL,
    --     PRIMARY KEY (id),
    --         FOREIGN KEY (creatorId)
    --         REFERENCES profiles(id)
    --         ON DELETE CASCADE
    -- )

--     CREATE TABLE listitems(
--   id INT NOT NULL AUTO_INCREMENT,   
--   listId INT,
--   itemId INT,
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (listId)
--   REFERENCES lists (id)
--   ON DELETE CASCADE,

--   FOREIGN KEY (itemId)
--   REFERENCES items (id)
--   ON DELETE CASCADE,

--    FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE

-- )
--     CREATE TABLE options(
--   id INT NOT NULL AUTO_INCREMENT,   
--   itemId INT,
--   color VARCHAR(255),
--   creatorId VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (itemId)
--   REFERENCES items (id)
--   ON DELETE CASCADE,

--    FOREIGN KEY (creatorId)
--         REFERENCES profiles(id)
--         ON DELETE CASCADE
-- )