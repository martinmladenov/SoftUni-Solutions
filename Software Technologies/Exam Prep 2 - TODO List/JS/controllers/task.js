const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => res.render('task/index', {tasks: tasks}));
    },
    createGet: (req, res) => {
        res.render('task/create');
    },
    createPost: (req, res) => {
        Task.create(req.body)
            .then(() => res.redirect('/'))
            .catch(() => res.render("task/create"));
    },
    deleteGet: (req, res) => {
        Task.findById(req.params.id)
            .then(task => res.render('task/delete', task))
            .catch(() => res.redirect('/'));
    },
    deletePost: (req, res) => {
        Task.findByIdAndRemove(req.params.id)
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/"));
    }
};