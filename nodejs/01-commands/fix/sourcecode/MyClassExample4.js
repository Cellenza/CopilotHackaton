class IList {
    getCount() {
        throw new Error('Method not implemented.');
    }

    setCount(count) {
        throw new Error('Method not implemented.');
    }

    counter() {
        throw new Error('Method not implemented.');
    }
}

class ICounter {
    getCount() {
        throw new Error('Method not implemented.');
    }

    setCount(count) {
        throw new Error('Method not implemented.');
    }
}

class IListCounter extends IList {
    constructor() {
        super();
        this.count = 0;
    }

    getCount() {
        return this.count;
    }

    setCount(count) {
        this.count = count;
    }
}

class MyClass {
    test(x) {
        x.setCount(1);
    }
}

const myClassInstance = new MyClass();
const listCounterInstance = new IListCounter();
myClassInstance.test(listCounterInstance);
console.log(listCounterInstance.getCount()); // Output: 1

module.exports = { IList, ICounter, IListCounter, MyClass };