package lognoziroh.controller;

import lognoziroh.bindingModel.ReportBindingModel;
import lognoziroh.entity.Report;
import lognoziroh.repository.ReportRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;

@Controller
public class ReportController {
    private final ReportRepository reportRepository;

    @Autowired
    public ReportController(ReportRepository reportRepository) {
        this.reportRepository = reportRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("reports", reportRepository.findAll());
        model.addAttribute("view", "report/index");
        return "base-layout";
    }

    @GetMapping("/details/{id}")
    public String details(Model model, @PathVariable int id) {
        Report report = reportRepository.findOne(id);
        if (report == null)
            return "redirect:/";
        model.addAttribute("report", report);
        model.addAttribute("view", "report/details");
        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("report", new ReportBindingModel());
        model.addAttribute("view", "report/create");
        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, ReportBindingModel reportBindingModel) {
        if (reportBindingModel.getStatus().isEmpty() ||
                reportBindingModel.getMessage().isEmpty() ||
                reportBindingModel.getOrigin().isEmpty()) {
            model.addAttribute("view", "report/create");
            return "base-layout";
        }
        Report report = new Report();
        report.setStatus(reportBindingModel.getStatus());
        report.setMessage(reportBindingModel.getMessage());
        report.setOrigin(reportBindingModel.getOrigin());
        reportRepository.saveAndFlush(report);
        return "redirect:/";
    }

    @GetMapping("/delete/{id}")
    public String delete(Model model, @PathVariable int id) {
        Report report = reportRepository.findOne(id);
        if (report == null)
            return "redirect:/";
        model.addAttribute("report", report);
        model.addAttribute("view", "report/delete");
        return "base-layout";
    }

    @PostMapping("/delete/{id}")
    public String deleteProcess(@PathVariable int id, ReportBindingModel reportBindingModel) {
        Report report = reportRepository.findOne(id);
        if (report != null)
            reportRepository.delete(id);

        return "redirect:/";
    }
}
