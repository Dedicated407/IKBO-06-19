## Задание

Что такое анаграмма? Что ж, два слова являются анаграммами друг друга, если они оба содержат одинаковые буквы.

Например:

```c#
"abba" & "baab" == true

"abba" & "bbaa" == true

"abba" & "abbba" == false

"abba" & "abca" == false
```

Напишите функцию, которая найдет все анаграммы слова из списка. Вам дадут два входных параметра: слово и массив со
словами. Вы должны вернуть массив всех анаграмм или пустой массив,

## Примеры

```c#
Anagrams("abba", ["aabb", "abcd", "bbaa", "dada"]) => ["aabb", "bbaa"]

Anagrams("racer", ["crazer", "carer", "racar", "caers", "racer"]) => ["carer", "racer"]

Anagrams("laser", ["lazing", "lazy",  "lacer"]) => []
```

## Тестируемый метод

```c#
// WhereMyAnagramsAt.KataWhereMyAnagramsAt.FindAnagrams
public static IEnumerable<string> FindAnagrams(string word, IEnumerable<string> words) 
```
