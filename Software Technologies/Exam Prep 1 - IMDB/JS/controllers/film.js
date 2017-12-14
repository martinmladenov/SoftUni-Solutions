const Film = require('../models/Film');

module.exports = {
    index: (req, res) => {
        Film.find().then(films => res.render('film/index', {films: films}));
    },
    createGet: (req, res) => {
        res.render('film/create');
    },
    createPost: (req, res) => {
        Film.create(req.body)
            .then(() => res.redirect('/'))
            .catch(() => res.render("film/create"));
    },
    editGet: (req, res) => {
        Film.findById(req.params.id)
            .then(film => res.render('film/edit', film))
            .catch(() => res.redirect('/'));
    },
    editPost: (req, res) => {
        Film.findByIdAndUpdate(req.params.id, req.body, {runValidators: true})
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/edit/" + req.params.id));
    },
    deleteGet: (req, res) => {
        Film.findById(req.params.id)
            .then(film => res.render('film/delete', film))
            .catch(() => res.redirect('/'));
    },
    deletePost: (req, res) => {
        Film.findByIdAndRemove(req.params.id)
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/"));
    }
};