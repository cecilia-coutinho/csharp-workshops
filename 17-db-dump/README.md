
Denna uppgiften är designad för att du ska träna på att ta "backup" av data och struktur i en databas. Det är några inställningar som behövs. Du kommer att använda DbGate för denna labb.

Vad du ska göra
- [x] Anslut till Monsters (hostad postgres) i DbGate (credentials ligger i klasskanalen).
- [x] Du har två tabeller i databasen nu, kkj_student och kkj_course
- [x] Högerklicka på en av dina tabeller nere till vänster i DbGate, välj alternativet SQL Generator: CREATE TABLE
- [x] Du får nu upp Generator-vyn i DbGate. Notera att din tabell blev ikryssad nere till vänster. Om du t.ex valde kkj_student är den ikryssad. Kryssa även i din andra tabell, kkj_course.
- [x] Till höger i DbGate har du ett antal alternativ, några är kryssade som default.
- [x] I min DbGate är Create tables, Create foreign keys samt Create indexes ikryssade som default.
- [x] Kryssa även i Drop tables, Test if exists
- [x] Kryssa i Drop references
- [x] Kryssa sedan i Insert och Skip autoincrement column
- [x] Det du ser på skärmen nu är din DB-dump. Med hjälp av den kan du återskapa databasens struktur och innehåll var som helst.
- [x] Kopiera ut all text från DbGate och spara i en textfil. Kopiera in det i ett Query och kör det. Får du några errors? Allt ska vara som innan, så ibland är det svårt att se om det fungerar.
- [x] Gå in med DbGate och ändra manuellt något fält nånstans men gör ingen ny dump
- [x] Kör din dump som ett query. Är allt återställt som det var innan din ändring? I så fall fungerar det.
- [x] Det är ett väldigt värdefullt verktyg att kunna skapa och återställa dumpar, t.ex om nåt hänt med databasen.

###Query - DB Dump###
DROP TABLE IF EXISTS "public"."csrc_student";
DROP TABLE IF EXISTS "public"."csrc_course";
CREATE TABLE "public"."csrc_student" ( 
  "id" SERIAL,
  "first_name" VARCHAR(50) NOT NULL,
  "last_name" VARCHAR(50) NOT NULL,
  "email" VARCHAR(100) NOT NULL,
  "age" INTEGER NOT NULL,
  "password" VARCHAR(15) NOT NULL,
  CONSTRAINT "csrc_student_pkey" PRIMARY KEY ("id"),
  CONSTRAINT "csrc_student_email_key" UNIQUE ("email")
);
CREATE TABLE "public"."csrc_course" ( 
  "id" SERIAL,
  "name" VARCHAR(50) NOT NULL,
  "points" INTEGER NOT NULL,
  "start_date" DATE NOT NULL,
  "end_date" DATE NULL,
  CONSTRAINT "csrc_course_pkey" PRIMARY KEY ("id")
);
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('pedro', 'student', 'pedrostudent@student.com', 23, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('peter', 'student', 'peterstudent@student.com', 25, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('ignacio', 'rosa', 'nachorosa@tester.com', 33, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('pepe', 'giovanni', 'pepe@student.com', 55, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('mora', 'amora', 'mora@student.com', 15, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('kalle', 'person', 'kalle@student.com', 38, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('marta', 'rosa', 'martarosa@tester.com', 23, '1111');
INSERT INTO "public"."csrc_student" ("first_name", "last_name", "email", "age", "password") VALUES ('maria', 'student', 'mariastudent@student.com', 18, '1111');
INSERT INTO "public"."csrc_course" ("name", "points", "start_date", "end_date") VALUES ('c++', 60, '2023-03-01', '2024-04-01');
INSERT INTO "public"."csrc_course" ("name", "points", "start_date", "end_date") VALUES ('c', 60, '2023-03-01', '2024-04-01');
INSERT INTO "public"."csrc_course" ("name", "points", "start_date", "end_date") VALUES ('python', 60, '2023-03-01', '2024-04-01');
INSERT INTO "public"."csrc_course" ("name", "points", "start_date", "end_date") VALUES ('.net', 50, '2023-01-01', '2024-01-01');
INSERT INTO "public"."csrc_course" ("name", "points", "start_date", "end_date") VALUES ('java', 50, '2023-10-01', '2024-11-01');