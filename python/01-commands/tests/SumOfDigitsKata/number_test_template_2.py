import pytest
from number import Number

@pytest.mark.parametrize("num, expected_res", [(0, 0), (10, 1)])
def test_digital_root(num, expected_res):
    number = Number(num)
    res = number.digital_root()
    assert res == expected_res