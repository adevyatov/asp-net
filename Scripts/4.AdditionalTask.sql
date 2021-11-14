-- Доп. задание 1.
-- 4.1. Добавить  в схему дату получения книги для выявления должников.
ALTER TABLE library_card
    ADD COLUMN IF NOT EXISTS date DATE NOT NULL DEFAULT CURRENT_DATE;

UPDATE library_card
SET date = CURRENT_DATE - INTERVAL '2' MONTH
WHERE person_id = 1
  AND book_id = 1;

UPDATE library_card
SET date = CURRENT_DATE - INTERVAL '21' DAY
WHERE person_id = 1
  AND book_id = 2;

UPDATE library_card
SET date = CURRENT_DATE - INTERVAL '15' DAY
WHERE person_id = 1
  AND book_id = 3;

UPDATE library_card
SET date = CURRENT_DATE - INTERVAL '1' MONTH
WHERE person_id = 3
  AND book_id = 7;

UPDATE library_card
SET date = CURRENT_DATE - INTERVAL '5' DAY
WHERE person_id = 4;

-- Добавить sql скрипты с запросами (книги берутся на 14 дней)
-- 4.1. Получить всех должников (Пользователь, книга, время просрочки сдачи в днях)
SELECT CONCAT_WS(' ', p.last_name, p.middle_name, p.first_name) AS Должник,
       b.name                                                   AS Книга,
       CURRENT_DATE - lc.date - 14                              AS "Дней просрочки",
       lc.date
FROM person p
         LEFT JOIN library_card lc ON p.id = lc.person_id
         JOIN book b ON b.id = lc.book_id
WHERE CURRENT_DATE - lc.date > 14;

-- 4.2. Получить всех должников, у которых более 3 просроченных книг (пользователь, кол-во книг)
SELECT CONCAT_WS(' ', p.last_name, p.middle_name, p.first_name) AS Должник,
       COUNT(lc.book_id)                                        AS "Количество книг"
FROM person p
         LEFT JOIN library_card lc ON p.id = lc.person_id
WHERE CURRENT_DATE - lc.date > 14
GROUP BY p.last_name, p.middle_name, p.first_name
HAVING COUNT(lc.book_id) > 2;
-- в базе у человека максимум 3 книги, поэтому чуть уменьшил условие

-- 4.3. Получить статистику по должникам (пользователь, количество просроченных книг, их суммарная по дням просрочка)
SELECT CONCAT_WS(' ', p.last_name, p.middle_name, p.first_name) AS Должник,
       COUNT(lc.book_id)                                        AS "Количество книг",
       SUM(CURRENT_DATE - lc.date)                              AS "Суммарная по дням просрочка"
FROM person p
         LEFT JOIN library_card lc ON p.id = lc.person_id
WHERE CURRENT_DATE - lc.date > 14
GROUP BY p.last_name, p.middle_name, p.first_name;