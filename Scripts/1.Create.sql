-- 1. Написать скрипт, который генерирует схему БД согласно рисунку.
CREATE TABLE author
(
    id          SERIAL       NOT NULL PRIMARY KEY,
    first_name  VARCHAR(255) NOT NULL,
    last_name   VARCHAR(255) NOT NULL,
    middle_name VARCHAR(255)
);

CREATE TABLE book
(
    id        SERIAL NOT NULL PRIMARY KEY,
    name      VARCHAR(255),
    author_id INT REFERENCES author (id) ON DELETE CASCADE
);

CREATE TABLE genre
(
    id         SERIAL NOT NULL PRIMARY KEY,
    genre_name VARCHAR(255)
);

CREATE TABLE book_genre
(
    -- PascalCase для маппинга entity, т.к. в ef core 5 нельзя указать название полей для связи в many-to-many.
    BooksId  INT NOT NULL REFERENCES book (id) ON DELETE CASCADE,
    GenresId INT NOT NULL REFERENCES genre (id) ON DELETE CASCADE,
    CONSTRAINT book_genre_pk PRIMARY KEY (BooksId, GenresId)
);

CREATE TABLE person
(
    id          SERIAL       NOT NULL PRIMARY KEY,
    first_name  VARCHAR(255) NOT NULL,
    last_name   VARCHAR(255) NOT NULL,
    middle_name VARCHAR(255),
    birth_date  DATE
);

CREATE TABLE library_card
(
    book_id   INT NOT NULL REFERENCES book (id) ON DELETE CASCADE,
    person_id INT NOT NULL REFERENCES person (id) ON DELETE CASCADE,
    CONSTRAINT book_person_pk PRIMARY KEY (book_id, person_id)
);