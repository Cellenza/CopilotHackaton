class MyClassExample2 {
    constructor() {
        this.i = 0;
    }

    method() {
        // Method implementation
    }

    getProp() {
        return 1;
    }

    main() {
        this.i = 10;
        this.method();
        const p = this.getProp();
        console.log(`i: ${this.i}, p: ${p}`);
    }
}

const instance = new MyClassExample2();
instance.main();

module.exports = MyClassExample2;