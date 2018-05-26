ALTER TABLE Users
ADD CONSTRAINT CK_PasswordLength CHECK(LEN(Password) >= 5)