import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import axios from 'axios';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {
  form: FormGroup;
  showErrorMessage: any;
  errorMessage: string = "";
  call: string = environment.call;
  
  constructor(private readonly fb: FormBuilder, private router: Router) { 
      this.form = this.fb.group({
        username: ['', Validators.required],
        password: ['', Validators.required]
      });
    }

  ngOnInit() {
  }

  response :any;
  async btnsubmit() {
    try {
      const instance = axios.create({
        baseURL: environment.API_URL,
        headers: {
          'Content-Type': 'application/json'
        }
      });

      const params = {
        "Username": this.form.value.username,
        "Password": this.form.value.password
      };

      this.response = await instance.post("/Authenticate/login", params);
      console.log("response: ", this.response);
      localStorage.setItem('token_hrgis', this.response.data.token);

      this.router.navigate(['/']);

      return this.response
    } catch (error) {
      console.log('RES ERROR: ', error.response);

      this.errorMessage = "*** Invalid username or password Please try again";
      this.showErrorMessage = true;

      localStorage.clear();
    }
  }

}