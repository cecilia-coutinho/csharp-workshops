Denna uppgiften är tänkt som en första intro till databaser. Du bekantar dig med DbGate och att skriva enklare queries inuti DbGate

Vad du ska göra
- [x] Skapa ett "användarnamn" som är unikt i klassen. Ta första bokstaven i ditt förnamn följt av första och andra bokstaven i ditt efternamn, bara små bokstäver. Kristian Kjeldsen -> "kkj"
 * Jag satte localhost

- [x] Anslut till Monsters (hostad postgres) i DbGate (credentials ligger i klasskanalen). Gör nedanstående enbart med hjälp av SQL queries. Använd alltså bara Query-vyn i DbGate, inte GUI:t i övrigt.
 * Jag använde localhost

- [x] Skapa en ny tabell som heter kkj_student (byt ut kkj som ditt eget användarnamn)
- [x] Skapa sex kolumner, id, first_name, last_name, email, age och password. Skapa id med attributet SERIAL. De övriga datatyperna får du välja själv.
 * CREATE TABLE csrc_student (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(50) NOT NULL,
    last_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    age INTEGER NOT NULL,
    password VARCHAR(15) NOT NULL
    );

- [x] Stoppa in 3 olika påhittade studenter i din tabell
 * INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('maria','student','mariastudent@student.com','18','1234');
 * INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('pedro','student','pedrostudent@student.com','23','1234');
 * INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('peter','student','peterstudent@student.com','25','1234');

- [x] Skriv en SQL-fråga för att läsa ut alla studenter samt en för att läsa ut en student med en viss email
 * SELECT * FROM "public"."csrc_student";

- [x] Skriv en SQL-fråga för att uppdatera lösenordet på en student med en viss email
 * UPDATE "public"."csrc_student" SET password = 4563 WHERE email = 'mariastudent@student.com';

- [x] Spara alla dina SQL-frågor med en kort kommentar om vad de gör i en textfil, de kommer behövas senare. Tänk på att alla queries försvinner när du stänger ner DbGate

Visa dina queries samt att de fungerar mot din databas för att klara workshopen