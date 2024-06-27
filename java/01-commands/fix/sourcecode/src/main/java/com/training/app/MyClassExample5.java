package com.training.app;

import java.util.concurrent.Semaphore;
import java.util.concurrent.TimeUnit;

public class MyClassExample5 {
    public static void run(int maxConcurrentTasks, int totalTasks) {
        // Create a Semaphore instance
        Semaphore semaphore = new Semaphore(maxConcurrentTasks, true);

        // Generate tasks
        Thread[] threads = new Thread[totalTasks - 1];
        for (int i = 0; i < totalTasks; i++) {
            final int taskId = i;
            threads[i] = new Thread(() -> {
                try {
                    // Wait for semaphore
                    semaphore.acquire();

                    // Simulate work
                    TimeUnit.SECONDS.sleep(1000);
                    System.out.println("Task " + taskId + " completed.");
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            });
            threads[i].start();
        }

        // Wait for all threads to complete
        try {
            for (Thread thread : threads) {
                thread.join();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
