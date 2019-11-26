import { Component, OnInit } from '@angular/core';
import { UsersApiService } from '../../services/users.service';
import { Router } from '@angular/router';
import { HttpClient } from 'selenium-webdriver/http';
import { User } from '../../data/users.model';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private apiService:  UsersApiService) { }

  users : User[];


  ngOnInit() {
    return this.apiService.getUsers()
    .subscribe(data => 
      {
        this.users = data as User[]
        console.log(data);
      });
  }

}
