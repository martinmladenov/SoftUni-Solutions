package teistermask.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import teistermask.bindingModel.TaskBindingModel;
import teistermask.entity.Task;
import teistermask.repository.TaskRepository;

@Controller
public class TaskController {
    private final TaskRepository taskRepository;

    @Autowired
    public TaskController(TaskRepository taskRepository) {
        this.taskRepository = taskRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("openTasks", taskRepository.findAllByStatus("Open"));
        model.addAttribute("inProgressTasks", taskRepository.findAllByStatus("In Progress"));
        model.addAttribute("finishedTasks", taskRepository.findAllByStatus("Finished"));
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
                taskBindingModel.getStatus().isEmpty()) {
            model.addAttribute("view", "task/create");
            return "base-layout";
        }

        Task task = new Task();
        task.setStatus(taskBindingModel.getStatus());
        task.setTitle(taskBindingModel.getTitle());
        taskRepository.saveAndFlush(task);
        return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    public String edit(Model model, @PathVariable int id) {
        Task task = taskRepository.findOne(id);
        if (task == null)
            return "redirect:/";
        model.addAttribute("task", task);
        model.addAttribute("view", "task/edit");
        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    public String editProcess(Model model, @PathVariable int id, TaskBindingModel taskBindingModel) {
        if (taskBindingModel.getTitle().isEmpty() ||
                taskBindingModel.getStatus().isEmpty()) {
            Task task = taskRepository.findOne(id);
            if (task == null)
                task = new Task();
            model.addAttribute("task", task);
            model.addAttribute("view", "task/edit");
            return "base-layout";
        }
        Task task = taskRepository.findOne(id);
        if (task != null) {
            task.setTitle(taskBindingModel.getTitle());
            task.setStatus(taskBindingModel.getStatus());
            taskRepository.saveAndFlush(task);
        }
        return "redirect:/";
    }
}
