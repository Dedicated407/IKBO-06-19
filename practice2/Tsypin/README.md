## О программе
Программа для решение разного рода задач, каждый метод – решение новой задачки. Все задачки взяты из сайта [CodeWars]( https://www.codewars.com/ )

## Структура проекта
- **ToCamelCase**: Задача на превращение входного предложения на «верблюжье» слово. Пробелы в своем предложении замените на `–` или `_`. Первое слово в выходных данных должно быть написано с заглавной буквы, только если исходное слово было написано с заглавной буквы (известно, как верхний регистр верблюда, также часто называемый регистром Паскаля).
    #### Входные данные:
    - sentence: ваше предложение. Тип данных - `string`
    #### Возвращаемые данные:
    - Метод возвращает строку по ТЗ. Тип данных - `string`

- **ArrayDiff**: Данный метод вычитает один массив из другого и возвращает результат. Он должен удалить все значения из массива `firstArray`, которые присутствуют в массиве `secondArray`, сохраняя их порядок.
    #### Входные данные:
    - firstArray: Первый массив, из которого происходит удаление. Тип данных - `IEnumerable<int>`
    - secondArray: Второй массив, имеет значения, которые нужно удалить. Тип данных - `IEnumerable<int>`
    #### Возвращаемые данные:
    - Метод возвращает массив. Тип данных - `int[]`

- **GetReadableTime**: Данный метод принимает неотрицательное целое число (секунды) в качестве входных данных и возвращает время в удобочитаемом формате (ЧЧ:ММ:СС). Максимальное значение результата метода – 99:59:59.
    #### Входные данные:
    - seconds: Количество секунд `int`
    #### Возвращаемые данные:
    - Метод возвращает строку по ТЗ. Тип данных - `string`
  
- **IsValidWalk**: Задача про ’10 минут’. Вы живете в городе Квадрат, где все дороги выложены в идеальную сетку. Вы приехали на десять минут раньше назначенного времени, поэтому решили воспользоваться возможностью и отправиться на короткую прогулку. Для направления используйте `['n', 's', 'w', 'e']`. Вы всегда проходите только один квартал для каждой буквы (направления), и вы знаете, что вам требуется одна минута, чтобы пересечь один городской квартал. Условием выполнения маршрута является возвращение на исходную точку и длительность прогулки (10 минут). Данный метод выдает значение `true` если вы успеваете, во всех других исходах `false`.
Данный метод принимает массив строк (ваш путь).
    #### Входные данные:
    - walk: Ваш составленный путь. Тип данных - `IReadOnlyCollection<string>`
    #### Возвращаемые данные:
    - Метод возвращает true или false, в соответствии с ТЗ. Тип данных - `bool`

- **RomanConvert**: Данный метод принимает положительное целое число в качестве параметра и возвращающую строку, содержащую представление этого целого числа римскими цифрами. 
    #### Входные данные:
    - number: Исходное число. Тип данных - `int`
    #### Выходные данные: 
    - Метод вовзращает строку с римскими цифрами. Тип данных - `string`

- **Extract**: Данный метод предназначен для выявления диапазона чисел. На вход принимается список целых чисел в порядке возрастания. Диапазон включает все целые числа в интервале, включая обе конечные точки. Он не считается диапазоном, если он не охватывает по крайней мере 3 числа. Например "12,13,15-17". 
    #### Входные данные:
    - args: Список целых чисел. Тип данных - `int[]`
    #### Выходные данные:
    - Метод возвращает строку в формате диапазона, если он присутствует. Тип данных - `string`

## Задание
Требуется протестировать следующие методы:
- ToCamelCase
- ArrayDiff
- GetReadableTime
- IsValidWalk
- RomanConvert
- Extract
