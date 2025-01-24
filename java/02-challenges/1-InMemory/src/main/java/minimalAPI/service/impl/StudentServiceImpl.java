package minimalAPI.service.impl;

import java.util.ArrayList;
import java.util.List;
import minimalAPI.model.Student;
import minimalAPI.service.StudentService;
import minimalAPI.web.exception.StudentNotFoundException;
import org.springframework.stereotype.Service;

@Service
public class StudentServiceImpl implements StudentService {
  private List<Student> students = new ArrayList<>();

  @Override
  public Iterable<Student> get() {
    return students;
  }

  @Override
  public Student find(long id) {
    return students.stream().filter(student -> student.getId() == id).findFirst().orElse(null);
  }

  @Override
  public Student create(Student student) {
    students.add(student);
    return student;
  }

  private boolean isStudentInList(Long id) {
    return students.stream().anyMatch(student -> student.getId() == id);
  }

  @Override
  public Student update(long id, Student student) {
    for (int i = 0; i < students.size(); i++) {
      Student currentStudent = students.get(i);
      if (currentStudent.getId() == id) {
        students.set(i, student);
        return student;
      }
    }
    throw new StudentNotFoundException("Student not found");
  }

  @Override
  public void delete(long id) {
    if (!isStudentInList(id)) {
      throw new StudentNotFoundException("Student not found");
    }
    students.removeIf(student -> student.getId() == id);
  }
}
