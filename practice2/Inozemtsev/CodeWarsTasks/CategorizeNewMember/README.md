﻿## Задание

Крокет-клуб Western Suburbs имеет две категории членства: Senior и Open. Им нужна ваша помощь с форма заявки, которая
сообщит потенциальным членам, в какую категорию они будут помещены.

Чтобы быть взрослым, член должен быть не моложе 55 лет и иметь гандикап больше 7. В этом крокет-клубе гандикапы от -2 до
+26; чем лучше игрок, тем меньше гандикап.

## Входные параметры

Вход будет состоять из списка списков, содержащих по два элемента в каждом. Каждый список содержит информацию об одном
потенциальном члене клуба. Информация состоит из целого числа для возраста человека и целого числа для гандикапа.

## Пример входных данных

```c#
new int[][] {new int[] {18, 20}, new int[] {45, 2}, new int[] {61, 12}, new int[] {37, 6}, new int[] {21, 21}, new int[] {78, 9}}
```

## Выходные данные

Вывод будет состоять из списка строковых значений, указывающих, должен ли соответствующий член быть помещен в Senior или
Open.

## Пример выходных данных

```c#
new string[] {"Open", "Open", "Senior", "Open", "Open", "Senior"}
``` 

## Тестируемые метод

```c#
// CategorizeNewMember.KataCategorizeNewMember.GetOpenOrSenior
public static IEnumerable<string> GetOpenOrSenior(IEnumerable<int[]> data)
```
