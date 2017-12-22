const mongoose = require('mongoose');

let reportSchema = mongoose.Schema({
    status: {type: 'string', required: 'true'},
    origin: {type: 'string', required: 'true'},
    message: {type: 'string', required: 'true'},
});

let Report = mongoose.model('Report', reportSchema);

module.exports = Report;