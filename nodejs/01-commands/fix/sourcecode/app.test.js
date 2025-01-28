const App = require('./app');

test('appHasAGreeting', () => {
    const classUnderTest = new App();
    expect(classUnderTest.getGreeting()).not.toBeNull();
    expect(classUnderTest.getGreeting()).toBe("Hello World!");
});