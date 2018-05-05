
use Proyecto;
create procedure ProyectoBackup
as
backup database [Proyecto] to disk =N'C:\BackupDB\backup.bak';


use master;
create procedure restoreProyecto
as 
restore database Proyecto from disk = 'C:\BackupDB\backup.bak';