class SearchInDictionary:
    def execute(self, dimensions, value_to_find):
        for key, value in dimensions.items():
            if value == value_to_find:
                if self.verify_ip_address(key):
                    return True
        return False

    def verify_ip_address(self, key):
        if len(key.split('.')) == 4 and (self.is_white_list(key) or not self.is_blacklisted(key)):
            return True
        elif len(key.split(':')) == 8:
            return True
        return False

    def verify_ip_address_simple(self, key):
        if len(key.split('.')) == 4:
            return True
        elif len(key.split(':')) == 8:
            return True
        return False

    def is_white_list(self, key):
        # Implement your whitelist check here
        pass

    def is_blacklisted(self, key):
        # Implement your blacklist check here
        pass