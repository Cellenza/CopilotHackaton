package com.training.app.MultiplesOf3or5;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class MultiplesOf3or5TestTemplate1 {

    @Test
    public void givenNegativeInput_return0() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(-1);
        assertEquals(0, multiplesOf3or5.sum());
    }

    @Test
    public void given0_return0() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(0);
        assertEquals(0, multiplesOf3or5.sum());
    }

    @Test
    public void given4_return3() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(4);
        assertEquals(3, multiplesOf3or5.sum());
    }

    @Test
    public void given10_return23() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(10);
        assertEquals(23, multiplesOf3or5.sum());
    }

    @Test
    public void given20_return78() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(20);
        assertEquals(78, multiplesOf3or5.sum());
    }

    @Test
    public void given200_return9168() {
        MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(200);
        assertEquals(9168, multiplesOf3or5.sum());
    }
}
