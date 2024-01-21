-- Создание БД
CREATE DATABASE universitet_db;

-- Создание СХЕМЫ
CREATE SCHEMA test_schema;

-- Создание таблиц
CREATE TABLE table_persons
(
    id            SERIAL NOT NULL PRIMARY KEY,
    last_name     TEXT   NOT NULL,
    first_name    TEXT   NOT NULL,
    patronymic    TEXT   NULL,
    date_of_birth DATE   NOT NULL
);

CREATE TABLE table_faculties
(
    id      SERIAL NOT NULL PRIMARY KEY,
    faculty TEXT   NOT NULL
);

CREATE TABLE table_subjects
(
    id      SERIAL NOT NULL PRIMARY KEY,
    subject TEXT   NOT NULL
);

CREATE TABLE table_teachers
(
    id         SERIAL  NOT NULL PRIMARY KEY,
    person_id  INTEGER NOT NULL,
    faculty_id INTEGER NOT NULL, 
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    FOREIGN KEY (person_id) REFERENCES table_persons (id) ON DELETE NO ACTION ON UPDATE NO ACTION ,
    FOREIGN KEY (faculty_id) REFERENCES table_faculties (id) ON DELETE NO ACTION ON UPDATE NO ACTION 
);

CREATE TABLE table_teacher_subjects 
(
    id SERIAL NOT NULL PRIMARY KEY ,
    teacher_id INT NOT NULL ,
    subject_id INT NOT NULL ,
    FOREIGN KEY (teacher_id) REFERENCES table_teachers(id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (subject_id) REFERENCES table_subjects(id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE table_students
(
    id         SERIAL  NOT NULL PRIMARY KEY,
    person_id  INTEGER NOT NULL,
    faculty_id INTEGER NOT NULL,
    course     INTEGER NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    FOREIGN KEY (person_id) REFERENCES table_persons (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (faculty_id) REFERENCES table_faculties (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE table_marks
(
    id         SERIAL  NOT NULL PRIMARY KEY,
    student_id INTEGER NOT NULL,
    date       DATE    NOT NULL DEFAULT CURRENT_DATE,
    mark       INTEGER NOT NULL,
    subject_id INTEGER NOT NULL,
    teacher_id INTEGER NOT NULL,
    FOREIGN KEY (student_id) REFERENCES table_students (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (subject_id) REFERENCES table_subjects (id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (teacher_id) REFERENCES table_teachers (id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

-- Создание ПРЕДСТАВЛЕНИЯ
CREATE VIEW view_students AS
SELECT table_students.id                                   AS id,
       concat(last_name, ' ', first_name, ' ', patronymic) AS full_name,
       date_of_birth,
       course,
       faculty
FROM table_students
         JOIN table_persons
              ON table_students.person_id = table_persons.id
         JOIN table_faculties
              ON table_students.faculty_id = table_faculties.id;

CREATE VIEW view_teachers AS
SELECT table_teachers.id                                   AS id,
       concat(last_name, ' ', first_name, ' ', patronymic) AS full_name,
       date_of_birth,
       faculty
FROM table_teachers
         JOIN table_persons
              ON table_teachers.person_id = table_persons.id
         JOIN table_faculties
              ON table_teachers.faculty_id = table_faculties.id;

CREATE VIEW view_teacher_subjects AS
     SELECT table_teacher_subjects.id AS id,
            full_name, subject
FROM table_teacher_subjects
    JOIN view_teachers
        ON table_teacher_subjects.teacher_id = view_teachers.id
    JOIN table_subjects
        ON table_teacher_subjects.subject_id = table_subjects.id;

CREATE VIEW view_marks AS
SELECT table_marks.id          AS id,
       view_students.full_name AS full_name_student,
       view_students.id        AS student_id,
       table_subjects.subject,
       table_marks.date,
       table_marks.mark,
       view_teachers.full_name AS full_name_teacher,
       view_teachers.id        AS teacher_id
FROM table_marks
         JOIN view_students
              ON table_marks.student_id = view_students.id
         JOIN table_subjects
              ON table_marks.subject_id = table_subjects.id
         JOIN view_teachers
              ON table_marks.teacher_id = view_teachers.id;

-- Наполнение таблиц тестовыми данными
INSERT INTO table_persons(last_name, first_name, patronymic, date_of_birth)
VALUES ('Starinin', 'Andrey', 'Nikolaevich', '1986-02-18'), ('Shubin', 'Yuriy', '', '1978-11-13');

INSERT INTO table_subjects(subject)
VALUES ('Math'), ('History');

INSERT INTO table_faculties(faculty)
VALUES ('SoftDev'), ('Design');

INSERT INTO table_teachers(person_id, faculty_id)
VALUES (
        (SELECT id FROM  table_persons WHERE last_name = 'Starinin'),
        (SELECT id FROM table_faculties WHERE faculty = 'SoftDev')
       );

INSERT INTO table_teacher_subjects(teacher_id, subject_id) VALUES
(
  (SELECT id FROM view_teachers WHERE full_name = 'Starinin Andrey Nikolaevich'),
  (SELECT id FROM table_subjects WHERE subject = 'Math')
),
(
  (SELECT id FROM view_teachers WHERE full_name = 'Starinin Andrey Nikolaevich'),
  (SELECT id FROM table_subjects WHERE subject = 'History')
);

INSERT INTO table_students(person_id, faculty_id, course)
VALUES (
        (SELECT id FROM  table_persons WHERE last_name = 'Shubin'),
        (SELECT id FROM table_faculties WHERE faculty = 'SoftDev'),
        4);

INSERT INTO table_marks(student_id, mark, subject_id, teacher_id)
VALUES (
        (SELECT id FROM view_students WHERE full_name = 'Shubin Yuriy '), 5, 
        (SELECT id FROM table_subjects WHERE subject = 'Math'),
        (SELECT id FROM view_teachers WHERE full_name = 'Starinin Andrey Nikolaevich')
       );

INSERT INTO table_marks(student_id, date, mark, subject_id, teacher_id)
VALUES (
        (SELECT id FROM view_students WHERE full_name = 'Shubin Yuriy '),
        '2024-01-03', 4,
        (SELECT id FROM table_subjects WHERE subject = 'Math'),
        (SELECT id FROM view_teachers WHERE full_name = 'Starinin Andrey Nikolaevich')
       );

INSERT INTO table_marks(student_id, mark, subject_id, teacher_id)
VALUES (
    (SELECT id FROM view_students WHERE full_name = 'Shubin Yuriy '), 7,
    (SELECT id FROM table_subjects WHERE subject = 'History'),
    (SELECT id FROM view_teachers WHERE full_name = 'Starinin Andrey Nikolaevich')
       );