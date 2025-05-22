
----------- 20 May 2025  ---------------
----- Please apply this query if your setting up the database for the first time

--Add-Migration "Create DB";

--Update-Database;


-----------22 May 2025 ---------------

Alter table [TrackerDB].[dbo].[FormManagements]
Add IsRecordDeleted bit not null default 0;