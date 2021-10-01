"""Пример работы с классом для тестирования"""
from main import *


def main():
    print("Setup")
    rules = InversionRulesController()
    rules.add_rule("first", InversionRule(
        path="simple/stupid/path"
    ))
    rules.add_rule("second", InversionRule(
        path_regex="simple/.*th",
        title="lol"
    ))
    rules.add_rule("third", InversionRule(
        path_regex="simp.*",
        title_regex=r"lol\d",
        use_root_title=True,
        exclude=True
    ))

    print("Check")
    assert rules.is_inversion_required(WindowInfo(path="simple/stupid/path"))
    assert rules.is_inversion_required(WindowInfo(path="simple/path", title="lol"))
    assert not rules.is_inversion_required(WindowInfo(path="simple/path", root_title="lol3"))

    print("Cleanup")
    rules.remove_rules({"first", "second", "third"})
    assert not rules.rules

    print("OK")


if __name__ == '__main__':
    main()
