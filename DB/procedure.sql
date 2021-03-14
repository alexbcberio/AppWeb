CREATE PROCEDURE getTipo
 @email nvarchar(50)
 As
 begin
 select tipo 
 from Usuarios 
 where email=@email
 end