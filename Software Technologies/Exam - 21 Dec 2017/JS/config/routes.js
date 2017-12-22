const reportController = require('../controllers/report');

module.exports = (app) => {
    app.get('/', reportController.index);

	app.get('/create/', reportController.createGet);
	app.post('/create/', reportController.createPost);

	app.get('/details/:id', reportController.detailsGet);

	app.get('/delete/:id', reportController.deleteGet);
	app.post('/delete/:id', reportController.deletePost);
};