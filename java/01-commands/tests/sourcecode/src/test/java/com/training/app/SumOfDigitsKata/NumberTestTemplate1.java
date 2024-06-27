package com.training.app.SumOfDigitsKata;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class NumberTestTemplate1 {

    @Test
    public void given0_resultShouldBe0() {
        long num = 0;
        int expectedRes = 0;
        Number number = new Number(num);

        long res = number.digitalRoot();

        assertEquals(expectedRes, res);
    }

    @Test
    public void given10_resultShouldBe1() {
        long num = 10;
        int expectedRes = 1;
        Number number = new Number(num);

        long res = number.digitalRoot();

        assertEquals(expectedRes, res);
    }
}
