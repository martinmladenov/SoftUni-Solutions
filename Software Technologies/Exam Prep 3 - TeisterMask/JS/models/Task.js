const mongoose = require('mongoose');

let taskSchema = mongoose.Schema({
    title: {type: 'string', required: 'true'},
    status: {type: 'string', required: 'true'},
});

let Task = mongoose.model('Task', taskSchema);

module.exports = Task;