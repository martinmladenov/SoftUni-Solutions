const User = require('mongoose').model('User');
const Article = require('mongoose').model('Article');
const encryption = require('./../utilities/encryption');

module.exports = {
    registerGet: (req, res) => {
        if (req.isAuthenticated()) {
            let errorMsg = 'You are already logged in!';
            res.render('/', {error: errorMsg});
            return;
        }

        res.render('user/register');
    },

    registerPost: (req, res) => {
        if (req.isAuthenticated()) {
            let errorMsg = 'You are already logged in!';
            res.render('/', {error: errorMsg});
            return;
        }

        let registerArgs = req.body;

        User.findOne({email: registerArgs.email}).then(user => {
            let errorMsg = '';
            if (user) {
                errorMsg = 'User with the same username exists!';
            } else if (registerArgs.password !== registerArgs.repeatedPassword) {
                errorMsg = 'Passwords do not match!'
            }

            if (errorMsg) {
                registerArgs.error = errorMsg;
                res.render('user/register', registerArgs)
            } else {
                let salt = encryption.generateSalt();
                let passwordHash = encryption.hashPassword(registerArgs.password, salt);

                let userObject = {
                    email: registerArgs.email,
                    passwordHash: passwordHash,
                    fullName: registerArgs.fullName,
                    salt: salt
                };

                User.create(userObject).then(user => {
                    req.logIn(user, (err) => {
                        if (err) {
                            registerArgs.error = err.message;
                            res.render('user/register', registerArgs);
                            return;
                        }

                        res.redirect('/')
                    })
                })
            }
        })
    },

    loginGet: (req, res) => {
        if (req.isAuthenticated()) {
            let errorMsg = 'You are already logged in!';
            res.render('error', {error: errorMsg});
            return;
        }

        res.render('user/login');
    },

    loginPost: (req, res) => {
        if (req.isAuthenticated()) {
            let errorMsg = 'You are already logged in!';
            res.render('error', {error: errorMsg});
            return;
        }

        let loginArgs = req.body;
        User.findOne({email: loginArgs.email}).then(user => {
            if (!user || !user.authenticate(loginArgs.password)) {
                loginArgs.error = 'Either username or password is invalid!';
                res.render('user/login', loginArgs);
                return;
            }

            req.logIn(user, (err) => {
                if (err) {
                    console.log(err);
                    res.redirect('/user/login', {error: err.message});
                    return;
                }

                res.redirect('/');
            })
        })
    },

    logout: (req, res) => {
        if (!req.isAuthenticated()) {
            let errorMsg = 'You are not logged in!';
            res.render('error', {error: errorMsg});
            return;
        }
        req.logOut();
        res.redirect('/');
    },

    userDetails: (req, res) => {
        if (!req.isAuthenticated()) {
            let errorMsg = 'You are not logged in!';
            res.render('error', {error: errorMsg});
            return;
        }
        Article.find({author: req.user.id}).then(articles =>
            res.render('user/details', {author: req.user, articles: articles}));
    },

    userDetailsById: (req, res) => {
        User.findOne({_id: req.params.id}).then(author =>
            Article.find({author: author.id}).then(articles =>
                res.render('user/details', {author: author, articles: articles})));
    }


};
