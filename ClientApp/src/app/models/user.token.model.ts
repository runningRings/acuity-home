export class UserToken {
  username = '';
  clientKey = '';
  jwtToken = '';
  isAuthenticated = false;
  hasRequestedPermission = false;
  error = '';

  clear() {
    this.username = '';
    this.jwtToken = '';
    this.isAuthenticated = false;
    this.hasRequestedPermission = false;
  }
}
