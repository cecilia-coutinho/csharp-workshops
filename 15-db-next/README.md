Vad du ska göra

- [x] Använd samma användarnamn som i föregående workshop
- [x] Anslut till Monsters (hostad postgres) i DbGate med enbart hjälp av SQL queries (credentials ligger i klasskanalen) Använd inte Query-vyn i DbGate, utan de knappar och vyer som finns för att skapa tabeller, läsa in data
 * Jag satte localhost

- [x] Skapa en ny tabell som heter kkj_course (byt ut kkj som ditt eget användarnamn)
- [x] Skapa fem kolumner, id, name, points, start_date, end_date. Skapa id genom att kryssa i NOT NULL, Is Primary Key samt Is Autoincrement
 * CREATE TABLE csrc_course (
   id SERIAL PRIMARY KEY,
   name VARCHAR(50) NOT NULL,
   points INTEGER NOT NULL,
   start_date DATE NOT NULL,
   end_date DATE);

- [x] Stoppa in 3 olika påhittade kurser i din tabell
 * INSERT INTO csrc_course ("name", "points", "start_date", "end_date") VALUES ('.net', 50, '01-01-2023', '01-01-2024');
 * INSERT INTO csrc_course ("name", "points", "start_date", "end_date") VALUES ('java', 50, '01-01-2023', '01-01-2024');
 * INSERT INTO csrc_course ("name", "points", "start_date", "end_date") VALUES ('python', 50, '01-01-2023', '01-01-2024');

- [x] Skriv en SQL-fråga för att läsa ut alla kurser samt en för att läsa ut en kurs med ett visst namn
 * SELECT * FROM csrc_course where name = '.net';

- [x] Öva på att ändra data på en av raderna. Vad krävs att du gör för att ändringen ska bli permanent?
 * om inte med query är det nödvändigt att spara (knapp spara)

- [x] Öva på att ta bort en av raderna. Vad krävs att du gör för att ändringen ska bli permanent?
 * om inte med query är det nödvändigt att spara (knapp spara)

Visa hur du hanterar DbGate för att få godkänt på denna workshop