-- 3.1: Получить список всех взятых пользователем книг в качестве параметра поиска - ID пользователя. Полное дерево: Книги - автор - жанр (через запятую)
SELECT 
       b.name as Книга, 
       concat_ws(' ', a.last_name, a.middle_name, a.first_name) as Автор,
       string_agg(g.genre_name, ', ') as Жанр
FROM person as p
    LEFT JOIN library_card lc on p.id = lc.person_id
    JOIN book b on b.id = lc.book_id
    JOIN author a on b.author_id = a.id
    LEFT JOIN book_genre bg on b.id = bg.book_id
    JOIN genre g on g.id = bg.genre_id
WHERE p.id = :person_id
group by b.name, a.last_name, a.middle_name, a.first_name;

-- 3.2: Получить список книг автора (книг может и не быть). автор + книги + жанры  (через запятую)
SELECT
    concat_ws(' ', a.last_name, a.middle_name, a.first_name) as Автор,
    b.name as Книга,
    string_agg(g.genre_name, ', ') as Жанр
FROM author as a
         LEFT JOIN book b on a.id = b.author_id
         LEFT JOIN book_genre bg on b.id = bg.book_id
         JOIN genre g on g.id = bg.genre_id
group by a.last_name, a.middle_name, a.first_name, b.name;

SELECT g.genre_name as Жанр, coalesce(sum(bg.book_id), 0) AS "Количество книг" FROM genre as g
    LEFT JOIN book_genre bg on g.id = bg.genre_id
group by g.genre_name ORDER BY "Количество книг" desc;
    
