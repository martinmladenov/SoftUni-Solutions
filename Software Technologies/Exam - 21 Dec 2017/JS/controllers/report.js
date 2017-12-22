const Report = require('../models/Report');

module.exports = {
    index: (req, res) => {
        Report.find().then(reports => res.render('report/index', {reports: reports}));
    },
    createGet: (req, res) => {
        res.render('report/create');
    },
    createPost: (req, res) => {
        Report.create(req.body)
            .then(() => res.redirect('/'))
            .catch(() => res.render("report/create"));
    },
    detailsGet: (req, res) => {
        Report.findById(req.params.id)
            .then(report => res.render('report/details', report))
            .catch(() => res.redirect('/'));
    },
    deleteGet: (req, res) => {
        Report.findById(req.params.id)
            .then(report => res.render('report/delete', report))
            .catch(() => res.redirect('/'));
    },
    deletePost: (req, res) => {
        Report.findByIdAndRemove(req.params.id)
            .then(() => res.redirect("/"))
            .catch(() => res.redirect("/"));
    }
};