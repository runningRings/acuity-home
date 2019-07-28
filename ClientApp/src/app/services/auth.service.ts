import { Injectable } from '@angular/core';
import { UserToken } from '../models/user.token.model';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { SignInModel } from '../models/sign-in.model';
import { UrlBuilderFactory } from './url.service';
import { environment as env } from '@env/environment';
import * as _ from "lodash";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: UserToken = new UserToken();

  constructor(
    private readonly http: HttpClient,
    private readonly urlFactory: UrlBuilderFactory
  ) {
  }

  signIn(model: SignInModel) {
    //this.signOut();
    const requestBody = new HttpParams().set('username', model.username).set('password', model.password);

    const url = this.urlFactory.create(env.auth.url, ['api', 'users', 'login']).build();

    return this.http.post(url.href, requestBody.toString(), {
      headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
    }).subscribe(res => {
      if (_.has(res, 'user')) {
        this.user = _.assignIn(this.user, _.get(res, 'user'));
        localStorage.setItem('token', this.user.jwtToken);
        //this.user.isAuthenticated = !this.jwtHelper.isTokenExpired();
      }
    }, err => {
      //this.logger.error('Error occurred signing in:', err);
      this.user.error = 'Invalid Username or Password';
    });
  }

  isAuthenticated() {
    const requestBody = new HttpParams().set('username', this.user.username)
  }

}
