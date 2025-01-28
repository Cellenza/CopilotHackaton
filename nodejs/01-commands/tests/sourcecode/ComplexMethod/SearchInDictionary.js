const Blacklist = require('./Blacklist');

class SearchInDictionary {
    async execute(dimensions, valueToFind) {
        for (const key of Object.keys(dimensions)) {
            if (dimensions[key] === valueToFind) {
                return await this.verifyIpAddress(key);
            }
        }

        return false;
    }

    async verifyIpAddress(key) {
        try {
            if (key.split('.').length === 4 && 
                (await Blacklist.isWhiteList(key) || 
                !(await Blacklist.isBlacklisted(key)))) {
                return true;
            } else if (key.split(':').length === 8) {
                return true;
            }
        } catch (e) {
            console.error(e);
        }

        return false;
    }

    verifyIpAddressSimple(key) {
        if (key.split('.').length === 4) {
            return true;
        } else if (key.split(':').length === 8) {
            return true;
        }

        return false;
    }
}

module.exports = SearchInDictionary;