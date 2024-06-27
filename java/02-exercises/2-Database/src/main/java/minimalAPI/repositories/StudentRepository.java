package minimalAPI.repositories;

import minimalAPI.model.Student;
import org.springframework.data.repository.CrudRepository;

public interface StudentRepository extends CrudRepository<Student, Long> {}
