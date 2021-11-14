-- 3. sql скрипты с запросами
-- 3.1. Получить список всех взятых пользователем книг в качестве параметра поиска - ID пользователя. Полное дерево: Книги - автор - жанр (через запятую)
SELECT b.name                                                   AS Книга,
       CONCAT_WS(' ', a.last_name, a.middle_name, a.first_name) AS Автор,
       STRING_AGG(g.genre_name, ', ')                           AS Жанр
FROM person AS p
         LEFT JOIN library_card lc ON p.id = lc.person_id
         JOIN book b ON b.id = lc.book_id
         JOIN author a ON b.author_id = a.id
         LEFT JOIN book_genre bg ON b.id = bg.book_id
         JOIN genre g ON g.id = bg.genre_id
WHERE p.id = :person_id
GROUP BY b.name, a.last_name, a.middle_name, a.first_name;

-- 3.2: Получить список книг автора (книг может и не быть). автор + книги + жанры  (через запятую)
SELECT CONCAT_WS(' ', a.last_name, a.middle_name, a.first_name) AS Автор,
       b.name                                                   AS Книга,
       STRING_AGG(g.genre_name, ', ')                           AS Жанр
FROM author AS a
         LEFT JOIN book b ON a.id = b.author_id
         LEFT JOIN book_genre bg ON b.id = bg.book_id
         JOIN genre g ON g.id = bg.genre_id
GROUP BY a.last_name, a.middle_name, a.first_name, b.name;

-- 3.3 Вывод статистики Жанр - количество книг
SELECT g.genre_name AS Жанр, COALESCE(COUNT(bg.book_id), 0) AS "Количество книг"
FROM genre AS g
         LEFT JOIN book_genre bg ON g.id = bg.genre_id
GROUP BY g.genre_name
ORDER BY "Количество книг" DESC;
    
