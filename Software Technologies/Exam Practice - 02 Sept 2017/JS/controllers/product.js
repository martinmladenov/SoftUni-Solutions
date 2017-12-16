const Product = require('../models/Product');

module.exports = {
    index: (req, res) => {
        Product.find().then(products => {
            res.render('product/index', {'entries': products})
        });
    },
    createGet: (req, res) => {
        res.render('product/create');
    },
    createPost: (req, res) => {
        Product.create(req.body)
            .then(() => res.redirect('/'))
            .catch(() => res.render('product/create'));
    },
    editGet: (req, res) => {
        Product.findById(req.params.id)
            .then(task => res.render('product/edit', task))
            .catch(() => res.redirect('/'));
    },
    editPost: (req, res) => {
        Product.findByIdAndUpdate(req.params.id, req.body, {runValidators: true})
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/edit/" + req.params.id));
    }
};