package minimalAPI.service;

import minimalAPI.model.Student;

public interface StudentService {
  Iterable<Student> get();

  Student find(long id);

  Student create(Student student);

  Student update(long id, Student student);

  void delete(long id);
}
