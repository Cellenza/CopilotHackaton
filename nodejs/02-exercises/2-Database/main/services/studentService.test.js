const createStudentService = require('./studentService');
const StudentNotFoundException = require('../exceptions/studentNotFoundException');

let studentService;

describe('StudentService', () => {
  beforeEach(() => {
    // Create a new instance of the service for each test
    studentService = createStudentService();
  });

  test('get should return all students', async () => {
    const students = await studentService.get();
    expect(students).toHaveLength(3);
  });

  test('find should return a student by ID', async () => {
    const student = await studentService.find(1);
    expect(student).toEqual({ id: 1, firstName: 'John', lastName: 'Doe' });
  });
  
  test('update should modify an existing student', async () => {
    const updatedStudent = { id: 1, firstName: 'Johnny', lastName: 'Doe' };
    const student = await studentService.update(1, updatedStudent);
    expect(student).toEqual(updatedStudent);
  });

  test('update should throw an error if student not found', async () => {
    const updatedStudent = { id: 4, firstName: 'Anna', lastName: 'Taylor' };
    await expect(studentService.update(4, updatedStudent)).rejects.toThrow(StudentNotFoundException);
  });

  test('delete should remove a student by ID', async () => {
    await studentService.delete(1);
    const students = await studentService.get();
    expect(students).toHaveLength(2);
  });

  test('delete should throw an error if student not found', async () => {
    await expect(studentService.delete(4)).rejects.toThrow(StudentNotFoundException);
  });
});
