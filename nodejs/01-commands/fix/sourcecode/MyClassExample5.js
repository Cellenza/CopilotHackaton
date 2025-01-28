const Semaphore = require('semaphore-async-await').default;

class MyClassExample5 {
    static async run(maxConcurrentTasks, totalTasks) {
        // Create a Semaphore instance
        const semaphore = new Semaphore(maxConcurrentTasks);

        // Generate tasks
        const tasks = [];
        for (let i = 0; i < totalTasks; i++) {
            const taskId = i;
            tasks.push(async () => {
                await semaphore.acquire();
                try {
                    // Simulate work
                    await new Promise(resolve => setTimeout(resolve, 1000));
                    console.log(`Task ${taskId} completed.`);
                } finally {
                    semaphore.release();
                }
            });
        }

        // Run tasks
        await Promise.all(tasks.map(task => task()));
    }
}

module.exports = MyClassExample5;