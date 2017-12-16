const productController = require('../controllers/product');

module.exports = (app) => {
    app.get('/', productController.index);

    app.get('/create/', productController.createGet);
    app.post('/create/', productController.createPost);

    app.get('/edit/:id', productController.editGet);
    app.post('/edit/:id', productController.editPost);
};