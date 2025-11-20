# Overview

This project aims to provide a lightweight, all-in-one local cloud platform running on a single Raspberry Pi server.

# Services

Basic user:

- Public Pages

Admin:
- Function (with console)
- Database
- Message Queue
- Page Management
- Logs
- Scheduler (trigger function)
- Virtual Drive (upload/download files)

Notes:

For external device:

- use device ip: https://192.168.100.186:3001 and http://192.168.100.186:3000/
- use localhost. https://localhost:3001/ and http://localhost:3000

SQLlite commands:

CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT)

INSERT INTO Users (Name) VALUES ("Roberto")

SELECT * FROM Users
