package todolist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import todolist.bindingModel.TaskBindingModel;
import todolist.entity.Task;
import todolist.repository.TaskRepository;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("tasks", taskRepository.findAll());
        model.addAttribute("view", "task/index");

        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("task", new TaskBindingModel());
        model.addAttribute("view", "task/create");

        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, TaskBindingModel taskBindingModel) {
        if (taskBindingModel.getTitle().isEmpty() ||
                taskBindingModel.getComments().isEmpty()) {
            model.addAttribute("view", "task/create");
            return "base-layout";
        }
        Task task = new Task();
        task.setTitle(taskBindingModel.getTitle());
        task.setComments(taskBindingModel.getComments());
        taskRepository.saveAndFlush(task);
        return "redirect:/";
    }

    @GetMapping("/delete/{id}")
    public String delete(Model model, @PathVariable int id) {
        Task task = taskRepository.findOne(id);
        if (task == null)
            return "redirect:/";
        model.addAttribute("task", task);
        model.addAttribute("view", "task/delete");
        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    public String deleteProcess(Model model, @PathVariable int id) {
        Task task = taskRepository.findOne(id);
        if (task != null)
            taskRepository.delete(id);

        return "redirect:/";
    }
}
