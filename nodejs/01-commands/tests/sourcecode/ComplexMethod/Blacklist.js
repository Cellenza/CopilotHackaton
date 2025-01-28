class Blacklist {
    static blackListedIP = ["12.5.6.7", "192.0.5.1"];
  
    // Get the current IP address
    static async getCurrentIpAddress() {
      const interfaces = os.networkInterfaces();
      for (const iface of Object.values(interfaces)) {
        for (const net of iface) {
          if (!net.internal && net.family === 'IPv4') {
            return net.address;
          }
        }
      }
      throw new Error("Unable to determine current IP address");
    }
  
    // Check if the given IP is blacklisted
    static isBlacklisted(key) {
      return this.blackListedIP.includes(key);
    }
  
    // Check if the given IP is whitelisted (matches the current IP address)
    static async isWhiteList(key) {
      const currentIp = await this.getCurrentIpAddress();
      return key === currentIp;
    }
  }
  
  module.exports = Blacklist;