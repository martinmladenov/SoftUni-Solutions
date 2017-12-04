package com.softuni.controller;

import com.softuni.entity.Calculator;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class HomeController {
    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("operator", "+");
        model.addAttribute("view", "views/calculatorForm");
        return "base-layout";
    }

    @PostMapping("/")
    public String calculate(@RequestParam String leftOperand,
                            @RequestParam String operator,
                            @RequestParam String rightOperand,
                            Model model) {
        double num1, num2;
        try {
            num1 = Double.parseDouble(leftOperand);
        } catch (NumberFormatException ex) {
            num1 = 0;
        }
        try {
            num2 = Double.parseDouble(rightOperand);
        } catch (NumberFormatException ex) {
            num2 = 0;
        }

        Calculator calculator = new Calculator(num1, num2, operator);

        model.addAttribute("leftOperand", calculator.getLeftOperand());
        model.addAttribute("rightOperand", calculator.getRightOperand());
        model.addAttribute("operator", calculator.getOperator());
        model.addAttribute("result", calculator.calculateResult());

        model.addAttribute("view", "views/calculatorForm");

        return "base-layout";
    }
}
