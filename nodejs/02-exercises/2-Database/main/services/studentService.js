const StudentNotFoundException = require('../exceptions/studentNotFoundException');

const createStudentService = () => {
  let students = [
    { id: 1, firstName: 'John', lastName: 'Doe' },
    { id: 2, firstName: 'Jane', lastName: 'Smith' },
    { id: 3, firstName: 'Jim', lastName: 'Beam' }
  ];

  const get = async () => {
    return students;
  };

  const find = async (id) => {
    return students.find(student => student.id === parseInt(id));
  };

  const create = async (astudents) => {
    students = [astudents];
    return students;
  };

  const add = async (student) => {
    students.push(student);
    return student;
  };

  const update = async (id, student) => {
    const index = students.findIndex(s => s.id === parseInt(id));
    if (index !== -1) {
      students[index] = student;
      return student;
    } else {
      throw new StudentNotFoundException('Student not found');
    }
  };

  const deleteStudent = async (id) => {
    const index = students.findIndex(s => s.id === parseInt(id));
    if (index !== -1) {
      students.splice(index, 1);
      return true;
    } else {
      throw new StudentNotFoundException('Student not found');
    }
  };

  return {
    add,
    get,
    find,
    create,
    update,
    delete: deleteStudent,
  };
};

module.exports = createStudentService;
