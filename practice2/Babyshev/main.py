"""
Сценарий:
Пользователь открывает окно программы
Информация об открытом окне записывается в экземпляр WindowInfo
И передаётся в InversionRulesController
Он, на основании набора предикатов, InversionRule
делает вывод о том, требуется ли сейчас включать инверсию цветов
"""

from dataclasses import dataclass
from re import compile


@dataclass
class WindowInfo:
    """Данные об открытом окне
    path: Путь до программы
    title: Заголовок окна
    root_title: Заголовок главного окна (может совпадать с title)
    """
    path: str = ""
    title: str = ""
    root_title: str = ""


@dataclass
class InversionRule:
    """Правило включения инверсии цветов
    path: Простой текст для проверки пути
    или
    path_regex: Регулярное выражение для проверки пути
    title: Простой текст для проверки заголовка
    или
    title_regex: Регулярное выражение для проверки заголовка
    use_root_title: Проверять заголовок главного окна вместо текущего
    exclude: Пометить правило как "исключающее"
    """
    path: str = None
    path_regex: str = None
    title: str = None
    title_regex: str = None
    use_root_title: bool = False
    exclude: bool = False

    def __post_init__(self):
        self.exclude = self.exclude or None

        if self.path is not None:
            self.path_regex = None
        elif self.path_regex is None:
            raise RuntimeError("Unable to create rule with no path condition")

        self._check_title = True
        if self.title is not None:
            self.title_regex = None
        elif self.title_regex is None:
            self._check_title = False
            self.use_root_title = None

        self._title_regex = _try_compile(self.title_regex)
        self._path_regex = _try_compile(self.path_regex)

    def is_active(self, info: WindowInfo) -> bool:
        """Проверяет подходит ли предоставленная информация под описание
        Сначала проверяется путь, если он совпал, проверяется заголовок,
        Если путь совпал и заголовок совпал (либо нет проверки на заголовок)
        Возвращает истину, иначе - ложь
        :param info: информация об открытом окне
        :return: Применимо ли правило к данной информации
        """
        return (self.__check_path(info)
                and self.__check_title(info))

    def __check_path(self, info: WindowInfo):
        return _check_text(info.path, self.path, self._path_regex)

    def __check_title(self, info: WindowInfo):
        if not self._check_title:
            return True

        title = (info.root_title
                 if self.use_root_title
                 else info.title)
        return _check_text(title, self.title, self._title_regex)


RULES = dict[str, InversionRule]


class InversionRulesController:
    """Свод правил инверсии цветов
    """
    def __init__(self):
        self._rules: RULES = dict()
        self._included: RULES = dict()
        self._excluded: RULES = dict()

    @property
    def rules(self):
        """Возвращает текущий набор правил"""
        return self._rules

    def add_rule(self, name: str, rule: InversionRule):
        """Добавляет правило в общий список
        :param name: Уникальное имя правила
        :param rule: Правило для добавления
        """
        self._rules[name] = rule
        self._detect_accessory(rule)[name] = rule

    def remove_rules(self, names: set[str]):
        """Удаляет указанные правила из общего списка
        :param names: Список уникальных имён удаляемых правил
        """
        if not names:
            return

        for name in names:
            del self._detect_accessory(self._rules[name])[name]
            del self._rules[name]

    def is_inversion_required(self, info: WindowInfo):
        """Обходит свод правил с предоставленной информацией
        Если есть соответствующее "исключающее" правило вернёт ложь
        Если есть соответствующее правило, вернёт истину иначе ложь
        :param info: Информация, предоставляемая для проверки по правилам
        :return: Текущее состояние инверсии (ложь = выключить)
        """
        return (
            self._has_active_rules(info, self._included) and
            not self._has_active_rules(info, self._excluded)
        )

    def _has_active_rules(self, info: WindowInfo, rules: RULES = None):
        if rules is None:
            rules = self._rules
        return next(self._get_active_rules(info, rules), None) is not None

    @staticmethod
    def _get_active_rules(info: WindowInfo, rules: RULES):
        return (name for name in rules
                if rules[name].is_active(info))

    def _detect_accessory(self, rule: InversionRule):
        if rule.exclude:
            return self._excluded
        return self._included


def _try_compile(raw_regex: str):
    if not raw_regex:
        return
    return compile(raw_regex)


def _check_text(text: str, plain: str, regex):
    if regex:
        return bool(regex.fullmatch(text))
    return text == plain
