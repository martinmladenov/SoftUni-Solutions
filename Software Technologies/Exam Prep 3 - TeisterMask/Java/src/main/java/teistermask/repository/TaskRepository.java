package teistermask.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import teistermask.entity.Task;

import java.util.List;

public interface TaskRepository extends JpaRepository<Task, Integer> {
    List<Task> findAllByStatus(String status); // might be helpful?
}
