const express = require('express');
const path = require('path');
const bodyParser = require('body-parser');
const session = require('express-session');
const helpers = require('../helpers/handlebarsHelpers');
const hbs = require('hbs');

hbs.registerHelper('sortedEach', function (context, options) {
    let result = "";

    context.sort((e1, e2) => {
        let result = 0;

        if(e1.status === "bought" && e2.status === "not bought") {
            result = 1;
        } else if (e1.status === "not bought" && e2.status === "bought") {
            result = -1;
        }

        if(result === 0) {
            result = e1.priority - e2.priority;
        }

        return result;
    }).forEach((e) => {
        result += options.fn(e);
    });

    return result;
});

module.exports = (app, config) => {
    // View engine setup.
    app.set('views', path.join(config.rootFolder, '/views'));
    app.set('view engine', 'hbs');

    // This set up which is the parser for the request's data.
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({extended: true}));

    app.use((req, res, next) => {
        next();
    });

    // This makes the content in the "public" folder accessible for every user.
    app.use(express.static(path.join(config.rootFolder, 'public')));
};



