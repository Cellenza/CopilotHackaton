package com.training.app.SumOfDigitsKata;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class NumberTestTemplate2 {

    @Test
    public void digitalRoot_ShouldReturnExpectedResult() {
        long num = 0;
        int expectedRes = 0;

        Number number = new Number(num);

        long res = number.digitalRoot();

        assertEquals(expectedRes, res);
    }
}
