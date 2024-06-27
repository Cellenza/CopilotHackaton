package com.training.app.MultiplesOf3or5;

import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class MultiplesOf3or5TestTemplate2 {

    @Test
    public void givenInput_ReturnExpectedSum() {
        int[][] testData = {
            {-1, 0},
            {0, 0},
            {4, 3},
            {10, 23},
            {20, 78},
            {200, 9168}
        };

        for (int[] data : testData) {
            int input = data[0];
            int expectedSum = data[1];
            MultiplesOf3or5 multiplesOf3or5 = new MultiplesOf3or5(input);
            assertEquals(expectedSum, multiplesOf3or5.sum());
        }
    }
}
