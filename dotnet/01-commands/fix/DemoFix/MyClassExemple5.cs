namespace DemoFix
{
    public static class MyClassExemple5
    {
        /// <summary>
        /// Runs the tasks asynchronously with a specified maximum number of concurrent tasks.
        /// </summary>
        /// <param name="maxConcurrentTasks">The maximum number of concurrent tasks.</param>
        /// <param name="totalTasks">The total number of tasks to run.</param>
        public static async Task Run(int maxConcurrentTasks, int totalTasks)
        {
            // Create a SemaphoreSlim instance
            using SemaphoreSlim semaphore = new(maxConcurrentTasks, maxConcurrentTasks);

            // Generate tasks
            var tasks = new Task<int>[totalTasks - 1];
            for (int i = 0; i < totalTasks; i++)
            {
                tasks[i] = Task.Run(async () =>
                {
                    // Wait for semaphore
                    await semaphore.WaitAsync();

                    // Simulate work
                    await Task.Delay(1000);
                    Console.WriteLine($"Task {i} completed.");
                });
            }

            // Wait for all tasks to complete
            await Task.WhenAll(tasks);
        }
    }
}