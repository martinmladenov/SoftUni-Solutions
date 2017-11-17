/**
 * Created by SoftUniLector on 11/6/2016.
 */

const crypto = require('crypto');
module.exports = {
    generateSalt: () => {
        return crypto.randomBytes(128).toString('base64');
    },
    hashPassword: (password, salt) => {
        return crypto.createHmac('sha256', salt).update(password).digest('hex');
    }
};



