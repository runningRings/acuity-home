"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var UserToken = /** @class */ (function () {
    function UserToken() {
        this.username = '';
        this.clientKey = '';
        this.jwtToken = '';
        this.isAuthenticated = false;
        this.hasRequestedPermission = false;
        this.error = '';
    }
    UserToken.prototype.clear = function () {
        this.username = '';
        this.jwtToken = '';
        this.isAuthenticated = false;
        this.hasRequestedPermission = false;
    };
    return UserToken;
}());
exports.UserToken = UserToken;
//# sourceMappingURL=user.token.model.js.map