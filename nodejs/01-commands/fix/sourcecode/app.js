const MyClassExample5 = require('./MyClassExample5');

class App {
    getGreeting() {
        return "Hello World!";
    }

    async main() {
        await MyClassExample5.run(2, 10);
    }
}

const app = new App();
app.main();