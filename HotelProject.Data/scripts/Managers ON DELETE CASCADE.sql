 ALTER TABLE Managers
 DROP CONSTRAINT fk_Hotel

 ALTER TABLE Managers
 ADD CONSTRAINT fk_Hotel
 FOREIGN KEY (HotelId)
 REFERENCES HOTELS (Id)
 ON DELETE CASCADE