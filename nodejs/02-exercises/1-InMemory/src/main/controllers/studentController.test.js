const request = require('supertest');
const express = require('express');
const bodyParser = require('body-parser');
const createStudentService = require('../services/studentService');
const studentControllerFactory = require('./studentController');


describe('StudentController Integration Tests', () => {
    let app;
    let studentService;

    beforeEach(() => {
        // Create a new instance of the student service for each test
        studentService = createStudentService();

        // Initialize Express app and inject the student service into the controller
        app = express();
        app.use(bodyParser.json());
        app.use('/api/students', studentControllerFactory(studentService));

        // Seed initial students
        studentService.create(
            [{ id: 1, firstName: 'John', lastName: 'Doe' },
                { id: 2, firstName: 'Homer', lastName: 'Simpson' }]);
    });

    test('should find all students', async () => {
        const response = await request(app).get('/api/students');
        expect(response.status).toBe(200);
        expect(response.body).toHaveLength(2);
        expect(response.body).toEqual(
            expect.arrayContaining([
                { id: 1, firstName: 'John', lastName: 'Doe' },
                { id: 2, firstName: 'Homer', lastName: 'Simpson' },
            ])
        );
    });

    test('should find one student by ID', async () => {
        const response = await request(app).get('/api/students/1');
        expect(response.status).toBe(200);
        expect(response.body).toEqual({ id: 1, firstName: 'John', lastName: 'Doe' });
    });

    test('should create a new student', async () => {
        const newStudent = { id: 3, firstName: 'Jane', lastName: 'Doe' };
        const response = await request(app).post('/api/students').send(newStudent);
        expect(response.status).toBe(201);
        expect(response.body).toEqual(newStudent);
    });

    test('should update an existing student', async () => {
        const updatedStudent = { id: 1, firstName: 'John', lastName: 'Connor' };
        const response = await request(app).put('/api/students/1').send(updatedStudent);
        expect(response.status).toBe(200);
        expect(response.body).toEqual(updatedStudent);
    });

    test('should delete a student by ID', async () => {
        const response = await request(app).delete('/api/students/1');
        expect(response.status).toBe(200);

        const findResponse = await request(app).get('/api/students/1');
        expect(findResponse.status).toBe(404);
    });
});
