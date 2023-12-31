1) В одномерном массиве из натуральных чисел удвоить четные элементы массива стоящие на нечетных местах и найти максимальное значение(max) из нечетных элементов стоящих на четных местах. Вывести исходный массив, получившийся массив, max и дополнительное сообщение, если в массиве не оказалось ни одного четного элемента стоящего на нечетном месте.
Количество элементов в массиве задается пользователем с клавиатуры, числа в массиве генерируются произвольно.

Пример работы кода:
```
Введите количество элементов в массиве: 10
Исходный массив:
42 69 29 45 58 66 68 71 23 76
Получившийся массив:
84 69 29 45 116 66 136 71 23 76
Максимальное нечетное значение на четной позиции: 71
```

2) Необходимо хранить свою библиотеку, нужны только названия книг и авторы, больше ничего хранить не надо.
   а) Предложите структуру таблиц. схему можно нарисовать от руки и
прикрепить к письму в виде фото.
   б) Напишите sql-запрос который бы формировал отчет содержащий список
книг, которые написаны 3мя и более со-авторами.

Пример структуры таблиц:
```
Таблица: Books
-------------------------------------
| BookID (Primary Key) | Title      |
-------------------------------------
| 1                    | Book 1     |
| 2                    | Book 2     |
| 3                    | Book 3     |
-------------------------------------

Таблица: Authors
-------------------------------------
| AuthorID (Primary Key)| Name      |
-------------------------------------
| 1                      | Author 1  |
| 2                      | Author 2  |
| 3                      | Author 3  |
| 4                      | Author 4  |
-------------------------------------

Таблица: BookAuthors
-------------------------------------
| BookID (Foreign Key) | AuthorID (Foreign Key) |
-------------------------------------------------
| 1                     | 1                      |
| 1                     | 2                      |
| 1                     | 3                      |
| 2                     | 1                      |
| 2                     | 2                      |
| 3                     | 1                      |
| 3                     | 2                      |
| 3                     | 3                      |
| 3                     | 4                      |
-------------------------------------------------
```

SQL запрос для формирования отчет содержащий список книг, которые написаны 3мя и более со-авторами:

```
SELECT b.Title, COUNT(ba.AuthorID) AS NumAuthors
FROM Books b
JOIN BookAuthors ba ON b.BookID = ba.BookID
GROUP BY b.BookID, b.Title
HAVING COUNT(ba.AuthorID) >= 3;
```
