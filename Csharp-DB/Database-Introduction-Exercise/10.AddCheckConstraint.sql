ALTER TABLE [Users]
ADD CHECK(LEN([Password]) >=5)