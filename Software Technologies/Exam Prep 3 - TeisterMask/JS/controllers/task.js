const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => {
            res.render('task/index', {
                'openTasks': tasks.filter(t => t.status === 'Open'),
                'inProgressTasks': tasks.filter(t => t.status === 'In Progress'),
                'finishedTasks': tasks.filter(t => t.status === 'Finished'),
            });
        })
    },
    createGet: (req, res) => {
        res.render('task/create');
    },
    createPost: (req, res) => {
        Task.create(req.body)
            .then(() => res.redirect('/'))
            .catch(() => res.render('task/create'));
    },
    editGet: (req, res) => {
        Task.findById(req.params.id)
            .then(task => res.render('task/edit', task))
            .catch(() => res.redirect('/'));
    },
    editPost: (req, res) => {
        Task.findByIdAndUpdate(req.params.id, req.body, {runValidators: true})
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/edit/" + req.params.id));
    }
};