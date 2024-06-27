package com.training.app.MultiplesOf3or5;

public class MultiplesOf3or5 {
    private int number;

    public MultiplesOf3or5(int number) {
        this.number = number;
    }

    public int sum() {
        if (number < 0) return 0;

        int sum = 0;

        while (number > 0) {
            number--;
            if (number % 3 == 0 || number % 5 == 0) {
                sum += number;
            }
        }

        return sum;
    }
}
