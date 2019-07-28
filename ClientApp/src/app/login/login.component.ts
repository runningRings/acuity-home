import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { UserToken } from '../models/user.token.model';
import { SignInModel } from '../models/sign-in.model';
import * as _ from 'lodash';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: UserToken = null;
  vmIsValid = true;
  form: FormGroup;

  constructor(
    public readonly loginService: AuthService,
    private readonly router: Router,
  ) { }

  ngOnInit() {
    this.initForm();

  }

  private initForm() {
    this.form = new FormGroup({
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      rememberMe: new FormControl(false)
    });
  }

  login() {

    let model: SignInModel = null;
    model = _.assignIn(model, this.form.value);

    this.loginService.signIn(model).add(() => {
      if (!this.loginService.user.isAuthenticated) {
        this.vmIsValid = false;
      } else {
        alert('logged');
      }
      

    });
  }


}


