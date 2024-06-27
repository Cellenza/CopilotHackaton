package minimalAPI.service.impl;

import lombok.AllArgsConstructor;
import minimalAPI.model.Student;
import minimalAPI.repositories.StudentRepository;
import minimalAPI.service.StudentService;
import minimalAPI.web.exception.StudentIdMismatchException;
import minimalAPI.web.exception.StudentNotFoundException;
import org.springframework.stereotype.Service;

@AllArgsConstructor
@Service
public class StudentServiceImpl implements StudentService {

  private StudentRepository studentRepository;

  @Override
  public Iterable<Student> get() {
    return studentRepository.findAll();
  }

  @Override
  public Student find(long id) {
    return studentRepository.findById(id).orElseThrow(StudentNotFoundException::new);
  }

  @Override
  public Student create(Student student) {
    return studentRepository.save(student);
  }

  @Override
  public Student update(long id, Student student) {
    if (student.getId() != id) {
      throw new StudentIdMismatchException();
    }
    studentRepository.findById(id).orElseThrow(StudentNotFoundException::new);
    return studentRepository.save(student);
  }

  @Override
  public void delete(long id) {
    studentRepository.findById(id).orElseThrow(StudentNotFoundException::new);
    studentRepository.deleteById(id);
  }
}
