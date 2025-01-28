class MyClassExample1 {
    f() {
        throw new Error('Method not implemented.');
    }
}

class MyClass2 extends MyClassExample1 {
    f() {
        return 0;
    }
}

const myClass2Instance = new MyClass2();
console.log(myClass2Instance.f());

module.exports = { MyClassExample1, MyClass2 };