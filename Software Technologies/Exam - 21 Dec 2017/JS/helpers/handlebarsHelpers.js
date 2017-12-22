const Handlebars = require('hbs');
Handlebars.registerHelper("checkif", require('handlebars-helper-checkif'));
Handlebars.registerHelper('toLowerCase', function(str) {return str.toLowerCase();});
Handlebars.registerHelper('compress', function(str) {return str.length > 50 ? str.substring(0, 50) + '...' : str});