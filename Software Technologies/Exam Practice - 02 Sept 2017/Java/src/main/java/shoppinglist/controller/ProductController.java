package shoppinglist.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import shoppinglist.bindingModel.ProductBindingModel;
import shoppinglist.entity.Product;
import shoppinglist.repository.ProductRepository;

@Controller
public class ProductController {

    private final ProductRepository productRepository;

    @Autowired
    public ProductController(ProductRepository productRepository) {
        this.productRepository = productRepository;
    }

    @GetMapping("/")
    public String index(Model model) {
        model.addAttribute("products", productRepository.findAll());
        model.addAttribute("view", "product/index");
        return "base-layout";
    }

    @GetMapping("/create")
    public String create(Model model) {
        model.addAttribute("product", new ProductBindingModel());
        model.addAttribute("view", "product/create");
        return "base-layout";
    }

    @PostMapping("/create")
    public String createProcess(Model model, ProductBindingModel productBindingModel) {
        if (productBindingModel.getName().isEmpty() ||
                productBindingModel.getStatus().isEmpty()) {
            model.addAttribute("view", "product/create");
            return "base-layout";
        }
        Product product = new Product();
        product.setName(productBindingModel.getName());
        product.setPriority(productBindingModel.getPriority());
        product.setQuantity(productBindingModel.getQuantity());
        product.setStatus(productBindingModel.getStatus());
        productRepository.saveAndFlush(product);
        return "redirect:/";
    }

    @GetMapping("/edit/{id}")
    public String edit(Model model, @PathVariable int id) {
        Product product = productRepository.findOne(id);
        if (product == null)
            return "redirect:/";
        model.addAttribute("product", product);
        model.addAttribute("view", "product/edit");
        return "base-layout";
    }

    @PostMapping("/edit/{id}")
    public String editProcess(Model model, @PathVariable int id, ProductBindingModel productBindingModel) {
        if (productBindingModel.getName().isEmpty() ||
                productBindingModel.getStatus().isEmpty()) {
            Product product = new Product();
            product.setName(productBindingModel.getName());
            product.setPriority(productBindingModel.getPriority());
            product.setQuantity(productBindingModel.getQuantity());
            product.setStatus(productBindingModel.getStatus());

            model.addAttribute("product", product);
            model.addAttribute("view", "product/edit");
            return "base-layout";
        }
        Product product = productRepository.findOne(id);
        if (product != null) {
            product.setName(productBindingModel.getName());
            product.setPriority(productBindingModel.getPriority());
            product.setQuantity(productBindingModel.getQuantity());
            product.setStatus(productBindingModel.getStatus());
            productRepository.saveAndFlush(product);
        }
        return "redirect:/";
    }
}
