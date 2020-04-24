import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
//import { createWriteStream } from 'fs';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(private authService : AuthService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Failed to log in');
    });
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; //if there's something in this token variable, return true. if it's empty, return false
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
